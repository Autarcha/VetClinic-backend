using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VetClinic_backend.Dto.VisitDetails;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;
using VetClinic_backend.Repositories;

namespace VetClinic_backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/visits/{visitId}/details")]
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

        public async Task<ActionResult<VisitDetailsDto>> AddVisitDetails([FromRoute] int visitId, VisitDetailsAddDto request)
        {
            var visit = await _visitRepository.GetVisitById(visitId);

            if (visit == null)
            {
                return NotFound("Not found visit of provided id");
            }

            var result = await _visitDetailsRepository.AddVisitDetails(_mapper.Map<VisitDetails>(request));

            visit.VisitDetails = result;

            await _visitRepository.UpdateVisit(visit);

            return Ok(_mapper.Map<VisitDetailsDto>(result));
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(VisitDetailsDto))]

        public async Task<ActionResult<VisitDetailsDto>> UpdateVisitDetails([FromRoute] int visitId, VisitDetailsUpdateDto request)
        {

            var visit = await _visitRepository.GetVisitById(visitId);

            if (visit == null)
            {
                return NotFound("Not found visit of provided id");
            }

            if (visit.VisitDetails == null)
            {
                return NotFound("There isn't any visit details yet");
            }

            var visitDetails = visit.VisitDetails;

            visitDetails.VisitPurpose = request.VisitPurpose ?? visitDetails.VisitPurpose;

            visitDetails.Description = request.Description ?? visitDetails.Description;

            visitDetails.AppliedDrugs = request.AppliedDrugs ?? visitDetails.AppliedDrugs;

            visitDetails.Prescription = request.Prescription ?? visitDetails.Prescription;

            visitDetails.Recommendations = request.Recommendations ?? visitDetails.Recommendations;

            visitDetails.Bill = request.Bill ?? visitDetails.Bill;

            var result = _visitDetailsRepository.UpdateVisitDetails(visitDetails);

            return Ok(_mapper.Map<VisitDetailsDto>(result));
        }

    }
}
