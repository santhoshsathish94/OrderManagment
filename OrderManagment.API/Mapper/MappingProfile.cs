using AutoMapper;
using OrderManagment.API.Models;
using OrderManagment.Domain.Entities;

namespace OrderManagment.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>();
        }
    }
}
