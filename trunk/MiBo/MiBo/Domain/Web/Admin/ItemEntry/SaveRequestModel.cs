using System.Collections.Generic;
using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.ItemEntry
{
    public class SaveRequestModel
    {
        public string Status { get; set; }

        [ValidRequired(MessageParam = "Mã sản phẩm")]
        public string ItemCd { get; set; }
        [ValidRequired(MessageParam = "Tên sản phẩm")]
        public string ItemName { get; set; }
        [ValidRequired(MessageParam = "Tên tìm kiếm")]
        public string ItemSearchName { get; set; }
        [ValidRequired(MessageParam = "Loại sản phẩm")]
        public string CategoryCd { get; set; }
        [ValidRequired(MessageParam = "Độ tuổi")]
        public string AgeCd { get; set; }
        [ValidRequired(MessageParam = "Giới tính")]
        public string GenderCd { get; set; }
        [ValidRequired(MessageParam = "Thương hiệu")]
        public string BrandCd { get; set; }
        [ValidRequired(MessageParam = "Xuất xứ")]
        public string CountryCd { get; set; }
        [ValidRequired(MessageParam = "Đơn vị")]
        public string UnitCd { get; set; }
        [ValidRequired(MessageParam = "Sản phẩm")]
        public string ItemDiv { get; set; }
        [ValidRequired(MessageParam = "Dữ liệu")]
        public string DeleteFlag { get; set; }
        [ValidRequired(MessageParam = "Giá bán")]
        public string SalesPrice { get; set; }
        [ValidRequired(MessageParam = "Giá mua")]
        public string BuyingPrice { get; set; }
        [ValidRequired(MessageParam = "Qui cách")]
        public string Packing { get; set; }

        public string ImagePath { get; set; }
        public string SummaryNotes { get; set; }
        public string Notes { get; set; }
        public string SortKey { get; set; }
    }
}