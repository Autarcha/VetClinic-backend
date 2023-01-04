using AutoMapper;
using VetClinic_backend.Dto.Visit;
using VetClinic_backend.Models;

namespace VetClinic_backend.Profiles
{
    public class VisitProfile : Profile
    {
        public VisitProfile()
        {
            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();
        }
    }
}
