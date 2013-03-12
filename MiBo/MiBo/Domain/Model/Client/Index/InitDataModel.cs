using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.Index
{
    public class InitDataModel
    {
        public IList<Banner> ListBanners { get; set; }
        public IList<ItemModel> ListNewItems { get; set; }
        public IList<ItemModel> ListHotItems { get; set; }
        public IList<ItemModel> ListOfferItems { get; set; }

        public string StrChatYahoo { get; set; }
        public string StrChatSkype { get; set; }
        public string StrHotline { get; set; }
    }
}