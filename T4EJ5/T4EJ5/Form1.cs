using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4EJ5
{
    public partial class Form1 : Form
    {
        private int contTimer = 0,contStr;
        private Timer timer = new Timer();
        private Icon icon;
        private string str;
        public Form1()
        {
            InitializeComponent();
            this.listBox1.SelectedIndexChanged += (Object sender, EventArgs e) => UpdateList();
            this.icon = this.Icon; 
            this.timer.Tick += TimerFunction;
            timer.Interval = 200;
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (text.Trim().Length > 0)
            {
                this.listBox1.Items.Add(text);
                UpdateList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection items = this.listBox1.Items;
            if (items.Count > 0)
            {
                ListBox.SelectedObjectCollection selected = this.listBox1.SelectedItems;
                if (selected.Count > 0)
                {
                    int removeCount = selected.Count;
                    for (int i = removeCount -1; i >= 0; i--)
                    {
                        this.listBox1.Items.Remove(selected[i]);
                    }
                    UpdateList();
                }
                else
                {
                    MessageBox.Show("No selected items!");
                }
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
        }

        private void TimerFunction(Object sender,EventArgs e)
        {
            string original = "titulo form";
            if (string.IsNullOrEmpty(str))
            {
                contStr = original.Length-1;
            }
            else if(contStr != 0 && !string.IsNullOrEmpty(str))
            {
                contStr--;
            }
          
            str = original[contStr]+str;

            if (contStr == 0)
            {
                str = "";
            }
            
            if (contTimer % 2 == 0 && contTimer != 0)
            {
                if (this.Icon == this.icon)
                {
                    this.Icon = new Icon("a.ico");
                }
                else
                {
                    this.Icon = this.icon;
                }
            }
            if (contTimer < original.Length)
            {
                contTimer++;
            }
            else
            {
                contTimer = 0;
            }
            this.Text = str;
        }

        private void UpdateList()
        {
            this.label1.Text = ""+this.listBox1.Items.Count;
            if (this.listBox1.SelectedItems.Count > 0)
            {
                this.label2.Text = "";
                if (this.listBox1.SelectedIndices.Count > 0)
                {
                    for (int i = 0;i < this.listBox1.SelectedIndices.Count;i++)
                    {
                        this.label2.Text += this.listBox1.SelectedIndices[i]+" ";
                    }
                }
                else
                {
                    this.label2.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Traspasar(this.listBox1,this.listBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Traspasar(this.listBox2, this.listBox1);
        }

        private void Traspasar(ListBox origin,ListBox reciver)
        {
            ListBox.ObjectCollection items = origin.Items;
            if (items.Count > 0)
            {
                ListBox.SelectedObjectCollection selected = origin.SelectedItems;
                if (selected.Count > 0)
                {
                    int removeCount = selected.Count;
                    for (int i = removeCount-1; i >= 0 ; i--)
                    {
                        reciver.Items.Insert(0,selected[i]);
                        origin.Items.Remove(selected[i]);
                    }
                    UpdateList();
                }
                else
                {
                    MessageBox.Show("No selected items!");
                }
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
            this.toolTip1.SetToolTip(this.listBox2, this.listBox2.Items.Count.ToString());
        }
    }
}
