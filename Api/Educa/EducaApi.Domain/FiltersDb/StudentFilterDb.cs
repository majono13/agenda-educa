using EducaApi.Domain.Repositories;

namespace EducaApi.Domain.FiltersDb
{
    public class StudentFilterDb : PageBaseRequest
    {
        public string? Name { get; set; }
    }
}
