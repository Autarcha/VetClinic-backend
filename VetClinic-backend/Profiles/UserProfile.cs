using VetClinic_backend.Models;
using AutoMapper;
using VetClinic_backend.Dto.UserDto;

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
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserProfileDto, User>();
        }
    }
}
