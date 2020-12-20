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
        public Form3()
        {
            InitializeComponent();
            this.KeyUp += (Object sender, KeyEventArgs e) => 
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };
        }
    }
}
