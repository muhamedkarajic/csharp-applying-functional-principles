using System;
using System.Linq;
using System.Windows.Forms;

namespace Exceptions
{
    public class CustomerService
    {
        public void CreateCustomer(string name)
        {
            var customer = new Customer(name);
            ResultWithEnum result = SaveCustomer(customer);

            if (result.IsFailure)
            {
                switch (result.ErrorType)
                {
                    case ErrorType.DatabaseIsOffline:
                        MessageBox.Show("Unable to connect to the database. Please try again later");
                        break;

                    case ErrorType.CustomerAlreadyExists:
                        MessageBox.Show("A customer with the name " + name + " already exists");
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }

        private ResultWithEnum SaveCustomer(Customer customer)
        {
            try
            {
                using (var context = new MyContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                return ResultWithEnum.Ok();
            }
            catch (DbUpdateException ex)
            {
                if (ex.Message == "Unable to open the DB connection")
                    ResultWithEnum.Fail(ErrorType.DatabaseIsOffline);

                if (ex.Message.Contains("IX_Customer_Name"))
                    return ResultWithEnum.Fail(ErrorType.CustomerAlreadyExists);

                throw;
            }
        }

        private ResultWithEnum<Customer> GetCustomer(int id)
        {
            try
            {
                using (var context = new MyContext())
                {
                    return ResultWithEnum.Ok(context.Customers.Single(x => x.Id == id));
                }
            }
            catch (DbUpdateException ex)
            {
                if (ex.Message == "Unable to open the DB connection")
                    return ResultWithEnum.Fail<Customer>(ErrorType.DatabaseIsOffline);

                throw;
            }
        }
    }
}
