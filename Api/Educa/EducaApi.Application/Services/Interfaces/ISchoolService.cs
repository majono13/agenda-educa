using EducaApi.Application.DTOs;

namespace EducaApi.Application.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<ResultService<SchoolDTO>> CreateSchoolAsync(SchoolDTO schoolDto);
    }
}
