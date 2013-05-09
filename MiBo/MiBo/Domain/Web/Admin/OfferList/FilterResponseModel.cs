using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferList
{
    public class FilterResponseModel : MessageResponse
    {
        public IList<OutputOfferModel> ListOffers { get; set; }
    }
}