using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.BannerList;

namespace MiBo.Domain.Logic.Admin.BannerList
{
    public class InitOperateLogic : IOperateLogic<InitResponseModel>
    {
        public InitResponseModel Invoke(object obj)
        {
            var logic = new InitLogic();

            return logic.Invoke((InitRequestModel)obj);
        }
    }
}