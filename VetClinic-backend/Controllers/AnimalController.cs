using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Dto.Animal;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Animals")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AnimalController(IAnimalRepository animalRepository, IMapper mapper, IUserRepository userRepository)
        {

            _animalRepository = animalRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AnimalDto>))]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAllAnimals()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);
            var request = _animalRepository.GetAllAnimals();


            if (userRole == Role.Customer)
            {
                request = request.Where(x => x.Owner.Id == userId);
            }

            var result = await request.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<AnimalDto>>(result));
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AnimalDto>))]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAllCustomerAnimals([FromRoute] int customerId)
        {
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Employee)
            {
                return Forbid();
            }

            var request = _animalRepository.GetAllAnimals().Where(x => x.Owner.Id == customerId);

            var result = await request.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<AnimalDto>>(result));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AnimalDto))]

        public async Task<ActionResult<AnimalDto>> AddAnimal(AnimalAddDto animalDetails)
        {
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Employee)
            {
                return Forbid();
            }

            var owner = await _userRepository.GetUserById(animalDetails.OwnerID);

            if(owner is null)
            {
                return NotFound("There isn't animal owner of provided id");
            }

            var animal = new Animal { Name = animalDetails.Name, Owner = owner, Specie = animalDetails.Specie, AdditionalInfo = animalDetails.AdditionalInfo };
            var result = await _animalRepository.AddAnimal(animal);
            return Ok(_mapper.Map<AnimalDto>(result));
        }

        [HttpPut("{animalId}")]

        public async Task<ActionResult<AnimalDto>> UpdateAnimal([FromRoute] int animalId, AnimalUpdateDto request)
        {

            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Employee)
            {
                return Forbid();
            }

            var animal = await _animalRepository.GetAnimalById(animalId);

            if (animal is null)
            {
                return NotFound("There isn't any animal of provided id");
            }


            animal.Name = request.Name ?? animal.Name;

            animal.Specie = request.Specie ?? animal.Specie;

            animal.AdditionalInfo = request.AdditionalInfo ?? animal.AdditionalInfo;

            var result = await _animalRepository.UpdateAnimal(animal);
            return Ok(_mapper.Map<AnimalDto>(result));
        }
    }
}
