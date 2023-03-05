using EducaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Domain.Repositories
{
    public interface ISchoolRepository
    {
        Task<School> CreateSchoolAsync(School school);
        Task<ICollection<School>> GetSchoolsAsync(int teacherId);
        Task<School> GetSchoolByIdAsync(int id);
        Task DeleteSchoolAsync(School school);
        Task EditSchoolAsync(School school);
    }
}
