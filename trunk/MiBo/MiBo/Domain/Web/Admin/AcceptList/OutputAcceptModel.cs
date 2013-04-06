using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.AcceptList
{
    public class OutputAcceptModel
    {
        public string AcceptSlipNo { get; set; }
        public string SlipStatus { get; set; }
        public string SlipStatusName { get; set; }
        public string AcceptDate { get; set; }
        public string DeliveryDate { get; set; }
        public string ClientCd { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientTel { get; set; }
        public string DeliveryCd { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryTel { get; set; }
        public string PaymentMethods { get; set; }
        public string PaymentMethodsName { get; set; }
        public string GiftCd { get; set; }
        public string ViewId { get; set; }
        public string Notes { get; set; }
        public string UpdateUser { get; set; }
        public string UpdateDate { get; set; }
        public string DeleteFlag { get; set; }
        public string DeleteFlagName { get; set; }

        public IList<ComboItem> ListSlipStatus { get; set; }
    }
}