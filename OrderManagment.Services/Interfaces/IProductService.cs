using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateOrUpdateAsync(ProductDto productDto);
        Task<bool> RemoveAsync(int[] Ids);
        Task<IEnumerable<ProductDto>> SearchByProductNameAsync(string productName);
    }
}
