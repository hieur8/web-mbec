using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.UserList;

namespace MiBo.Domain.Logic.Admin.UserList
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