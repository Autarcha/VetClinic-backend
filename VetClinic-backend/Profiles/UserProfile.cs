using VetClinic_backend.Dto;
using VetClinic_backend.Models;
using AutoMapper;

namespace VetClinic_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}
