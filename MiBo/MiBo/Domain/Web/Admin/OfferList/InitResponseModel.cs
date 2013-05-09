using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<ComboItem> ListOfferDiv { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public IList<OutputOfferModel> ListOffers { get; set; }
    }
}