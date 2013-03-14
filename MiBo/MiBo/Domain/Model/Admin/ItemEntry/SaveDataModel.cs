﻿using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.ItemEntry
{
    public class SaveDataModel
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
        public string ImagePath { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string Notes { get; set; }
        public decimal? SortKey { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}