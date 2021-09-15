
namespace Nulls.Logic
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Maybe<Customer> GetById(int id);
    }
}
