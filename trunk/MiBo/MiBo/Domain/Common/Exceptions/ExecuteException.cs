using System;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Common.Exceptions
{
    [Serializable]
    public class ExecuteException : Exception
    {
        public ExecuteException(string messageId, params object[] param)
        {
            var message = MessageHelper.GetMessageError(messageId, param);
            throw new SysRuntimeException(message);
        }
    }
}