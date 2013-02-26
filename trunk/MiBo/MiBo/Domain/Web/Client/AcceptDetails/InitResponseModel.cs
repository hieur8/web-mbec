using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.AcceptDetails
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputDetailsModel> Details { get; set; }
    }
}