using CustomerManagement.Interfaces.Repositories;
using CustomerManagement.Interfaces.Services;

namespace CustomerManagement.Entity
{
    public class CustomerService : ICustomerService<Customer>
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            Customer existentCustomer = _repository.GetById(customer.Id);
            Customer includedCustomer = new Customer();

            if (existentCustomer == null)
            {
                includedCustomer = await _repository.CreateAsync(customer);
                return includedCustomer;
            }

            return null;
        }

        public Customer Update(Customer customer)
        {
            Customer existentCustomer = _repository.GetById(customer.Id);
            Customer updatedCustomer = new Customer();

            if (existentCustomer != null)
            {
                updatedCustomer =  _repository.Update(customer);
                return updatedCustomer;
            }

            return null;
        }

        public Customer Delete(int id)
        {
            Customer customer = _repository.GetById(id);
            Customer deletedCustomer = new Customer();

            if (customer != null)
            {
                deletedCustomer = _repository.Delete(customer);
                return deletedCustomer;
            }

            return null;
        }
    }
}
