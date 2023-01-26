using EducaApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Application.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<ResultService<TeacherDto>> CreateTeacherAsync(TeacherDto teacherDto);
    }
}
