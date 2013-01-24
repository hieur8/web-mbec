using System.Web.UI;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Logic;

namespace MiBo.Domain.Common.Controller
{
    public class BaseMasterPage : MasterPage
    {
        protected void Refresh()
        {
            Response.Redirect(Request.Path);
        }

        protected string GetUrlWithReturnUrl(string url)
        {
            return url + "?returnUrl=" + Request.Url.PathAndQuery;
        }

        protected T Invoke<T>(IOperateLogic<T> logic, object obj) where T : class
        {
            // Local variable declaration
            T responseModel = null;

            try
            {
                PageHelper.Validate(obj);

                // Invoke processing
                responseModel = (T) logic.Invoke(obj);
            }
            catch (SysRuntimeException ex)
            {
                // Set message
                PageHelper.SetMessage(ex.Message);
                return null;
            }

            // Return value
            return responseModel;
        }
    }
}