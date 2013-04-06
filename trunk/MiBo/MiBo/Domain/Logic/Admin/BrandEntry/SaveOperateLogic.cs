using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.BrandEntry;

namespace MiBo.Domain.Logic.Admin.BrandEntry
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