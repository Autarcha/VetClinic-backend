using Microsoft.AspNetCore.Mvc;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userRepository;
        public UserController(IUserInterface userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType( 200 , Type = typeof(IEnumerable<User>))]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(users);
        }
    }
}
