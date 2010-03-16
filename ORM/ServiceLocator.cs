using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
namespace OrmSpikes
{
    [SetUpFixture]
    public class ServiceLocator
    {
        private static ISessionFactory factory;

        public static ISessionFactory Factory
        {
            get
            {
                if(factory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    factory = configuration.BuildSessionFactory();
                }
                return factory;
            }
        }
    }
}