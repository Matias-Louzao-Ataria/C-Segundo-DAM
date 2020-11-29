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

namespace T3EJ4
{
    public partial class Form1 : Form
    {
        string route = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = this.textBox1.Text.ToString();

            if (str.Trim().Replace("%","").Length > 0 && str.StartsWith("%") && str.EndsWith("%"))
            {
                try
                {
                    if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(this.textBox1.Text.ToString().Replace("%", ""))))
                    {
                        DirectoryInfo dir = new DirectoryInfo(Environment.GetEnvironmentVariable(this.textBox1.Text.ToString().Replace("%", "")) + "\\");
                        if (dir.Extension.Length == 0 && dir.Exists)
                        {
                            getSubdir(dir);
                        }
                        else
                        {
                            MessageBox.Show("Could not find directory!");
                        }
                    }
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is System.Security.SecurityException || ex is ArgumentException || ex is PathTooLongException ||ex is NotSupportedException)
                {
                    MessageBox.Show("Invalid route!");
                }
            }
            else if(str.Trim().Length > 0 && str.Contains("%") == false)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(this.textBox1.Text.ToString());
                    if (dir.Extension.Length == 0 && dir.Exists)
                    {
                        getSubdir(dir);
                    }
                    else
                    {
                        MessageBox.Show("Could not find directory!");
                    }
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is System.Security.SecurityException || ex is ArgumentException || ex is PathTooLongException)
                {
                    MessageBox.Show("Invalid route!");
                }
            }
        }

        private void getSubdir(DirectoryInfo dir)
        {
            this.textBox2.Text = "";
            route = dir.FullName;
            try
            {
                DirectoryInfo[] subdirs = dir.GetDirectories();
                this.textBox2.Text += "\r\n";
                foreach (DirectoryInfo subdir in subdirs)
                {
                    this.textBox2.Text += subdir.Name + "\r\n";
                }
                FileInfo[] subfiles = dir.GetFiles();
                foreach (FileInfo file in subfiles)
                {
                    this.textBox2.Text += file.Name + "\r\n";
                }
            }
            catch (Exception ex) when (ex is System.Security.SecurityException ||ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when tryed to access files and subdirectories!");
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException)
            {
                MessageBox.Show("Could not find directory!");
            }
        }
    }
}
