using EducaApi.Application.DTOs;
using EducaApi.Application.Services;
using EducaApi.Application.Services.Interfaces;
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
    }
}
