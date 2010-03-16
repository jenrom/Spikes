using System.Data.Objects;
namespace OrmSpikes
{
    public class MFPaymentModel: ObjectContext
    {
        private ObjectSet<Domain.Address> _addresses;
        private ObjectSet<Domain.Contact> _contacts;

        public MFPaymentModel()
            : base("name = MFPaymentModel", "MFPaymentModel")
        {
            _contacts = CreateObjectSet<Domain.Contact>();
            //_addresses = CreateObjectSet<Domain.Address>();
            ContextOptions.LazyLoadingEnabled = true;
            ContextOptions.ProxyCreationEnabled = true;
        }

        public ObjectSet<Domain.Address> Addresses
        {
            get { return _addresses; }
        }

        public ObjectSet<Domain.Contact> Contacts
        {
            get { return _contacts; }
        }
    }
}