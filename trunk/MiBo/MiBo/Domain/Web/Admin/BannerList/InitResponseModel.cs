using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.BannerList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputBannerModel> ListBanners { get; set; }
    }
}