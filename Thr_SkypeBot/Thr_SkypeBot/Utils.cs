using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thr_SkypeBot
{
    class Utils
    {
        public static string XOR(string decinfo, int cipher)
        {
            char[] x = new char[decinfo.Length];
            for (int i = 0; i < decinfo.Length; i++)
            {
                x[i] = (char)((uint)decinfo[i] ^ cipher);
            }
            string output = Encoding.UTF8.GetString(Convert.FromBase64String(Reverse(Encoding.UTF8.GetString(Convert.FromBase64String(new string(x))))));
            char[] v = new char[output.Length];
            for (int i = 0; i < output.Length; i++)
            {
                v[i] = (char)((uint)output[i] ^ cipher);
            }
            //return string.
            return new string(v);
        }
        public static string Reverse(string x)
        {
            char[] charArray = new char[x.Length];
            int len = x.Length - 1;
            for (int i = 0; i <= len; i++)
                charArray[i] = x[len - i];
            return new string(charArray);
        }

        public static List<string> ParseParameters(string parametrs)
        {
            List<string> parameters = new List<string>();
            parameters.Add("");
            int index = 0;
            bool quoteOn = false;
            foreach (char character in parametrs)
            {
                if (character == '"')
                {
                    quoteOn = !quoteOn;
                    if (parameters[index] != "")
                    {
                        parameters.Add("");
                        index++;
                    }
                }
                else if (character == ' ' && !quoteOn)
                {
                    if (parameters[index] != "")
                    {
                        parameters.Add("");
                        index++;
                    }
                }
                else
                {
                    parameters[index] += character;
                }
            }

            if (parameters[index] == "") parameters.RemoveAt(index);
            return parameters;
        }
    }
}
