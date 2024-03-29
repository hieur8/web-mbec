﻿using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Items
{
    public class InitRequestModel : PagerRequest
    {
        public string SearchText { get; set; }
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string PriceCd { get; set; }
        public string ShowCd { get; set; }
        public string OfferGroupCd { get; set; }
    }
}