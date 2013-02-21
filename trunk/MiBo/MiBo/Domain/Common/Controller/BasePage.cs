using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Logic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Controller
{
    public class BasePage : Page
    {
        protected bool HasError { get; private set; }

        protected override void InitializeCulture()
        {
            // Retrieve culture information from session
            var culture = Convert.ToString(PageHelper.LocaleCd);

            // Check whether a culture is stored in the session
            if (String.IsNullOrEmpty(culture)) culture = Logics.LOCALE_DEFAULT;

            // Set culture to culture of thread
            Culture = culture;

            // Set culture to current thread
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            // Call base class
            base.InitializeCulture();
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
                if(responseModel.HasMessage)
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

        protected void RedirectWithReturnUrl(string url)
        {
            if (!DataCheckHelper.IsNull(Request["returnUrl"]))
                url = Request["returnUrl"];

            Redirect(url);
        }

        protected void Refresh()
        {
            Redirect(Request.Path);
        }

        protected void Redirect(string url)
        {
            Response.Redirect(url);
        }

        protected static T InvokeStatic<T>(IOperateLogic<T> logic, object obj) where T : MessageResponse
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
            }
            catch (SysRuntimeException ex)
            {
                // Set message
                PageHelper.SetMessage(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                // Set message
                PageHelper.SetMessage(ex);
                return null;
            }

            // Return value
            return responseModel;
        }
    }
}