using aTr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            textBox1.Text = "https://guproth.com/?gupro=register";
            webBrowser1.Navigate(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;

            webBrowser1.Navigate(textBox1.Text);
            webBrowser1.Refresh();
            textBox2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Green;
            button1.ForeColor = Color.Black;

            webBrowser1.Navigate(textBox1.Text);
            textBox2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            char[] lt = "iojkpblcnhduatxeaztedge".ToCharArray();
            Random r = new Random();
            string randoomStrinf = "";
            for (int i =0; i < 7; i++)
            {
                randoomStrinf += lt[r.Next(0, 7)].ToString();
            }


            textBox2.Text = webBrowser1.Document.GetElementById("Code2").GetAttribute("value");
            webBrowser1.Document.GetElementById("txtUsername").SetAttribute("value", randoomStrinf + "123");
            webBrowser1.Document.GetElementById("txtPassword").SetAttribute("value", randoomStrinf + "456");
            webBrowser1.Document.GetElementById("txtConPassword").SetAttribute("value", randoomStrinf + "456");
            webBrowser1.Document.GetElementById("txtemail").SetAttribute("value", randoomStrinf + "@gmail.com");
            listBox1.Items.Add("Username : " + webBrowser1.Document.GetElementById("txtUsername").GetAttribute("value"));
            listBox1.Items.Add(" Password : " + webBrowser1.Document.GetElementById("txtPassword").GetAttribute("value"));
            listBox1.Items.Add(" Fmail : " + webBrowser1.Document.GetElementById("txtemail").GetAttribute("value"));
            webBrowser1.Document.GetElementById("Code1").SetAttribute("value", textBox2.Text);
            webBrowser1.Document.GetElementById("button").InvokeMember("Click");
            button4.ForeColor = Color.Green;
            button1.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0)
            {
                using(TextWriter tw = new StreamWriter("list.txt"))
                {
                    foreach (string intemtext in listBox1.Items)
                    {
                        tw.Write(intemtext);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            textBox2.Refresh();
            textBox2.Text = webBrowser1.Document.GetElementById("Code2").GetAttribute("value");
            timer1.Stop();
            timer1.Interval = 500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button4.PerformClick();
            button2.PerformClick();
            button5.PerformClick();
            return;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

    }
}
