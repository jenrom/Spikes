using System.Data.Objects;
using System.Transactions;
using NHibernate;
using NUnit.Framework;

namespace OrmSpikes
{
    /// <summary>
    /// When_Using_A_Transaction_With_NHibernate.
    /// </summary>
    [TestFixture]
    public class When_Using_A_Transaction_With_EntityFramework
    {
        [Test]
        public void Should_Not_Save_All_Changes_To_The_Database_When_Commiting_A_Transactio_Scope()
        {
            
            var customer = new Customer { name = "Tester" };
            var entities = new Entities();
            entities.AddToCustomerSet(customer);
            entities.SaveChanges();
            using (var transactionScope = new TransactionScope())
            {
                customer.name = "Updated tester";
                transactionScope.Complete();
            }
            entities.Refresh(RefreshMode.StoreWins, customer);
            Assert.That(customer.name, Is.EqualTo("Tester"));

            entities.DeleteObject(customer);
        }
    }
}