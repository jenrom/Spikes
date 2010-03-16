using System.Transactions;
using NHibernate;
using NUnit.Framework;

namespace OrmSpikes
{
    /// <summary>
    /// When_Using_A_Transaction_With_NHibernate.
    /// </summary>
    [TestFixture]
    public class When_Using_A_Transaction_With_NHibernate
    {
        [Test]
        public void Should_Save_All_Changes_To_The_Database_When_Commiting_A_NHibernate_Transaction()
        {
            ISession session = ServiceLocator.Factory.OpenSession();
            var customer = new Domain.Customer { Name = "Tester" };
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(customer);
                transaction.Commit();
            }
            using (ITransaction transaction = session.BeginTransaction())
            {
                customer.Name = "Updated tester";
                transaction.Commit();
            }
            session.Refresh(customer);
            
            Assert.That(customer.Name, Is.EqualTo("Updated tester"));

            session.Delete(customer);
        }

        [Test]
        public void Should_Not_Save_All_Changes_To_The_Database_When_Commiting_A_Transactio_Scope()
        {
            ISession session = ServiceLocator.Factory.OpenSession();
            var customer = new Domain.Customer { Name = "Tester" };
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(customer);
                transaction.Commit();
            }
            using (var transactionScope = new TransactionScope())
            {
                customer.Name = "Updated tester";
                transactionScope.Complete();
            }
            session.Refresh(customer);

            Assert.That(customer.Name, Is.EqualTo("Tester"));

            session.Delete(customer);
        }
    }
}