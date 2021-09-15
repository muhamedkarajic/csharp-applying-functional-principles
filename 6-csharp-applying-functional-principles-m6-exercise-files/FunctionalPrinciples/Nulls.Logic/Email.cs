using System.Text.RegularExpressions;

namespace Nulls.Logic
{
    public class Email : ValueObject<Email>
    {
        private readonly string _value;

        private Email(string value)
        {
            _value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Fail<Email>("Email should not be empty");

            email = email.Trim();
            if (email.Length > 256)
                return Result.Fail<Email>("Email is too long");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Fail<Email>("Email is invalid");

            return Result.Ok(new Email(email));
        }

        protected override bool EqualsCore(Email other)
        {
            return _value == other._value;
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }

        public static implicit operator string (Email email)
        {
            return email._value;
        }
    }
}
