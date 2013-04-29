using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GroupList
{
    public class OutputGroupModel
    {
        public string GroupCd { get; set; }
        public string GroupName { get; set; }
        public string SortKey { get; set; }
        public string DeleteFlag { get; set; }
        public string UpdateDate { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}