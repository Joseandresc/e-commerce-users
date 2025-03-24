using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;


namespace eCommerce.Core.Mappers
{
    // This class defines mapping rules between the ApplicationUser entity and the AuthenticationResponse DTO.
    // It inherits from AutoMapper's Profile class, which is used to configure mapping definitions.
    public class ApplicationUserMappingProfile : Profile
    {
        // The constructor sets up the mapping configuration.
        public ApplicationUserMappingProfile()
        {
            // Mapping from ApplicationUser to AuthenticationResponse:

            // Define mapping between ApplicationUser and AuthenticationResponse.
            CreateMap<ApplicationUser, AuthenticationResponse>()
                // Map the UserId property directly.
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                // Map the Email property directly.
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                // Map the PersonName property directly.
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                // Map the Gender property directly.
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                // Ignore the Token property so that it can be set later (e.g., after generating a JWT).
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                // Ignore the Success property to allow custom business logic to set it.
                .ForMember(dest => dest.Success, opt => opt.Ignore());


          


        }
    }
}