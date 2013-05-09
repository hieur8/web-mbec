using System;
using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferEntry
{
    public class InitDataModel
    {
        public string OfferCd { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OfferDiv { get; set; }
        public IList<MCode> ListOfferDiv { get; set; }
    }
}