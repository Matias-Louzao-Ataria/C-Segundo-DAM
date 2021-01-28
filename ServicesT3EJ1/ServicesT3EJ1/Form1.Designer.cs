namespace ServicesT3EJ1
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
            this.lblServer = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnsend = new System.Windows.Forms.Button();
            this.btnHora = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(101, 51);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(577, 233);
            this.lblServer.TabIndex = 0;
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(104, 342);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(574, 20);
            this.txtCommand.TabIndex = 1;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(101, 9);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(349, 389);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.Connect);
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(697, 338);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 23);
            this.btnsend.TabIndex = 4;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.send);
            // 
            // btnHora
            // 
            this.btnHora.Location = new System.Drawing.Point(104, 287);
            this.btnHora.Name = "btnHora";
            this.btnHora.Size = new System.Drawing.Size(75, 23);
            this.btnHora.TabIndex = 5;
            this.btnHora.Text = "Hora";
            this.btnHora.UseVisualStyleBackColor = true;
            this.btnHora.Click += new System.EventHandler(this.BtnHora_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(185, 287);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(75, 23);
            this.btnFecha.TabIndex = 6;
            this.btnFecha.Text = "Fecha";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.BtnHora_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(266, 287);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(75, 23);
            this.btnTodo.TabIndex = 7;
            this.btnTodo.Text = "Todo";
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.BtnHora_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(347, 287);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(75, 23);
            this.btnApagar.TabIndex = 8;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.BtnHora_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnsend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnTodo);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.btnHora);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.lblServer);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Button btnHora;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Button btnApagar;
    }
}

