using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic_backend.Dto;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;
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

        [HttpPost("register", Name = "RegisterUser")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserRegisterDto userRegisterData)
        {
            if(userRegisterData == null)
            {
                return BadRequest(ModelState);
            }
            var users = await _userRepository.GetAllUsers();
            var withEmail = users.Where(u => u.Email == userRegisterData.Email).ToList();
            if (withEmail.Count > 0)
            {
                ModelState.AddModelError("", "Konto z takim adresem email zostało już utworzone");
                return StatusCode(422, ModelState);
            }

            var userRegisterMap = _mapper.Map<User>(userRegisterData);
            userRegisterMap.Password = BCrypt.Net.BCrypt.HashPassword(userRegisterData.Password);
            await _userRepository.AddUser(userRegisterMap);
            await _userRepository.SaveChangesAsync();
            return Ok("Pomysnie utworzono użytkownika");
        }
    }
}
