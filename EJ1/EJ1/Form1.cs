using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJ1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Aquí no eh!, se pulsa el botón");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.label2.Text = string.Format("= {0}", float.Parse(this.textBox1.Text) + float.Parse(this.textBox2.Text));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
