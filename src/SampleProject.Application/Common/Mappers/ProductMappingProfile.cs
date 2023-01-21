using AutoMapper;
using SampleProject.Application.DTO;
using SampleProject.Domain.Entities;

namespace SampleProject.Application.Common.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, Products.Create.Response>().ReverseMap();
            CreateMap<Product, Products.Update.Response>().ReverseMap();

        }
    }
}
