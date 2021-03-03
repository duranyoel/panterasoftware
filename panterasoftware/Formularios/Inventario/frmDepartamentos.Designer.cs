namespace panterasoftware.Formularios.Inventario
{
    partial class frmDepartamentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrecioMinimo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioMayor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioOferta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecioMaximo = new System.Windows.Forms.TextBox();
            this.lblFicha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblNombreFoto = new System.Windows.Forms.Label();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.campoFoto = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePrecios = new System.Windows.Forms.TabPage();
            this.tabPageComisionVentas = new System.Windows.Forms.TabPage();
            this.tabPageComisionCobranza = new System.Windows.Forms.TabPage();
            this.txtCVPrecioMaximo = new System.Windows.Forms.TextBox();
            this.txtCVPrecioMinimo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCVPrecioOferta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCVPrecioMayor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCCPrecioMaximo = new System.Windows.Forms.TextBox();
            this.txtCCPrecioMinimo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCCPrecioOferta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCCPrecioMayor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buscarImagen = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.campoFoto)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPagePrecios.SuspendLayout();
            this.tabPageComisionVentas.SuspendLayout();
            this.tabPageComisionCobranza.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.toolStripSeparator2,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnSalir});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(568, 25);
            this.toolStripMenu.TabIndex = 20;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::panterasoftware.Properties.Resources.New;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(82, 22);
            this.btnNuevo.Text = "Nuevo(F1)";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::panterasoftware.Properties.Resources.grabar;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 22);
            this.btnGuardar.Text = "Guardar(F2)";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::panterasoftware.Properties.Resources.eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 22);
            this.btnEliminar.Text = "Eliminar(F3)";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::panterasoftware.Properties.Resources.salida;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(74, 22);
            this.btnSalir.Text = "Salir(Esc)";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblFicha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 75);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // txtPrecioMinimo
            // 
            this.txtPrecioMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioMinimo.Location = new System.Drawing.Point(175, 58);
            this.txtPrecioMinimo.MaxLength = 50;
            this.txtPrecioMinimo.Name = "txtPrecioMinimo";
            this.txtPrecioMinimo.Size = new System.Drawing.Size(160, 20);
            this.txtPrecioMinimo.TabIndex = 44;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(9, 32);
            this.txtCodigo.Mask = "#####";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(160, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(172, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "% Precio Mínimo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "% Precio Mayor:";
            // 
            // txtPrecioMayor
            // 
            this.txtPrecioMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioMayor.Location = new System.Drawing.Point(9, 58);
            this.txtPrecioMayor.MaxLength = 50;
            this.txtPrecioMayor.Name = "txtPrecioMayor";
            this.txtPrecioMayor.Size = new System.Drawing.Size(160, 20);
            this.txtPrecioMayor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(172, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "% Precio Oferta:";
            // 
            // txtPrecioOferta
            // 
            this.txtPrecioOferta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioOferta.Location = new System.Drawing.Point(175, 19);
            this.txtPrecioOferta.MaxLength = 50;
            this.txtPrecioOferta.Name = "txtPrecioOferta";
            this.txtPrecioOferta.Size = new System.Drawing.Size(160, 20);
            this.txtPrecioOferta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "% Precio Máximo:";
            // 
            // txtPrecioMaximo
            // 
            this.txtPrecioMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioMaximo.Location = new System.Drawing.Point(9, 19);
            this.txtPrecioMaximo.MaxLength = 50;
            this.txtPrecioMaximo.Name = "txtPrecioMaximo";
            this.txtPrecioMaximo.Size = new System.Drawing.Size(160, 20);
            this.txtPrecioMaximo.TabIndex = 2;
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFicha.Location = new System.Drawing.Point(64, 16);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(13, 13);
            this.lblFicha.TabIndex = 33;
            this.lblFicha.Text = "0";
            this.lblFicha.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(172, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(175, 32);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Codigo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgListado);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Location = new System.Drawing.Point(12, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 310);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado";
            // 
            // dgListado
            // 
            this.dgListado.AllowUserToAddRows = false;
            this.dgListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgListado.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListado.Location = new System.Drawing.Point(8, 45);
            this.dgListado.Name = "dgListado";
            this.dgListado.ReadOnly = true;
            this.dgListado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgListado.Size = new System.Drawing.Size(500, 259);
            this.dgListado.TabIndex = 1;
            this.dgListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListado_CellClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::panterasoftware.Properties.Resources.Search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(179, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar(F4)";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Location = new System.Drawing.Point(9, 19);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(160, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // lblNombreFoto
            // 
            this.lblNombreFoto.AutoSize = true;
            this.lblNombreFoto.Location = new System.Drawing.Point(386, 28);
            this.lblNombreFoto.Name = "lblNombreFoto";
            this.lblNombreFoto.Size = new System.Drawing.Size(41, 13);
            this.lblNombreFoto.TabIndex = 65;
            this.lblNombreFoto.Text = "label12";
            this.lblNombreFoto.Visible = false;
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.AutoSize = true;
            this.btnBuscarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarArchivo.Image = global::panterasoftware.Properties.Resources.Search;
            this.btnBuscarArchivo.Location = new System.Drawing.Point(389, 180);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(128, 26);
            this.btnBuscarArchivo.TabIndex = 64;
            this.btnBuscarArchivo.Text = "Buscar";
            this.btnBuscarArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarArchivo.UseCompatibleTextRendering = true;
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // campoFoto
            // 
            this.campoFoto.Image = global::panterasoftware.Properties.Resources.Factory;
            this.campoFoto.Location = new System.Drawing.Point(389, 46);
            this.campoFoto.Name = "campoFoto";
            this.campoFoto.Size = new System.Drawing.Size(128, 128);
            this.campoFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.campoFoto.TabIndex = 63;
            this.campoFoto.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePrecios);
            this.tabControl1.Controls.Add(this.tabPageComisionVentas);
            this.tabControl1.Controls.Add(this.tabPageComisionCobranza);
            this.tabControl1.Location = new System.Drawing.Point(12, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 128);
            this.tabControl1.TabIndex = 66;
            // 
            // tabPagePrecios
            // 
            this.tabPagePrecios.Controls.Add(this.txtPrecioMaximo);
            this.tabPagePrecios.Controls.Add(this.txtPrecioMinimo);
            this.tabPagePrecios.Controls.Add(this.label3);
            this.tabPagePrecios.Controls.Add(this.txtPrecioOferta);
            this.tabPagePrecios.Controls.Add(this.label4);
            this.tabPagePrecios.Controls.Add(this.label6);
            this.tabPagePrecios.Controls.Add(this.txtPrecioMayor);
            this.tabPagePrecios.Controls.Add(this.label5);
            this.tabPagePrecios.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrecios.Name = "tabPagePrecios";
            this.tabPagePrecios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrecios.Size = new System.Drawing.Size(360, 102);
            this.tabPagePrecios.TabIndex = 0;
            this.tabPagePrecios.Text = "Precios";
            this.tabPagePrecios.UseVisualStyleBackColor = true;
            // 
            // tabPageComisionVentas
            // 
            this.tabPageComisionVentas.Controls.Add(this.txtCVPrecioMaximo);
            this.tabPageComisionVentas.Controls.Add(this.txtCVPrecioMinimo);
            this.tabPageComisionVentas.Controls.Add(this.label7);
            this.tabPageComisionVentas.Controls.Add(this.txtCVPrecioOferta);
            this.tabPageComisionVentas.Controls.Add(this.label8);
            this.tabPageComisionVentas.Controls.Add(this.label9);
            this.tabPageComisionVentas.Controls.Add(this.txtCVPrecioMayor);
            this.tabPageComisionVentas.Controls.Add(this.label10);
            this.tabPageComisionVentas.Location = new System.Drawing.Point(4, 22);
            this.tabPageComisionVentas.Name = "tabPageComisionVentas";
            this.tabPageComisionVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComisionVentas.Size = new System.Drawing.Size(360, 102);
            this.tabPageComisionVentas.TabIndex = 1;
            this.tabPageComisionVentas.Text = "Comisión En Ventas";
            this.tabPageComisionVentas.UseVisualStyleBackColor = true;
            // 
            // tabPageComisionCobranza
            // 
            this.tabPageComisionCobranza.Controls.Add(this.txtCCPrecioMaximo);
            this.tabPageComisionCobranza.Controls.Add(this.txtCCPrecioMinimo);
            this.tabPageComisionCobranza.Controls.Add(this.label11);
            this.tabPageComisionCobranza.Controls.Add(this.txtCCPrecioOferta);
            this.tabPageComisionCobranza.Controls.Add(this.label12);
            this.tabPageComisionCobranza.Controls.Add(this.label13);
            this.tabPageComisionCobranza.Controls.Add(this.txtCCPrecioMayor);
            this.tabPageComisionCobranza.Controls.Add(this.label14);
            this.tabPageComisionCobranza.Location = new System.Drawing.Point(4, 22);
            this.tabPageComisionCobranza.Name = "tabPageComisionCobranza";
            this.tabPageComisionCobranza.Size = new System.Drawing.Size(360, 102);
            this.tabPageComisionCobranza.TabIndex = 2;
            this.tabPageComisionCobranza.Text = "Comisión En Cobranzas";
            this.tabPageComisionCobranza.UseVisualStyleBackColor = true;
            // 
            // txtCVPrecioMaximo
            // 
            this.txtCVPrecioMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVPrecioMaximo.Location = new System.Drawing.Point(9, 19);
            this.txtCVPrecioMaximo.MaxLength = 50;
            this.txtCVPrecioMaximo.Name = "txtCVPrecioMaximo";
            this.txtCVPrecioMaximo.Size = new System.Drawing.Size(160, 20);
            this.txtCVPrecioMaximo.TabIndex = 45;
            // 
            // txtCVPrecioMinimo
            // 
            this.txtCVPrecioMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVPrecioMinimo.Location = new System.Drawing.Point(175, 58);
            this.txtCVPrecioMinimo.MaxLength = 50;
            this.txtCVPrecioMinimo.Name = "txtCVPrecioMinimo";
            this.txtCVPrecioMinimo.Size = new System.Drawing.Size(160, 20);
            this.txtCVPrecioMinimo.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "% Precio Máximo:";
            // 
            // txtCVPrecioOferta
            // 
            this.txtCVPrecioOferta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVPrecioOferta.Location = new System.Drawing.Point(175, 19);
            this.txtCVPrecioOferta.MaxLength = 50;
            this.txtCVPrecioOferta.Name = "txtCVPrecioOferta";
            this.txtCVPrecioOferta.Size = new System.Drawing.Size(160, 20);
            this.txtCVPrecioOferta.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(172, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "% Precio Oferta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(172, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "% Precio Mínimo:";
            // 
            // txtCVPrecioMayor
            // 
            this.txtCVPrecioMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVPrecioMayor.Location = new System.Drawing.Point(9, 58);
            this.txtCVPrecioMayor.MaxLength = 50;
            this.txtCVPrecioMayor.Name = "txtCVPrecioMayor";
            this.txtCVPrecioMayor.Size = new System.Drawing.Size(160, 20);
            this.txtCVPrecioMayor.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "% Precio Mayor:";
            // 
            // txtCCPrecioMaximo
            // 
            this.txtCCPrecioMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCPrecioMaximo.Location = new System.Drawing.Point(9, 19);
            this.txtCCPrecioMaximo.MaxLength = 50;
            this.txtCCPrecioMaximo.Name = "txtCCPrecioMaximo";
            this.txtCCPrecioMaximo.Size = new System.Drawing.Size(160, 20);
            this.txtCCPrecioMaximo.TabIndex = 53;
            // 
            // txtCCPrecioMinimo
            // 
            this.txtCCPrecioMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCPrecioMinimo.Location = new System.Drawing.Point(175, 58);
            this.txtCCPrecioMinimo.MaxLength = 50;
            this.txtCCPrecioMinimo.Name = "txtCCPrecioMinimo";
            this.txtCCPrecioMinimo.Size = new System.Drawing.Size(160, 20);
            this.txtCCPrecioMinimo.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(6, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "% Precio Máximo:";
            // 
            // txtCCPrecioOferta
            // 
            this.txtCCPrecioOferta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCPrecioOferta.Location = new System.Drawing.Point(175, 19);
            this.txtCCPrecioOferta.MaxLength = 50;
            this.txtCCPrecioOferta.Name = "txtCCPrecioOferta";
            this.txtCCPrecioOferta.Size = new System.Drawing.Size(160, 20);
            this.txtCCPrecioOferta.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(172, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "% Precio Oferta:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(172, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "% Precio Mínimo:";
            // 
            // txtCCPrecioMayor
            // 
            this.txtCCPrecioMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCPrecioMayor.Location = new System.Drawing.Point(9, 58);
            this.txtCCPrecioMayor.MaxLength = 50;
            this.txtCCPrecioMayor.Name = "txtCCPrecioMayor";
            this.txtCCPrecioMayor.Size = new System.Drawing.Size(160, 20);
            this.txtCCPrecioMayor.TabIndex = 55;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(6, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "% Precio Mayor:";
            // 
            // buscarImagen
            // 
            this.buscarImagen.FileName = "BuscarImagen";
            this.buscarImagen.Filter = "Archivos PNG(*.png)|*.png|Archivos JPEG(*.jpeg)|*.jpeg|Archivos JPG(*.jpg)|*.jpg|" +
    "Todos (*.*)|*.*";
            // 
            // frmDepartamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 561);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblNombreFoto);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.campoFoto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripMenu);
            this.KeyPreview = true;
            this.Name = "frmDepartamentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departamentos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDepartamentos_FormClosed);
            this.Load += new System.EventHandler(this.frmDepartamentos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDepartamentos_KeyDown);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.campoFoto)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPagePrecios.ResumeLayout(false);
            this.tabPagePrecios.PerformLayout();
            this.tabPageComisionVentas.ResumeLayout(false);
            this.tabPageComisionVentas.PerformLayout();
            this.tabPageComisionCobranza.ResumeLayout(false);
            this.tabPageComisionCobranza.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioMayor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioOferta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecioMaximo;
        private System.Windows.Forms.Label lblFicha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtPrecioMinimo;
        private System.Windows.Forms.Label lblNombreFoto;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.PictureBox campoFoto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePrecios;
        private System.Windows.Forms.TabPage tabPageComisionVentas;
        private System.Windows.Forms.TabPage tabPageComisionCobranza;
        private System.Windows.Forms.TextBox txtCVPrecioMaximo;
        private System.Windows.Forms.TextBox txtCVPrecioMinimo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCVPrecioOferta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCVPrecioMayor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCCPrecioMaximo;
        private System.Windows.Forms.TextBox txtCCPrecioMinimo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCCPrecioOferta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCCPrecioMayor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.OpenFileDialog buscarImagen;
    }
}