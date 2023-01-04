using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using VetClinic_backend.Dto.Visit;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Visits")]
    [ApiController]
    public class VisitController : Controller
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAnimalRepository _animalRepository;

        public VisitController(IVisitRepository visitRepository, IMapper mapper, IUserRepository userRepository, IAnimalRepository animalRepository)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _animalRepository = animalRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<VisitDto>))]
        public async Task<ActionResult<IEnumerable<VisitDto>>> GetAllVisits()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);
            var request = _visitRepository.GetAllVisits();

            if (userRole != Role.Admin)
            {
                request = request.Where(x => x.CustomerId == userId);
            }
            var result = await request.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VisitDto>>(result));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VisitDto))]

        public async Task<ActionResult<VisitDto>> AddVisit(VisitAddDto visitBody)
        {
            var customer = await _userRepository.GetUserById(visitBody.CustomerId);
            var employee = await _userRepository.GetUserById(visitBody.EmployeeId);
            Animal? animal = null;

            if (visitBody.AnimalID.HasValue)
            {
                animal = await _animalRepository.GetAnimalById(visitBody.AnimalID.Value);
            }


            var visit = new Visit { Customer = customer, Employee = employee, Animal = animal,
                CustomerId = visitBody.CustomerId, EmployeeId = visitBody.EmployeeId,
                VisitDateTime = visitBody.VisitDateTime, VisitStatus = visitBody.VisitStatus
            };
            var result = await _visitRepository.AddVisit(visit);

            return Ok(_mapper.Map<VisitDto>(result));
        }

        [HttpPut("{visitId}")]
        [ProducesResponseType(200, Type = typeof(VisitDto))]

        public async Task<ActionResult<VisitDto>> UpdateVisit([FromRoute] int visitId, VisitUpdateDto request)
        {
            var visit = await _visitRepository.GetVisitById(visitId);
            var employee = await _userRepository.GetUserById(request.EmployeeId);
            Animal? animal = null;

            if (visit is null)
            {
                ModelState.AddModelError("", "Nie znaleziono wizyty o podanym ID");
                return StatusCode(404, ModelState);
            }

            if (request.AnimalID.HasValue)
            {
                animal = await _animalRepository.GetAnimalById(request.AnimalID.Value);
                visit.Animal = animal;
            }

            visit.Employee = employee;

            visit.VisitDateTime = request.VisitDateTime;

            visit.VisitStatus = request.VisitStatus;

            var result = await _visitRepository.UpdateVisit(visit);

            return Ok(_mapper.Map<VisitDto>(result));
        }
    }
}
