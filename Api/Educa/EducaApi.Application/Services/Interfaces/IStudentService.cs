using EducaApi.Application.DTOs;
using EducaApi.Domain.FiltersDb;

namespace EducaApi.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task <ResultService<StudentDetailDTO>> CreateStudentAsync(StudentDTO studentDTO);
        Task<ResultService<StudentDetailDTO>> GetStudentByIdAsync(int id);
        Task<ResultService<ICollection<StudentDetailDTO>>> GetStudentsAsync(int teacherId);
        Task<ResultService> UpdateStudentAsync(StudentDTO studentDTO);
        Task<ResultService> DeleteStudentAsync(int id);
        Task<ResultService<PageBaseResponseDTO<StudentDetailDTO>>> GetPagedAsync(StudentFilterDb studentFilterDb, int teacherId);
    }
}
