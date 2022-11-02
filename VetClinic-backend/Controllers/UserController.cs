using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic_backend.Dto;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserInterface userRepository, IMapper mapper )
        {
            _userRepository = userRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType( 200 , Type = typeof(IEnumerable<User>))]
        public IActionResult GetAllUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetAllUsers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if(!_userRepository.UserExists(userId))
                return NotFound();

            var user = _mapper.Map<User>(_userRepository.GetUser(userId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }
    }
}
