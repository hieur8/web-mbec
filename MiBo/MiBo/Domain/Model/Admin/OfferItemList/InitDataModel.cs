using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferItemList
{
    public class InitDataModel
    {
        public string OfferCd { get; set; }
        public IList<OfferItem> ListOfferItems { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}