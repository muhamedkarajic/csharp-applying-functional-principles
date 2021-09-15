namespace ErrorsAndFailures
{
    public interface IDatabase
    {
        Maybe<Customer> GetById(int id);
        Result Save(Customer customer);
    }
}
