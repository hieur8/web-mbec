using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GroupRoleList
{
    public class InitResponseModel : MessageResponse
    {
        public string GroupCd { get; set; }
        public IList<OutputGroupRoleModel> ListGroupRoles { get; set; }
    }
}