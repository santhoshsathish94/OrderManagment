using AutoMapper;
using OrderManagment.API.Models;
using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;

namespace OrderManagment.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductDto>();
            CreateMap<OrderModel, OrderDto>().IncludeAllDerived();
            CreateMap<OrderItemModel, OrderItemDto>().IncludeAllDerived();
        }
    }
}
