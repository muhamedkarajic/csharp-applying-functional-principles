namespace ErrorsAndFailures
{
    public class Customer
    {
        public decimal Balance { get; private set; }
        public string BillingInfo { get; private set; }

        public void AddBalance(MoneyToCharge amount)
        {
            Balance += amount;
        }
    }
}
