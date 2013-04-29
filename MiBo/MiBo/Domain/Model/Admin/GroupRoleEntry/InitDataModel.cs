using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GroupRoleEntry
{
    public class InitDataModel
    {
        public string GroupCd { get; set; }
        public Group Group { get; set; }
        public string RoleCd { get; set; }
        public bool? DeleteFlag { get; set; }
        public IList<MCode> ListRole { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}