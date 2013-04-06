using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GiftList
{
    public class FilterDataModel
    {
        public string GiftCd { get; set; }
        public string GiftStatus { get; set; }
        public bool? DeleteFlag { get; set; }

        public IList<GiftCard> ListGifts { get; set; }
        public IList<MCode> ListGiftStatus { get; set; }
    }
}