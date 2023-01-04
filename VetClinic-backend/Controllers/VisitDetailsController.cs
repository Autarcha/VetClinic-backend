using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetClinic_backend.Dto.Visit;
using VetClinic_backend.Dto.VisitDetails;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;
using VetClinic_backend.Repositories;

namespace VetClinic_backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/VisitDetails")]
    [ApiController]
    public class VisitDetailsController : Controller
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IVisitDetailsRepository _visitDetailsRepository;
        private readonly IMapper _mapper;

        public VisitDetailsController(IVisitRepository visitRepository, IMapper mapper, IVisitDetailsRepository visitDetailsRepository)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
            _visitDetailsRepository = visitDetailsRepository;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VisitDetailsDto))]

        public async Task<ActionResult<VisitDetailsDto>> AddVisitDetails(VisitDetailsAddDto request)
        {
            var visit = await _visitRepository.GetVisitById(request.VisitId);

            var result = await _visitDetailsRepository.AddVisitDetails(_mapper.Map<VisitDetails>(request));
            var createdVisitDetails = await _visitDetailsRepository.GetVisitDetailsByVisitId(request.VisitId);

            visit.VisitDetailsId = createdVisitDetails.Id;
            visit.VisitDetails = createdVisitDetails;

            await _visitRepository.UpdateVisit(visit);

            return Ok(_mapper.Map<VisitDetailsDto>(result));
        }

    }
}
