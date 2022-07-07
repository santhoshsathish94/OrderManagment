using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagment.Repository.Implimentation;
using OrderManagment.Repository.Interface;

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
