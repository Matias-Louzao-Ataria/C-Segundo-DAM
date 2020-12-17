using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4EJ8
{
    public partial class Form2 : Form
    {
        private Form1 parent = null;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.parent.Text = "";
            this.parent.lblDir.Text = "";
            this.parent.lblInfo.Text = "";
            this.Close();
        }

        private void PreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.parent.BtnRetirada_Click(sender,e);
        }

        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.parent.BtnAvanti_Click(sender,e);
        }
    }
}
