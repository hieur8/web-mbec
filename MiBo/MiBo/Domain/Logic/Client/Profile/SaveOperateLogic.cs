using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Profile;

namespace MiBo.Domain.Logic.Client.Profile
{
    public class SaveOperateLogic : IOperateLogic<SaveResponseModel>
    {
        public SaveResponseModel Invoke(object obj)
        {
            var logic = new SaveLogic();

            return logic.Invoke((SaveRequestModel)obj);
        }
    }
}