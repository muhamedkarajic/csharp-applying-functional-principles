namespace Nulls.Logic
{
    public class CustomerName : ValueObject<CustomerName>
    {
        private readonly string _value;

        private CustomerName(string value)
        {
            _value = value;
        }

        public static Result<CustomerName> Create(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return Result.Fail<CustomerName>("Customer name should not be empty");

            customerName = customerName.Trim();
            if (customerName.Length > 100)
                return Result.Fail<CustomerName>("Customer name is too long");

            return Result.Ok(new CustomerName(customerName));
        }

        protected override bool EqualsCore(CustomerName other)
        {
            return _value == other._value;
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }

        public static explicit operator CustomerName(string customerName)
        {
            return Create(customerName).Value;
        }

        public static implicit operator string(CustomerName customerName)
        {
            return customerName._value;
        }
    }
}
