namespace Nulls.Logic
{
    public class Customer
    {
        public CustomerName Name { get; set; }
        public Email Email { get; set; }

        public Customer(CustomerName name, Email email)
        {
            Name = name;
            Email = email;
        }
    }
}
