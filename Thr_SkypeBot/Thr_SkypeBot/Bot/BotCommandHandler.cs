using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thr_SkypeBot
{
    /// <summary>
    /// A bot command class.
    /// </summary>
    public abstract class BotCommand
    {
        /// <summary>
        /// The name of the command (without the delimiter, for example "about")
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// The number of arguments required by this command.
        /// </summary>
        public abstract int NumberOfArgs { get; }
        /// <summary>
        /// The event handler to handle the task when the particular message is received.
        /// </summary>
        /// <param name="message">The ChatMessage instance.</param>
        /// <param name="args">An array containing all arguments, args[0] is the name of the command.</param>
        /// <returns></returns>
        public abstract string Handle(SKYPE4COMLib.ChatMessage message, string[] args);
        /// <summary>
        /// The usage of the command, ex: getinfo < param1 > < param2 >
        /// </summary>
        public abstract string Usage { get; }
        /// <summary>
        /// The text to put in the help menu, for example: about - Shows the about dialog.
        /// </summary>
        public abstract string HelpMenu { get; }
    }
    /// <summary>
    /// A bot command class.
    /// </summary>
    public abstract class BotCommandSent
    {
        /// <summary>
        /// The name of the command (without the delimiter, for example "about")
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// The number of arguments required by this command.
        /// </summary>
        public abstract int NumberOfArgs { get; }
        /// <summary>
        /// The event handler to handle the task when the particular message is received.
        /// </summary>
        /// <param name="message">The ChatMessage instance.</param>
        /// <param name="args">An array containing all arguments, args[0] is the name of the command.</param>
        /// <returns></returns>
        public abstract string Handle(SKYPE4COMLib.ChatMessage message, string[] args);
        /// <summary>
        /// The usage of the command, ex: getinfo < param1 > < param2 >
        /// </summary>
        public abstract string Usage { get; }
        /// <summary>
        /// The text to put in the help menu, for example: about - Shows the about dialog.
        /// </summary>
        public abstract string HelpMenu { get; }
    }
}
