using AutoMapper;
using OrderManagment.API.Models;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<OrderItemModel, OrderItem>();
            CreateMap<OrderItemUpdateModel, OrderItem>();
            CreateMap<PageModel, SearchCriteria>();
        }
    }
}
