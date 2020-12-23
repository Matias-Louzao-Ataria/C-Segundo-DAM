using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing.Printing;

namespace T4EJ7
{
    public partial class Form1 : Form
    {
        private ArrayList recentFiles = new ArrayList();
        private bool saved = true;
        private Form3 info = null;
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem upperItem = (ToolStripMenuItem)this.menuStrip1.Items["herramientas"];
            ToolStripItemCollection items = ((ToolStripMenuItem)upperItem.DropDownItems["seleccionDeEscritura"]).DropDownItems;
            upperItem.DropDownItems["acercaDe"].Click += (Object sender, EventArgs e) =>
            {
                Form2 about = new Form2();
                about.ShowDialog();
            };
            items["normal"].Tag = CharacterCasing.Normal;
            items["mayusculas"].Tag = CharacterCasing.Upper;
            items["minusculas"].Tag = CharacterCasing.Lower;
            updateToolTip();
        }

        private void MenuSaveAndNew(Object sender, EventArgs e)
        {
            SaveAndNew(sender == ((ToolStripDropDownItem)this.menuStrip1.Items["archivo"]).DropDownItems["guardar"]);
        }

        private void SaveAndNew(bool saving)
        {
            string errormsg = "Failed to save!";
            SaveFileDialog save = null;
            DialogResult result = DialogResult.None;
            if (this.recentFiles.Count == 0 || !saving)
            {
                save = new SaveFileDialog();
                if (!saving)
                {
                    if (!this.saved)
                    {
                        if (MessageBox.Show("Would you like to save?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MenuSaveAndNew(((ToolStripDropDownItem)this.menuStrip1.Items["archivo"]).DropDownItems["guardar"], new EventArgs());
                        }
                    }
                    save.Title = "New file";
                    errormsg = "Failed to create a new file!";
                }
                result = save.ShowDialog();
            }
            else
            {
                result = DialogResult.OK;
            }
            if (result == DialogResult.OK)
            {
                try
                {
                    if(saving)
                    {
                        string currentFile = "";
                        if (save == null)
                        {
                            currentFile = this.recentFiles[0].ToString();
                        }
                        else
                        {
                            currentFile = save.FileName;
                        }
                        if (this.txtContent.Text.Trim().Length > 0)
                        {
                            using (StreamWriter writer = new StreamWriter(currentFile))
                            {
                                for (int i = 0; i < this.txtContent.Lines.Count(); i++)
                                {
                                    writer.Write(this.txtContent.Lines[i]);
                                }
                            }
                        }
                        CheckRecentFiles(currentFile);
                    }
                    else
                    {
                        this.txtContent.Text = "";
                        FileInfo file = new FileInfo(save.FileName);
                        if (!file.Exists)
                         {
                            file.Create();
                        }
                        if (file.Exists && file.Length > 0)
                        {
                            file.Delete();
                            file.Create();
                        }
                        file = null;
                        ChangeFile(save.FileName);
                    }
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException || ex is NotSupportedException || ex is System.Security.SecurityException || ex is IOException)
                {
                    MessageBox.Show(errormsg);
                }
            }
        }

        private void MenuOpenFile(Object sender, EventArgs e)
        {
            detectChange();
            if (!this.saved)
            {
                if (MessageBox.Show("Would you like to save?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MenuSaveAndNew(((ToolStripDropDownItem)this.menuStrip1.Items["archivo"]).DropDownItems["guardar"], new EventArgs());
                }
            }
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt (*.txt)|*.txt|ini (*.ini)|*.ini|java (*.java)|*.java|cs (*.cs)|*.cs|py (*.py)|*.py|html (*.html)|*.hmtl|css (*.css)|*.css|xml (*.xml)|*.xml|All|*.*";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    ChangeFile(fileDialog.FileName);
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException || ex is NotSupportedException || ex is System.Security.SecurityException || ex is IOException)
                {
                    MessageBox.Show("Failed to open the file!");
                }
            }
        }

        private void ChangeFile(String route)
        {
            this.txtContent.Text = "";
            FileInfo file = new FileInfo(route);
            if (file.Exists && file.Length > 0)
            {
                using (StreamReader reader = new StreamReader(route))
                {
                    this.txtContent.Text += reader.ReadToEnd();
                }
            }
            file = null;
            CheckRecentFiles(route);
            //this.saved = true;
        }

        private void CheckRecentFiles(string route)
        {
            if (this.recentFiles.Contains(route))
            {
                this.recentFiles.Remove(route);
            }
            if (this.recentFiles.Count < 5)
            {
                this.recentFiles.Insert(0, route);
            }
            else
            {
                this.recentFiles.RemoveAt(4);
                this.recentFiles.Insert(0, route);
            }
        }

        private void Exit(Object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuCopy(Object sender, EventArgs e)
        {
            this.txtContent.Copy();
            /*Clipboard.SetText(this.txtContent.SelectedText);
            if (sender == ((ToolStripDropDownItem)this.menuStrip1.Items["editar"]).DropDownItems["cortar"] || sender == this.toolStrip1.Items["cortarStrip"])
            {
                this.txtContent.SelectedText = "";
            }*/
        }

        private void MenuCut(Object sender, EventArgs e)
        {
            this.txtContent.Cut();
        }

        private void MenuPaste(Object sender, EventArgs e)
        {
            //this.txtContent.Text += Clipboard.GetText();
            this.txtContent.Paste();
        }

        private void MenuUndo(Object sender, EventArgs e)
        {
            this.txtContent.Undo();
            //this.saved = true;
        }

        private void ContentTextChanged(Object sender, EventArgs e)
        {
            //this.saved = false;
            updateToolTip();
            detectChange();
        }

        private void detectChange()
        {
            try
            {
                this.saved = !(this.recentFiles.Count == 0 && this.txtContent.Text.Trim().Replace(" ", "").Replace("\t", "").Length > 0);
                if (this.recentFiles.Count > 0)
                {
                    using (StreamReader reader = new StreamReader(this.recentFiles[0].ToString()))
                    {
                        string original = reader.ReadToEnd();
                        this.saved = (original.ToLower().Trim() == this.txtContent.Text.ToLower().Trim());
                    }
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is System.Security.SecurityException || ex is IOException)
            {
                Console.WriteLine(ex.Message+" , "+ ex.Source);
            }
        }

        private void updateToolTip()
        {
            int wordCount = 0, letterCount = 0;
            string[] lineas = this.txtContent.Lines;
            for (int i = 0; i < lineas.Length; i++)
            {
                string[] aux = lineas[i].Split(' ');
                wordCount += aux.Length;
            }

            for (int i = 0; i < lineas.Length; i++)
            {
                StringReader stringReader = new StringReader(lineas[i]);
                int aux = 0;
                while ((aux = stringReader.Read()) != -1)
                {
                    letterCount++;
                }
            }

            this.toolTip1.SetToolTip(this.txtContent, "Amout of sentences: " + this.txtContent.Lines.Length + ", Amount of words: " + wordCount + ", Amount of characters: " + letterCount);
        }

        private void SelectAll(Object sender, EventArgs e)
        {
            this.txtContent.SelectAll();
        }

        private void MenuWordWrapCheckedChange(Object sender, EventArgs e)
        {
            ToolStripDropDownItem item = ((ToolStripDropDownItem)this.menuStrip1.Items["herramientas"]);
            this.txtContent.WordWrap = ((ToolStripMenuItem)item.DropDownItems["ajusteDeLinea"]).Checked;
            //this.saved = true;
        }

        private void MenuCharacterCasingChanged(Object sender, EventArgs e)
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
                //this.saved = true;
            }
        }

        private void MenuColorPicker(Object sender, EventArgs e)
        {
            ToolStripMenuItem upperItem = (ToolStripMenuItem)this.menuStrip1.Items["herramientas"];
            ToolStripItemCollection items = ((ToolStripMenuItem)upperItem.DropDownItems["color"]).DropDownItems;
            ColorDialog colorPicker = new ColorDialog();
            DialogResult dialogResult = colorPicker.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (sender == items["colorDetexto"])
                {
                    this.txtContent.ForeColor = colorPicker.Color;
                }
                else
                {
                    this.txtContent.BackColor = colorPicker.Color;
                }
            }
        }

        private void MenuFontPicker(Object sender, EventArgs e)
        {
            try
             {
                FontDialog fontPicker = new FontDialog();
                DialogResult dialogResult = fontPicker.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    this.txtContent.Font = fontPicker.Font;
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RecentFiles(Object sender,EventArgs e)
        {
            ToolStripDropDownItem recientes = (ToolStripDropDownItem)((ToolStripDropDownItem)this.menuStrip1.Items["archivo"]).DropDownItems["archivosrecientes"];
            recientes.DropDownItems.Clear();
            for (int i = 0;i < this.recentFiles.Count;i++)
            {
                string current = this.recentFiles[i].ToString();
                ToolStripItem recent = new ToolStripMenuItem(current);
                recent.Click += (Object sender2, EventArgs e2) =>
                {
                    ChangeFile(current);
                };
                recientes.DropDownItems.Add(recent);
            }
        }

        private void configFileCreator()
        {
            try
            {
                ToolStripDropDownItem item = ((ToolStripDropDownItem)this.menuStrip1.Items["herramientas"]);
                using (FileStream stream = new FileStream("config.temp.json",FileMode.OpenOrCreate))
                {
                    using (Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream))
                    {
                        jsonWriter.WriteStartObject();
                        jsonWriter.WriteBoolean("WordWrap", ((ToolStripMenuItem)item.DropDownItems["ajusteDeLinea"]).Checked);
                        jsonWriter.WriteString("CharacterCasing", JsonSerializer.Serialize(this.txtContent.CharacterCasing));
                        jsonWriter.WriteNumber("ForeColor",this.txtContent.ForeColor.ToArgb());
                        jsonWriter.WriteNumber("BackColor", this.txtContent.BackColor.ToArgb());
                        jsonWriter.WritePropertyName("Font");
                        jsonWriter.WriteStartArray();
                        jsonWriter.WriteStringValue(this.txtContent.Font.FontFamily.Name);
                        jsonWriter.WriteNumberValue(this.txtContent.Font.Size);
                        jsonWriter.WriteEndArray();
                        if (this.recentFiles.Count > 0)
                        {
                            jsonWriter.WriteString("RecentFiles",JsonSerializer.Serialize<ArrayList>(this.recentFiles));
                            jsonWriter.WriteString("Dir", this.recentFiles[0].ToString());
                        }
                        jsonWriter.WriteEndObject();
                    }
                }
                FileInfo config = new FileInfo("config.temp.json");
                if (config.Exists && config.Length > 0)
                {
                    using (StreamWriter writer = new StreamWriter("config.json"))
                    {
                        using (StreamReader reader = new StreamReader("config.temp.json"))
                        {
                            writer.Write(reader.ReadToEnd());
                        }
                    }
                }
                config.Delete();
            }
            catch (Exception ex) when (ex is IOException || ex is JsonException)
            {
                try
                {
                    FileInfo config = new FileInfo("config.temp.json");
                    if (config.Exists && config.Length > 0)
                    {
                        config.Delete();
                    }
                }
                catch (Exception ex2) when (ex2 is IOException || ex2 is System.Security.SecurityException)
                {
                    Console.WriteLine(ex2.Message);
                }
                MessageBox.Show("Failed to create the configuration file!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            detectChange();
            if (!this.saved)
            {
                if (MessageBox.Show("Are you sure you'd like to exit?","Exit confirmation",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            if (!e.Cancel)
            {
                configFileCreator();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileInfo configFile = new FileInfo("config.json");
            if (configFile.Exists && configFile.Length > 0)
            {
                byte[] data = File.ReadAllBytes(configFile.FullName);
                Utf8JsonReader jsonReader = new Utf8JsonReader(data);
                ToolStripDropDownItem item = ((ToolStripDropDownItem)this.menuStrip1.Items["herramientas"]);
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                    {
                        try
                        {
                            switch (jsonReader.GetString())
                            {
                                case "WordWrap":
                                    jsonReader.Read();
                                    ((ToolStripMenuItem)item.DropDownItems["ajusteDeLinea"]).Checked = jsonReader.GetBoolean();
                                    this.txtContent.WordWrap = ((ToolStripMenuItem)item.DropDownItems["ajusteDeLinea"]).Checked;
                                    break;
                                case "CharacterCasing":
                                    jsonReader.Read();
                                    ((ToolStripMenuItem)((ToolStripMenuItem)item.DropDownItems["seleccionDeEscritura"]).DropDownItems[(int)JsonSerializer.Deserialize<CharacterCasing>(jsonReader.GetString())]).Checked = true;
                                    this.txtContent.CharacterCasing = JsonSerializer.Deserialize<CharacterCasing>(jsonReader.GetString());
                                    break;
                                case "ForeColor":
                                    jsonReader.Read();
                                    this.txtContent.ForeColor = Color.FromArgb(jsonReader.GetInt32());
                                    break;
                                case "BackColor":
                                    jsonReader.Read();
                                    this.txtContent.BackColor = Color.FromArgb(jsonReader.GetInt32());
                                    break;
                                case "Font":
                                    jsonReader.Read();
                                    jsonReader.Read();
                                    FontFamily fontFamily = new FontFamily(jsonReader.GetString());
                                    jsonReader.Read();
                                    float size = (float)jsonReader.GetDouble();
                                    this.txtContent.Font = new Font(fontFamily, size);
                                    break;
                                case "Dir":
                                    jsonReader.Read();
                                    ChangeFile(jsonReader.GetString());
                                    break;
                                case "RecentFiles":
                                    jsonReader.Read();
                                    ArrayList aux = JsonSerializer.Deserialize<ArrayList>(jsonReader.GetString());
                                    foreach (JsonElement element in aux)
                                    {
                                        CheckRecentFiles(element.ToString());
                                    }
                                    break;
                            }
                        }
                        catch (Exception ex) when (ex is JsonException || ex is ArgumentException || ex is ArgumentNullException || ex is System.Security.SecurityException)
                        {
                            if (MessageBox.Show("Config file is corrupted" + Environment.NewLine + "The program will start using default settings!" + Environment.NewLine + "Would you like to erase it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    configFile.Delete();
                                }
                                catch (Exception ex2) when  (ex2 is IOException ||ex2 is System.Security.SecurityException ||ex is UnauthorizedAccessException)
                                {
                                    MessageBox.Show("Failed to delete the configuration file, please do so manually!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MenuSelectionInfo(object sender, EventArgs e)
        {
            this.info = new Form3(this);
            UpdateSelectionInfo();
            this.info.Show();
        }

        private void txtContent_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateSelectionInfo();
        }

        private void txtContent_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSelectionInfo();
        }

        private void UpdateSelectionInfo()
        {
            if (this.info != null)
            {
                this.info.txtBegining.Text = this.txtContent.SelectionStart.ToString();
                this.info.txtLength.Text = this.txtContent.SelectionLength.ToString();
            }
        }

        /*private void print_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog print = new PrintDialog();
                PrintDocument document = new PrintDocument();
                document.PrintPage += (Object sender2, PrintPageEventArgs e2) =>
                {
                    int numLines = (int)(e2.MarginBounds.Height / this.txtContent.Font.GetHeight(e2.Graphics));
                    for (int i = 0; i < this.txtContent.Lines.Length && i < numLines; i++)
                    {
                        Rectangle rectPage = new Rectangle(0, i * this.txtContent.Font.Height, e2.PageBounds.Width, e2.PageBounds.Height);
                        string currentLine = this.txtContent.Lines[i];
                        if (e2.Graphics.MeasureString(currentLine, this.txtContent.Font,e2.PageBounds.Width).Width > rectPage.Width)
                        {
                            MessageBox.Show("a");
                        }
                        if (currentLine.Length > e2.Graphics.MeasureString(currentLine, this.txtContent.Font).Width)
                        {
                            currentLine = currentLine.Replace(currentLine.Substring(e2.MarginBounds.Right, currentLine.Length), Environment.NewLine + currentLine.Substring(e2.MarginBounds.Right, currentLine.Length));
                        }
                        //TextRenderer.DrawText("",this.txtContent.Font);
                        //e2.Graphics.DrawString(currentLine, this.txtContent.Font, new SolidBrush(this.txtContent.ForeColor), e2.PageBounds.Left, i * this.txtContent.Font.Height);
                        e2.Graphics.DrawString(currentLine, this.txtContent.Font, new SolidBrush(this.txtContent.ForeColor),rectPage);
                    }
                };
                print.Document = document;
                print.AllowSelection = true;
                DialogResult result = print.ShowDialog();
                if (result == DialogResult.OK)
                {
                    print.Document.Print();
                }
            }
            catch (Exception ex) when (ex is IOException ||ex is ArgumentException || ex is ArgumentNullException || ex is InvalidPrinterException ||ex is System.Security.SecurityException)
            {
                MessageBox.Show("Failed to print the file!");
            }
        }*/
    }
}
