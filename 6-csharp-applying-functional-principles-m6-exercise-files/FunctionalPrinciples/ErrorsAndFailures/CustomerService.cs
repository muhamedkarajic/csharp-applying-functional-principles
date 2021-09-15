namespace ErrorsAndFailures
{
    public class CustomerService
    {
        private readonly IDatabase _database;
        private readonly ILogger _logger;
        private readonly IPaymentGateway _paymentGateway;

        public CustomerService(IDatabase database, ILogger logger, IPaymentGateway paymentGateway)
        {
            _database = database;
            _logger = logger;
            _paymentGateway = paymentGateway;
        }

        public string RefillBalance(int customerId, decimal moneyAmount)
        {
            Result<MoneyToCharge> moneyToCharge = MoneyToCharge.Create(moneyAmount);
            Result<Customer> customer = _database.GetById(customerId).ToResult("Customer is not found");

            return Result.Combine(moneyToCharge, customer)
                .OnSuccess(() => customer.Value.AddBalance(moneyToCharge.Value))
                .OnSuccess(() => _paymentGateway.ChargePayment(customer.Value.BillingInfo, moneyToCharge.Value))
                .OnSuccess(
                    () => _database.Save(customer.Value)
                        .OnFailure(() => _paymentGateway.RollbackLastTransaction()))
                .OnBoth(result => Log(result))
                .OnBoth(result => result.IsSuccess ? "OK" : result.Error);
        }

        private void Log(Result result)
        {
            if (result.IsFailure)
                _logger.Log(result.Error);
            else
                _logger.Log("OK");
        }
    }
}
