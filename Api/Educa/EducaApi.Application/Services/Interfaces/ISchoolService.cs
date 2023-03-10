using EducaApi.Application.DTOs;

namespace EducaApi.Application.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<ResultService<SchoolDTO>> CreateSchoolAsync(SchoolDTO schoolDto);
        Task<ResultService<ICollection<SchoolDTO>>> GetSchoolsAsync(int teacherId);
        Task<ResultService<SchoolDTO>> GetSchoolByIdAsync(int schoolId);
        Task<ResultService> DeleteSchoolAsync(int id);
        Task<ResultService> EditSchoolAsync(SchoolDTO schoolDTO);

    }
}
