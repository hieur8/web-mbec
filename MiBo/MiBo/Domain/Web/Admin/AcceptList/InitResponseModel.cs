using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.AcceptList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputAcceptModel> ListAccepts { get; set; }
        public ListItem[] ListSlipStatus { get; set; }
        public string AcceptDateStart { get; set; }
        public string AcceptDateEnd { get; set; }
    }
}