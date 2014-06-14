using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thr_SkypeBot
{
    public class BotInfo
    {
        public BotInfo()
        {
            CommandDelimiter = Utils.XOR("᧫᧘ᧉ᧧ᧁ᧎ᦲᦲ", 627513743);
            BotName = Utils.XOR("땯땪땟딍땲땐땮땤땲땨땥땎땪땆땩딎땨딍땟딍땲땐땪땤땲땨땦땊땪땆땩딎", 345617724);
            BotVersion = Utils.XOR("㜳㜏㜬㝔㜫㜠㜒㜜㜫㜱㜷㜳㜨㜏㜰㝕㜳㜭㜎㝔㜫㜤㝘㝘", 1555248997);
            BotCreator = Utils.XOR("鋺鋷鋏鋃鋗鋷鋱銨鋎鋍鋃鋖鋽鋏鋲銫", 212112025);
            foreground = ConsoleColor.White;
            background = ConsoleColor.Blue;
            Logging = false;
            FileSize = Convert.ToInt32(Utils.XOR("壿壽壜壀壦壾壄壤壱壼壾壄壻墚壭墙売壃壜壀壦壿壺壤壱壼壾壺壻墚壭墙壱墘壜壀壦壾壄壤壱壼壾壉壻墚壭墙", 1156208808));
        }
        /// <summary>
        /// The name of your bot.
        /// </summary>
        public string BotName { get; set; }
        /// <summary>
        /// The version of your bot.
        /// </summary>
        public string BotVersion { get; set; }
        /// <summary>
        /// The creator of your bot (you).
        /// </summary>
        public string BotCreator { get; set; }
        /// <summary>
        /// The command delimiter, for example: !test - the command delimiter would be "!"
        /// </summary>
        public string CommandDelimiter { get; set; }
        /// <summary>
        /// The foreground color of the console.
        /// </summary>
        public ConsoleColor foreground { get; set; }
        /// <summary>
        /// The background color of the console.
        /// </summary>
        public ConsoleColor background { get; set; }
        /// <summary>
        /// Logging.
        /// </summary>
        public bool Logging { get; set; }
        /// <summary>
        /// Filesize to compress logs (in MegaBytes).
        /// </summary>
        public long FileSize { get; set; }
    }
}
