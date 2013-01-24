using System;

namespace MiBo.Domain.Common.Validate
{
    public abstract class AbstractValidation : Attribute
    {
        public string MessageId { get; set; }
        public string MessageParam { get; set; }
        public ushort Index { get; set; }
        public abstract void IsValid(object item);
    }
}