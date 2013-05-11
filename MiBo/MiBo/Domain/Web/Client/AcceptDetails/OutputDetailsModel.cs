using System.Collections.Generic;

namespace MiBo.Domain.Web.Client.AcceptDetails
{
    public class OutputDetailsModel
    {
        public string AcceptSlipNo { get; set; }
        public string SlipStatus { get; set; }
        public string SlipStatusName { get; set; }
        public string AcceptDate { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string PaymentMethods { get; set; }
        public string PaymentMethodsName { get; set; }
        public string TotalAmount { get; set; }
        public string ShipAmount { get; set; }
        public IList<OutputAcceptDetailsModel> ListAcceptDetails { get; set; }
    }
}