using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NUnit.Framework;
using System.Transactions;
using System.Data;

namespace OrmSpikes
{
    /// <summary>
    /// RelationshipTests.
    /// </summary>
    [TestFixture]
    public class RelationshipTests
    {
        #region Entity Framework

        /// <summary>
        /*SELECT 
            1 AS [C1], 
            [Extent1].[Id] AS [Id], 
            [Extent1].[Name] AS [Name], 
            [Extent2].[Id] AS [Id1]
            FROM  [dbo].[Contacts] AS [Extent1]
            LEFT OUTER JOIN [dbo].[Adressses] AS [Extent2] ON ([Extent2].[ContactId] IS NOT NULL) AND ([Extent1].[Id] = [Extent2].[ContactId])
            WHERE N'Test' = [Extent1].[Name]*/
        /// </summary>
        [Test]
        public void ContactHasOneOrZeroAddresses_AddressHasOneContact_WithEF()
        {
            using (new TransactionScope())
            {
                var entities = new Entities();
                var contact = new Contact{Name = "Test"};
                contact.Address = new Address {Street = "Lipowa"};
                entities.AddToContactSet(contact);
                entities.SaveChanges();
                List<Contact> contacts = entities.ContactSet.Where(x=>x.Name == "Test").ToList();
                entities.DeleteObject(contacts[0].Address);
                contacts[0].Address = null;
                entities.SaveChanges();
            }
        }

        [Test]
        public void WhenRemovingContactShouldAlsoRemoveReferencedAddress_withEF()
        {
            using (new TransactionScope())
            {
                var contact = new Contact {Name = "Test", Address = new Address {Street = "Lipowa"}};
                var entities = new Entities();
                entities.AddToContactSet(contact);
                entities.SaveChanges();
                entities.DeleteObject(contact);
                entities.SaveChanges();
            }
        }

        [Test]
        public void ShouldAddAContactWithAddress_usingEF2()
        {
            var mfPaymentModel = new MFPaymentModel();
            var contact = new Domain.Contact{Name = "Test"};
            //var address = new Domain.Address{Contact = contact, Street = "Lipowa 5"};
            //contact.Address = address;
            //TODO: Relationship
            mfPaymentModel.Contacts.AddObject(contact);
        }

        [Test]
        public void WhenRemovingCustomerShouldRemoveAlsoServices_withEF()
        {
            using (new TransactionScope())
            {
                var entities = new Entities();
                var customer = new Customer {name = "RJ"};
                customer.Services.Add(new Service{Name = "VOIP", MonthlyFee = 20});
                entities.AddToCustomerSet(customer);
                entities.SaveChanges();
                entities = new Entities();
                Customer retrievedCustomer = entities.CustomerSet.Include("Services").Where(c => c.id == customer.id).First();
                entities.DeleteObject(retrievedCustomer);
                entities.SaveChanges();
            }
        }

        [Test]
        //http://ayende.com/Blog/archive/2010/01/16/eagerly-loading-entity-associations-efficiently-with-nhibernate.aspx#feedback
        public void ShouldRetrieveAllCustomerRelatioinshipsWithAPerformantQuery_EF()
        {
            using (new TransactionScope())
            {
                var customer = new Customer { name = "Test Customer" };
                var paymentMethod = new DirectDebitPaymentMethod
                                        {
                                            AssignedTo = customer,
                                            bankAccountNumber= "1234",
                                            holderName = "Test Customer",
                                            registrationDate= DateTime.Today,
                                            status = 1
                                        };
                customer.Services.Add(new Service { BoughtBy = customer, MonthlyFee = 20, Name = "Voip" });
                var entities = new Entities(); 
                entities.AddToCustomerSet(customer);
                entities.AddToPaymentMethodSet(paymentMethod);
                entities.SaveChanges();
                customer.UsedPaymentMethod = paymentMethod;
                entities.SaveChanges();
                entities = new Entities();
                List<Customer> customers = entities.CustomerSet.Include("UsedPaymentMethod").Include("Services").Where(
                    x => x.name == "Test Customer").ToList();
                Assert.That(customers, Has.Count.EqualTo(1));
                Assert.That(customer.Services, Has.Count.EqualTo(1));
                Assert.That(customer.UsedPaymentMethod, Is.Not.Null);
            }
        }

        #endregion

        #region NHibernate

        [Test]
        public void ContactHasOneOrZeroAddresses_AddressHasOneContact_WithNHibernate()
        {
            using (new TransactionScope())
            {
                ISession session = ServiceLocator.Factory.OpenSession();
                var address = new Domain.Address{Street = "Lipowa"};
                var contact = new Domain.Contact {Name = "Test", Address = address};
                address.Contact = contact;
                
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(contact);
                    transaction.Commit();
                }
                session = ServiceLocator.Factory.OpenSession();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Domain.Contact> contacts = session.Linq<Domain.Contact>().Where(x => x.Name == "Test").ToList();
                    Assert.That(contacts.Count, Is.EqualTo(1));
                }
            }
        }

        [Test]
        public void ShouldThrowAnExceptionWhenSavingAddressWithoutContactReference_withNH()
        {
            //Required not null property mapping
            var address = new Domain.Address {Street = "Lipowa"};
            ISession session = ServiceLocator.Factory.OpenSession();
            using(ITransaction transaction = session.BeginTransaction())
            {
                Assert.Throws(typeof(PropertyValueException),()=>session.Save(address));
            }
        }


        //Because the services set has the cascade property set to all, or higher.
        [Test]
        public void WhenRemovingCustomerShouldRemoveAlsoServices_withNH()
        {
            var customer = new Domain.Customer {Name = "Tester"};
            customer.Services = new HashSet<Domain.Service>();
            customer.Services.Add(new Domain.Service{MonthlyFee = 2, Name = "VOIP", BoughtBy = customer});
            ISession session = ServiceLocator.Factory.OpenSession();
            using (var transactionScope = new TransactionScope())
            {
                //Adding customer with services
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(customer);
                    transaction.Commit();
                }

                //Removing customer
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(customer);
                    transaction.Commit();
                }
                Assert.That(session.Linq<Domain.Service>().Count(), Is.EqualTo(0));
            }
        }

        //Because the services set has the cascade property set to all-delete-orphan.
        [Test]
        public void When_Dereferencing_TheService_From_The_Customer_Should_Also_Remove_The_Service_Because_It_Beomes_An_Oprhan_Object()
        {
            var customer = new Domain.Customer { Name = "Tester" };
            customer.Services = new HashSet<Domain.Service>();
            customer.Services.Add(new Domain.Service { MonthlyFee = 2, Name = "VOIP", BoughtBy = customer });
            ISession session = ServiceLocator.Factory.OpenSession();
            using (var transactionScope = new TransactionScope())
            {
                //Adding customer with services
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(customer);
                    transaction.Commit();
                }

                //Removing customer
                using (ITransaction transaction = session.BeginTransaction())
                {
                    customer.Services.Clear();
                    transaction.Commit();
                }
                Assert.That(session.Linq<Domain.Service>().Count(), Is.EqualTo(0));
            }
        }

        [Test]
        //http://ayende.com/Blog/archive/2010/01/16/eagerly-loading-entity-associations-efficiently-with-nhibernate.aspx#feedback
        public void ShouldRetrieveAllCustomerRelatioinshipsWithAPerformantQuery_NH()
        {
            using (new TransactionScope())
            {
                ISession session = ServiceLocator.Factory.OpenSession();
                var customer = new Domain.Customer {Name = "Test Customer"};
                var paymentMethod = new Domain.DirectDebitPaymentMethod
                                        {
                                            AssignedTo = customer,
                                            BankAccountNumber = "1234",
                                            HolderName = "Test Customer",
                                            RegistrationDate = DateTime.Today,
                                            Status = 1
                                        };
                customer.UsedPaymentMethod = paymentMethod;
                customer.Services = new HashSet<Domain.Service>();
                customer.Services.Add(new Domain.Service {BoughtBy = customer, MonthlyFee = 20, Name = "Voip"});
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(customer);
                    session.Save(paymentMethod);
                    transaction.Commit();
                }
                session.Clear();
                IEnumerable<Domain.Customer> customers = session.CreateCriteria(typeof(Domain.Customer))
                    .SetFetchMode("Services", FetchMode.Eager)
                    .Add(Expression.Eq("Name", "Test Customer")).Future<Domain.Customer>();
                session.CreateCriteria(typeof(Domain.Customer))
                    .SetFetchMode("UsedPaymentMethod", FetchMode.Eager)
                    .Add(Expression.Eq("Name", "Test Customer")).Future<Domain.Customer>();
                customers = customers.ToList();
                Assert.That(customers, Has.Count.EqualTo(1));
                Assert.That(customer.Services, Has.Count.EqualTo(1));
                Assert.That(customer.UsedPaymentMethod, Is.Not.Null);
            }
        }

        [Test]
        public void Should_Update_The_Customer_with_different_services()
        {
            using (new TransactionScope())
            {
                ISession session = ServiceLocator.Factory.OpenSession();
                var customer = new Domain.Customer {Name = "Test Customer"};
                customer.Services = new HashSet<Domain.Service>();
                customer.Services.Add(new Domain.Service {BoughtBy = customer, MonthlyFee = 20, Name = "Voip"});
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(customer);
                    transaction.Commit();
                }
                using (ITransaction transaction = session.BeginTransaction())
                {
                    customer.Services.Clear();
                    customer.Services.Add(new Domain.Service { BoughtBy = customer, MonthlyFee = 23, Name = "Voip2" });
                    transaction.Commit();
                }
            }
        }

        #endregion
    }
}