using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.BrandEntry
{
    public class InitDataModel
    {
        public string BrandCd { get; set; }

        public Brand Brand { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}