
namespace T4EJ9
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listViewStudents = new System.Windows.Forms.ListView();
            this.studentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mathematics = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.physics = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tecnicalDrawing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.algebra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTable = new System.Windows.Forms.Button();
            this.txtSubjectMedian = new System.Windows.Forms.TextBox();
            this.lblSubjectMedian = new System.Windows.Forms.Label();
            this.lblStudenMedian = new System.Windows.Forms.Label();
            this.txtStudentMedian = new System.Windows.Forms.TextBox();
            this.lblHighest = new System.Windows.Forms.Label();
            this.txtHighest = new System.Windows.Forms.TextBox();
            this.lblLowest = new System.Windows.Forms.Label();
            this.txtLowest = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewStudents
            // 
            this.listViewStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.studentName,
            this.mathematics,
            this.physics,
            this.tecnicalDrawing,
            this.algebra});
            this.listViewStudents.HideSelection = false;
            this.listViewStudents.Location = new System.Drawing.Point(155, 58);
            this.listViewStudents.Name = "listViewStudents";
            this.listViewStudents.Size = new System.Drawing.Size(410, 252);
            this.listViewStudents.TabIndex = 0;
            this.listViewStudents.UseCompatibleStateImageBehavior = false;
            this.listViewStudents.View = System.Windows.Forms.View.Details;
            this.listViewStudents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewStudents_ColumnClick);
            this.listViewStudents.SelectedIndexChanged += new System.EventHandler(this.listViewStudents_SelectedIndexChanged);
            // 
            // studentName
            // 
            this.studentName.Text = "Name";
            this.studentName.Width = 54;
            // 
            // mathematics
            // 
            this.mathematics.Text = "Mathematics";
            this.mathematics.Width = 106;
            // 
            // physics
            // 
            this.physics.Text = "Physics";
            // 
            // tecnicalDrawing
            // 
            this.tecnicalDrawing.Text = "Tecnical drawing";
            this.tecnicalDrawing.Width = 113;
            // 
            // algebra
            // 
            this.algebra.Text = "Algebra";
            this.algebra.Width = 71;
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(32, 58);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(111, 23);
            this.btnTable.TabIndex = 1;
            this.btnTable.Text = "Show whole class";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.WholeTable);
            // 
            // txtSubjectMedian
            // 
            this.txtSubjectMedian.Location = new System.Drawing.Point(32, 385);
            this.txtSubjectMedian.Name = "txtSubjectMedian";
            this.txtSubjectMedian.Size = new System.Drawing.Size(100, 20);
            this.txtSubjectMedian.TabIndex = 2;
            this.txtSubjectMedian.TabStop = false;
            // 
            // lblSubjectMedian
            // 
            this.lblSubjectMedian.AutoSize = true;
            this.lblSubjectMedian.Location = new System.Drawing.Point(32, 366);
            this.lblSubjectMedian.Name = "lblSubjectMedian";
            this.lblSubjectMedian.Size = new System.Drawing.Size(87, 13);
            this.lblSubjectMedian.TabIndex = 3;
            this.lblSubjectMedian.Text = "Subject\'s median";
            // 
            // lblStudenMedian
            // 
            this.lblStudenMedian.AutoSize = true;
            this.lblStudenMedian.Location = new System.Drawing.Point(298, 366);
            this.lblStudenMedian.Name = "lblStudenMedian";
            this.lblStudenMedian.Size = new System.Drawing.Size(88, 13);
            this.lblStudenMedian.TabIndex = 5;
            this.lblStudenMedian.Text = "Student\'s median";
            // 
            // txtStudentMedian
            // 
            this.txtStudentMedian.Location = new System.Drawing.Point(298, 385);
            this.txtStudentMedian.Name = "txtStudentMedian";
            this.txtStudentMedian.Size = new System.Drawing.Size(100, 20);
            this.txtStudentMedian.TabIndex = 4;
            this.txtStudentMedian.TabStop = false;
            // 
            // lblHighest
            // 
            this.lblHighest.AutoSize = true;
            this.lblHighest.Location = new System.Drawing.Point(415, 366);
            this.lblHighest.Name = "lblHighest";
            this.lblHighest.Size = new System.Drawing.Size(118, 13);
            this.lblHighest.TabIndex = 7;
            this.lblHighest.Text = "Student\'s highest grade";
            // 
            // txtHighest
            // 
            this.txtHighest.Location = new System.Drawing.Point(415, 385);
            this.txtHighest.Name = "txtHighest";
            this.txtHighest.Size = new System.Drawing.Size(100, 20);
            this.txtHighest.TabIndex = 6;
            this.txtHighest.TabStop = false;
            // 
            // lblLowest
            // 
            this.lblLowest.AutoSize = true;
            this.lblLowest.Location = new System.Drawing.Point(539, 366);
            this.lblLowest.Name = "lblLowest";
            this.lblLowest.Size = new System.Drawing.Size(114, 13);
            this.lblLowest.TabIndex = 9;
            this.lblLowest.Text = "Student\'s lowest grade";
            // 
            // txtLowest
            // 
            this.txtLowest.Location = new System.Drawing.Point(539, 385);
            this.txtLowest.Name = "txtLowest";
            this.txtLowest.Size = new System.Drawing.Size(100, 20);
            this.txtLowest.TabIndex = 8;
            this.txtLowest.TabStop = false;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(186, 366);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(76, 13);
            this.lblClass.TabIndex = 11;
            this.lblClass.Text = "Class\'s median";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(186, 385);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 20);
            this.txtClass.TabIndex = 10;
            this.txtClass.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Passed students";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblLowest);
            this.Controls.Add(this.txtLowest);
            this.Controls.Add(this.lblHighest);
            this.Controls.Add(this.txtHighest);
            this.Controls.Add(this.lblStudenMedian);
            this.Controls.Add(this.txtStudentMedian);
            this.Controls.Add(this.lblSubjectMedian);
            this.Controls.Add(this.txtSubjectMedian);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.listViewStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.ColumnHeader studentName;
        private System.Windows.Forms.ColumnHeader mathematics;
        private System.Windows.Forms.ColumnHeader physics;
        private System.Windows.Forms.ColumnHeader tecnicalDrawing;
        private System.Windows.Forms.ColumnHeader algebra;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.TextBox txtSubjectMedian;
        private System.Windows.Forms.Label lblSubjectMedian;
        private System.Windows.Forms.Label lblStudenMedian;
        private System.Windows.Forms.TextBox txtStudentMedian;
        private System.Windows.Forms.Label lblHighest;
        private System.Windows.Forms.TextBox txtHighest;
        private System.Windows.Forms.Label lblLowest;
        private System.Windows.Forms.TextBox txtLowest;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Button button1;
    }
}

