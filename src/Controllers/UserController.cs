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
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/User?params=...
        // Obtiene una lista de usuarios con paginación y filtros
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>> GetAll([FromQuery] UserParams userParams)
        {
            var query = _unitOfWork.UserRepository.GetUsersQueryable();

            if(userParams.IsActive.HasValue)
                query = query.Where(u => u.IsActive == userParams.IsActive.Value);

            if(!string.IsNullOrWhiteSpace(userParams.SearchTerm)){
                var term = userParams.SearchTerm.ToLower();
                query = query.Where(u =>
                    u.FirstName.Contains(userParams.SearchTerm) ||
                    u.LastName.Contains(userParams.SearchTerm) ||
                    (u.Email != null && u.Email.ToLower().Contains(term)));
            }

            if(userParams.RegisteredFrom.HasValue)
                query = query.Where(u => u.RegisteredAt >= userParams.RegisteredFrom.Value);

            if(userParams.RegisteredTo.HasValue)
                query = query.Where(u => u.RegisteredAt <= userParams.RegisteredTo.Value);

            var total = await query.CountAsync();

            var users = await query
                .OrderByDescending(u => u.RegisteredAt)
                .Skip((userParams.PageNumber - 1) * userParams.PageSize)
                .Take(userParams.PageSize)
                .ToListAsync();

            var dtos = user.Select(u => UserMapper.UserToUserDto(u)).ToList();

            Response.AddPaginationHeader(new PaginationMetadata
            {
                CurrentPage = userParams.PageNumber,
                TotalPages = (int)Math.Ceiling((double)total / userParams.PageSize),
                PageSize = userParams.PageSize,
                TotalCount = total
            });

            return Ok(new ApiResponse<IEnumerable<UserDto>>(true, "Usuarios obtenidos correctamente", dtos));
        }

        //PUT: api/User/{id}/status
        // Cambia el estado de un usuario (activo/inactivo)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<ActionResult<ApiResponse<string>>> ToggleStatus(string id, [FromBody] ToggleStatusDto dto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new ApiResponse<string>(false, "Usuario no encontrado"));

            user.IsActive = !user.IsActive;
            user.DeactivationReason = user.IsActive ? null : dto.Reason;

            await _unitOfWork.UserRepository.UpdateUserAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var message = user.IsActive ? "Usuario activado correctamente" : "Usuario desactivado correctamente";
            return Ok(new ApiResponse<string>(true, message));
        }
    }
}