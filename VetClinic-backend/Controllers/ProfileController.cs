using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Dto.User;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

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
                return NotFound("Not found user of provided id");
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
                return NotFound("Not found user of provided id");
            }


            if (request.OldPassword is not null && request.NewPassword is not null)
            {
                if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.Password))
                {
                    ModelState.AddModelError("", "Wrong current password");
                    return StatusCode(406, ModelState);
                }


                if (BCrypt.Net.BCrypt.Verify(request.NewPassword, user.Password))
                {

                    ModelState.AddModelError("", "New password cannot bet the same as old one");
                    return StatusCode(500, ModelState);
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            }

            var result = await _userRepository.UpdateUser(user);
            return Ok(_mapper.Map<UserDto>(result));

        }
    }
}
