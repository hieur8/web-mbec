using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.ItemDetails
{
    public class InitDataModel
    {
        // Request
        public string ItemCd { get; set; }
        public string ItemName { get; set; }

        // Response
        public ItemModel Item { get; set; }
    }
}