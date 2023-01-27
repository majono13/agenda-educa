using EducaApi.Domain.Entities;

namespace EducaApi.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<ICollection<Student>> GetStudentsAsync(int teacherId);
        Task<Student> CreateStudentAync(Student student);
        Task EditStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
