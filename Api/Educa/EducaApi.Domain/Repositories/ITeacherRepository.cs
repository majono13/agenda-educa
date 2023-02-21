using EducaApi.Domain.Entities;

namespace EducaApi.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<Teacher> GetTeacherByEmailAsync(string email);
        Task<Teacher> CreateTeacherAync(Teacher teacher);
        Task EditTeacherAsync(Teacher teacher);
    }
}
