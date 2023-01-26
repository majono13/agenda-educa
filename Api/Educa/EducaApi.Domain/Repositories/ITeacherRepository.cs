using EducaApi.Domain.Entities;

namespace EducaApi.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<Teacher> CreateTeacherAync(Teacher teacher);
        Task EditTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Teacher teacher);
    }
}
