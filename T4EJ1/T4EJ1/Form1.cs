//#define VALUE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4EJ1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
#if VALUE
            this.KeyDown += OnKeyDown;
#else
            this.KeyPress += OnKeyPressed;
#endif
        }
        
        private void OnMouseMove(Object sender,MouseEventArgs e)
        {
            if (sender is Button)
            {
                this.Text = string.Format("X:{0} Y:{1}",((Button)sender).Location.X+e.X, ((Button)sender).Location.Y+e.Y);
            }
            else
            {
                this.Text = string.Format("X:{0} Y:{1}",e.X,e.Y);
            }
        }

        private void ResetTitle(Object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }

        private void ClickDownHandler(Object sender,MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                this.button1.BackColor = Color.Blue;
            }
            else if(Control.MouseButtons == MouseButtons.Right)
            {
                this.button2.BackColor = Color.Blue;
            }
            else
            {
                this.button1.BackColor = Color.Blue;
                this.button2.BackColor = Color.Blue;
            }
        }

        private void ClickUpHandler(Object sender, MouseEventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            switch (args.Button)
            {
                case MouseButtons.Left:
                    this.button1.BackColor = Color.Transparent;
                    break;
                
                case MouseButtons.Right:
                    this.button2.BackColor = Color.Transparent;
                    break;
                
                default:
                    this.button1.BackColor = Color.Transparent;
                    this.button2.BackColor = Color.Transparent;
                    break;
            }
        }
#if VALUE
        private void OnKeyDown(Object sender,KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Text = "Mouse Tester";
                    break;

                default:
                    this.Text = e.KeyCode.ToString();
                    break;
            }
        }

#else
        private void OnKeyPressed(Object sender,KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    this.Text = "Mouse Tester";
                    break;

                default:
                    this.Text = e.KeyChar.ToString();
                    break;
            }
        }
#endif
        private void FormCloseConfirm(Object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", this.Text, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
