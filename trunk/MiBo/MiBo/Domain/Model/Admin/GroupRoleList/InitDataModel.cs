using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GroupRoleList
{
    public class InitDataModel
    {
        public string GroupCd { get; set; }
        public IList<GroupRole> ListGroupRoles { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}