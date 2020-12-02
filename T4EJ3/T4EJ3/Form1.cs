using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4EJ3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += ExitConfirm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "jpg (*.jpg)|*.jpg|png (*.png)|*.png|All files (*.*)|*.*";
            result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //MessageBox.Show(fileDialog.FileName);
                Form2 f = new Form2();
                ((PictureBox)f.Controls["pictureBox1"]).Image = new Bitmap(fileDialog.FileName);
                f.Text = fileDialog.SafeFileName;
                if (this.checkBox1.Checked)
                {
                    f.ShowDialog();
                }
                else
                {
                    f.Show();
                }
            }
        }

        private void ExitConfirm(Object sender,FormClosingEventArgs e)
        {
            if (MessageBox.Show("Would you really like to exit?","EJ3",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
