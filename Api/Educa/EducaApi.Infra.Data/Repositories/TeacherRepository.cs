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

        #region Create teacher
        /** Método assíncrono para criar novo professor **/
        public async Task<Teacher> CreateTeacherAync(Teacher teacher)
        {
            _db.Add(teacher);
            await _db.SaveChangesAsync();
            return teacher;
        }
        #endregion

        #region Edite teacher
        /** Método assíncrono para editar professor **/
        public async Task EditTeacherAsync(Teacher teacher)
        {
            _db.Update(teacher);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Get teacher by id
        /** Método assíncrono para buscar professor por id **/
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _db.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);
        }
        #endregion

        #region Get teacher by email
        /** Método assíncrono para buscar professor por email **/
        public async Task<Teacher> GetTeacherByEmailAsync(string email)
        {
            return await _db.Teachers.FirstOrDefaultAsync(teacher => teacher.Email == email);
        }
        #endregion
    }
}
