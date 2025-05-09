using TallerIDWM.src.Mappers;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using api.src.Helpers;
using api.src.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TallerIDWM.src.Mappers;

namespace api.src.Controllers
{
    public class AuthController(ILogger<AuthController> logger, UserManager<User> userManager, ITokenServices tokenService, UserMapper userMapper) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly UserManager<User> _userManager = userManager;
        private readonly ITokenServices _tokenService = tokenService;
        private readonly UserMapper _userMapper = userMapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto newUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<string>(false, "Datos Invalidos", null, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
                }

                var user = UserMapper.RegisterToUser(newUser);
                if (string.IsNullOrEmpty(newUser.Password) || string.IsNullOrEmpty(newUser.ConfirmPassword))
                {
                    return BadRequest(new ApiResponse<string>(false, "La contraseña y/o la confirmación no pueden estar vacias"));
                }

                var createUser = await _userManager.CreateAsync(user, newUser.Password);
                if (!createUser.Succeeded)
                {
                    return BadRequest(new ApiResponse<string>(false, "Error al crear el usuario", null, createUser.Errors.Select(e => e.Description).ToList()));
                }

                var roleUser = await _userManager.AddToRoleAsync(user, "User");
                if (!roleUser.Succeeded)
                {
                    return BadRequest(new ApiResponse<string>(false, "Error al asignar el rol de usuario", null, roleUser.Errors.Select(e => e.Description).ToList()));
                }

                var role = await _userManager.GetRolesAsync(user);
                var roleName = role.FirstOrDefault() ?? "User";

                var token = await _tokenService.GenerateToken(user, roleName);
                var userDto = UserMapper.UserToAuthenticatedDto(user, token);

                return Ok(new ApiResponse<AuthenticatedUserDto>(true, "Usuario creado correctamente", userDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar el usuario: {Message}", ex.Message);
                return StatusCode(500, new ApiResponse<string>(false, "Error interno del servidor", null, new List<string> { "Error interno del servidor" }));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResponse<string>(false, "Datos Invalidos", null, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));

                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                    return Unauthorized(new ApiResponse<string>(false, "Correo o contraseña incorrectos"));

                if (!user.IsActive)
                    return Unauthorized(new ApiResponse<string>(false, "Tu cuenta no esta activa, contacta al administrador"));

                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!result)
                    return Unauthorized(new ApiResponse<string>(false, "Correo o contraseña incorrectos"));

                user.LastLogin = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault() ?? "User";

                var token = await _tokenService.GenerateToken(user, roleName);
                var userDto = UserMapper.UserToAuthenticatedDto(user, token);

                return Ok(new ApiResponse<AuthenticatedUserDto>(true, "Login exitoso", userDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al iniciar sesión: {Message}", ex.Message);
                return StatusCode(500, new ApiResponse<string>(false, "Error interno del servidor", null, new List<string> { "Error interno del servidor" }));
            }
        }
    }
}