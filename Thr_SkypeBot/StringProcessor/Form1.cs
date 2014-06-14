using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Threading;
namespace StringProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random g;
        Computer mypc = new Computer();
        public void Form1_Load(object sender, EventArgs e)
        {
            g = new Random(Environment.TickCount);
        }

        public ArrayList XOR(string decinfo)
        {          
            int cipher = g.Next();
            char[] v = new char[decinfo.Length];
            for (int i = 0; i < decinfo.Length; i++)
            {
                v[i] = (char)((uint)decinfo[i] ^ cipher);
            }
            //return string.
            string output = Convert.ToBase64String(Encoding.UTF8.GetBytes(Reverse(Convert.ToBase64String(Encoding.UTF8.GetBytes(new string(v))))));
            char[] x = new char[output.Length];
            for (int i = 0; i < output.Length; i++)
            {
                x[i] = (char)((uint)output[i] ^ cipher);
            }
            ArrayList f = new ArrayList();
            f.Add(new string(x));
            f.Add(cipher);
            return f;
            
        }
        public string Reverse(string x)
        {
            char[] charArray = new char[x.Length];
            int len = x.Length - 1;
            for (int i = 0; i <= len; i++)
                charArray[i] = x[len - i];
            return new string(charArray);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lastencrypted = XOR(textBox1.Text);
            textBox2.Text = string.Format("Utils.XOR(\"{0}\",{1})", lastencrypted[0], lastencrypted[1]);
            //wait to set clipboard.
        }
        ArrayList lastencrypted;
        public string XOR(string decinfo, int cipher)
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
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] h = textBox3.Text.Replace("Utils.XOR(", "").Replace("\"", "").Replace(")", "").Replace(";", "").Split(',');
                textBox4.Text = XOR(h[0], Convert.ToInt32(h[1]));
            }
            catch
            {
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            mypc.Clipboard.SetText(textBox2.Text);
        }
    }
}
