namespace MiBo.Domain.Common.Model
{
    public class PagerRequest
    {
        public string Offset { get; set; }
        public string Limit { get; set; }
        public string IsAsc { get; set; }
        public string SortBy { get; set; }
    }
}