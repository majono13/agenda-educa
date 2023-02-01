using EducaApi.Application.DTOs;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Domain.FiltersDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducaApi.Api.Controllers
{
    [Authorize]
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //Método post para criação de Alunos
        [HttpPost]
        public async Task<ActionResult> CreateStudentAsync([FromBody] StudentDTO studentDto)
        {
            var result = await _studentService.CreateStudentAsync(studentDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método get para buscar alunos relacionados a determinado professor
        [HttpGet]
        [Route("get-students/{teacherId}")]
        public async Task<ActionResult> GetStudentsAsync(int teacherId)
        {
            var result = await _studentService.GetStudentsAsync(teacherId);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método get para buscar aluno por id
        [HttpGet]
        [Route("get-student/{id}")]
        public async Task<ActionResult> GetStudentByIdAsync(int id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método get para buscar alunos de maneira paginada
        [HttpGet]
        [Route("pagination/{teacherId}")]
        public async Task<ActionResult> GetStudentsPaged([FromQuery] StudentFilterDb studentFilterDb, int teacherId)
        {
            var result = await _studentService.GetPagedAsync( studentFilterDb, teacherId);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método put para Editar aluno salvo no banco
        [HttpPut]
        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO studentDto)
        {
            var result = await _studentService.UpdateStudentAsync(studentDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método delete para deletar aluno salvo no banco
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
