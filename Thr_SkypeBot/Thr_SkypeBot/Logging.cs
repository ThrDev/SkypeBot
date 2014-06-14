using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Thr_SkypeBot
{
    class ConsoleWriter : TextWriter
    {
        private TextWriter originalOut;

        public ConsoleWriter()
        {
            originalOut = Console.Out;
        }

        public override Encoding Encoding
        {
            get { return new System.Text.ASCIIEncoding(); }
        }
        public override void WriteLine(string message)
        {
            originalOut.WriteLine(String.Format(Utils.XOR("멎멆먱먳멏멯멥멱멏멫멘먳멣멕멘먳멠멆멪먳멏멨머멱멏멫멛멻멠멕멘먳멠멆멪먳멏멬멏멵멏멫멘먵멣멕멘먳멤멆멪먳멏멫멛멵멏멫멛멩멣멕멘먳", 1930410497), DateTime.Now, message));
            //log text.
            Logger.Log(Utils.XOR("❺❇❅❞❧❭❨❐❊❭❻❓❤❇❨✙❋❭❣❞❧❮✙❐❊❭❸✛❤❇❨✙❋❃❣❞❧❮✙❐❊❭❻❑❤❇❨✙❌❽❣❞❧❨✔✔", 154019625) + message);
        }
        public override void Write(string message)
        {
            originalOut.Write(String.Format(Utils.XOR("쫹쫂쫺쫠쫢쪞쫾쫔쫿쫖쫈쫵쫈쫹쫟쪟쫸쫴쫪쫠쫢쪝쫢쫔쫿쫖쫈쫯쫏쫹쫟쪟쫸쫴쫪쫠쫢쪟쫄쪝쫿쫖쫈쫿쫈쫹쫟쪟쫵쪟쫪쫠쫢쪝쫄쪝쫿쫖쫏쫖쫈쫹쫟쪟", 82627244), DateTime.Now, message));
            //log text.
            //Format with today's date, move old logs from yesterday into a tar file.
            Logger.Log(Utils.XOR("苹芙苬苠苤苀苤芛苹苾苰芘苎苿苁芘苈苲苼苠苤苇苒芛苹苾苳芛苎苿苁芘苋芙苼苠苤苇苒芛苹苾苰苝苎苿苁芘苏苢苼苠苤苍芗芗", 804815530) + message);
        }
    }
    class Logger
    {
        public static bool logging = false;
        public static long fileSize = Convert.ToInt32(Utils.XOR("쭾쭇쭅쭥쭧쬘쭙쬜쭺쭓쭍쭄쭌쭼쭚쬚쭳쭱쭅쭥쭧쬛쭧쬜쭺쭓쭍쭺쭌쭼쭚쬚쭳쭡쭅쭥쭧쬘쭙쬜쭺쭓쭍쭳쭌쭼쭚쬚", 1487129385));
        public static string FileName
        {
            get { return string.Format(Utils.XOR("䍢䍹䍉䍉䍍䍛䍎䍺䍐䍗䍕䌱䍎䍨䍨䌲䍧䍋䍯䍉䍍䍐䍰䍺䍐䍗䍕䌵䍦䍖䍨䌲䍍䍇䍉䍉䍍䍛䍕䌶䍐䍗䍕䍱䍎䍨䍨䌲䍠䍹䍉䍉䍍䍛䍚䍺䍐䍗䍕䍹䍦䍖䍨䌲䍧䍹䍉䍉䍍䍔䍰䍺䍐䍗䍕䍹䍎䍨䍨䌲䍧䍩䍉䍉䍍䍒䌾䌾", 1381647107), DateTime.Today.ToString("d").Replace("/", "-")); }
        }
        public static void Log(string msg)
        {
            if (!logging) return;
            Directory.CreateDirectory(Utils.XOR("뀴뀓뀛끦뀘뀸뀾뀒뀘뀒뀏끧뀇뀬뀇끤뀘뀽뀛끦뀘뀱끫끫", 345354326));
            if (File.Exists(FileName))
            {
                FileInfo f = new FileInfo(FileName);
                if (f.Length >= fileSize)
                {
                    CompressLog(FileName, Utils.XOR("뺠뺲뺿뻉뺴뺖뺠뺂뺴뺀뺠뺢뺙뺮뺙뻈", 1100201722));
                }
            }
            File.AppendAllText(FileName, string.Format(Utils.XOR("", 701425250).Replace(@"\n", "\n"), DateTime.Now, msg));
        }

        public static void LogMessage(string msg)
        {
            if (!logging) return;
            Directory.CreateDirectory(Utils.XOR("꽰꽽꽣꽐꽧꽂꼑꽐꽊꽃꽳꽡꽤꽇꽠꼛꽻꽃꽣꽐꽧꽎꼔꼔", 1300803369));
            if (File.Exists(FileName.Replace(Utils.XOR("퇒톫퇏퇃퇗퇣퇓퇵퇎퇍퇺퇡퇃퇏퇲톪", 2140656025), Utils.XOR("㦨㦧㦟㧸㦄㦎㦜㦢㦄㦠㦘㧸㦓㦞㦓㧺㦮㦍㦏㧸㦄㦂㦀㦢㦄㦠㦛㧻㦓㦞㦓㧺㦄㦝㦏㧸㦄㦂㦐㦢㦄㦠㦘㦿㦓㦞㦓㧺", 1511012810))))
            {
                FileInfo f = new FileInfo(FileName.Replace(Utils.XOR("蟪蟴蟪蟻蟾蟜蟗蟂蟣蟚蟪蟝蟻螀蟟螂蟩蟉蟄蟻蟾蟗融融", 922060720), Utils.XOR("嗨嗟嗴嗓嗼嗧嗸嗞嗥嗘嗤嗫嗨嗤嗝喃嗤嗟嗤嗓嗼嗤嗠嗞嗥嗘嗤嗱嗨嗤嗝喃嗣嗟嗤嗓嗼嗤嗚嗞嗥嗘嗤嗟嗨嗤嗝喃", 1457542578)));
                if (f.Length >= fileSize)
                {
                    CompressLog(FileName.Replace(Utils.XOR("", 1744954150), Utils.XOR("琭瑋琘瑊琵琮琗琿琵琯琭琗琪琁琮瑊琢瑋琶瑊琵琬琽琿琵琯琭琱琪琁琮瑊琨琮琶瑊琵琬琭琿琵琯琭琣琪琁琮瑊", 566457467)), Utils.XOR("㽶㽷㽪㼐㽭㽦㽀㽚㽭㽙㽱㽥㽮㽉㽀㼓㽲㽙㽪㼐㽭㽥㽦㽚㽭㽙㽱㽱㽮㽉㽀㼓㽱㽙㽪㼐㽭㽦㼛㽚㽭㽙㽲㼞", 405487395));
                }
            }
            File.AppendAllText(FileName.Replace(Utils.XOR("൪ൎെ൅െീ൒൐൜ൌ൚ൽ൞സൿസ൩ഹ൬൅െ൉വവ", 770116872), Utils.XOR("評詏詴詔詖詶詒詬詋詢詁設詺詍詫訪詔訪訩詔詖該詎詬詋詢詂詡詺詍詫訪詻詵訩詔詖該詴詬詋詢詁詠詺詍詫訪", 1358268952)), string.Format(Utils.XOR("乽丞丝乡乢乴么乘乸乨乺乿乎乹乛丝乶乫乀乡乢乺乄乘乸乨乺乢乍乹乛丝乹丞乀乡乢乹书乜乸乨乺乢乍乹乛丝义乫丝乡乢乺书乘乸乨乺乆乍乹乛丝乻乫丝乡乢乸乢乘乸乨乹丑", 578047532).Replace(@"\n", "\n"), DateTime.Now, msg));
        }

        public static void CompressLog(string path, string destprefix)
        {
            if (!Directory.Exists(Utils.XOR("蚵蚈蚰蚭蚨蚊蚼蚞蚵蚌蚼蚥蚅蚳蚉蛔蚵蚈蚠蚭蚨蚍蚒蚞蚵蚌蚿蛛",822707942) + DateTime.Today.ToString("d").Replace("/", "-")))
                Directory.CreateDirectory(Utils.XOR("靪靦靤革靆面靫靱靟面青霺靅靤靧霺靪面靂革靆靥靻靱靟面靑霵", 1009293064) + DateTime.Today.ToString("d").Replace("/", "-"));
            string Filename = "";
            for(int i = 0; i < 100000; i++)
            {
                Filename = string.Format(Utils.XOR("㝫㝮㝳㜋㝴㝽㝫㝃㝴㝮㝨㝬㝟㝮㝯㜊㝩㝾㝳㜋㝴㝿㝂㜏㝴㝮㝨㝹㝷㝐㝯㜊㝬㝢㝑㜋㝴㝿㝝㝃㝴㝮㝨㝶㝟㝮㝯㜊㝫㝐㝳㜋㝴㝼㝒㜏㝴㝮㝨㝳㝷㝐㝯㜊㝩㝢㝑㜋㝴㝿㝳㝃㝴㝮㝨㝭㝟㝮㝯㜊㝩㝾㝳㜋㝴㝿㝎㜏㝴㝮㝨㝹㝷㝐㝯㜊㝬㝔㝑㜋㝴㝿㝕㝃㝴㝮㝨㝑㝷㝐㝯㜊㝬㝐㝳㜋㝴㝼㝙㝃㝴㝮㝫㜇", 137049914), DateTime.Today.ToString("d").Replace("/", "-"), i.ToString(), destprefix); 
                if (!File.Exists(Filename))
                {
                    Filename = string.Format(Utils.XOR("胻胴肦胕胑胱胳胏背胋胅胦胋肯胴肭胺胚胫胕胑胲胳胏背胋胅肯背肯胴肭胾肯肦胕胑胱胷胓背胋胅胯胋肯胴肭胻胊胫胕胑胲胫胏背胋胅肪背肯胴肭胾胊肦胕胑胱胅胓背胋胅胭胋肯胴肭胻肯胫胕胑胲胳胏背胋胅肮背肯胴肭胾肯肦胕胑胱胻胓背胋胅胥胋肯胴肭胑胚肦胕胑胱胻胏背胋胅肩胋肯胴肭",1999667359), destprefix, DateTime.Today.ToString("d").Replace("/", "-"), i.ToString());
                    File.Move(path, Filename);
                    break;
                }
            }
            //Compress file.
            File.WriteAllBytes(Filename.Replace(Utils.XOR("푺푋푺푿푐퐭푮푖푉푴푺푦푌퐯푱퐭푺퐮푐푿푐푩퐣퐣", 116904990), Utils.XOR("䌉䌎䌪䌌䌈䌑䌮䍳䌕䌒䌐䌰䌋䌭䌭䍷", 347161414)), Compress(File.ReadAllBytes(Filename)));
            File.Delete(Filename);
        }

        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }
    }
}
