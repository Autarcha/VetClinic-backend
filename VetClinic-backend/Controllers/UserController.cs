using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Users")]
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

        [HttpGet("Profile")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> GetUserById()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var request = await _userRepository.GetUserById(userId);
            return Ok(_mapper.Map<UserDto>(request));
        }

        [HttpPost("Register", Name = "RegisterUser")]
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
        [HttpPost("Login", Name = "LoginUser")]
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
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "AuthToken");
            HttpContext.Response.Headers.Add("AuthToken", token);
            return Ok(_mapper.Map<UserDto>(result.Result));
        }

        [HttpPut("UpdateDetails")]
        public async Task<ActionResult<UserDto>> UpdateUserDetails(UserUpdateDto request)
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var user = await _userRepository.GetUserById(userId);

            if (user is null)
            {
                ModelState.AddModelError("", "Nie znaleziono takiego użytkownika");
                return StatusCode(404, ModelState);
            }

            if (!String.IsNullOrEmpty(request.Email))
            {
                var checkIfExist = await _userRepository.GetUserByEmail(request.Email);
                if (checkIfExist is not null && user.Email != request.Email)
                {
                    return Problem("Zarejestrowano juz konto na ten mail");
                }
                user.Email = request.Email;
            }

/*            if (!(String.IsNullOrEmpty(request.OldPassword) && String.IsNullOrEmpty(request.NewPassword)))
            {
                if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.Password))
                {
                    return Problem("Błędne obecne hasło");
                }


                if (BCrypt.Net.BCrypt.Verify(request.NewPassword, user.Password))
                {
                    return Problem("Nowe hasło nie może być takie smao jak poprzednie");
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            }*/
            if (!String.IsNullOrEmpty(request.Name))
            {
                user.Name = request.Name;
            }
            if (!String.IsNullOrEmpty(request.Surname))
            {
                user.Surname = request.Surname;
            }
            if (!String.IsNullOrEmpty(request.PhoneNumber))
            {
                user.PhoneNumber = request.PhoneNumber;
            }

            var result = await _userRepository.UpdateUser(user);

            return Ok(_mapper.Map<UserDto>(result));

        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult<UserDto>> ChangePassword(UserChangePasswordDto request)
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);

            var user = await _userRepository.GetUserById(userId);

            if (user is null)
            {
                ModelState.AddModelError("", "Nie znaleziono takiego użytkownika");
                return StatusCode(404, ModelState);
            }


            if (!(String.IsNullOrEmpty(request.OldPassword) && String.IsNullOrEmpty(request.NewPassword)))
            {
                if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.Password))
                {
                    return Problem("Błędne obecne hasło");
                }


                if (BCrypt.Net.BCrypt.Verify(request.NewPassword, user.Password))
                {
                    return Problem("Nowe hasło nie może być takie smao jak poprzednie");
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            }

            var result = await _userRepository.UpdateUser(user);

            return Ok(_mapper.Map<UserDto>(result));

        }

    }
}
