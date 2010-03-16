namespace OrmSpikes.Domain
{
    public class Service
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal MonthlyFee { get; set; }
        public virtual Customer BoughtBy { get; set; }
    }
}