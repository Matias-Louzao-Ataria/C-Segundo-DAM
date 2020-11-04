using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyTaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ViewProcesses_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            this.textBox1.Text += "Nombre de proceso | Process Name | PID\r\n";
            foreach (Process p in processes)
            {
                String pMain = p.MainWindowTitle,pName = p.ProcessName,pid = ""+p.Id;

                if (pMain.Length < 18)
                {
                    for (int i = 0; i < 18 - pMain.Length; i++)
                    {
                        pMain += " ";
                    }
                }
                
                if (pName.Length < 12)
                {
                    for (int i = 0;i < 13-pName.Length;i++)
                    {
                        pName += " ";
                    }
                }

                if (pid.Length < 3)
                {
                    for (int i = 0;i < 4-pid.Length;i++)
                    {
                        pid += " ";
                    }
                }

                string algo = string.Format("{0}  | {1} | {2}\r\n",p.MainWindowTitle.Length > 0 ? p.MainWindowTitle.Length > 18 ? p.MainWindowTitle.Substring(0, 18) + "...:" : p.MainWindowTitle+":" : pMain, p.ProcessName.Length > 0 ? p.ProcessName.Length > 8 ? p.ProcessName.Substring(0, 8) + "...:" : pName + ":" : "", pid);
                this.textBox1.Text += algo;
            }
        }
    }
}
