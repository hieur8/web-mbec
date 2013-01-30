using MiBo.Domain.Common.Model;
using System.Collections.Generic;

namespace MiBo.Domain.Model.Client.Items
{
    public class InitDataModel
    {
        // Request
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string PriceCd { get; set; }
        public bool? IsOffer { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsHot { get; set; }

        // Response
        public IList<ItemModel> ListItems { get; set; }
    }
}