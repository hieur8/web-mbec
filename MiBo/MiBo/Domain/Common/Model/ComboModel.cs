using System.Collections.Generic;

namespace MiBo.Domain.Common.Model
{
    public class ComboModel
    {
        public IList<ComboItem> ListItems { get; set; }
        public string SeletedValue { get; set; }
    }
}