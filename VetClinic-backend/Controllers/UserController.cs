using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Authentication;
using VetClinic_backend.Dto.User;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthentication _jwtAuthenctiaction;
        private readonly IGeneratePassword _generatePassword;
        private readonly IEmailService _emailService;
        public UserController(IUserRepository userRepository, IMapper mapper, IAuthentication jwtAuthenctiaction, IGeneratePassword generatePassword, IEmailService emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtAuthenctiaction = jwtAuthenctiaction;
            _generatePassword = generatePassword;
            _emailService = emailService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Employee)
            {
                return Forbid();
            }
            var request = _userRepository.GetAllUsers();

            if (userRole != Role.Admin)
            {
                request = request.Where(x => x.Role == Role.Customer);
            }
            var result = await request.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(result));
        }

        [HttpGet("Employees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllEmployees()
        {

            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Employee)
            {
                return Forbid();
            }

            var request = _userRepository.GetAllUsers().Where(x => x.Role != Role.Customer);

            var result = await request.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(result));
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] int userId, UserDetailsDto request)
        {
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Employee)
            {
                return Forbid();
            }

            var user = await _userRepository.GetUserById(userId);

            if (user is null)
            {
                return NotFound("Not found user of provided id");
            }

            if(request.Email is not null)
            {
                var checkIfExist = await _userRepository.GetUserByEmail(request.Email);

                if (checkIfExist is not null && user.Email != request.Email)
                {
                    return Forbid();
                }
            }

    
            user.Email = request.Email ?? user.Email;
                
            user.Name = request.Name ?? user.Name;

            user.Surname = request.Surname ?? user.Surname;
           
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;

            var role = user.Role;

            Enum.TryParse<Role>(request.Role?.ToString(), out role);

            user.Role = role;

            var result = await _userRepository.UpdateUser(user);
            return Ok(_mapper.Map<UserDto>(result));

        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<UserDto>> DeleteUser([FromRoute] int userId)
        {
            var userRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (userRole > Role.Admin)
            {
                return Forbid();
            }

            var user = await _userRepository.GetUserById(userId);

            if (user is null)
            {
                return NotFound("Not found user of provided id");
            }

            var result = await _userRepository.DeleteUser(user);
            return Ok(_mapper.Map<UserDto>(result));

        }

        [HttpPost("Register", Name = "RegisterUser")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> RegisterUser(UserDetailsDto userRegisterData)
        {

            var employeeRole = Enum.Parse<Role>(User.Claims.First(x => x.Type == "userRole").Value);

            if (employeeRole > Role.Admin)
            {
                return Forbid();
            }

            if (userRegisterData is null)
            {
                return BadRequest(ModelState);
            }

            var users = _userRepository.GetAllUsers();

            var withEmail = await users.FirstOrDefaultAsync(u => u.Email == userRegisterData.Email);
            if (withEmail is not null)
            {
                ModelState.AddModelError("", "Account with that email already exists");
                return StatusCode(422, ModelState);
            }

            var userPassword = _generatePassword.GenerateRandomCode();

            if (employeeRole != Role.Admin)
            {
                userRegisterData.Role = 4;
            }

            var userRegisterMap = _mapper.Map<User>(userRegisterData);
            userRegisterMap.Password = BCrypt.Net.BCrypt.HashPassword(userPassword);

            await _userRepository.AddUser(userRegisterMap);
            await _emailService.SendPasswordMail(userRegisterMap, userPassword);
            return Ok(_mapper.Map<UserDto>(userRegisterMap));
        }

        [AllowAnonymous]
        [HttpPost("Login", Name = "LoginUser")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> LoginUser(UserLoginDto loginData)
        {
            var userLoginMap = _mapper.Map<User>(loginData);
            var result = await _userRepository.LoginUser(userLoginMap.Email, userLoginMap.Password);

            if(result is null)
            {
                return Forbid("Provided wrong login credentials");
            }

            var token = _jwtAuthenctiaction.GenerateAuthenticationToken(result);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "AuthToken");
            HttpContext.Response.Headers.Add("AuthToken", token);
            return Ok(_mapper.Map<UserDto>(result));
        }

    }
}
