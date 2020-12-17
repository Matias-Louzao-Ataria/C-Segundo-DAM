namespace T4EJ8
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRetirada = new System.Windows.Forms.Button();
            this.btnAvanti = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblDir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(111, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnRetirada
            // 
            this.btnRetirada.Location = new System.Drawing.Point(12, 123);
            this.btnRetirada.Name = "btnRetirada";
            this.btnRetirada.Size = new System.Drawing.Size(75, 23);
            this.btnRetirada.TabIndex = 1;
            this.btnRetirada.Text = "Previous";
            this.btnRetirada.UseVisualStyleBackColor = true;
            this.btnRetirada.Click += new System.EventHandler(this.BtnRetirada_Click);
            // 
            // btnAvanti
            // 
            this.btnAvanti.Location = new System.Drawing.Point(216, 123);
            this.btnAvanti.Name = "btnAvanti";
            this.btnAvanti.Size = new System.Drawing.Size(75, 23);
            this.btnAvanti.TabIndex = 2;
            this.btnAvanti.Text = "Next";
            this.btnAvanti.UseVisualStyleBackColor = true;
            this.btnAvanti.Click += new System.EventHandler(this.BtnAvanti_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 69);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 3;
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(15, 104);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(0, 13);
            this.lblDir.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(303, 162);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnAvanti);
            this.Controls.Add(this.btnRetirada);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Image visualizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitConfirmation);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRetirada;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Label lblDir;
    }
}

