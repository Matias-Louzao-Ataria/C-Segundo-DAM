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
            this.textBox1.KeyUp += button2_Click;
            this.textBox2.KeyUp += button2_Click;
            this.textBox3.KeyUp += button2_Click;
            this.FormClosing += ExitConfirmation;
            this.textBox4.KeyDown += button3_Click;
            for (int i = 0;i < this.Controls.Count;i++)
            {
                if (this.Controls[i].GetType() == this.button1.GetType())
                {
                    ((Button)this.Controls[i]).MouseEnter += Encima;
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
                switch (((KeyEventArgs)e).KeyCode)
                {
                    case Keys.Enter:
                        ChangeBackground();
                        break;
                    case Keys.Escape:
                        this.Close();
                        break;
                }
            }
            
        }

        private void ChangeBackground()
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text.Trim()) && !string.IsNullOrEmpty(this.textBox2.Text.Trim()) && !string.IsNullOrEmpty(this.textBox3.Text.Trim()))
            {
                try
                {
                    if (int.Parse(this.textBox1.Text) >= 0 && int.Parse(this.textBox1.Text) <= 255 && int.Parse(this.textBox2.Text) >= 0 && int.Parse(this.textBox2.Text) <= 255 && int.Parse(this.textBox3.Text) >= 0 && int.Parse(this.textBox3.Text) <= 255)
                    {
                        this.BackColor = Color.FromArgb(int.Parse(this.textBox1.Text), int.Parse(this.textBox2.Text), int.Parse(this.textBox3.Text));
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
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
            if (sender.GetType() == this.button3.GetType())
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
                        }
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is System.Security.SecurityException || ex is ArgumentException || ex is PathTooLongException)
                    {
                        MessageBox.Show("Invalid path or not an image!");
                    }
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

        private void Encima(Object sender,EventArgs e)
        {
            ((Button)sender).BackColor = Color.Yellow;
        }

        private void ExitButton(Object sender,EventArgs e)
        {
            ((Button)sender).BackColor = Color.Transparent;
        }
    }
}
