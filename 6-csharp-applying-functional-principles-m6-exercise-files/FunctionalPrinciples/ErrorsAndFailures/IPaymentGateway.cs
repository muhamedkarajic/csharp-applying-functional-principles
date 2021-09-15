namespace ErrorsAndFailures
{
    public interface IPaymentGateway
    {
        void RollbackLastTransaction();
        Result ChargePayment(string billingInfo, MoneyToCharge moneyToCharge);
    }
}
