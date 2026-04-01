using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the ApplicationUserMappingProfile class,
    /// which defines the mapping configuration between the ApplicationUser entity and the AuthenticationResponse DTO.
    /// </summary>
    public ApplicationUserMappingProfile()
    {
        // Define a mapping from ApplicationUser to AuthenticationResponse using the ConstructUSing to make it as parameterized constructor.
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ConstructUsing(src => new AuthenticationResponse(
                src.UserId,
                src.Email,
                src.PersonName,
                src.Gender,
                Token: default,
                IsAuthenticated: default))
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.IsAuthenticated, opt => opt.Ignore());
    }
}
