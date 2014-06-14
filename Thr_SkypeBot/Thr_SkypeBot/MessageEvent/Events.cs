using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKYPE4COMLib;

namespace Thr_SkypeBot
{
    public class MessageEvent : EventArgs
    {
        public MessageEvent(ChatMessage f, TChatMessageStatus g)
        {
            Status = g;
            Message = f;
        }
        public TChatMessageStatus Status { get; set; }
        public ChatMessage Message { get; set; }
    }
    public class UserAuthEvent : EventArgs
    {
        public UserAuthEvent(User pUser)
        {
            userName = pUser;
        }
        public User userName { get; set; }
    }
}
