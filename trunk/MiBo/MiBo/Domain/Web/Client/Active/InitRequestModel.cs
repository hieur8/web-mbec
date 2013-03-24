using MiBo.Domain.Common.Validate;
namespace MiBo.Domain.Web.Client.Active
{
    public class InitRequestModel
    {
        [ValidRequired(MessageParam = "Mã kích hoạt")]
        public string UserCd { get; set; }
    }
}