using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ItemEntry
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputDetailsModel> Details { get; set; }
    }
}