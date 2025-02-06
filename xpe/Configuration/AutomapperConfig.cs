using AutoMapper;
using xpe.DTOs;
using xpe.Models;

namespace xpe.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}