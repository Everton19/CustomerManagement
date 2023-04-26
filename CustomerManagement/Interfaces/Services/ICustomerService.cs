using CustomerManagement.Entity;

namespace CustomerManagement.Interfaces.Services
{
    public interface ICustomerService<TEntity> where TEntity : class
    {
        TEntity Update(Customer customer);
        TEntity Delete(int id);
        Task<TEntity> CreateAsync(Customer customer);
    }
}
