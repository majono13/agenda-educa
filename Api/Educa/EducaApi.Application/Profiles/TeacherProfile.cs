using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Domain.Entities;

namespace EducaApi.Application.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
        }
    }
}
