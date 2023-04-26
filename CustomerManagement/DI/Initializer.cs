using CustomerManagement.Entity;
using CustomerManagement.Interfaces;
using CustomerManagement.Interfaces.Repositories;
using CustomerManagement.Interfaces.Services;
using CustomerManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<AppCustomerContext>(options => options.UseNpgsql(connection));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped(typeof(IRepository<Customer>), typeof(CustomerRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(ICustomerService<Customer>), typeof(CustomerService));
            services.AddScoped(typeof(IUnit), typeof(Unit));
        }
    }
}
