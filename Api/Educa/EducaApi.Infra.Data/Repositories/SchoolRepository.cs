using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
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
    }
}
