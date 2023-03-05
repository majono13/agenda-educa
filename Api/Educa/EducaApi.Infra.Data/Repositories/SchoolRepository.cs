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
    public class SchoolRepository : ISchoolRepository
    {
        private readonly AppDbContext _db;

        public SchoolRepository(AppDbContext db)
        {
            _db = db;
        }

        #region Create School
        //Método assíncrono para criar nova escola
        public async Task<School> CreateSchoolAsync(School school)
        {
            _db.Schools.Add(school);
            await _db.SaveChangesAsync();

            return school;
        }
        #endregion

        #region Get Schools
        //Método assíncrono para buscar escola pelo id do professor
        public async Task<ICollection<School>> GetSchoolsAsync(int teacherId)
        {
            return await _db.Schools.Where(x => x.TeacherId == teacherId).ToListAsync();
        }
        #endregion

        #region Get School By Id
        //Método assíncrono para buscar escola por id
        public async Task<School> GetSchoolByIdAsync(int id)
        {
            return await _db.Schools.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Delete School
        //Método assíncrono para excluir escola
        public async Task DeleteSchoolAsync(School school)
        {
            _db.Remove(school);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Edite School
        //Método assíncrono para editar escola
        public async Task EditSchoolAsync(School school)
        {
            _db.Update(school);
            await _db.SaveChangesAsync();
        }
        #endregion
    }
}
