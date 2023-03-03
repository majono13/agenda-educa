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
    }
}
