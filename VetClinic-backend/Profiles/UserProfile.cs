using VetClinic_backend.Models;
using AutoMapper;
using VetClinic_backend.Dto.User;

namespace VetClinic_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();
            CreateMap<User, UserProfileDto>().ReverseMap();
        }
    }
}
