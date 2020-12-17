namespace T4EJ7
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.archivosrecientes = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editar = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortar = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionartodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDeLaSelecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.ajusteDeLinea = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionDeEscritura = new System.Windows.Forms.ToolStripMenuItem();
            this.mayusculas = new System.Windows.Forms.ToolStripMenuItem();
            this.minusculas = new System.Windows.Forms.ToolStripMenuItem();
            this.normal = new System.Windows.Forms.ToolStripMenuItem();
            this.color = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDetexto = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDeFondo = new System.Windows.Forms.ToolStripMenuItem();
            this.fuente = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.ademas = new System.Windows.Forms.ToolStripMenuItem();
            this.contenido = new System.Windows.Forms.ToolStripMenuItem();
            this.indice = new System.Windows.Forms.ToolStripMenuItem();
            this.buscar = new System.Windows.Forms.ToolStripMenuItem();
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevo = new System.Windows.Forms.ToolStripButton();
            this.abrir = new System.Windows.Forms.ToolStripButton();
            this.cortarStrip = new System.Windows.Forms.ToolStripButton();
            this.copiarStrip = new System.Windows.Forms.ToolStripButton();
            this.pegarStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivo,
            this.editar,
            this.herramientas,
            this.ademas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivo
            // 
            this.archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardar,
            this.archivosrecientes,
            this.salirToolStripMenuItem});
            this.archivo.Name = "archivo";
            this.archivo.Size = new System.Drawing.Size(60, 20);
            this.archivo.Text = "&Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nuevoToolStripMenuItem.Text = "&Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.MenuNewAndSave);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.MenuOpenFile);
            // 
            // guardar
            // 
            this.guardar.Image = ((System.Drawing.Image)(resources.GetObject("guardar.Image")));
            this.guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardar.Name = "guardar";
            this.guardar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardar.Size = new System.Drawing.Size(170, 22);
            this.guardar.Text = "&Guardar";
            this.guardar.Click += new System.EventHandler(this.MenuNewAndSave);
            // 
            // archivosrecientes
            // 
            this.archivosrecientes.Name = "archivosrecientes";
            this.archivosrecientes.Size = new System.Drawing.Size(170, 22);
            this.archivosrecientes.Text = "Archivos &recientes";
            this.archivosrecientes.MouseHover += new System.EventHandler(this.RecentFiles);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // editar
            // 
            this.editar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem,
            this.cortar,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.seleccionartodoToolStripMenuItem,
            this.informacionDeLaSelecciónToolStripMenuItem});
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(49, 20);
            this.editar.Text = "&Editar";
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.deshacerToolStripMenuItem.Text = "&Deshacer";
            this.deshacerToolStripMenuItem.Click += new System.EventHandler(this.MenuUndo);
            // 
            // cortar
            // 
            this.cortar.Image = ((System.Drawing.Image)(resources.GetObject("cortar.Image")));
            this.cortar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortar.Name = "cortar";
            this.cortar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortar.Size = new System.Drawing.Size(256, 22);
            this.cortar.Text = "Cor&tar";
            this.cortar.Click += new System.EventHandler(this.MenuCopy);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copiarToolStripMenuItem.Image")));
            this.copiarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.copiarToolStripMenuItem.Text = "&Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.MenuCopy);
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pegarToolStripMenuItem.Image")));
            this.pegarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.pegarToolStripMenuItem.Text = "&Pegar";
            this.pegarToolStripMenuItem.Click += new System.EventHandler(this.MenuPaste);
            // 
            // seleccionartodoToolStripMenuItem
            // 
            this.seleccionartodoToolStripMenuItem.Name = "seleccionartodoToolStripMenuItem";
            this.seleccionartodoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.seleccionartodoToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.seleccionartodoToolStripMenuItem.Text = "&Seleccionar todo";
            this.seleccionartodoToolStripMenuItem.Click += new System.EventHandler(this.SelectAll);
            // 
            // informacionDeLaSelecciónToolStripMenuItem
            // 
            this.informacionDeLaSelecciónToolStripMenuItem.Name = "informacionDeLaSelecciónToolStripMenuItem";
            this.informacionDeLaSelecciónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.informacionDeLaSelecciónToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.informacionDeLaSelecciónToolStripMenuItem.Text = "&Informacion de la selección";
            // 
            // herramientas
            // 
            this.herramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajusteDeLinea,
            this.seleccionDeEscritura,
            this.color,
            this.fuente,
            this.acercaDe});
            this.herramientas.Name = "herramientas";
            this.herramientas.Size = new System.Drawing.Size(90, 20);
            this.herramientas.Text = "&Herramientas";
            // 
            // ajusteDeLinea
            // 
            this.ajusteDeLinea.CheckOnClick = true;
            this.ajusteDeLinea.Name = "ajusteDeLinea";
            this.ajusteDeLinea.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.ajusteDeLinea.Size = new System.Drawing.Size(189, 22);
            this.ajusteDeLinea.Text = "A&juste de linea";
            this.ajusteDeLinea.CheckedChanged += new System.EventHandler(this.MenuWordWrapCheckedChange);
            // 
            // seleccionDeEscritura
            // 
            this.seleccionDeEscritura.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mayusculas,
            this.minusculas,
            this.normal});
            this.seleccionDeEscritura.Name = "seleccionDeEscritura";
            this.seleccionDeEscritura.Size = new System.Drawing.Size(189, 22);
            this.seleccionDeEscritura.Text = "Se&lección de escritura";
            // 
            // mayusculas
            // 
            this.mayusculas.CheckOnClick = true;
            this.mayusculas.Name = "mayusculas";
            this.mayusculas.Size = new System.Drawing.Size(136, 22);
            this.mayusculas.Tag = "CharacterCasing.Upper";
            this.mayusculas.Text = "Ma&yúsculas";
            this.mayusculas.CheckedChanged += new System.EventHandler(this.MenuTextSelectionChanged);
            // 
            // minusculas
            // 
            this.minusculas.CheckOnClick = true;
            this.minusculas.Name = "minusculas";
            this.minusculas.Size = new System.Drawing.Size(136, 22);
            this.minusculas.Text = "M&inúsculas";
            this.minusculas.CheckedChanged += new System.EventHandler(this.MenuTextSelectionChanged);
            // 
            // normal
            // 
            this.normal.CheckOnClick = true;
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(136, 22);
            this.normal.Text = "&Normal";
            this.normal.CheckedChanged += new System.EventHandler(this.MenuTextSelectionChanged);
            // 
            // color
            // 
            this.color.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorDetexto,
            this.colorDeFondo});
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(189, 22);
            this.color.Text = "&Color";
            // 
            // colorDetexto
            // 
            this.colorDetexto.Name = "colorDetexto";
            this.colorDetexto.Size = new System.Drawing.Size(154, 22);
            this.colorDetexto.Text = "Color de &texto";
            this.colorDetexto.Click += new System.EventHandler(this.MenuColorPicker);
            // 
            // colorDeFondo
            // 
            this.colorDeFondo.Name = "colorDeFondo";
            this.colorDeFondo.Size = new System.Drawing.Size(154, 22);
            this.colorDeFondo.Text = "Color de &fondo";
            this.colorDeFondo.Click += new System.EventHandler(this.MenuColorPicker);
            // 
            // fuente
            // 
            this.fuente.Name = "fuente";
            this.fuente.Size = new System.Drawing.Size(189, 22);
            this.fuente.Text = "&Fuente";
            this.fuente.Click += new System.EventHandler(this.MenuFontPicker);
            // 
            // acercaDe
            // 
            this.acercaDe.Name = "acercaDe";
            this.acercaDe.Size = new System.Drawing.Size(189, 22);
            this.acercaDe.Text = "Acerca de...";
            this.acercaDe.Click += new System.EventHandler(this.MenuAboutLambda);
            // 
            // ademas
            // 
            this.ademas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contenido,
            this.indice,
            this.buscar,
            this.acercadeToolStripMenuItem});
            this.ademas.Name = "ademas";
            this.ademas.Size = new System.Drawing.Size(62, 20);
            this.ademas.Text = "A&demás";
            // 
            // contenido
            // 
            this.contenido.Name = "contenido";
            this.contenido.Size = new System.Drawing.Size(135, 22);
            this.contenido.Text = "&Contenido";
            // 
            // indice
            // 
            this.indice.Name = "indice";
            this.indice.Size = new System.Drawing.Size(135, 22);
            this.indice.Text = "Índic&e";
            // 
            // buscar
            // 
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(135, 22);
            this.buscar.Text = "&Buscar";
            // 
            // acercadeToolStripMenuItem
            // 
            this.acercadeToolStripMenuItem.Name = "acercadeToolStripMenuItem";
            this.acercadeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercadeToolStripMenuItem.Text = "&Acerca de...";
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtContent.Location = new System.Drawing.Point(0, 47);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(800, 403);
            this.txtContent.TabIndex = 1;
            this.txtContent.WordWrap = false;
            this.txtContent.TextChanged += new System.EventHandler(this.ContentTextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevo,
            this.abrir,
            this.toolStripSeparator1,
            this.cortarStrip,
            this.copiarStrip,
            this.pegarStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevo
            // 
            this.nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevo.Image = ((System.Drawing.Image)(resources.GetObject("nuevo.Image")));
            this.nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(23, 22);
            this.nuevo.Text = "&Nuevo";
            this.nuevo.Click += new System.EventHandler(this.MenuNewAndSave);
            // 
            // abrir
            // 
            this.abrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrir.Image = ((System.Drawing.Image)(resources.GetObject("abrir.Image")));
            this.abrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(23, 22);
            this.abrir.Text = "&Abrir";
            this.abrir.Click += new System.EventHandler(this.MenuOpenFile);
            // 
            // cortarStrip
            // 
            this.cortarStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cortarStrip.Image = ((System.Drawing.Image)(resources.GetObject("cortarStrip.Image")));
            this.cortarStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortarStrip.Name = "cortarStrip";
            this.cortarStrip.Size = new System.Drawing.Size(23, 22);
            this.cortarStrip.Text = "Cort&ar";
            this.cortarStrip.Click += new System.EventHandler(this.MenuCopy);
            // 
            // copiarStrip
            // 
            this.copiarStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copiarStrip.Image = ((System.Drawing.Image)(resources.GetObject("copiarStrip.Image")));
            this.copiarStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiarStrip.Name = "copiarStrip";
            this.copiarStrip.Size = new System.Drawing.Size(23, 22);
            this.copiarStrip.Text = "&Copiar";
            this.copiarStrip.Click += new System.EventHandler(this.MenuCopy);
            // 
            // pegarStrip
            // 
            this.pegarStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pegarStrip.Image = ((System.Drawing.Image)(resources.GetObject("pegarStrip.Image")));
            this.pegarStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pegarStrip.Name = "pegarStrip";
            this.pegarStrip.Size = new System.Drawing.Size(23, 22);
            this.pegarStrip.Text = "&Pegar";
            this.pegarStrip.Click += new System.EventHandler(this.MenuPaste);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Text Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivo;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardar;
        private System.Windows.Forms.ToolStripMenuItem archivosrecientes;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editar;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortar;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionartodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionDeLaSelecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientas;
        private System.Windows.Forms.ToolStripMenuItem ajusteDeLinea;
        private System.Windows.Forms.ToolStripMenuItem seleccionDeEscritura;
        private System.Windows.Forms.ToolStripMenuItem color;
        private System.Windows.Forms.ToolStripMenuItem acercaDe;
        private System.Windows.Forms.ToolStripMenuItem ademas;
        private System.Windows.Forms.ToolStripMenuItem contenido;
        private System.Windows.Forms.ToolStripMenuItem indice;
        private System.Windows.Forms.ToolStripMenuItem buscar;
        private System.Windows.Forms.ToolStripMenuItem acercadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mayusculas;
        private System.Windows.Forms.ToolStripMenuItem minusculas;
        private System.Windows.Forms.ToolStripMenuItem normal;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ToolStripMenuItem fuente;
        private System.Windows.Forms.ToolStripMenuItem colorDetexto;
        private System.Windows.Forms.ToolStripMenuItem colorDeFondo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuevo;
        private System.Windows.Forms.ToolStripButton abrir;
        private System.Windows.Forms.ToolStripButton cortarStrip;
        private System.Windows.Forms.ToolStripButton copiarStrip;
        private System.Windows.Forms.ToolStripButton pegarStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

