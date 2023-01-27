using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Infra.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;

        public StudentRepository()
        { }

        public StudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Student> CreateStudentAync(Student student)
        {
            _db.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudentAsync(Student student)
        {
            _db.Remove(student);
            await _db.SaveChangesAsync();
        }

        public async Task EditStudentAsync(Student student)
        {
            _db.Update(student);
            await _db.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ICollection<Student>> GetStudentsAsync(int teacherId)
        {
            return await _db.Students
                .Where(student => student.TeacherId == teacherId)
                .ToListAsync();
        }
    }
}
