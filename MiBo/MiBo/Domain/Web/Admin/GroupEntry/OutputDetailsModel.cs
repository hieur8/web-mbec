using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GroupEntry
{
    public class OutputDetailsModel
    {
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}