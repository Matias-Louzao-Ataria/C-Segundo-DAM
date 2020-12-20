
namespace T4EJ7
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBegining = new System.Windows.Forms.TextBox();
            this.lblBegining = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBegining
            // 
            this.txtBegining.Location = new System.Drawing.Point(22, 37);
            this.txtBegining.Name = "txtBegining";
            this.txtBegining.Size = new System.Drawing.Size(100, 20);
            this.txtBegining.TabIndex = 0;
            // 
            // lblBegining
            // 
            this.lblBegining.AutoSize = true;
            this.lblBegining.Location = new System.Drawing.Point(19, 21);
            this.lblBegining.Name = "lblBegining";
            this.lblBegining.Size = new System.Drawing.Size(48, 13);
            this.lblBegining.TabIndex = 1;
            this.lblBegining.Text = "Begining";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(173, 21);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 3;
            this.lblLength.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(176, 37);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(111, 63);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 95);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.lblBegining);
            this.Controls.Add(this.txtBegining);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Selection info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBegining;
        private System.Windows.Forms.Label lblLength;
        public System.Windows.Forms.TextBox txtBegining;
        public System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Button btnApply;
    }
}