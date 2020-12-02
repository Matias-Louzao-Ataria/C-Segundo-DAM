using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploExamenDI1EV
{
    public partial class Form1 : Form
    {
        private int[] codes = {1342,1234,4567,8552,5443};
        private int contFails = 0;
        public Form1()
        {
            InitializeComponent();
            this.txtNombre.GotFocus += GotFocustxt;
            this.txtNombre.LostFocus += LostFocustxt;
            this.txtDestinatario.GotFocus += GotFocustxt;
            this.txtDestinatario.LostFocus += LostFocustxt;
            this.txtNota.GotFocus += GotFocustxt;
            this.txtNota.LostFocus += LostFocustxt;
            this.txtNombre.Tag = Color.LightPink;
            this.txtDestinatario.Tag = Color.LightPink;
            this.txtNota.Tag = Color.Aquamarine;
            this.FormClosing += ClosingForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;
            Form2 f = new Form2();
            bool correct = false;
            do {
                result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string res = f.Controls["txtpin"].Text;
                    if (res.Trim().Length > 0)
                    {
                        try
                        {
                            int passwd = int.Parse(res);
                            if (!this.codes.Contains(passwd))
                            {
                                this.contFails++;
                                f.Controls["lblError"].Text = "Incorrect code!";
                            }
                            else
                            {
                                correct = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Enter valid number");
                        }
                    }
                }
                else
                {
                    contFails = 3;
                }
            } while ((result == DialogResult.Cancel || !correct) && contFails < 3);
            
            this.groupBox1.Enabled = ((CheckBox)f.Controls["chkCompleta"]).Checked;
            this.groupBox1.Visible = ((CheckBox)f.Controls["chkCompleta"]).Checked;
            this.groupBox2.Enabled = ((CheckBox)f.Controls["chkCompleta"]).Checked;
            this.groupBox2.Visible = ((CheckBox)f.Controls["chkCompleta"]).Checked;

            if (contFails >= 3)
            {
                f.Close();
                this.Close();
            }
        }

        private void GotFocustxt(Object sender,EventArgs e)
        {
            ((TextBox)sender).BackColor = (Color)((Control)sender).Tag ;
        }

        private void LostFocustxt(Object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClosingForm(Object sender,FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Would you really like to exit?","My form",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            FileDialog

        }
    }
}
