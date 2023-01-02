using VetClinic_backend.Models;
using AutoMapper;
using VetClinic_backend.Dto.User;

namespace VetClinic_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginDto>();
            CreateMap<User, UserDetailsDto>();
            CreateMap<UserDetailsDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserProfileDto, User>();
        }
    }
}
