namespace ErrorsAndFailures
{
    public class MoneyToCharge : ValueObject<MoneyToCharge>
    {
        public decimal Value { get; }

        private MoneyToCharge(decimal value)
        {
            Value = value;
        }

        public static Result<MoneyToCharge> Create(decimal moneyToCharge)
        {
            if (moneyToCharge <= 0 || moneyToCharge > 1000)
                return Result.Fail<MoneyToCharge>("Money amount is invalid");

            return Result.Ok(new MoneyToCharge(moneyToCharge));
        }

        protected override bool EqualsCore(MoneyToCharge other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator MoneyToCharge(decimal moneyToCharge)
        {
            return Create(moneyToCharge).Value;
        }

        public static implicit operator decimal (MoneyToCharge moneyToCharge)
        {
            return moneyToCharge.Value;
        }
    }
}
