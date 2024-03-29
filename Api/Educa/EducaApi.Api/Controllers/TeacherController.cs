﻿using EducaApi.Application.DTOs;
using EducaApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        //Método post para criar professor
        [HttpPost]
        public async Task<ActionResult> CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            var result = await _teacherService.CreateTeacherAsync(teacherDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método get para buscar professor por id
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult> GetTeacherByIdAsync(int id)
        {
            var result = await _teacherService.GetTeacherByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método get para buscar professor por email
        [HttpGet]
        [Route("get-teacher-by-email/{email}")]
        [Authorize]
        public async Task<ActionResult> GetTeacherByEmailAsync(string email)
        {
            var result = await _teacherService.GetTeacherByEmailAsync(email);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //Método put para editar professor salvo no banco
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpadateTeacherAsync([FromBody] TeacherDto teacherDto)
        {
            var result = await _teacherService.UpdateTeacherAsync(teacherDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
