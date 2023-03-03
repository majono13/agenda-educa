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

        [HttpPost]
        public async Task<IActionResult> CreateSchool([FromBody] SchoolDTO schoolDto)
        {
            var result = await _schoolService.CreateSchoolAsync(schoolDto);

                return Ok(result);
        }
    }
}
