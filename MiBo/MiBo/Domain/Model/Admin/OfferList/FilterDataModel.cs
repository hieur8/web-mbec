using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferList
{
    public class FilterDataModel
    {
        public string ItemCd { get; set; }
        public string OfferDiv { get; set; }
        public bool? DeleteFlag { get; set; }

        public IList<Offer> ListOffers { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}