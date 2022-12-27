using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetClinic_backend.Dto.UserDto;
using VetClinic_backend.Interfaces;

namespace VetClinic_backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Profile")]
    [ApiController]

    public class ProfileController : Controller
    {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public ProfileController(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserProfileDto))]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile()
        {
            var userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var request = await _userRepository.GetUserById(userId);
            return Ok(_mapper.Map<UserProfileDto>(request));
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateProfile(UserDetailsDto request)
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
                    ModelState.AddModelError("", "Błędne obecne hasło");
                    return StatusCode(406, ModelState);
                }


                if (BCrypt.Net.BCrypt.Verify(request.NewPassword, user.Password))
                {

                    ModelState.AddModelError("", "Nowe hasło nie może być takie samo jak poprzednie");
                    return StatusCode(500, ModelState);
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            }

            var result = await _userRepository.UpdateUser(user);

            return Ok(_mapper.Map<UserDto>(result));

        }
    }
}
