namespace OrmSpikes.Domain
{
    public class CreditCardPaymentMethod: PaymentMethod
    {
        public virtual string CardHolderName { get; set; }

        public virtual string CardNumber { get; set; }

        public virtual string  CardType { get; set; }
    }
}