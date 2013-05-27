namespace MiBo.Domain.Model.Admin.BannerEntry
{
    public class SaveDataModel
    {
        public string BannerCd { get; set; }
        public string BannerName { get; set; }
        public string FileId { get; set; }
        public string OfferGroupCd { get; set; }
        public decimal? SortKey { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}