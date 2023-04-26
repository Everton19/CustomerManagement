using CustomerManagement.Entity;
using CustomerManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        private readonly Unit _unit;

        public CustomerRepository(AppCustomerContext context) : base(context)
        {
            _unit = new Unit(context);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var query =  _context.Set<Customer>().Where(x => x.Id == id).AsNoTracking();

            if (await query.AnyAsync())
                return await query.FirstOrDefaultAsync();

            return null;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var query = _context.Set<Customer>();

            return await query.AnyAsync() ? await query.AsNoTracking().ToListAsync() : new List<Customer>();
        }
    }
}
