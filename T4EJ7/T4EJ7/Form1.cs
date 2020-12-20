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
namespace T4EJ7
{
    public partial class Form1 : Form
    {
        private ArrayList recentFiles = new ArrayList();
        private bool saved = true;
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

        private void MenuNewAndSave(Object sender, EventArgs e)
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
                try {
                    if (!saving)
                    {
                        this.txtContent.Text = "";
                        FileInfo file = new FileInfo(save.FileName);
                        file.Create();
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(save.FileName, true))
                        {
                            if (this.txtContent.Text.Trim().Length > 0)
                            {
                                for (int i = 0; i < this.txtContent.Lines.Count(); i++)
                                {
                                    writer.WriteLine(this.txtContent.Lines[i]);
                                }
                                this.saved = true;
                            }
                        }
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
                catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException || ex is NotSupportedException || ex is System.Security.SecurityException || ex is IOException)
                {
                    Console.WriteLine(ex.Message);
                    if (saving)
                    {
                        this.saved = false;
                        MessageBox.Show("Failed to save!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to create a new file!");
                    }
                }
            }
        }

        private void MenuOpenFile(Object sender, EventArgs e)
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
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is UnauthorizedAccessException || ex is PathTooLongException || ex is NotSupportedException || ex is System.Security.SecurityException || ex is IOException)
                {
                    MessageBox.Show("Failed to open the file!");
                }
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
            this.saved = true;
        }

        private void ContentTextChanged(Object sender, EventArgs e)
        {
            this.saved = false;
            updateToolTip();
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
        }

        private void MenuTextSelectionChanged(Object sender, EventArgs e)
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
            FontDialog fontPicker = new FontDialog();
            DialogResult dialogResult = fontPicker.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.txtContent.Font = fontPicker.Font;
            }
        }

        private void RecentFiles(Object sender,EventArgs e)
        {
            ToolStripDropDownItem recientes = (ToolStripDropDownItem)((ToolStripDropDownItem)this.menuStrip1.Items[0]).DropDownItems[3];
            recientes.DropDownItems.Clear();
            for (int i = 0;i < this.recentFiles.Count;i++)
            {
                string current = this.recentFiles[i].ToString();
                ToolStripItem recent = new ToolStripMenuItem(current);
                recent.Click += (Object sender2, EventArgs e2) =>
                {
                    using (StreamReader reader = new StreamReader(current))//this.recentFiles[i].ToString() ArrayIndexOutOfBounds
                    {
                        this.txtContent.Text = "";
                        this.txtContent.Text += reader.ReadToEnd();
                    }
                };
                recientes.DropDownItems.Add(recent);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
                            jsonWriter.WriteString("Dir", (string)this.recentFiles[0]);
                            jsonWriter.WriteString("RecentFiles",JsonSerializer.Serialize<ArrayList>(this.recentFiles));
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

                }
                MessageBox.Show("Failed to create the configuration file!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                                    this.txtContent.Text = File.ReadAllText(jsonReader.GetString());
                                    break;
                                case "RecentFiles":
                                    jsonReader.Read();
                                    this.recentFiles = JsonSerializer.Deserialize<ArrayList>(jsonReader.GetString());
                                    break;
                            }
                        }
                        catch (Exception ex)//TODO: Controlar excepciones
                        {

                        }
                    }
                }
            }
        }
    }
}
