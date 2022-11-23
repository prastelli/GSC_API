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

            CreateMap<Category, CategoryViewModel>().ReverseMap()
               .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.CreationDate,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Things,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description
                ));
            CreateMap<Category, CategoryViewModel>()
               .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src =>src.Id)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description
                ));
            CreateMap<Thing, ThingsViewModel>().ReverseMap();
            CreateMap<Thing, ThingsViewModel>();

            CreateMap<Rol, RolViewModel>().ReverseMap();
            CreateMap<Rol, RolViewModel>();

            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<Rol, RolDTO>();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDto>();
        }
    }
}
