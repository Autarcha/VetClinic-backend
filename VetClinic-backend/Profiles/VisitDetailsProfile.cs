using AutoMapper;
using VetClinic_backend.Dto.VisitDetails;
using VetClinic_backend.Models;

namespace VetClinic_backend.Profiles
{
    public class VisitDetailsProfile : Profile
    {
        public VisitDetailsProfile()
        {
            CreateMap<VisitDetails, VisitDetailsDto>().ReverseMap(); ;
            CreateMap<VisitDetailsAddDto, VisitDetails>().ReverseMap(); ;
            CreateMap<VisitDetailsUpdateDto, VisitDetails>().ReverseMap(); ;
        }
    }
}
