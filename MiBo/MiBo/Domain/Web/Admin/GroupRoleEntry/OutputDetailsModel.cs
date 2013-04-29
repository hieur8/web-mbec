using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GroupRoleEntry
{
    public class OutputDetailsModel
    {
        public string GroupCd { get; set; }
        public string GroupName { get; set; }
        public string RoleCd { get; set; }
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListRole { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}