using AutoMapper;
using VetClinic_backend.Dto.Animal;
using VetClinic_backend.Models;

namespace VetClinic_backend.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalAddDto>().ReverseMap();
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<Animal, AnimalUpdateDto>().ReverseMap();
        }
    }
}
