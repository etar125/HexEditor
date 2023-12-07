using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HexEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string chr = " 1234567890-=+_!@#$%^&*(){}[];:'\"\\|/?.>,<~`qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reader.Text = "";
                string hex = "";
                string nor = "";
                string txt = "";
                StreamReader a = new StreamReader(openFileDialog1.FileName);
                string s;
                while(true)
                {
                    s = a.ReadLine();
                    if (s != null)
                    {
                        foreach(char b in s)
                        {
                            hex += ((int)b).ToString("X") + " ";
                            nor += ((int)b).ToString() + " ";
                            if (checkBox1.Checked)
                                if (chr.Contains(b))
                                    txt += b;
                            else
                                txt += b;
                        }
                        reader.Text += "HEX: " + hex + " NORMAL: " + nor + " TEXT: " + txt + "\n";
                        hex = "";
                        nor = "";
                        txt = "";
                    }
                    else
                        break;
                }
                a.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> result = new List<string> { };
                string temp = "";
                string opt = option.Text;
                foreach (string s in writer.Lines)
                {
                    if (opt == "HEX")
                    {
                        string[] a = s.Split(' ');
                        foreach(string b in a)
                            temp += (char)Convert.ToInt32(b, 16);
                    }
                    else if (opt == "DEC")
                    {
                        string[] a = s.Split(' ');
                        foreach (string b in a)
                            temp += (char)(int.Parse(b));
                    }
                    else if (opt == "TEXT")
                    {
                        temp += s;
                    }
                    result.Add(temp);
                    temp = "";
                }
                File.WriteAllLines(saveFileDialog1.FileName, result.ToArray());
            }
        }
    }
}
