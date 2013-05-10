using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.OfferItemList
{
    public class UpdateDataModel
    {
        public IList<OfferItem> ListOfferItems { get; set; }
    }
}