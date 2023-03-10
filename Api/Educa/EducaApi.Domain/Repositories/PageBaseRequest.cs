namespace EducaApi.Domain.Repositories
{
    public class PageBaseRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderByPropety { get; set; }
        public int SchoolId { get; set; }

        public PageBaseRequest()
        {
            Page = 1;
            PageSize = 1;
            OrderByPropety = "Id";
            SchoolId = 0;
        }
    }
}
