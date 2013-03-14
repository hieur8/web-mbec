using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.AcceptList
{
    public class FilterResponseModel : MessageResponse
    {
        public IList<OutputAcceptModel> ListAccepts { get; set; }
    }
}