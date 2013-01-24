using System;
using MiBo.Domain.Common.Enum;

namespace MiBo.Domain.Common.Model
{
    [Serializable]
    public class Message
    {
        public string MessageId { get; set; }
        public string MessageDetail { get; set; }
        public string MessageTitle { get; set; }
        public string MessageHead { get; set; }
        public MessageType MessageType { get; set; }
    }
}