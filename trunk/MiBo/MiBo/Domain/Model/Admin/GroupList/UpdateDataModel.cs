using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GroupList
{
    public class UpdateDataModel
    {
        public IList<Group> ListGroups { get; set; }
    }
}