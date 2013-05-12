using MiBo.Domain.Common.Dao;
using System.Collections.Generic;

namespace MiBo.Domain.Model.Admin.BannerEntry
{
    public class InitDataModel
    {
        public string BannerCd { get; set; }
        public Banner Banner { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}