using System;
using System.Text.RegularExpressions;

namespace PrimitiveObsession.Logic
{
    public class Customer
    {
        public CustomerName Name { get; private set; }
        public Email Email { get; private set; }

        public Customer(CustomerName name, Email email)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            Name = name;
            Email = email;
        }

        public void ChangeName(CustomerName name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void ChangeEmail(Email email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}
