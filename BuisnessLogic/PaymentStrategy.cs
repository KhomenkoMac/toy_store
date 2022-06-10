namespace BuisnessLogic
{
    #region Payment Strategy
    public class PaymentStratagyContext
    {
        private IPaymentStrategy _paymentStrategy;
        public IPaymentStrategy Strategy
        {
            set { _paymentStrategy = value; }
        }
        
        public double TotalToPay { get; set; }

        public PaymentStratagyContext(IPaymentStrategy paymentStrategy)
        {
            this._paymentStrategy = paymentStrategy;
        }

        public void Pay()
        {
            _paymentStrategy.Pay(TotalToPay);
        }
    }

    public interface IPaymentStrategy
    {
        bool Pay(double total);
    }

    public class FakePaymentStrategy : IPaymentStrategy
    {
        private readonly string _phoneNumber;
        private readonly string _password;

        public FakePaymentStrategy((string, string) creadentials)
        {
            _phoneNumber = creadentials.Item1;
            _password = creadentials.Item2;
        }
        public bool Pay(double total)
        {
            return true;
        }
    }
    #endregion
}
