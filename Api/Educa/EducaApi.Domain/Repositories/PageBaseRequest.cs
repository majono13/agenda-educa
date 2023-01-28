namespace EducaApi.Domain.Repositories
{
    public class PageBaseRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderByPropety { get; set; }

        public PageBaseRequest()
        {
            Page = 1;
            PageSize = 2;
            OrderByPropety = "Id";
        }
    }
}
