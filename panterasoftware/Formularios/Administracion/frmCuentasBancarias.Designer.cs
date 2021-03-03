namespace panterasoftware.Administracion
{
    partial class frmCuentasBancarias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbDatosTitular = new System.Windows.Forms.GroupBox();
            this.txtRif = new System.Windows.Forms.MaskedTextBox();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFicha = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtTelOfi = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.toolStripmenu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosCuenta = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodigoContable = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbNaturaleza = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdb = new System.Windows.Forms.TextBox();
            this.cmbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbCorrelativos = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumCheque = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNotaCredito = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNotaDebito = new System.Windows.Forms.TextBox();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
            this.gbDatosTitular.SuspendLayout();
            this.toolStripmenu.SuspendLayout();
            this.gbDatosCuenta.SuspendLayout();
            this.gbCorrelativos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.dgListado);
            this.gbListado.Controls.Add(this.btnBuscarUsuario);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Location = new System.Drawing.Point(12, 230);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(512, 196);
            this.gbListado.TabIndex = 0;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "Listado";
            // 
            // dgListado
            // 
            this.dgListado.AllowUserToAddRows = false;
            this.dgListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            this.dgListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgListado.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListado.Location = new System.Drawing.Point(9, 45);
            this.dgListado.Name = "dgListado";
            this.dgListado.ReadOnly = true;
            this.dgListado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgListado.Size = new System.Drawing.Size(495, 145);
            this.dgListado.TabIndex = 1;
            this.dgListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListado_CellDoubleClick);
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.AutoSize = true;
            this.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarUsuario.Image = global::panterasoftware.Properties.Resources.Search;
            this.btnBuscarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(179, 14);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(86, 25);
            this.btnBuscarUsuario.TabIndex = 2;
            this.btnBuscarUsuario.Text = "Buscar(F4)";
            this.btnBuscarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
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
            // gbDatosTitular
            // 
            this.gbDatosTitular.Controls.Add(this.txtRif);
            this.gbDatosTitular.Controls.Add(this.txtFax);
            this.gbDatosTitular.Controls.Add(this.label8);
            this.gbDatosTitular.Controls.Add(this.label6);
            this.gbDatosTitular.Controls.Add(this.lblFicha);
            this.gbDatosTitular.Controls.Add(this.label7);
            this.gbDatosTitular.Controls.Add(this.txtEmail);
            this.gbDatosTitular.Controls.Add(this.label5);
            this.gbDatosTitular.Controls.Add(this.txtApellidos);
            this.gbDatosTitular.Controls.Add(this.txtTelOfi);
            this.gbDatosTitular.Controls.Add(this.label4);
            this.gbDatosTitular.Controls.Add(this.label2);
            this.gbDatosTitular.Controls.Add(this.txtDireccion);
            this.gbDatosTitular.Controls.Add(this.txtCodigo);
            this.gbDatosTitular.Controls.Add(this.label3);
            this.gbDatosTitular.Controls.Add(this.label1);
            this.gbDatosTitular.Controls.Add(this.txtNombre);
            this.gbDatosTitular.Location = new System.Drawing.Point(12, 28);
            this.gbDatosTitular.Name = "gbDatosTitular";
            this.gbDatosTitular.Size = new System.Drawing.Size(512, 196);
            this.gbDatosTitular.TabIndex = 35;
            this.gbDatosTitular.TabStop = false;
            this.gbDatosTitular.Text = "Datos Titular";
            // 
            // txtRif
            // 
            this.txtRif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRif.Location = new System.Drawing.Point(175, 32);
            this.txtRif.Mask = "L-########-#";
            this.txtRif.Name = "txtRif";
            this.txtRif.Size = new System.Drawing.Size(160, 20);
            this.txtRif.TabIndex = 1;
            this.txtRif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFax
            // 
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Location = new System.Drawing.Point(341, 72);
            this.txtFax.Mask = "(999)000-0000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(160, 20);
            this.txtFax.TabIndex = 5;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Rif:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Fax:";
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.Location = new System.Drawing.Point(55, 16);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(13, 13);
            this.lblFicha.TabIndex = 54;
            this.lblFicha.Text = "0";
            this.lblFicha.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(9, 112);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidos.Location = new System.Drawing.Point(9, 72);
            this.txtApellidos.MaxLength = 150;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(160, 20);
            this.txtApellidos.TabIndex = 3;
            // 
            // txtTelOfi
            // 
            this.txtTelOfi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelOfi.Location = new System.Drawing.Point(175, 72);
            this.txtTelOfi.Mask = "(999)000-0000";
            this.txtTelOfi.Name = "txtTelOfi";
            this.txtTelOfi.Size = new System.Drawing.Size(160, 20);
            this.txtTelOfi.TabIndex = 4;
            this.txtTelOfi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Location = new System.Drawing.Point(175, 113);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(326, 78);
            this.txtDireccion.TabIndex = 7;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Codigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombres:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(341, 32);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // toolStripmenu
            // 
            this.toolStripmenu.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.toolStripSeparator2,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnSalir});
            this.toolStripmenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripmenu.Name = "toolStripmenu";
            this.toolStripmenu.Size = new System.Drawing.Size(864, 25);
            this.toolStripmenu.TabIndex = 34;
            this.toolStripmenu.Text = "toolStrip1";
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
            // gbDatosCuenta
            // 
            this.gbDatosCuenta.Controls.Add(this.label19);
            this.gbDatosCuenta.Controls.Add(this.cmbBanco);
            this.gbDatosCuenta.Controls.Add(this.label15);
            this.gbDatosCuenta.Controls.Add(this.cmbEstatus);
            this.gbDatosCuenta.Controls.Add(this.label14);
            this.gbDatosCuenta.Controls.Add(this.txtCodigoContable);
            this.gbDatosCuenta.Controls.Add(this.label12);
            this.gbDatosCuenta.Controls.Add(this.cmbNaturaleza);
            this.gbDatosCuenta.Controls.Add(this.label11);
            this.gbDatosCuenta.Controls.Add(this.label13);
            this.gbDatosCuenta.Controls.Add(this.txtIdb);
            this.gbDatosCuenta.Controls.Add(this.cmbTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.dtpFecha);
            this.gbDatosCuenta.Controls.Add(this.label10);
            this.gbDatosCuenta.Controls.Add(this.txtNumCuenta);
            this.gbDatosCuenta.Controls.Add(this.label9);
            this.gbDatosCuenta.Location = new System.Drawing.Point(535, 28);
            this.gbDatosCuenta.Name = "gbDatosCuenta";
            this.gbDatosCuenta.Size = new System.Drawing.Size(317, 196);
            this.gbDatosCuenta.TabIndex = 37;
            this.gbDatosCuenta.TabStop = false;
            this.gbDatosCuenta.Text = "Datos de la Cuenta";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(169, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 54;
            this.label19.Text = "Banco:";
            // 
            // cmbBanco
            // 
            this.cmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Items.AddRange(new object[] {
            "Activa",
            "Inactiva"});
            this.cmbBanco.Location = new System.Drawing.Point(172, 152);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(139, 21);
            this.cmbBanco.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Estatus:";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "Activa",
            "Inactiva"});
            this.cmbEstatus.Location = new System.Drawing.Point(6, 152);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(160, 21);
            this.cmbEstatus.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(169, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Codigo Contable:";
            // 
            // txtCodigoContable
            // 
            this.txtCodigoContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoContable.Location = new System.Drawing.Point(172, 112);
            this.txtCodigoContable.MaxLength = 50;
            this.txtCodigoContable.Name = "txtCodigoContable";
            this.txtCodigoContable.Size = new System.Drawing.Size(139, 20);
            this.txtCodigoContable.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Naturaleza:";
            // 
            // cmbNaturaleza
            // 
            this.cmbNaturaleza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNaturaleza.FormattingEnabled = true;
            this.cmbNaturaleza.Items.AddRange(new object[] {
            "Natural",
            "Juridica"});
            this.cmbNaturaleza.Location = new System.Drawing.Point(6, 112);
            this.cmbNaturaleza.Name = "cmbNaturaleza";
            this.cmbNaturaleza.Size = new System.Drawing.Size(160, 21);
            this.cmbNaturaleza.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "IDB:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Tipo de Cuenta:";
            // 
            // txtIdb
            // 
            this.txtIdb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdb.Location = new System.Drawing.Point(172, 71);
            this.txtIdb.MaxLength = 50;
            this.txtIdb.Name = "txtIdb";
            this.txtIdb.Size = new System.Drawing.Size(139, 20);
            this.txtIdb.TabIndex = 3;
            // 
            // cmbTipoCuenta
            // 
            this.cmbTipoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoCuenta.FormattingEnabled = true;
            this.cmbTipoCuenta.Items.AddRange(new object[] {
            "Ahorro",
            "Corriente",
            "Ahorro Digital",
            "Corriente Digital",
            "VIP"});
            this.cmbTipoCuenta.Location = new System.Drawing.Point(6, 71);
            this.cmbTipoCuenta.Name = "cmbTipoCuenta";
            this.cmbTipoCuenta.Size = new System.Drawing.Size(160, 21);
            this.cmbTipoCuenta.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(172, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(139, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Fecha Apertura:";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCuenta.Location = new System.Drawing.Point(6, 32);
            this.txtNumCuenta.Mask = "####-####-##-##########";
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(160, 20);
            this.txtNumCuenta.TabIndex = 0;
            this.txtNumCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Numero:";
            // 
            // gbCorrelativos
            // 
            this.gbCorrelativos.Controls.Add(this.label18);
            this.gbCorrelativos.Controls.Add(this.txtNumCheque);
            this.gbCorrelativos.Controls.Add(this.label16);
            this.gbCorrelativos.Controls.Add(this.txtNotaCredito);
            this.gbCorrelativos.Controls.Add(this.label17);
            this.gbCorrelativos.Controls.Add(this.txtNotaDebito);
            this.gbCorrelativos.Location = new System.Drawing.Point(535, 230);
            this.gbCorrelativos.Name = "gbCorrelativos";
            this.gbCorrelativos.Size = new System.Drawing.Size(317, 196);
            this.gbCorrelativos.TabIndex = 53;
            this.gbCorrelativos.TabStop = false;
            this.gbCorrelativos.Text = "Correlativos";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 13);
            this.label18.TabIndex = 54;
            this.label18.Text = "Numero de Cheque:";
            // 
            // txtNumCheque
            // 
            this.txtNumCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCheque.Location = new System.Drawing.Point(9, 71);
            this.txtNumCheque.MaxLength = 50;
            this.txtNumCheque.Name = "txtNumCheque";
            this.txtNumCheque.Size = new System.Drawing.Size(139, 20);
            this.txtNumCheque.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(148, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Nota de Crédito:";
            // 
            // txtNotaCredito
            // 
            this.txtNotaCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotaCredito.Location = new System.Drawing.Point(151, 32);
            this.txtNotaCredito.MaxLength = 50;
            this.txtNotaCredito.Name = "txtNotaCredito";
            this.txtNotaCredito.Size = new System.Drawing.Size(139, 20);
            this.txtNotaCredito.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 50;
            this.label17.Text = "Nota de Débito:";
            // 
            // txtNotaDebito
            // 
            this.txtNotaDebito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotaDebito.Location = new System.Drawing.Point(6, 32);
            this.txtNotaDebito.MaxLength = 50;
            this.txtNotaDebito.Name = "txtNotaDebito";
            this.txtNotaDebito.Size = new System.Drawing.Size(139, 20);
            this.txtNotaDebito.TabIndex = 0;
            // 
            // frmCuentasBancarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 441);
            this.ControlBox = false;
            this.Controls.Add(this.gbCorrelativos);
            this.Controls.Add(this.gbDatosCuenta);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbDatosTitular);
            this.Controls.Add(this.toolStripmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCuentasBancarias";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas Bancarias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCuentasBancarias_FormClosed);
            this.Load += new System.EventHandler(this.frmCuentasBancarias_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCuentasBancarias_KeyDown);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            this.gbDatosTitular.ResumeLayout(false);
            this.gbDatosTitular.PerformLayout();
            this.toolStripmenu.ResumeLayout(false);
            this.toolStripmenu.PerformLayout();
            this.gbDatosCuenta.ResumeLayout(false);
            this.gbDatosCuenta.PerformLayout();
            this.gbCorrelativos.ResumeLayout(false);
            this.gbCorrelativos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.MaskedTextBox txtTelOfi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ToolStrip toolStripmenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtNumCuenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTipoCuenta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbNaturaleza;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIdb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCodigoContable;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNumCheque;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNotaCredito;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNotaDebito;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.Label lblFicha;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtRif;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.GroupBox gbCorrelativos;
        public System.Windows.Forms.GroupBox gbListado;
        public System.Windows.Forms.GroupBox gbDatosTitular;
        public System.Windows.Forms.ToolStripButton btnNuevo;
        public System.Windows.Forms.ToolStripButton btnGuardar;
        public System.Windows.Forms.GroupBox gbDatosCuenta;
    }
}