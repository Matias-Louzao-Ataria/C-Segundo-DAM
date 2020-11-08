using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            this.listView1.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                ListViewItem item = new ListViewItem(new string[] {p.MainWindowTitle.Length > 8 ? p.MainWindowTitle + "..." : p.MainWindowTitle, p.ProcessName.Length > 15 ? p.ProcessName.Substring(0, 15) + "..." : p.ProcessName, ""+p.Id});
                this.listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)//TODO Diferencia entre el botón 3 y el 4, preguntar si se le pregunta en uno y se fuerza en otro o si se usan funciones diferentes o que.
        {
            int pid = 0;
            string id = this.textBox2.Text;
            if (id.Length > 0)
            {
                try
                {
                    pid = int.Parse(id);
                    try
                    {
                        Process p = Process.GetProcessById(pid);
                        p.Kill();
                    }
                    catch (Exception ex) when (ex is ArgumentException ||ex is Win32Exception)
                    {
                        if (ex is Win32Exception)
                        {
                            MessageBox.Show("PID not given!");
                        }
                        else
                        {
                            MessageBox.Show("Process not found or access denied!");
                        }
                    }
                }
                catch (Exception ex) when (ex is FormatException || ex is OverflowException)
                {
                    MessageBox.Show("invalid PID!");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pid = 0;
            string id = this.textBox2.Text;
            if (id.Length > 0)
            {
                try
                {
                    pid = int.Parse(id);
                    try
                    {
                        Process p = Process.GetProcessById(pid);
                        p.CloseMainWindow();
                    }
                    catch (Exception ex) when (ex is ArgumentException || ex is Win32Exception)
                    {
                        if (ex is Win32Exception)
                        {
                            MessageBox.Show("PID not given!");
                        }
                        else
                        {
                            MessageBox.Show("Process not found or access denied!");
                        }
                    }
                }
                catch (Exception ex) when (ex is FormatException || ex is OverflowException)
                {
                    MessageBox.Show("invalid PID!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string process = this.textBox2.Text;
            if (process.Length > 0)
            {
                ProcessStartInfo info = new ProcessStartInfo(process);
                Process p;
                try
                {
                    p = Process.Start(info);//Solo acepta rutas en inglés.
                }
                catch (Exception ex) when (ex is ArgumentNullException ||ex is InvalidOperationException ||ex is ObjectDisposedException ||ex is FileNotFoundException ||ex is Win32Exception)
                {
                    MessageBox.Show("invalid route or application name!");
                }
            }
        }

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection processes = this.listView1.SelectedItems;

            foreach (ListViewItem item in processes)
            {
                ListViewItem.ListViewSubItemCollection subitems = item.SubItems;
                foreach (ListViewItem.ListViewSubItem item2 in subitems)
                {
                        this.textBox2.Text = item2.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            int pid = 0;
            string id = this.textBox2.Text;
            if (id.Length > 0)
            {
                try
                {
                    pid = int.Parse(id);
                    try
                    {
                        Process p = Process.GetProcessById(pid);
                        ListViewItem item = new ListViewItem(new string[] { p.MainWindowTitle.Length > 8 ? p.MainWindowTitle + "..." : p.MainWindowTitle, p.ProcessName.Length > 15 ? p.ProcessName.Substring(0, 15) + "..." : p.ProcessName, "" + p.Id });
                        this.listView1.Items.Add(item);
                    }
                    catch (Exception ex) when (ex is ArgumentException || ex is Win32Exception)
                    {
                        if (ex is Win32Exception)
                        {
                            MessageBox.Show("PID not given!");
                        }
                        else
                        {
                            MessageBox.Show("Process not found or access denied!");
                        }
                    }
                }
                catch (Exception ex) when (ex is FormatException || ex is OverflowException)
                {
                    MessageBox.Show("invalid PID!");
                }
            }
        }
    }
}
