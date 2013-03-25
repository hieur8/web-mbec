using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.CategoryList;

namespace MiBo.Domain.Logic.Admin.CategoryList
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