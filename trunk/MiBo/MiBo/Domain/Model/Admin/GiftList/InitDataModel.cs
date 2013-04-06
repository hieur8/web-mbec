using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GiftList
{
    public class InitDataModel
    {
        public IList<GiftCard> ListGifts { get; set; }
        public IList<MCode> ListGiftStatus { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}