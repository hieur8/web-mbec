using System.Collections.Generic;

namespace MiBo.Domain.Web.Client.Checkout
{
    public class OutputEmailModel
    {
        public string ViewId { get; set; }
        public string AcceptDate { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientTel { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryTel { get; set; }
        public string PaymentMethodsContent { get; set; }
        public string Notes { get; set; }
        public string Hotline { get; set; }
        public string EmailSupport { get; set; }

        public IList<OutputAcceptDetailsModel> AcceptDetails { get; set; }
        public string TotalAmount { get; set; }
    }
}