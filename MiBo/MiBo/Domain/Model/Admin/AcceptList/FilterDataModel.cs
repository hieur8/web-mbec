using System;
using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.AcceptList
{
    public class FilterDataModel
    {
        public string SlipNoStart { get; set; }
        public string SlipNoEnd { get; set; }
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string ClientCd { get; set; }
        public string ClientName { get; set; }
        public string SlipStatus { get; set; }
        public DateTime? AcceptDateStart { get; set; }
        public DateTime? AcceptDateEnd { get; set; }
        public DateTime? DeliveryDateStart { get; set; }
        public DateTime? DeliveryDateEnd { get; set; }

        public IList<Accept> ListAccepts { get; set; }
        public IList<MCode> ListSlipStatus { get; set; }
    }
}