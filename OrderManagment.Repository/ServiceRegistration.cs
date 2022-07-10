using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Repository.Implimentation;

namespace OrderManagment.Repository
{
    public static class ServiceRegistration
    {
        public static void AddOrderManagmentRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
