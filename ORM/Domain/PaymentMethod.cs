using System;

namespace OrmSpikes.Domain
{
    public abstract class PaymentMethod
    {
        public virtual int Id { get; set; }

        public virtual byte Status { get; set; }

        public virtual DateTime RegistrationDate { get; set; }

        public virtual Customer AssignedTo { get; set; }
    }
}