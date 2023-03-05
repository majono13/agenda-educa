namespace EducaApi.Domain.Repositories
{
    public class PageBaseResponse<T>
    {
        public ICollection<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }

    }
}
