namespace OrmSpikes.Domain
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string  Street { get; set; }

        public virtual Domain.Contact Contact { get; set; }
    }
}