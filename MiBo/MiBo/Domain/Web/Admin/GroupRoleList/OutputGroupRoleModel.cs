using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GroupRoleList
{
    public class OutputGroupRoleModel
    {
        public string GroupCd { get; set; }
        public string GroupName { get; set; }
        public string RoleCd { get; set; }
        public string RoleName { get; set; }
        public string DeleteFlag { get; set; }
        public string UpdateDate { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}