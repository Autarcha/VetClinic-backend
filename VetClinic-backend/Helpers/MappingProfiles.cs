using AutoMapper;
using VetClinic_backend.Dto;
using VetClinic_backend.Models;

namespace VetClinic_backend.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
