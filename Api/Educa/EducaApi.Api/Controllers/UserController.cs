using EducaApi.Application.DTOs;
using EducaApi.Application.Services;
using EducaApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducaApi.Api.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Método post para criar novo usuário
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] UserDTO userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método post para logar usuário
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync([FromBody] UserDTO userDto)
        {
            var result = await _userService.LoginAsync(userDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método get para buscar usuário por email
        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult> GetUserByEmailAsync(string email)
        {
            var result = await _userService.GetUserByEmailAsync(email);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método put para editar usuário
        [HttpPut]
        [Route("edit")]
        [Authorize]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserDTO userDto)
        {
            try
            {
                var result = await _userService.UpdateUserAsync(userDto);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
