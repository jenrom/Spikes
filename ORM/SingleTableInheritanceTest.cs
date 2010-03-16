using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate;
using NUnit.Framework;
using NHibernate.Cfg.ConfigurationSchema;
using NHibernate.Cfg;
using NHibernate.Linq;
using System.Transactions;
using NHibernate.Criterion;

namespace OrmSpikes
{
    [TestFixture]
    public class SingleTableInheritanceTest
    {
        [Test]
        public void addPymentMethodWithEntityFramework()
        {
            var customer = new Customer { name = "Sciemniacz" };
            var creditCardPaymentMethod = new CreditCardPaymentMethod() { cardHolderName = "Roman", cardNumber = "123123", cardType = "visa", registrationDate = DateTime.Now, status = 1, AssignedTo = customer};
            var directDebitPaymentMethod = new DirectDebitPaymentMethod()
                                    {bankAccountNumber = "12345", holderName = "Roman", registrationDate = DateTime.Now, status = 2, AssignedTo = customer};
            customer.UsedPaymentMethod = creditCardPaymentMethod;
            var entities = new Entities();
            
            entities.AddToPaymentMethodSet(creditCardPaymentMethod);
            entities.AddToPaymentMethodSet(directDebitPaymentMethod);
            entities.SaveChanges();
            
            var entities1 = new Entities();
            List<PaymentMethod> paymentMethods = entities1.PaymentMethodSet
                .Where(x => x.registrationDate < DateTime.Now)
                .ToList();
            foreach (var paymentMethod in paymentMethods)
            {
                   Console.WriteLine(paymentMethod.GetType());
            }
        }

        [Test]
        //Ommiting problem with ghost objects
        //http://feedproxy.google.com/~r/AyendeRahien/~3/3HW3NOdYRDg/nhibernate-polymorphic-associations-and-ghost-objects.aspx
        public void ShouldRetrieveTheAssociatedObjectThatIsADerivedClass()
        {
            using (var scope = new TransactionScope())
            {
                ISession session = ServiceLocator.Factory.OpenSession();
                string customerName = "Test Customer";
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var customer = new Domain.Customer {Name = customerName};
                    var paymentMethod = new Domain.CreditCardPaymentMethod
                                            {
                                                AssignedTo = customer,
                                                CardHolderName = "Joseph",
                                                CardNumber = "AAABBB!@#12",
                                                CardType = "Visa",
                                                RegistrationDate = new DateTime(2008, 10, 10),
                                                Status = 1
                                            };
                    session.Save(customer);
                    session.Save(paymentMethod);
                    customer.UsedPaymentMethod = paymentMethod;
                    transaction.Commit();
                }
                session = ServiceLocator.Factory.OpenSession();
                var previouslyAddedCustomer = session.Linq<Domain.Customer>().Where(x => x.Name == customerName).First();
                Assert.That(previouslyAddedCustomer.UsedPaymentMethod, Is.TypeOf<Domain.CreditCardPaymentMethod>());
            }
        }

        [Test]
        public void AddPaymentMethodWithNhibernate()
        {
            ISession session = ServiceLocator.Factory.OpenSession();
            
            var method = new Domain.CreditCardPaymentMethod { RegistrationDate = DateTime.Now, Status = 2, CardHolderName = "Roman Jendrusz", CardNumber = "1234", CardType = "Visa" };
            var method2 = new Domain.DirectDebitPaymentMethod
                              {
                                  RegistrationDate = DateTime.Now,
                                  Status = 1,
                                  BankAccountNumber = "123123",
                                  HolderName = "sciemniacz"
                              };
            
            var customer = new Domain.Customer{Name = "Roman"};
            method.AssignedTo =  customer;
            method2.AssignedTo = customer;
            customer.UsedPaymentMethod = method2;
            var customer2 = new Domain.Customer { Name = "Marcin" };
            customer2.UsedPaymentMethod = method2;
            using(ITransaction transaction = session.BeginTransaction())
            {
                session.Save(customer);
                session.Save(method);
                session.Save(method2);
                transaction.Commit();
            }
            //IList<Domain.PaymentMethod> methods = session.CreateQuery("from PaymentMethod pm where pm.AssignedTo = :customer")
            //    .SetParameter("customer", customer)
            //    .List<Domain.PaymentMethod>();
            session = ServiceLocator.Factory.OpenSession();
            IList<Domain.PaymentMethod> methods =
                session.Linq<Domain.PaymentMethod>().Where(pm => pm.AssignedTo == customer).ToList();
            foreach (var paymentMethod in methods)
            {
                Console.WriteLine(paymentMethod.GetType().ToString());
            }
        }
    }
}
