using AutoMapper;
using OrderManagment.Repository.Entities;
using OrderManagment.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Services.Mapper
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Quantity , s => s.MapFrom(p => p.Package))
                .ForMember(d => d.Price, s => s.MapFrom(p => p.UnitPrice));
            CreateMap<Order, OrderDto>().IncludeAllDerived();
            CreateMap<OrderItem, OrderItemDto>().IncludeAllDerived();
        }
    }
}
