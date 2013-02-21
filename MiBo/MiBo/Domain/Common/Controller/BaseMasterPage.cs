using System;
using System.Web.UI;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Logic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Controller
{
    public class BaseMasterPage : MasterPage
    {
        protected bool HasError { get; private set; }

        protected void Refresh()
        {
            Response.Redirect(Request.Path);
        }

        protected string GetUrlWithReturnUrl(string url)
        {
            return url + "?returnUrl=" + Request.Url.PathAndQuery;
        }

        protected T Invoke<T>(IOperateLogic<T> logic, object obj) where T : MessageResponse
        {
            // Local variable declaration
            T responseModel = null;
            try
            {
                // Validate
                PageHelper.Validate(obj);

                // Invoke processing
                responseModel = (T)logic.Invoke(obj);

                // Set message
                if (responseModel.HasMessage)
                    PageHelper.SetMessage(responseModel.MessageSingle);

                // Set value
                HasError = false;
            }
            catch (SysRuntimeException ex)
            {
                // Set message
                PageHelper.SetMessage(ex.Message);
                HasError = true;
                return null;
            }
            catch (Exception ex)
            {
                // Set message
                PageHelper.SetMessage(ex);
                HasError = true;
                return null;
            }

            // Return value
            return responseModel;
        }
    }
}