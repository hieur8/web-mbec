using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GiftList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputGiftModel> ListGifts { get; set; }
        public IList<ComboItem> ListGiftStatus { get; set; }
        public string GiftStatus { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public string DeleteFlag { get; set; }
    }
}