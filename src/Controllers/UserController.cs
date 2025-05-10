using api.src.Data;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserRepository userRepository, UnitOfWork unitOfWork) : ControllerBase
    {
        private readonly UnitOfWork _context = unitOfWork;
        private readonly IUserRepository _userRepository = userRepository;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        // GET: api/User/5
        // Obtiene un usuario por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}