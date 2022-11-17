using AutoMapper;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using System.Xml.Linq;

namespace GSC_API.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Person, PersonDto>().ReverseMap()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => $"{src.PhoneNumber}")
                )
                .ForMember(
                    dest => dest.EmailAddress,
                    opt => opt.MapFrom(src => $"{src.EmailAddress}"
                ));
            CreateMap<Person, PersonDto>()
               .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => $"{src.PhoneNumber}")
                )
                .ForMember(
                    dest => dest.EmailAddress,
                    opt => opt.MapFrom(src => $"{src.EmailAddress}"
                )                      
              );

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>();

        }
    }
}
