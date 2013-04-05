using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.CategoryEntry;

namespace MiBo.Domain.Logic.Admin.CategoryEntry
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