using System;
using System.Collections.Generic;
using System.Text;
using Thr_SkypeBot;
using SKYPE4COMLib;

namespace TestSkypeBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Skype skype = new Skype();

            // Initialize Botinfo.
            BotInfo botinfo = new BotInfo();
            botinfo.BotName = "TestBot";
            botinfo.BotVersion = "v1.0";
            botinfo.BotCreator = "Thr";
            botinfo.CommandDelimiter = "!";
            botinfo.foreground = ConsoleColor.White;
            botinfo.background = ConsoleColor.Blue;
            botinfo.Logging = true;
            // Set compression filesize.
            botinfo.FileSize = 100;
            // Intialize Bot.
            Bot bot = new Bot(skype, botinfo);

            bot.HelpMessage += bot_HelpMessage; // Custom help message header.
            bot.IgnoredMessage += bot_IgnoredMessage; // Custom ignored user message.
            bot.InvalidMessage += bot_InvalidMessage; // Custom Invalid message text.
            bot.MessageReceived += bot_MessageReceived; // Override the message_received and either allow it or not based off of your own defined events.
            bot.UserRequest_Received += bot_UserRequest_Received; // Override the user request and allow it or deny it.
        }

        static bool bot_UserRequest_Received(object sender, UserAuthEvent e)
        {
            return true;
        }

        static bool bot_MessageReceived(object sender, MessageEvent e)
        {
            return true;
        }

        static string bot_InvalidMessage(object sender, MessageEvent e)
        {
            return "Unknown Command!";
        }

        static string bot_IgnoredMessage(object sender, MessageEvent e)
        {
            return "Lol you're ignored - " + e.Message.Sender.FullName;
        }

        static string bot_HelpMessage(object sender, MessageEvent e)
        {
            return "--- Help ---";
        }
    }
}
