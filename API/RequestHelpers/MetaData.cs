namespace API.RequestHelpers
{
    public class MetaData
    {
        //client a dönücek olan model
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}