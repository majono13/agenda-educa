using EducaApi.Application.DTOs;
using EducaApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducaApi.Api.Controllers
{

    [Route("/api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            var result = await _teacherService.CreateTeacherAsync(teacherDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
