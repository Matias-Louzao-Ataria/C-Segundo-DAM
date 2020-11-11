using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3EJ4
{
    public partial class Form1 : Form
    {
        string ruta = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = this.textBox1.Text.ToString();

            if (str.Length > 0 && str.StartsWith("%")&&str.EndsWith("%"))
            {
                ruta = Environment.GetEnvironmentVariable(this.textBox1.Text.ToString().Replace("%",""));
            }
            Console.WriteLine(ruta);
        }
    }
}
