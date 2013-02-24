using System;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Common.Validate
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidRequired : AbstractValidation
    {
        public ValidRequired()
        {
            MessageId = "E_MSG_00004";
            Index = 0;
        }

        public override void IsValid(object obj)
        {
            // Local variable declaration
            string item = null;

            // Variable initialize
            item = Convert.ToString(obj);

            // Check
            if (DataCheckHelper.IsNull(item))
                throw new ExecuteException(MessageId, MessageParam);
        }
    }
}