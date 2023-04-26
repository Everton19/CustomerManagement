using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Entity
{
    public class AppCustomerContext : DbContext
    {
        public AppCustomerContext(DbContextOptions<AppCustomerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
