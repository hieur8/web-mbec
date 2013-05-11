using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.Checkout
{
    public class InitDataModel
    {
        public bool StatusFlag { get; set; }
        public Accept Accept { get; set; }
        public IList<CartItem> Cart { get; set; }
        public string AcceptSlipNo { get; set; }
    }
}



