using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace T4EJ8
{
    public partial class Form1 : Form
    {
        private FileInfo imageInfo = null;
        private Form2 fImage = null;
        public Form1()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btnOpen,"Opens image");
            this.toolTip1.SetToolTip(this.btnAvanti,"Shows next image");
            this.toolTip1.SetToolTip(this.btnRetirada,"Shows previous image");
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            DialogResult dialogResult = openDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    fImage = new Form2(this);
                    if (ImageChange(openDialog.FileName))
                    {
                        fImage.Show();
                    }
                }
                catch (Exception ex) when (ex is FileNotFoundException ||ex is PathTooLongException || ex is OutOfMemoryException || ex is ArgumentNullException ||ex is ArgumentException)
                {
                    MessageBox.Show("Failed to open the file!");
                }
            }
        }

        private bool ImageChange(string str)
        {
            try
            {
                if(str == "")
                {
                    this.Text = "";
                    this.lblDir.Text = "";
                    this.lblInfo.Text = "";
                }
                else
                {
                    this.Text = "Image visualizer -<" + str + ">";
                    Bitmap img = new Bitmap(str);
                    imageInfo = new FileInfo(str);
                    this.lblDir.Text = imageInfo.DirectoryName;
                    this.lblInfo.Text = "Image file name: " + str + Environment.NewLine + "Size: " + imageInfo.Length / 1024 + "KB " + "resolution: " + img.PhysicalDimension.ToString().Replace("{", "").Replace("}", "");
                    fImage.picImg.Image = img;
                }
                return true;
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is PathTooLongException || ex is OutOfMemoryException || ex is ArgumentNullException || ex is ArgumentException)
            {
                
                MessageBox.Show("Failed to open the file!");
                return false;
            }
        }

        private void ExitConfirmation(Object sender,FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you'd like to exit?","Confirmation",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void BtnRetirada_Click(object sender, EventArgs e)
        {
            if (this.imageInfo != null)
            {
                DirectoryInfo imageDirectory = new DirectoryInfo(this.imageInfo.DirectoryName);
                FileInfo[] files = imageDirectory.GetFiles();
                int pos = 0;
                for (int i = 0;i <files.Length;i++)
                {
                    if (files[i].FullName == this.imageInfo.FullName)
                    {
                        pos = i;
                    }
                }
                for (int i = 0;i < files.Length;i++)
                {
                    if (sender == this.btnRetirada || sender == this.fImage.contextMenuStrip1.Items["previous"])
                    {
                        if (isImage(files[i].FullName) && pos > i)
                        {
                            ImageChange(files[i].FullName);
                        }
                    }
                    else
                    {
                        if (isImage(files[i].FullName) && pos < i)
                        {
                            ImageChange(files[i].FullName);
                        }
                    }
                }
            }
        }

        private bool isImage(string str)
        {
            try
            {
                Bitmap tester = new Bitmap(str);
                return true;
            }
            catch (Exception ex) when (ex is ArgumentException ||ex is ArgumentNullException || ex is OutOfMemoryException)
            {
                return false;
            }
        }

        public void BtnAvanti_Click(object sender, EventArgs e)
        {
            this.BtnRetirada_Click(sender,e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is Form)
            {
                if (e.KeyCode == Keys.A)
                {
                    BtnRetirada_Click(this.btnRetirada, new EventArgs());
                }
                else if (e.KeyCode == Keys.D)
                {
                    BtnAvanti_Click(this.btnAvanti, new EventArgs());
                }
            }
        }
    }
}
