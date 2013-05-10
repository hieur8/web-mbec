using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.OfferItemList
{
    public class InitRequestModel
    {
        [ValidRequired(MessageParam = "Mã khuyến mãi")]
        public string OfferCd { get; set; }
    }
}