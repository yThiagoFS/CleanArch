using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;

namespace CleanArch.Application.AutoMapper 
{
    public class DtoToCommandMappingProfile : Profile 
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDto, ProductCreateCommand>();
            CreateMap<ProductDto, ProductUpdateCommand>();
        }
    }
}