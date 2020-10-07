using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJ5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) {
                if (MessageBox.Show("Quieres cambiar el título del formulario a: " + textBox1.Text + "?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Text = this.textBox1.Text;
                }
            }
        }
    }
}
