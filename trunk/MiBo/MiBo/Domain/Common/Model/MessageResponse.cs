using System;
using System.Collections.Generic;

namespace MiBo.Domain.Common.Model
{
    [Serializable]
    public class MessageResponse
    {
        public IList<Message> Messages { get; set; }
        public bool HasMessage { get { return Messages.Count > 0; } }

        public MessageResponse()
        {
            Messages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }

        public Message MessageSingle
        {
            get { return Messages.Count > 0 ? Messages[0] : null; }
        }
    }
}