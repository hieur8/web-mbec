using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GroupList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputGroupModel> ListGroups { get; set; }
    }
}