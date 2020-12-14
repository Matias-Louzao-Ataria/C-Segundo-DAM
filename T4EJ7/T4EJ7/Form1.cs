using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace T4EJ7
{
    public partial class Form1 : Form
    {
        private string[] recentFiles = new string[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void aux(Object sender,EventArgs e)
        {
            if (sender == this.menuStrip1.Items["Guardar"])
            {
                NewDoc(false);
            }
            else
            {
                NewDoc(true);
            }
        }

        private void NewDoc(bool saving)
        {
            SaveFileDialog save = new SaveFileDialog();
            DialogResult result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                try{
                    if (!saving)
                    {
                        FileInfo file = new FileInfo(save.FileName);
                        file.Create();
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(save.FileName,true))
                        {
                            if (this.txtContent.Text.Trim().Length > 0)
                            {
                                for (int i = 0;i < this.txtContent.Lines.Count();i++)
                                {
                                    writer.WriteLine(this.txtContent.Lines[i]);
                                }
                            }
                        }
                    }
                    this.recentFiles.Prepend(save.FileName);
                    this.recentFiles[this.recentFiles.Length] = null;
                }
                catch (Exception ex) when (ex is ArgumentNullException ||ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException ||ex is NotSupportedException ||ex is System.Security.SecurityException || ex is IOException)
                {
                    if (saving)
                    {
                        MessageBox.Show("Failed to save!");
                    }
                    else
                    {
                        MessageBox.Show("Filed create a new file!");
                    }
                }
            }
        }

        private void OpenFile(Object sender,EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt (*.txt)|*.txt|ini (*.ini)|*.ini|java (*.java)|*.java|cs (*.cs)|*.cs|py (*.py)|*.py|html (*.html)|*.hmtl|css (*.css)|*.css|xml (*.xml)|*.xml|All|*.*";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileDialog.FileName))
                    {
                        this.txtContent.Text = "";
                        this.txtContent.Text += reader.ReadToEnd();
                    }
                    this.recentFiles.Prepend(fileDialog.FileName);
                    this.recentFiles[this.recentFiles.Length] = null;
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException || ex is NotSupportedException || ex is System.Security.SecurityException || ex is IOException)
                {
                    MessageBox.Show("Failed to open the file!");
                }
            }
        }

        private void RecentFiles(Object sender,EventArgs e)
        {
            
        }
    }
}
