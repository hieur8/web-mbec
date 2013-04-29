using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.UserEntry;

namespace MiBo.Domain.Logic.Admin.UserEntry
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