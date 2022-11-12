using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic_backend.Dto;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Repositories;

namespace VetClinic_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var request = await _userRepository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(request));
        }

        [HttpGet("userId")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var request = await _userRepository.GetUserById(id);
            return Ok(_mapper.Map<UserDto>(request));
        }

        [HttpGet("userName")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> GetUserByName(string name, string surname)
        {
            var request = await _userRepository.GetUserByName(name, surname);
            return Ok(_mapper.Map<UserDto>(request));
        }
    }
}
