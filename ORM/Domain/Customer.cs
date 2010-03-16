using System.Collections.Generic;

namespace OrmSpikes.Domain
{
    public class Customer
    {
        public virtual string Name { get; set; }
        public virtual PaymentMethod UsedPaymentMethod { get; set; }
        public virtual int Id { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}