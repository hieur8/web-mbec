﻿namespace MiBo.Domain.Web.Admin.ItemList
{
    public class FilterRequestModel
    {
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string CountryCd { get; set; }
        public string UnitCd { get; set; }
        public string ItemDiv { get; set; }
        public string DeleteFlag { get; set; }
    }
}