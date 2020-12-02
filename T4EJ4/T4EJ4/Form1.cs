using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace T4EJ4
{
    public partial class Form1 : Form
    {
        private Hashtable operations;
        private delegate void functions();
        private RadioButton checkedRad = null;
        Timer timer = new Timer();
        int min = 0;
        int seg = 0;
        public Form1()
        {
            InitializeComponent();
            operations = new Hashtable();
            operations.Add("Add", new functions(() => {
                if (!string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(this.textBox2.Text))
                {
                    try
                    {
                        double res = double.Parse(this.textBox1.Text.ToString()) + double.Parse(this.textBox2.Text.ToString());
                        MessageBox.Show(res.ToString());
                    }
                    catch (Exception ex) when (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    {
                        MessageBox.Show("Enter valid numbers!");
                    }
                }
            }));
            operations.Add("Substract", new functions(() => {
                if (!string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(this.textBox2.Text))
                {
                    try
                    {
                        double res = double.Parse(this.textBox1.Text.ToString()) - double.Parse(this.textBox2.Text.ToString());
                        MessageBox.Show(res.ToString());
                    }
                    catch (Exception ex) when (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    {
                        MessageBox.Show("Enter valid numbers!");
                    }
                }
            }));
            operations.Add("Multiply", new functions(() => {
                if (!string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(this.textBox2.Text))
                {
                    try
                    {
                        double res = double.Parse(this.textBox1.Text.ToString()) * double.Parse(this.textBox2.Text.ToString());
                        MessageBox.Show(res.ToString());
                    }
                    catch (Exception ex) when (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    {
                        MessageBox.Show("Enter valid numbers!");
                    }
                }
            }));
            operations.Add("Division", new functions(() => {
                if (!string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(this.textBox2.Text))
                {
                    try
                    {
                        double res = double.Parse(this.textBox1.Text.ToString()) / double.Parse(this.textBox2.Text.ToString());
                        MessageBox.Show(res.ToString());
                    }
                    catch (Exception ex) when (ex is FormatException || ex is ArgumentNullException || ex is OverflowException)
                    {
                        MessageBox.Show("Enter valid numbers!");
                    }
                }
            }));
            this.radioButton2.CheckedChanged += radioButton1_CheckedChanged;
            this.radioButton3.CheckedChanged += radioButton1_CheckedChanged;
            this.radioButton4.CheckedChanged += radioButton1_CheckedChanged;
            this.timer.Tick +=
            (Object sender, EventArgs e) => {
                if (seg >= 60)
                {
                    min++;
                }
                else
                {
                    seg++;
                }
                this.Text = string.Format("{0,2}:{1,2}", min, seg);
            };
            timer.Interval = 1000;
            timer.Start();
        }

        public void NotImplementedYet() => MessageBox.Show("Not implemented yet!");

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                checkedRad = (RadioButton)sender;
                this.label1.Text = ((Control)sender).Tag.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedRad != null)
            {
                ((functions)operations[checkedRad.Text.ToString()])();
            }
        }
    }
}
