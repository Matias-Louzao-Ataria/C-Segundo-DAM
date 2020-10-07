#define RESTA
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJ3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.credito <= 0) {
                credito = 0;
                this.label2.Text = this.credito+"€";
            }
            else {
                this.credito -= 2;
                this.label2.Text = this.credito+"€";
                Random r = new Random();
                int n1 = r.Next(1,7), n2 = r.Next(1, 7), n3 = r.Next(1, 7);
                this.textBox1.Text = n1.ToString();
                this.textBox2.Text = n2.ToString();
                this.textBox3.Text = n3.ToString();
                if (n1 == n2 && n2 == n3)
                {
                    this.credito += 20;
                    this.label2.Text = this.credito + "€";
                    this.label1.Text = "Premio gordo!";
                }
                else if ((n1 == n2) || (n2 == n3) || (n1 == n3))
                {
#if !RESTA
                    this.credito += 5;
#else
                    if (this.credito <= 0)
                    {
                        this.credito -=5;
                    }

#endif
                    this.label2.Text = this.credito + "€";
                    this.label1.Text = "Premio normal!";
                }
                else
                {
                    this.label1.Text = "No hay premio!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.credito += 10;
            this.label2.Text = this.credito + "€";
        }
    }
}
