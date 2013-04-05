namespace MiBo.Domain.Model.Admin.CategoryEntry
{
    public class SaveDataModel
    {
        public string CategoryCd { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDiv { get; set; }
        public decimal? SortKey { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}