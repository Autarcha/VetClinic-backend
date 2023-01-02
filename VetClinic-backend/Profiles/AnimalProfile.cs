using AutoMapper;
using VetClinic_backend.Dto.Animal;
using VetClinic_backend.Models;

namespace VetClinic_backend.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDetailsDto>();
            CreateMap<AnimalDetailsDto, Animal>();
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalDto, Animal>();
        }
    }
}
