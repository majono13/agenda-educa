using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Domain.Entities;

namespace EducaApi.Application.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
