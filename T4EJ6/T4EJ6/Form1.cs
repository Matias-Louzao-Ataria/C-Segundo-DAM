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
namespace T4EJ6
{
    public partial class Form1 : Form
    {
        int[] passwd = { 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool acertado = false;
            int contFails = 0, contCorrect = 0;
            Form2 fPasswd = new Form2();
            do
            {
                DialogResult result = fPasswd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string response = fPasswd.txtpasswd.Text;
                    if (response.Length == this.passwd.Length)
                    {
                        for (int i = 0; i < this.passwd.Length; i++)
                        {
                            try{
                                if (int.Parse(""+response[i]) == this.passwd[i])
                                {
                                    contCorrect++;
                                }
                            }
                            catch (Exception ex) when (ex is FormatException ||ex is ArgumentNullException ||ex is OverflowException)
                            {
                                MessageBox.Show(Resource1.Numbers);
                                i = this.passwd.Length;
                            }
                        }
                        if (contCorrect == 4)
                        {
                            acertado = true;
                        }
                        else
                        {
                            contFails++;
                            fPasswd.label2.Text = Resource1.PIN;
                        }
                    }
                    else
                    {
                        contFails++;
                        fPasswd.label2.Text = Resource1.PIN;
                    }
                }
                else
                {
                    contFails = 3;
                }
            } while (!acertado && contFails < 3);
            if (contFails == 3)
            {
                this.Close();
            }
            if (acertado)
            {
                int mody = 0,modx = 0;
                for (int i = 0; i < 12; i++)
                {
                    string str = "";
                    Button boton = new Button();
                    if (i < 10)
                    {
                        str = "&"+i;
                    } else if (i == 10) {
                        str = "#";
                    }
                    else if(i == 11)
                    {
                        str = "*";
                    }

                    if (i % 3 == 0)
                    {
                        mody += 80;
                        modx = 0;
                    }
                    boton.Text = str;
                    boton.MouseEnter += MouseEnter;
                    boton.MouseLeave += MouseLeave;
                    if (i < 12)
                    {
                        boton.Click += ButtonClick;
                    }
         
                    boton.AutoSize = true;
                    boton.Location = new Point(5+modx,5+mody);
                    boton.TabIndex = i;
                    modx += 80;
                    this.Controls.Add(boton);
                }
            }
        }

        private void MouseEnter(Object sender,EventArgs e)
        {
            Control env = ((Button)sender);
            if (env.BackColor != Color.Yellow)
            {
                env.BackColor = Color.Blue;
            }
        }

        private void MouseLeave(Object sender, EventArgs e)
        {
            Control env = ((Button)sender);
            if (env.BackColor != Color.Yellow)
            {
                env.BackColor = Color.Transparent;
            }

        }

        private void ButtonClick(Object sender,EventArgs e)
        {
            this.txtPantalla.Text += ((Control)sender).Text.Replace("&","");
            ((Button)sender).BackColor = Color.Yellow;
        }

        private void ButtonReset(Object sender,EventArgs e)
        {
            this.txtPantalla.Text = "";
            for (int i = 0;i < this.Controls.Count;i++)
            {
                if (this.Controls[i] is Button)
                {
                    Button current = (Button)this.Controls[i];
                    current.BackColor = Color.Transparent;
                }
            }
        }

        private void MenuExitClick(Object sender,EventArgs e)
        {
            this.Close();
        }

        private void MenuSaveClick(Object sender,EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            DialogResult result;
            save.AddExtension = true;
            save.DefaultExt = "txt";
            save.Filter = "Txt (*.txt)|*.txt|All|*.*";
            result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.FileName,true))
                {
                    if (this.txtPantalla.Text.Trim().Length > 0)
                    {
                        try
                        {
                            writer.WriteLine(this.txtPantalla.Text);
                            MessageBox.Show(Resource1.NoError);
                        }
                        catch (Exception ex) when (ex is IOException)
                        {
                            MessageBox.Show(Resource1.Error);
                        }
                    }
                }
            }
        }
    }
}
