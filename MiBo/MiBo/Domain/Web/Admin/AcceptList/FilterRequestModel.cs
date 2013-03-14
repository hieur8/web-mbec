namespace MiBo.Domain.Web.Admin.AcceptList
{
    public class FilterRequestModel
    {
        public string SlipNoStart { get; set; }
        public string SlipNoEnd { get; set; }
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string ClientCd { get; set; }
        public string ClientName { get; set; }
        public string SlipStatus { get; set; }
        public string AcceptDateStart { get; set; }
        public string AcceptDateEnd { get; set; }
        public string DeliveryDateStart { get; set; }
        public string DeliveryDateEnd { get; set; }
    }
}