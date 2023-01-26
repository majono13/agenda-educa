using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EducaApi.Infra.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {

        private readonly AppDbContext _db;

        public TeacherRepository()
        {}

        public TeacherRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Teacher> CreateTeacherAync(Teacher teacher)
        {
            _db.Add(teacher);
            await _db.SaveChangesAsync();
            return teacher;
        }

        public async Task DeleteTeacherAsync(Teacher teacher)
        {
            _db.Remove(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task EditTeacherAsync(Teacher teacher)
        {
            _db.Update(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _db.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);
        }
    }
}
