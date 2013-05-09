using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferList
{
    public class UpdateDataModel
    {
        public IList<Offer> ListOffers { get; set; }
    }
}