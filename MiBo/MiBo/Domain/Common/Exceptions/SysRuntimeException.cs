using System;
using System.Runtime.Serialization;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Exceptions
{
    [Serializable]
    public class SysRuntimeException : Exception
    {
        private readonly Message _message;
        public new Message Message { get { return _message; } }

        public SysRuntimeException(Message message)
        {
            _message = message;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}