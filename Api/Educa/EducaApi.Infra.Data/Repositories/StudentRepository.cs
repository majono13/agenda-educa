using EducaApi.Domain.Entities;
using EducaApi.Domain.FiltersDb;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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

        #region Create student
        /** Método assíncrono para criar novo aluno **/
        public async Task<Student> CreateStudentAync(Student student)
        {
            _db.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }
        #endregion

        #region Delete student
        /** Método assíncrono para deletar aluno **/
        public async Task DeleteStudentAsync(Student student)
        {
            _db.Remove(student);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Edit student
        /** Método assíncrono para editar aluno **/
        public async Task EditStudentAsync(Student student)
        {
            _db.Update(student);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Get students paged
        /** Método assíncrono para buscas alunos no banco de dados de forma paginada **/
        public async Task<PageBaseResponse<Student>> GetPagedAsync(StudentFilterDb request, int teacherId)
        {
            //Query com todos os alunos
            var teacher = await _db.Teachers
                .FirstOrDefaultAsync(x => x.Id == teacherId);

            if (teacher == null)
                return null;

            var students = teacher.Students;

            if (request.SchoolId != 0)
                students = students.Where(x => x.SchoolId == request.SchoolId).ToList();


            //Realiza filtro de busca caso tenha sido passado
            if (!string.IsNullOrEmpty(request.Name))
                students = students.Where(x => x.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase)).ToList();

            return await PageBaseResponseHelper.GetResponseAsync<PageBaseResponse<Student>, Student>(students, request);

        }
        #endregion

        #region Get student by id
        /** Método assíncrono para burcar aluno por id **/
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
        #endregion

        #region Get students
        /** Método assíncrono para buscar todos os alunos de determinado professor **/
        public async Task<ICollection<Student>> GetStudentsAsync(int teacherId)
        {
            return await _db.Students
                .Where(student => student.TeacherId == teacherId)
                .ToListAsync();
        }
        #endregion
    }
}
