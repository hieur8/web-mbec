using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.GroupEntry;

namespace MiBo.Domain.Logic.Admin.GroupEntry
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