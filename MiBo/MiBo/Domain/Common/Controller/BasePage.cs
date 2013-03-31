using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Logic;
using MiBo.Domain.Common.Model;
using System.Collections.Generic;

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

        public string GetPagingInfo<T>(PagerResponse<T> list)
        {
            var pagingDisplay = string.Empty;

            var start = list.Offset + 1;
            var end = list.CurrentPageNumber * list.Limit;
            var total = list.AllRecordCount;
            if (end > total) end = (int)total;

            return string.Format("Sản phẩm {0} đến {1} của tất cả {2}", start, end, total);
        }

        public IList<PagerModel> GetPaging<T>(PagerResponse<T> list, int pagerSize, string forControl)
        {
            var listPager = new List<PagerModel>();
            var totalPageNumber = list.TotalPageNumber;
            var currentPageNumber = list.CurrentPageNumber;

            // Get start & end
            var start = currentPageNumber - pagerSize / 2;
            if (start > totalPageNumber - pagerSize && start <= totalPageNumber)
                start = (int)totalPageNumber - pagerSize;
            if (start < 0) start = 0;
            var end = start + pagerSize;
            if (end > totalPageNumber) end = (int)totalPageNumber;

            // Get first & pre
            if (list.IsExistPrePage)
            {
                var first = new PagerModel();
                first.Name = "Đầu";
                first.Page = 1;
                first.Limit = list.Limit;
                first.ForControl = forControl;
                listPager.Add(first);

                var pre = new PagerModel();
                pre.Name = "Trước";
                pre.Page = list.CurrentPageNumber - 1;
                pre.Limit = list.Limit;
                pre.ForControl = forControl;
                listPager.Add(pre);
            }

            // Get page
            for (int i = start; i < end; i++)
            {
                var page = new PagerModel();
                page.Name = (i + 1).ToString();
                page.Page = i + 1;
                page.Limit = list.Limit;
                page.ForControl = forControl;
                listPager.Add(page);
            }

            // Get next last
            if (list.IsExistNextPage)
            {
                var next = new PagerModel();
                next.Name = "Sau";
                next.Page = currentPageNumber + 1;
                next.Limit = list.Limit;
                next.ForControl = forControl;
                listPager.Add(next);

                var last = new PagerModel();
                last.Name = "Cuối";
                last.Page = (int)totalPageNumber;
                last.Limit = list.Limit;
                last.ForControl = forControl;
                listPager.Add(last);
            }

            return listPager;
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
            Redirect(Request.Url.AbsoluteUri);
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