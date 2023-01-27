using EducaApi.Application.DTOs;
using EducaApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducaApi.Api.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudentAsync([FromBody] StudentDTO studentDto)
        {
            var result = await _studentService.CreateStudentAsync(studentDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("get-students/{teacherId}")]
        public async Task<ActionResult> GetStudentsAsync(int teacherId)
        {
            var result = await _studentService.GetStudentsAsync(teacherId);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("get-student/{id}")]
        public async Task<ActionResult> GetStudentByIdAsync(int id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO studentDto)
        {
            var result = await _studentService.UpdateStudentAsync(studentDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> CreateStudentAsync(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
