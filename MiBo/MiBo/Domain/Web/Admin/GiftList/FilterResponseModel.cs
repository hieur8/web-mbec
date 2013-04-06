using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GiftList
{
    public class FilterResponseModel : MessageResponse
    {
        public IList<OutputGiftModel> ListGifts { get; set; }
    }
}