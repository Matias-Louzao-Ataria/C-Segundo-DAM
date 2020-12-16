﻿using System;
using System.Collections;
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
        private ArrayList recentFiles = new ArrayList();
        private string oldContentText = "";
        private string newContentText = "";
        public Form1()
        {
            InitializeComponent();
            this.oldContentText = this.txtContent.Text;
            ToolStripMenuItem upperItem = (ToolStripMenuItem)this.menuStrip1.Items["herramientas"];
            ToolStripItemCollection items = ((ToolStripMenuItem)upperItem.DropDownItems["seleccionDeEscritura"]).DropDownItems;
            items["normal"].Tag = CharacterCasing.Normal;
            items["mayusculas"].Tag = CharacterCasing.Upper;
            items["minusculas"].Tag = CharacterCasing.Lower;
        }

        private void aux(Object sender,EventArgs e)
        {
            if (sender == ((ToolStripDropDownItem)this.menuStrip1.Items["archivo"]).DropDownItems["guardar"])
            {
                NewDoc(true);
            }
            else
            {
                NewDoc(false);
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
                        this.txtContent.Text = "";
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
                        this.oldContentText = this.txtContent.Text;
                    }
                    if (this.recentFiles.Count < 5)
                    {
                        this.recentFiles.Insert(0, save.FileName);
                    }
                    else
                    {
                        this.recentFiles.RemoveAt(4);
                        this.recentFiles.Insert(0, save.FileName);
                    }
                }
                catch (Exception ex) when (ex is ArgumentNullException ||ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException ||ex is NotSupportedException ||ex is System.Security.SecurityException || ex is IOException)
                {
                    Console.WriteLine(ex.Message);
                    if (saving)
                    {
                        MessageBox.Show("Failed to save!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to create a new file!");
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
                    if (this.recentFiles.Count < 5)
                    {
                        this.recentFiles.Insert(0, fileDialog.FileName);
                    }
                    else
                    {
                        this.recentFiles.RemoveAt(4);
                        this.recentFiles.Insert(0, fileDialog.FileName);
                    }
                    this.oldContentText = this.txtContent.Text;
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException || ex is NotSupportedException || ex is System.Security.SecurityException || ex is IOException)
                {
                    MessageBox.Show("Failed to open the file!");
                }
            }
        }

        private void Exit(Object sender,EventArgs e)
        {
            this.Close();
        }

        private void MenuCopy(Object sender,EventArgs e)
        {
                Clipboard.SetText(this.txtContent.SelectedText);
            if (sender == ((ToolStripDropDownItem)this.menuStrip1.Items["editar"]).DropDownItems["cortar"])
            {
                this.txtContent.SelectedText = "";
            }
        }

        private void MenuPaste(Object sender,EventArgs e)
        {
            this.txtContent.Text += Clipboard.GetText();
        }

        private void MenuUndo(Object sender,EventArgs e)
        {
            this.txtContent.Text = this.oldContentText;
        }

        private void ContentTextChanged(Object sender,EventArgs e)
        {
            string text = this.txtContent.Text;
            this.newContentText = text;
        }

        private void SelectAll(Object sender,EventArgs e)
        {
            this.txtContent.SelectAll();
        }

        private void MenuWordWrapCheckedChange(Object sender,EventArgs e)
        {
            ToolStripDropDownItem item = ((ToolStripDropDownItem)this.menuStrip1.Items["herramientas"]);
            this.txtContent.WordWrap = ((ToolStripMenuItem)item.DropDownItems["ajusteDeLinea"]).Checked;
        }

        private void MenuTextSelectionChanged(Object sender,EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                ToolStripMenuItem upperItem = (ToolStripMenuItem)this.menuStrip1.Items["herramientas"];
                ToolStripItemCollection items = ((ToolStripMenuItem)upperItem.DropDownItems["seleccionDeEscritura"]).DropDownItems;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] == sender)
                    {
                        this.txtContent.CharacterCasing = (CharacterCasing)items[i].Tag;
                    }
                    else
                    {
                        ((ToolStripMenuItem)items[i]).Checked = false;
                    }
                }
            }
        }

        private void RecentFiles(Object sender,EventArgs e)
        {
            ToolStripDropDownItem recientes = (ToolStripDropDownItem)((ToolStripDropDownItem)this.menuStrip1.Items[0]).DropDownItems[3];
            recientes.DropDownItems.Clear();
            foreach (string file in this.recentFiles)
            {
                recientes.DropDownItems.Add(file);
            }
        }
    }
}
