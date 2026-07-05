using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class ApplicationUserToUserResponseDTOMappingProfile : Profile
    {
        public ApplicationUserToUserResponseDTOMappingProfile()
        {
            CreateMap<ApplicationUser, UserResponseDTO>()
                .ForMember(des => des.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(des => des.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
