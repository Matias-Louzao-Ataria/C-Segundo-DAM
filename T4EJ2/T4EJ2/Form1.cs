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

namespace T4EJ2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += ExitConfirmation;
            for (int i = 0;i < this.Controls.Count;i++)
            {
                if (this.Controls[i] is Button)//.GetType() == this.button1.GetType())
                {
                    ((Button)this.Controls[i]).MouseEnter += EnterButton;
                    ((Button)this.Controls[i]).MouseLeave += ExitButton;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == this.button2.GetType())
            {
                ChangeBackground();
            }
            else
            {
                if (((KeyEventArgs)e).KeyCode == Keys.Enter)
                {
                    ChangeBackground();
                }
            }
            
        }

        private void ChangeButton(Object sender,EventArgs e)
        {
            if(sender == this.textBox4)
            {
                this.AcceptButton = this.button3;
            }
            else
            {
                this.AcceptButton = this.button2;
            }
        }

        private void ChangeBackground()
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text.Trim()) && !string.IsNullOrEmpty(this.textBox2.Text.Trim()) && !string.IsNullOrEmpty(this.textBox3.Text.Trim()))
            {
                try
                {
                    this.BackColor = Color.FromArgb(int.Parse(this.textBox1.Text), int.Parse(this.textBox2.Text), int.Parse(this.textBox3.Text));
                }
                catch (Exception ex) when (ex is ArgumentException || ex is FormatException ||ex is OverflowException)
                {
                    MessageBox.Show("Enter valid numbers from 0 to 255");
                }
            }
        }

        private void ExitConfirmation(Object sender,FormClosingEventArgs e)
        {
            if (e.Cancel != true) {
                if (MessageBox.Show("Would you like to exit?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sender == this.button3)
            {
                string route = this.textBox4.Text;
                if (!string.IsNullOrEmpty(route))
                {
                    try
                    {
                        FileInfo f = new FileInfo(route);
                        if (f.Exists && f.Extension.Length > 0)
                        {
                            Bitmap bitmap = new Bitmap(route);
                            this.label1.BackgroundImage = bitmap;
                            this.label1.Width = bitmap.Width;
                            this.label1.Height = bitmap.Height;
                        }
                        else
                        {
                            MessageBox.Show("File doesn't exist or is not an image!");
                        }
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is System.Security.SecurityException || ex is ArgumentException || ex is PathTooLongException)
                    {
                        MessageBox.Show("Invalid path or not an image!");
                    }
                }
                else
                {
                    Console.WriteLine("a");
                }
            }
            else
            {
                if (((KeyEventArgs)e).KeyCode == Keys.Enter)
                {
                    this.button3.PerformClick();
                }
            }
        }

        private void EnterButton(Object sender,EventArgs e)
        {
            ((Button)sender).BackColor = Color.Yellow;
        }

        private void ExitButton(Object sender,EventArgs e)
        {
            ((Button)sender).BackColor = Color.Transparent;
        }
    }
}
