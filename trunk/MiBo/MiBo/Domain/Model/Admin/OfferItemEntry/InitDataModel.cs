using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferItemEntry
{
    public class InitDataModel
    {
        public string OfferCd { get; set; }
        public bool? DeleteFlag { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}