using System;
using System.Collections.Generic;

namespace Unwind.Core.Models
{
    public class Conversation
    {
        public Conversation()
        {
            this.ConversationItems = new List<ConversationItem>();
        }

        public List<ConversationItem> ConversationItems { get; set; }
    }
}
