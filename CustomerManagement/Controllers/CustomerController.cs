using CustomerManagement.Entity;
using CustomerManagement.Interfaces.Repositories;
using CustomerManagement.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService<Customer> _customerService;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(ICustomerService<Customer> customerService, IRepository<Customer> customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            IEnumerable<Customer> customers =  await _customerRepository.GetAllAsync();

            if (customers == null)
                return NotFound();
            
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Customer customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            Customer createdCustomer = await _customerService.CreateAsync(customer);

            return Ok(createdCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            Customer updateCustomer = _customerService.Update(customer);

            if (updateCustomer == null)
                return NotFound();

            return Ok(updateCustomer);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Customer deletedCustomer = _customerService.Delete(id);

            if (deletedCustomer == null)
                return NotFound();

            return Ok(deletedCustomer);
        }
    }
}
