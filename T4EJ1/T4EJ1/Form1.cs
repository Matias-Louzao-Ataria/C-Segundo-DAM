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
            //this.MouseHover += new EventHandler(OnMouseHover);
            //this.mouse
            this.MouseLeave += this.ResetTitle;
            this.MouseMove += OnMouseHover;
            this.button1.MouseMove += OnMouseHover;
            this.button2.MouseMove += OnMouseHover;
            this.MouseDown += ClickDownHandler;
            this.MouseUp += ClickUpHandler;
            this.KeyUp += OnKeyPressed;
            this.FormClosing += FormCloseConfirm;
        }
        
        private void OnMouseHover(Object sender,EventArgs e)
        {
            this.Text = ""+ Control.MousePosition;
        }

        private void ResetTitle(Object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }

        private void ClickDownHandler(Object sender,EventArgs e)
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

        private void ClickUpHandler(Object sender, EventArgs e)
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

        private void OnKeyPressed(Object sender,KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Text = "Mouse Tester";
                    break;
                
                default:
#if VALUE
                    this.Text = e.KeyData.ToString();
#else
                    this.Text = e.KeyValue.ToString();
#endif
                    break;
            }
        }
        private void FormCloseConfirm(Object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Form", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
