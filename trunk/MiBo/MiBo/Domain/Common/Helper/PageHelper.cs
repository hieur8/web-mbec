using System;
using System.Linq;
using System.Reflection;
using System.Web;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Enum;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Validate;
using MiBo.Domain.Common.Utils;

namespace MiBo.Domain.Common.Helper
{
    public static class PageHelper
    {
        public static void Validate(object item)
        {
            // Get properties
            var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(AbstractValidation), true)
                    .OrderBy(attr => DataHelper.GetProperty(attr, "Index")).ToList();

                foreach (var attribute in attributes)
                {
                    var valAtt = attribute as AbstractValidation;

                    if (valAtt == null) continue;

                    valAtt.IsValid(property.GetValue(item, null));
                }
            }
        }

        public static void SetMessage(Message msg)
        {
            // Check null
            if (msg == null) return;

            // Add message to session
            switch (msg.MessageType)
            {
                case MessageType.FATAL:
                    HttpContext.Current.Session["err-title"] = msg.MessageTitle;
                    HttpContext.Current.Session["err-head"] = msg.MessageHead;
                    HttpContext.Current.Session["err-content"] = msg.MessageDetail;
                    HttpContext.Current.Response.Redirect(Pages.ERROR_PAGE);
                    break;
                case MessageType.ERROR:
                    HttpContext.Current.Session["error"] = msg.MessageDetail;
                    break;
                case MessageType.WARN:
                    HttpContext.Current.Session["warn"] = msg.MessageDetail;
                    break;
                case MessageType.INFO:
                    HttpContext.Current.Session["info"] = msg.MessageDetail;
                    break;
                default:
                    break;
            }
        }

        public static void SetMessage(Exception ex)
        {
            // Add message to session
            HttpContext.Current.Session["err-title"] = "Error";
            HttpContext.Current.Session["err-head"] = "Exception";
            HttpContext.Current.Session["err-content"] = ex.Message;
            HttpContext.Current.Response.Redirect(Pages.ERROR_PAGE);
        }

        public static bool HasAuthenticated
        {
            get
            {
                var userCom = new UserCom();
                var userCd = PageHelper.UserCd;
                if (DataCheckHelper.IsNull(userCd)) return false;
                return userCom.IsExist(userCd, false);
            }
        }

        public static Guid UserCd
        {
            get { 
                var strUserCd = Convert.ToString(HttpContext.Current.Session["userCd"]);
                var userCd = DataHelper.ConvertInputGuid(strUserCd);
                return userCd;
            } 
        }

        public static string UserName
        {
            get
            {
                var strUserName = Convert.ToString(HttpContext.Current.Session["userName"]);
                var userName = DataHelper.ConvertInputString(strUserName);
                return userName;
            }
        }

        public static string LocaleCd
        {
            get
            {
                var strLocaleCd = Convert.ToString(HttpContext.Current.Session["localeCd"]);
                var localeCd = DataHelper.ConvertInputString(strLocaleCd);
                return localeCd;
            }
        }
    }
}