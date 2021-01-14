using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesT3EJ1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (this.txtIp.Text.Length > 0 && this.txtPort.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
