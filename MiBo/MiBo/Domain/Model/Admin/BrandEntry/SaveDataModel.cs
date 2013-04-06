namespace MiBo.Domain.Model.Admin.BrandEntry
{
    public class SaveDataModel
    {
        public string BrandCd { get; set; }
        public string BrandName { get; set; }
        public string BrandSearchName { get; set; }
        public string FileId { get; set; }
        public string Notes { get; set; }
        public decimal? SortKey { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}