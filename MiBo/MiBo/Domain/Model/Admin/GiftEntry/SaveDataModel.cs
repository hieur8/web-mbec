using System;

namespace MiBo.Domain.Model.Admin.GiftEntry
{
    public class SaveDataModel
    {
        public string GiftCd { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
    }
}