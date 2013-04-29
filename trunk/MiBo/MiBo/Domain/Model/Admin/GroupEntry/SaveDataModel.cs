namespace MiBo.Domain.Model.Admin.GroupEntry
{
    public class SaveDataModel
    {
        public string GroupCd { get; set; }
        public string GroupName { get; set; }
        public decimal? SortKey { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}