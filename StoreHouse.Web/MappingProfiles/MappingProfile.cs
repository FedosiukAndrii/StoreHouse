using AutoMapper;
using StoreHouse.Models.DTOs;
using StoreHouse.Models.Entities;

namespace StoreHouse.Web.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                ;
        }
    }
}
