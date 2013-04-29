using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.GroupEntry
{
    public class InitDataModel
    {
        public bool? DeleteFlag { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}