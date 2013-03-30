namespace MiBo.Domain.Common.Model
{
    public class PagerModel
    {
        public decimal? Offset { get; set; }
        public decimal? Limit { get; set; }
        public bool? IsAsc { get; set; }
        public string SortBy { get; set; }
    }
}