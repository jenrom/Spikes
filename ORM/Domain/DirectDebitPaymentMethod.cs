namespace OrmSpikes.Domain
{
    public class DirectDebitPaymentMethod: PaymentMethod
    {
        public virtual string BankAccountNumber { get; set; }
        public virtual string HolderName { get; set; }
    }
}