using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3EJ2;

namespace T4EJ9
{
    public partial class Form1 : Form
    {
        private Aula aula = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void WholeTable(Object sender,EventArgs e)
        {
            if (this.aula == null)
            {
                this.aula = new Aula();
            }
            this.listViewStudents.Items.Clear();
            this.txtClass.Text = string.Format("{0:0.000}", this.aula.median());
            for (int i = 0;i < this.aula.Grades.GetLength(0);i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = this.aula.Names[i];
                for (int j = 0;j < this.aula.Grades.GetLength(1); j++)
                {
                    item.SubItems.Add(this.aula.Grades[i,j].ToString());
                }
                this.listViewStudents.Items.Add(item);
            }
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            if (list.SelectedItems.Count > 0)
            {
                int pos = 0;
                double max = 0, min = 99;
                for (int i = 0; i < this.aula.Names.Length; i++)
                {
                    if (this.aula.Names[i] == list.SelectedItems[0].Text)
                    {
                        pos = i;
                    }
                }
                for (int i = 0; i < list.SelectedItems.Count; i++)
                {
                    this.aula.MaxMinStudentGrade(pos, ref max, ref min);
                    this.txtStudentMedian.Text = string.Format("{0:0.000}", this.aula.MedianStudent(pos));
                    this.txtHighest.Text = string.Format("{0:0.000}", max);
                    this.txtLowest.Text = string.Format("{0:0.000}", min);
                }
            }
        }

        private void listViewStudents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView list = (ListView)sender;
            if (e.Column != 0 && list.Items.Count > 0)
            {
                foreach (ColumnHeader c in list.Columns)
                {
                    if (c.Index == e.Column)
                    {
                        this.txtSubjectMedian.Text = string.Format("{0:0.000}", this.aula.MedianSubject((Subjects)c.Index));
                        this.lblSubjectMedian.Text = ((Subjects)e.Column).ToString()+"'s median";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.aula == null)
            {
                this.aula = new Aula();
            }
            this.listViewStudents.Items.Clear();
            Hashtable result = this.aula.PassedStudents();
            foreach (DictionaryEntry entry in result)
            {
                ListViewItem item = new ListViewItem();
                item.Text = this.aula.Names[int.Parse(entry.Key.ToString())];
                for (int i = 0; i < ((double[])entry.Value).Length; i++)
                {
                    item.SubItems.Add(string.Format("{0}",((double[])entry.Value)[i]));
                }
                this.listViewStudents.Items.Add(item);
            }
        }
    }
}
