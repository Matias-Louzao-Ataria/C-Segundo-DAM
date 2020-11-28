using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace ServicesT1EJ2_Mejorado_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            this.textBox1.Text += String.Format("{0,4} {1,7} {2,9}\r\n","MainWindow","Name","PID");
            foreach (Process p in processes)
            {
                this.textBox1.Text += String.Format("{0,7} {1,15} {2,-9}\r\n",p.MainWindowTitle.Length >= 8? p.MainWindowTitle.Substring(0,4)+"...":p.MainWindowTitle, p.ProcessName.Length >= 15 ? p.ProcessName.Substring(0, 12) + "..." : p.ProcessName, p.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessById(int.Parse(this.textBox2.Text));
            string moduless = "";
            string threadss = "";
            foreach (ProcessModule module in p.Modules)
            {
                moduless += module.ModuleName;
            }

            foreach (ProcessThread thread in p.Threads)
            {
                threadss += thread.ThreadState;
            }
            this.textBox1.Text = String.Format("{0}{1}{2}{3}{4}{5}",p.ProcessName,p.MainWindowTitle,p.Id,p.StartTime.Hour,moduless,threadss);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProcessStartInfo s = new ProcessStartInfo(this.textBox2.Text);
            Process p = Process.Start(s);

        }
    }
}
