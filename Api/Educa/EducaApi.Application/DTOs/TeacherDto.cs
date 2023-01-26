using EducaApi.Domain.Entities;

namespace EducaApi.Application.DTOs
{
    public class TeacherDto
    {
        public int Id { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }

    }
}
