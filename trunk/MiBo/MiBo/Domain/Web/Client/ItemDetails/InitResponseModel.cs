using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.ItemDetails
{
    public class InitResponseModel : MessageResponse
    {
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public IList<string> ItemImages { get; set; }
        public string ItemDiv { get; set; }
        public string OfferDiv { get; set; }
        public string Price { get; set; }
        public string PriceOld { get; set; }
        public string Notes { get; set; }
    }
}