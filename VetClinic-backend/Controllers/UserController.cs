using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using VetClinic_backend.Authentication;
using VetClinic_backend.Dto;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;
using VetClinic_backend.Repositories;

namespace VetClinic_backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthentication _jwtAuthenctiaction;
        public UserController(IUserRepository userRepository, IMapper mapper, IAuthentication jwtAuthenctiaction)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtAuthenctiaction = jwtAuthenctiaction;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var request = _userRepository.GetAllUsers();
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
            var users = _userRepository.GetAllUsers();
            var withEmail = await users.FirstOrDefaultAsync(u => u.Email == userRegisterData.Email);
            if (withEmail is not null)
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

        [AllowAnonymous]
        [HttpPost("login", Name = "LoginUser")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> LoginUser(UserLoginDto loginData)
        {
            var userLoginMap = _mapper.Map<User>(loginData);
            var result = _userRepository.LoginUser(userLoginMap.Email, userLoginMap.Password);

            if(result.Result is null)
            {
                ModelState.AddModelError("", "Podano błędne dane logowania");
                return StatusCode(403, ModelState);
            }

            var token = _jwtAuthenctiaction.GenerateAuthenticationToken(result.Result);
            HttpContext.Response.Headers.Add("AuthToken", token);
            return Ok(_mapper.Map<UserDto>(result.Result));
        }
    }
}
