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
            CreateMap<Student, StudentDetailDTO>()
                .ForMember(x => x.School, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new StudentDetailDTO
                    {
                        School = model.School.Name,
                        Id = model.Id,
                        Class = model.Class,
                        TeacherId = model.TeacherId,
                        SchoolId = model.SchoolId
                };

                    return dto;
                });
        }
    }
}
