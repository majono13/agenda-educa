using EducaApi.Application.DTOs;

namespace EducaApi.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task <ResultService<StudentDTO>> CreateStudentAsync(StudentDTO studentDTO);
        Task<ResultService<StudentDTO>> GetStudentByIdAsync(int id);
        Task<ResultService<ICollection<StudentDTO>>> GetStudentsAsync(int teacherId);
        Task<ResultService> UpdateStudentAsync(StudentDTO studentDTO);
        Task<ResultService> DeleteStudentAsync(int id);
    }
}
