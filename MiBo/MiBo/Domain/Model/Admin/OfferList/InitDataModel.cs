using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferList
{
    public class InitDataModel
    {
        public IList<Offer> ListOffers { get; set; }
        public IList<MCode> ListOfferDiv { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}