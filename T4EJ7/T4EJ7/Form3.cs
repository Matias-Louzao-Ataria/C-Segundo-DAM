using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4EJ7
{
    public partial class Form3 : Form
    {
        Form1 parent = null;
        public Form3(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.KeyUp += (Object sender, KeyEventArgs e) => 
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                this.parent.txtContent.SelectionStart = int.Parse(this.txtBegining.Text);
                this.parent.txtContent.SelectionLength = int.Parse(this.txtLength.Text);
            }
            catch (Exception ex) when (ex is OverflowException || ex is IndexOutOfRangeException || ex is FormatException || ex is ArgumentException)
            {
                MessageBox.Show("Invalid specified selection parameters!");
            }
        }
    }
}
