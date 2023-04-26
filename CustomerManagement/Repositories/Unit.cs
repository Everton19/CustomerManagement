using CustomerManagement.Entity;
using CustomerManagement.Interfaces;

namespace CustomerManagement.Repositories
{
    public class Unit : IUnit
    {
        private readonly AppCustomerContext _context;

        public Unit(AppCustomerContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
