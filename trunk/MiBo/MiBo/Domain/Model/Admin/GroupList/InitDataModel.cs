using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GroupList
{
    public class InitDataModel
    {
        public IList<Group> ListGroups { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}