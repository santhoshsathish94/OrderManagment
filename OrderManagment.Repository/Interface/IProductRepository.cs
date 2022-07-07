using OrderManagment.Repository.Entities;

namespace OrderManagment.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> SearchByProductNameAsync(string productName);
    }
}