using EducaApi.Application.DTOs;
using EducaApi.Application.Services;
using EducaApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducaApi.Api.Controllers
{
    [Route("/api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        //Método post para criar escola
        [HttpPost]
        public async Task<IActionResult> CreateSchool([FromBody] SchoolDTO schoolDto)
        {
            var result = await _schoolService.CreateSchoolAsync(schoolDto);

                return Ok(result);
        }

        //Método get para buscar escolas
        [HttpGet]
        [Route("{teacherId}")]
        public async Task<ActionResult> GetSchoolsAsync(int teacherId)
        {
            var result = await _schoolService.GetSchoolsAsync(teacherId);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método put para Editar escola salva no banco
        [HttpPut]
        public async Task<ActionResult> UpdateStudentAsync([FromBody] SchoolDTO schoolDTO)
        {
            var result = await _schoolService.EditSchoolAsync(schoolDTO);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método delete para excluir escola
        [HttpDelete]
        [Route("{schoolId}")]
        public async Task<IActionResult> DeleteSchoolAsync(int schoolId)
        {
            var result = await _schoolService.DeleteSchoolAsync(schoolId);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
