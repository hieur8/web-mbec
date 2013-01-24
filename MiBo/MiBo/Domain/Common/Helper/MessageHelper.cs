using Resources;
using MiBo.Domain.Common.Enum;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Helper
{
    public static class MessageHelper
    {
        /// <summary>
        /// Get message string from resource.
        /// </summary>
        /// <param name="messageId">Message id</param>
        /// <param name="param">Array message param</param>
        /// <returns>Message string</returns>
        public static string GetMessageString(string messageId, params object[] param)
        {
            var rm = Messages.ResourceManager;
            return string.Format(rm.GetString(messageId), param);
        }

        /// <summary>
        /// Get message from resource.
        /// </summary>
        /// <param name="messageId">Message id</param>
        /// <param name="messageType">Message type</param>
        /// <param name="param">Array message param</param>
        /// <returns>Message</returns>
        public static Message GetMessage(string messageId, MessageType messageType, params object[] param)
        {
            var message = new Message();
            message.MessageId = messageId;
            message.MessageType = messageType;
            message.MessageDetail = GetMessageString(messageId, param);

            return message;
        }

        /// <summary>
        /// Get message fatal from resource.
        /// </summary>
        /// <param name="messageId">Message id</param>
        /// <param name="messageTitle">Message title</param>
        /// <param name="messageHead">Message head</param>
        /// <param name="param">Array message param</param>
        /// <returns>Message</returns>
        public static Message GetMessageFatal(string messageId, string messageTitle, string messageHead, params object[] param)
        {
            var message = GetMessage(messageId, MessageType.FATAL, param);
            message.MessageTitle = messageTitle;
            message.MessageHead = messageHead;

            return message;
        }

        /// <summary>
        /// Get message error from resource.
        /// </summary>
        /// <param name="messageId">Message id</param>
        /// <param name="param">Array message param</param>
        /// <returns>Message</returns>
        public static Message GetMessageError(string messageId, params object[] param)
        {
            return GetMessage(messageId, MessageType.ERROR, param);
        }

        /// <summary>
        /// Get message warn from resource.
        /// </summary>
        /// <param name="messageId">Message id</param>
        /// <param name="param">Array message param</param>
        /// <returns>Message</returns>
        public static Message GetMessageWarn(string messageId, params object[] param)
        {
            return GetMessage(messageId, MessageType.WARN, param);
        }

        /// <summary>
        /// Get message info from resource.
        /// </summary>
        /// <param name="messageId">Message id</param>
        /// <param name="param">Array message param</param>
        /// <returns>Message</returns>
        public static Message GetMessageInfo(string messageId, params object[] param)
        {
            return GetMessage(messageId, MessageType.INFO, param);
        }
    }
}