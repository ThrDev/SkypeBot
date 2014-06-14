using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thr_SkypeBot
{
    class TestCommand : BotCommand
    {
        public override string Name
        {
            get { return Utils.XOR("⾇⾌⾒⾱⾆⾌⾣⿺⾫⾢⾚⾽⾆⾦⾁⿸⾫⾜⾒⾱⾆⾀⾉⿺⾫⾢⾙⿵", 390672328); }
        }

        public override int NumberOfArgs
        {
            get { return Convert.ToInt32(Utils.XOR("吤呰吤吡后向命命",1240880192)); }
        }

        public override string Handle(SKYPE4COMLib.ChatMessage message, string[] args)
        {
            return string.Format(Utils.XOR("豫谂豼豿豼豞豖豺豦豶豨豫豠谂豅谀豠豧豖豿豼豙豴豺豦豶豨豫豠谂豅谀豣豙豖豿豼豞豚豺豦豶豨豜豠谂豅谀豧谂豼豿豼豙豸豺豦豶豨豺豠谂豅谀豫豧豖豿豼豞豨豺豦豶豨豛豠谂豅谀豨谂豖豿豼豞豼豶豦豶豨豞豠谂豅谀豨豧豖豿豼豜豂豺豦豶豨豦豣谂豅谀豫谂豼豿豼豙豴豺豦豶豨豚豠谂豅谀豐豧豖豿豼豞豼豶豦豶豨豱豣谂豅谀豠豷豼豿豼豙豼豶豦豶豨豰豣谂豅谀豧谂豼豿豼豟豸豾豦豶豨豦豣谂豅谀豨豙豼豿豼豞豼豶豦豶豨豺豠谂豅谀豨豷豖豿豼豜豖豺豦豶豨豫豠谂豅谀豣谂豖豿豼豙豊豺豦豶豨豓豠谂豅谀豓豷豖豿豼豘豠豶豦豶豫豄豣谂豅谀豫谂豼豿豼豞豰豺豦豶豨豶豣谂豅谀象豙豖豿豼豞豼豶豦豶豨豿豠谂豅谀豧豧豖豿豼豞豼豶豦豶豨豪豠谂豅谀豥豷豖豿豼豟豤豺豦豶豨豛豠谂豅谀豣谂豖豿豼豟豨豺豦豶豨豙豠谂豅谀豗豷豖豿豼豕谏谏", 416058418), Config.botInfo.BotCreator);
        }

        public override string Usage
        {
            get { return Utils.XOR("勴勫勵勹勭勵勇劒勴勷勵勭勇勵勈劒勲勍勵勹勭勶勭劒勴勷勶办", 1074418339); }
        }

        public override string HelpMenu
        {
            get { return Utils.XOR("鬺鬛鬕鬷鬑鬱鬕魪鬆鬋鬅魬鬺鬈鬚魭鬐鬇鬳鬷鬑鬶魧鬦鬆鬋鬆魭鬺鬈鬚魭鬻鬱鬳鬷鬑鬲魮魪鬆鬋鬆鬨鬺鬈鬚魭鬋鬇鬳鬷鬑鬶魧鬦鬆鬋鬆魭鬺鬈鬚魭鬒魬鬳鬷鬑鬱鬕魪鬆鬋鬆鬩鬒鬲鬚魭鬼鬱鬳鬷鬑鬱鬙魪鬆鬋鬅魬鬺鬈鬚魭鬐鬇鬳鬷鬑鬶鬫魪鬆鬋鬆鬩鬒鬲鬚魭鬻魬鬳鬷鬑鬵鬉魪鬆鬋鬅魫鬺鬈鬚魭鬒鬱鬳鬷鬑鬶魧鬦鬆鬋鬅鬥鬺鬈鬚魭鬺鬗鬳鬷鬑鬱鬍魪鬆鬋鬅鬧鬺鬈鬚魭鬼鬱鬳鬷鬑鬵鬅魪鬆鬋鬅鬐鬺鬈鬚魭鬓鬥鬕鬷鬑鬱鬴鬦鬆鬋鬆鬩鬒鬲鬚魭鬼鬱鬳鬷鬑鬱鬙魪鬆鬋鬅魬鬺鬈鬚魭鬐鬇鬳鬷鬑鬶鬫魪鬆鬋鬆魢", 557554527); }
        }
    }
}
