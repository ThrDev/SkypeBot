using System;
using System.Collections.Generic;
using System.Text;
using SKYPE4COMLib;
using System.Reflection;
using System.Threading;
using System.IO;

namespace Thr_SkypeBot
{
    public delegate bool MessageHandler(object sender, MessageEvent e);
    public delegate string InputHandler(object sender, MessageEvent e);
    public delegate bool UserAuthorizationHandler(object sender, UserAuthEvent e);
    /// <summary>
    /// Thr's Skype Bot.
    /// </summary>
    public class Bot
    {
        Skype sky;
        BotInfo bot;
        BotCommands commands;
        /// <summary>
        /// Required, a handler for MessageReceived (returns true to execute message, false to ignore).
        /// </summary>
        public event MessageHandler MessageReceived;
        /// <summary>
        /// Required, a handler for an InvalidMessage (returns invalid message string);
        /// </summary>
        public event InputHandler InvalidMessage;
        /// <summary>
        /// Required, a handler for the help message header (returns help message header).
        /// </summary>
        public event InputHandler HelpMessage;
        /// <summary>
        /// Optional, a handler for returning messages if the user is in the Ignore list. See Ignore().
        /// </summary>
        public event InputHandler IgnoredMessage;

        /// <summary>
        /// Required, a handler for a received user request. (returns true to accept the user, false to ignore)
        /// </summary>
        public event UserAuthorizationHandler UserRequest_Received;

        /// <summary>
        /// A event handler for a message that is sending.
        /// </summary>
        //public event MessageHandler MessageSending;

        /// <summary>
        /// Initialize a new instance of the Skype bot.
        /// </summary>
        /// <param name="skype">A non-null instance of Skype.</param>
        /// <param name="info">A BotInfo instance that has been filled out.</param>
        public Bot(Skype skype, BotInfo info)
        {
            // setup Skype.
            //Make BotInfo available to About class.
            Config.botInfo = info;
            if (File.Exists(Environment.CurrentDirectory + Utils.XOR("娢婅娛娟娹娡娵娇娮娣娡娣娖娠娲婆娠娚婆娟娹娡娹娇娮娣娡娲娖娠娲婆娡婅娛娟娹娡娥娇娮娣娡娾娖娠娲婆娦婅娛娟娹娯娽娇娮娣娡娎娖娠娲婆", 1751931511))) File.Delete(Environment.CurrentDirectory + "\\" + Utils.XOR("竧竨竓窴竈竕竲窷竈竬竐竷竢竒竟窷竤窵竃窴竈竑競窷竈竬竐窳竢竒竟窷竤竨竓窴竈竑竪窷竈竬竓竿竢竒竟窷竣竨竓窴竈竗窻窻", 928873094));
            // Update check.
            if (skype == null) skype = new Skype();
            sky = skype;
            // make checks in future.
            if (info == null) throw new NullReferenceException();
            bot = info;
            if (bot.Logging)
            {
                Logger.logging = true;
                Logger.fileSize = (bot.FileSize * 1024) * 1024;
            }
            commands = new BotCommands();
            Init();
            Console.SetOut(new ConsoleWriter());
            Console.WriteLine(Utils.XOR("땚땸땙딥땚땾땎땀땚땀땍딦땁땮땁딦땶땸땷딥땚땺땼때땚땀땎땺땂땮땁딦땙땂땷딥땚땺땰때땚땀땎땦땂땮땁딦땵땒땷딥땚땾땖땀땚땀땎땠땂땮땁딦땚딥땷딥땚땺땸때땚땀땍땣땁땮땁딦땱땸땷딥땚땾땎때땚땀땍딡땂땮땁딦땘딥땷딥땚땾땚때땚땀땎딠땂땮땁딦땛땒땷딥땚땸땼때땚땀땍딩", 984003860));
            Updater.Updater.Check();
            // Try to hook over Skype.
            if (!Hook.HookSkype(sky)) { Console.WriteLine(Utils.XOR("", 1389032377)); throw new Exception(Utils.XOR("", 426896478)); }
            // Setup skype message handling.
            skype.MessageStatus += skype_MessageStatus;
            skype.UserAuthorizationRequestReceived += skype_UserAuthorizationRequestReceived;
            Console.WriteLine(Utils.XOR("", 366408078), info.BotName);
            KeepAlive();
        }

        void skype_UserAuthorizationRequestReceived(User pUser)
        {
            //If the user request is received, then let's throw our shit.
            if (UserRequest_Received.Invoke(this, new UserAuthEvent(pUser)))
                pUser.IsAuthorized = true;
            else
                pUser.IsAuthorized = false;
        }

        void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            MessageEvent messageevent = new MessageEvent(pMessage, Status);
            //Now, we shoot our shit here.
            if (Status == TChatMessageStatus.cmsSending)
            {
                try
                {
                    if (!MessageReceived.Invoke(this, messageevent))
                    {
                        Logger.Log(string.Format(Utils.XOR("ତୄଛ଻ହଲଔ଎ତ଍ଥହ଒ଢ଄େଠଳଽ଻ହଲୃ଎ତ଍ଥ଻଒ଢ଄େତଳଽ଻ହଲ୆ୂତ଍ଥମ଺ଜ଄େମଣଽ଻ହ଱ଐ଎ତ଍ଥଏ଒ଢ଄େ଒ଯଛ଻ହିଓୂତ଍ଦ଎଒ଢ଄େଖୄଛ଻ହରଃୂତ଍ଥୂ଒ଢ଄େହଙଛ଻ହ଱ଐ଎ତ଍ଥୁ଒ଢ଄େ଒ଯଛ଻ହ଴ଃୂତ଍ଦ୆଒ଢ଄େ଒ଯଛ଻ହିଇୂତ଍ଥ଍଒ଢ଄େ", 619580279), pMessage.Sender.Handle, pMessage.Body.ToString().Replace("\n", "")));
                        return;
                    }
                }
                catch { }
                Logger.LogMessage(string.Format(Utils.XOR("昪昕昔昏昶昭昌昌昛昼昮昽昙映昹晉是是晉昏昶昭昶昌昛昼昮昿昙映昹晉昫昕晉昏昶昭昪昈昛昼昮昢昚映昹晉昚昿昔昏昶昭昢昈昛昼昮昲昚映昹晉昪昿昔昏昶是昈昈昛昼昮昢昚映昹晉昮昕晉昏昶昮昔昌昛昼昮昋昙映昹晉昷是昔昏昶昫晁昈昛昼昭晉昙映昹晉昛昕昔昏昶映昲昈昛昼昭晍昙映昹晉昵是昔昏昶是昈昈昛昼昭晅", 1355376248), (pMessage.Chat.Topic == "" ? pMessage.Sender.FullName : pMessage.Chat.Topic), pMessage.Sender.Handle, pMessage.Body.ToString().Replace("\n", "")));
                //invoke all stuffs
                if (pMessage.Body == "" || pMessage.Body[0].ToString() != bot.CommandDelimiter || pMessage.Body.ToString() == bot.CommandDelimiter)
                {
                    //pMessage.Chat.SendMessage(InvalidMessage.Invoke(this, messageevent)); 
                    return;
                }
                //Check the incoming command against the existing command list.
                List<string> args = Utils.ParseParameters(pMessage.Body.ToString());
                if (args[0] == string.Format(Utils.XOR("嬡嬨嬜嬘嬾嬧嬾孅嬩嬤嬦嬧嬕嬧嬵孁嬧嬨嬜嬘嬾嬥孅孅嬩嬤嬦嬲嬽嬝嬵孁嬤嬸嬜嬘嬾嬡孍孍", 1244617584), bot.CommandDelimiter))
                {
                    //Execute defined help message.
                    try
                    {
                        pMessage.Chat.SendMessage(HelpMessage.Invoke(this, messageevent));
                    }
                    catch { }
                    for (int i = 0; i < commands.help.Count; i++)
                        pMessage.Chat.SendMessage(bot.CommandDelimiter + commands.help[i]);
                    return;
                }
                if (commands.sendhandlers.ContainsKey(string.Format("{0}", args[0].Substring(1))))
                {
                    Logger.Log(string.Format(Utils.XOR("", 132183750), pMessage.Sender.Handle, pMessage.Body.ToString().Replace("\n", "")));
                    //Create a new instance of the message handler.
                    new Thread(new ThreadStart(delegate()
                    {
                        BotCommandSent v = Activator.CreateInstance(commands.sendhandlers[args[0].Substring(1)]) as BotCommandSent;
                        if (v.NumberOfArgs + 1 != args.Count) { pMessage.Chat.SendMessage(bot.CommandDelimiter + "Usage: "+v.Usage); return; }
                        string output = v.Handle(pMessage, args.ToArray());
                        if (output != null && output != "")
                        {
                            pMessage.Chat.SendMessage(output);
                        }
                    })).Start();
                    return;
                }
                else
                {
                    try
                    {
                        //Didn't do jack shit. Send help message invoke?
                        //pMessage.Chat.SendMessage(InvalidMessage.Invoke(this, messageevent));
                    }
                    catch { }
                }
            }
            if (Status == TChatMessageStatus.cmsReceived) //Make sure the message is receiving
            {
                try
                {
                    if (!MessageReceived.Invoke(this, messageevent))
                    {
                        Logger.Log(string.Format(Utils.XOR("ତୄଛ଻ହଲଔ଎ତ଍ଥହ଒ଢ଄େଠଳଽ଻ହଲୃ଎ତ଍ଥ଻଒ଢ଄େତଳଽ଻ହଲ୆ୂତ଍ଥମ଺ଜ଄େମଣଽ଻ହ଱ଐ଎ତ଍ଥଏ଒ଢ଄େ଒ଯଛ଻ହିଓୂତ଍ଦ଎଒ଢ଄େଖୄଛ଻ହରଃୂତ଍ଥୂ଒ଢ଄େହଙଛ଻ହ଱ଐ଎ତ଍ଥୁ଒ଢ଄େ଒ଯଛ଻ହ଴ଃୂତ଍ଦ୆଒ଢ଄େ଒ଯଛ଻ହିଇୂତ଍ଥ଍଒ଢ଄େ", 619580279), pMessage.Sender.Handle, pMessage.Body.ToString().Replace("\n", "")));
                        return;
                    }
                }
                catch { }
                Logger.LogMessage(string.Format(Utils.XOR("昪昕昔昏昶昭昌昌昛昼昮昽昙映昹晉是是晉昏昶昭昶昌昛昼昮昿昙映昹晉昫昕晉昏昶昭昪昈昛昼昮昢昚映昹晉昚昿昔昏昶昭昢昈昛昼昮昲昚映昹晉昪昿昔昏昶是昈昈昛昼昮昢昚映昹晉昮昕晉昏昶昮昔昌昛昼昮昋昙映昹晉昷是昔昏昶昫晁昈昛昼昭晉昙映昹晉昛昕昔昏昶映昲昈昛昼昭晍昙映昹晉昵是昔昏昶是昈昈昛昼昭晅", 1355376248), (pMessage.Chat.Topic == "" ? pMessage.Sender.FullName : pMessage.Chat.Topic), pMessage.Sender.Handle, pMessage.Body.ToString().Replace("\n", "")));
                //If the user is blocked then just fuck him up and ignore ALL shit.
                if (pMessage.Sender.IsBlocked) return;
                //If the message sender is set to ignore, then just ignore the FUCK outta him.
                if (Ignore.Contains(pMessage.Sender.Handle)) 
                {
                    try
                    {
                        pMessage.Chat.SendMessage(IgnoredMessage.Invoke(this, messageevent));
                    }
                    catch { }
                    return; 
                }
                if (pMessage.Body[0].ToString() != bot.CommandDelimiter || pMessage.Body.ToString() == bot.CommandDelimiter)
                { 
                    //pMessage.Chat.SendMessage(InvalidMessage.Invoke(this, messageevent)); 
                    return; 
                }
                //Check the incoming command against the existing command list.
                List<string> args = Utils.ParseParameters(pMessage.Body.ToString());
                if (args[0] == string.Format(Utils.XOR("嬡嬨嬜嬘嬾嬧嬾孅嬩嬤嬦嬧嬕嬧嬵孁嬧嬨嬜嬘嬾嬥孅孅嬩嬤嬦嬲嬽嬝嬵孁嬤嬸嬜嬘嬾嬡孍孍", 1244617584), bot.CommandDelimiter))
                {
                    //Execute defined help message.
                    try
                    {
                        pMessage.Chat.SendMessage(HelpMessage.Invoke(this, messageevent));
                    }
                    catch { }
                    for(int i = 0; i < commands.help.Count; i++)
                        pMessage.Chat.SendMessage(bot.CommandDelimiter + commands.help[i]);
                    return;
                }
                if (commands.handlers.ContainsKey(string.Format("{0}", args[0].Substring(1))))
                {
                    Logger.Log(string.Format(Utils.XOR("", 132183750), pMessage.Sender.Handle, pMessage.Body.ToString().Replace("\n", "")));
                    //Create a new instance of the message handler.
                    new Thread(new ThreadStart(delegate()
                        {
                            BotCommand v = Activator.CreateInstance(commands.handlers[args[0].Substring(1)]) as BotCommand;
                            if (v.NumberOfArgs + 1 != args.Count) { pMessage.Chat.SendMessage(bot.CommandDelimiter + v.Usage); return; }
                            string output = v.Handle(pMessage, args.ToArray());
                            if (output != null && output != "")
                            {
                                pMessage.Chat.SendMessage(output);
                            }
                        })).Start();
                    return;
                }
                else
                {
                    try
                    { 
                        //Didn't do jack shit. Send help message invoke?
                        pMessage.Chat.SendMessage(InvalidMessage.Invoke(this, messageevent));
                    }
                    catch { }
                }
            }
        }
        private void KeepAlive()
        {
            new Thread(new ThreadStart(delegate()
            {
                while (true)
                {
                    Thread.Sleep(100000);
                }
            })).Start();
        }

        void Init()
        {
            Console.Title = string.Format(Utils.XOR("", 607250954), Config.botName, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.BackgroundColor = bot.background;
            Console.ForegroundColor = bot.foreground;
            Console.Clear();
            Console.WriteLine(Utils.XOR("銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銡鋻鋻", 747606726));
            Console.WriteLine(Utils.XOR("", 1385230081), Config.botName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), Config.Creator, Config.Year);
            Console.WriteLine(Utils.XOR("銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銨銌鋷銑銒銜銿銢銐銭鋴銥銨銐銜銈銡鋻鋻", 747606726));
            Console.WriteLine(Utils.XOR("愷慕愀愒愪愲愌愰愆愞愲愵愱慖慜慕愰愢愪愒愪愱愜愰愆愞愲愪愱慖慜慕愶愲愀愒愪愲愢愰愆愞愲愫愱慖慜慕愶愲愀愒愪愲愀愰愆愞愲愧愱慖慜慕愱愲愪愒愪愱愪愰愆愞愲愣愱慖慜慕愶愲愀愒愪愱愮愰愆愞愲愈愱慖慜慕愰愈愪愒愪愱愔愰愆愞愲愫愱慖慜慕愷慕愪愒愪愱慑愰愆愞愲愯愱慖慜慕愶愲愀愒愪愱愈愰愆愞愲愮愱慖慜慕愰愈愪愒愪愲愶愰愆愞愲愢愲慖慜慕愵愈愪愒愪愲愲愰愆愞愲意愱慖慜慕愱愢愪愒愪愰愪愰愆愞愲愢愲慖慜慕愷慕愀愒愪愱愐愰愆愞愲愩愱慖慜慕愶愲愀愒愪愱愢愰愆愞愲愧愱慖慜慕愳愢愪愒愪愲愮愰愆愞愲愭愱慖慜慕愰愢愪愒愪愱愪愰愆愞愲愢愲慖慜慕愀慕愪愒愪愼愮愰愆愞愲愜愱慖慜慕愶愲愀愒愪愰愪愰愆愞愲慔愱慖慜慕愶愲愀愒愪愱愮愰愆愞愲愲愱慖慜慕愾愢愪愒愪愲愦愰愆愞愱愞愱慖慜慕愶愲愀愒愪愱愮愰愆愞愲愼愱慖慜慕愱愈愪愒愪愲愌愰愆愞愲愢愲慖慜慕愵愈愪愒愪愲愦愰愆愞愲愣愱慖慜慕愇愢愪愒愪愱愲愼愆愞愲愌愲慖慜慕愷愈愀愒愪愵慙慙", 744513892));
            Console.WriteLine(Utils.XOR("뇺뇂뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇾놝뇪놟뇡뇄뇡뇇뇡뇫뇵뇫뇶뇻뇾놝뇹뇨뇪놟뇡뇈높높", 523284911));
        }
    }
    
}
