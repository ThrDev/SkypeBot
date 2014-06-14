using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thr_SkypeBot;

namespace TestSkypeBot
{
    class TestCommand : BotCommand
    {
        public override string Handle(SKYPE4COMLib.ChatMessage message, string[] args)
        {
            return "Testing 123..."; //return sends a message to the chat. if you return "", it won't send a message.
        }

        public override string HelpMenu
        {
            get { return Name + " - Executes the test command."; }
        }

        public override string Name
        {
            get { return "testcommand"; }
        }

        public override int NumberOfArgs
        {
            get { return 1; }
        }

        public override string Usage
        {
            get { return Name + " <testarg>"; }
        }
    }
}
