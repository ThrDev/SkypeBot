using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Thr_SkypeBot
{
    class BotCommands
    {
        public Dictionary<string, Type> handlers = new Dictionary<string, Type>();
        public Dictionary<string, Type> sendhandlers = new Dictionary<string, Type>();
        public List<string> help = new List<string>();
        public BotCommands()
        {
            foreach (Type f in Assembly.GetEntryAssembly().GetTypes())
            {
                if (typeof(BotCommand).IsAssignableFrom(f) && f != typeof(BotCommand))
                {
                    // Create instance of type.
                    BotCommand g = Activator.CreateInstance(f) as BotCommand;
                    help.Add(g.HelpMenu);
                    handlers.Add(g.Name, f);
                }
            }
            foreach (Type f in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(BotCommand).IsAssignableFrom(f) && f != typeof(BotCommand))
                {
                    // Create instance of type.
                    BotCommand g = Activator.CreateInstance(f) as BotCommand;
                    help.Add(g.HelpMenu);
                    handlers.Add(g.Name, f);
                }
            }
            foreach (Type f in Assembly.GetEntryAssembly().GetTypes())
            {
                if (typeof(BotCommandSent).IsAssignableFrom(f) && f != typeof(BotCommandSent))
                {
                    // Create instance of type.
                    BotCommandSent g = Activator.CreateInstance(f) as BotCommandSent;
                    help.Add(g.HelpMenu);
                    sendhandlers.Add(g.Name, f);
                }
            }
            foreach (Type f in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(BotCommandSent).IsAssignableFrom(f) && f != typeof(BotCommandSent))
                {
                    // Create instance of type.
                    BotCommandSent g = Activator.CreateInstance(f) as BotCommandSent;
                    help.Add(g.HelpMenu);
                    sendhandlers.Add(g.Name, f);
                }
            }
        }
        public List<string> GetHelp()
        {
            return help;
        }
    }
}