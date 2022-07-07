using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagment.Service.Implimentations;
using OrderManagment.Service.Interfaces;

namespace OrderManagment.Services
{
    public static class ServiceRegistration
    {
        public static void AddOrderManagmentServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}