using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GiftList
{
    public class UpdateDataModel
    {
        public IList<GiftCard> ListGifts { get; set; }
    }
}