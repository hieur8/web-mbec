using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferItemList
{
    public class InitResponseModel : MessageResponse
    {
        public string OfferCd { get; set; }
        public IList<OutputOfferItemModel> ListOfferItems { get; set; }
    }
}