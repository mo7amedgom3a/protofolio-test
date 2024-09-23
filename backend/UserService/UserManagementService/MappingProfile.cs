using AutoMapper;
using UserManagementService.DTOs;
using UserManagementService.Models;
namespace UserManagementService.MappingProfiles
{
public class UserProfileMapping : Profile
{
    public UserProfileMapping()
    {
        CreateMap<User, UserProfileDto>();
        CreateMap<UserProfileCreateDto, User>();
        CreateMap<UserProfileUpdateDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<UserRegistrationDto, User>();
    }
}

}