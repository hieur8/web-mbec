using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.CategoryEntry
{
    public class InitDataModel
    {
        public string CategoryDiv { get; set; }
        public bool? DeleteFlag { get; set; }
        public IList<MCode> ListCategoryDiv { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}