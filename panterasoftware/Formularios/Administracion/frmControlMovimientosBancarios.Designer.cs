namespace panterasoftware.Administracion
{
    partial class frmControlMovimientosBancarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFicha = new System.Windows.Forms.Label();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTipoCuenta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomBanco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaldoReal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldoConciliado = new System.Windows.Forms.TextBox();
            this.tabControlAcciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMontoCheque = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBenificiario = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.dtpFechaCheque = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumCheque = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMontoDeposito = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDepositante = new System.Windows.Forms.TextBox();
            this.txtConceptoDeposito = new System.Windows.Forms.TextBox();
            this.dtpFechaDeposito = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.dgListado = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlAcciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFicha);
            this.groupBox1.Controls.Add(this.btnBuscarUsuario);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTipoCuenta);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNomBanco);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNumCuenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Banco";
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.Location = new System.Drawing.Point(111, 16);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(13, 13);
            this.lblFicha.TabIndex = 55;
            this.lblFicha.Text = "0";
            this.lblFicha.Visible = false;
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.AutoSize = true;
            this.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarUsuario.Image = global::panterasoftware.Properties.Resources.Search;
            this.btnBuscarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(175, 28);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(68, 25);
            this.btnBuscarUsuario.TabIndex = 1;
            this.btnBuscarUsuario.Text = "Buscar";
            this.btnBuscarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tipo de Cuenta:";
            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoCuenta.Location = new System.Drawing.Point(9, 110);
            this.txtTipoCuenta.MaxLength = 150;
            this.txtTipoCuenta.Name = "txtTipoCuenta";
            this.txtTipoCuenta.Size = new System.Drawing.Size(160, 20);
            this.txtTipoCuenta.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Banco:";
            // 
            // txtNomBanco
            // 
            this.txtNomBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomBanco.Location = new System.Drawing.Point(10, 71);
            this.txtNomBanco.MaxLength = 150;
            this.txtNomBanco.Name = "txtNomBanco";
            this.txtNomBanco.Size = new System.Drawing.Size(160, 20);
            this.txtNomBanco.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Numero de Cuenta:";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCuenta.Location = new System.Drawing.Point(9, 32);
            this.txtNumCuenta.MaxLength = 150;
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(160, 20);
            this.txtNumCuenta.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSaldoReal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSaldoConciliado);
            this.groupBox2.Location = new System.Drawing.Point(280, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 109);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Saldo Real:";
            // 
            // txtSaldoReal
            // 
            this.txtSaldoReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldoReal.Location = new System.Drawing.Point(9, 68);
            this.txtSaldoReal.MaxLength = 150;
            this.txtSaldoReal.Name = "txtSaldoReal";
            this.txtSaldoReal.Size = new System.Drawing.Size(160, 20);
            this.txtSaldoReal.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Saldo Conciliado:";
            // 
            // txtSaldoConciliado
            // 
            this.txtSaldoConciliado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldoConciliado.Location = new System.Drawing.Point(9, 32);
            this.txtSaldoConciliado.MaxLength = 150;
            this.txtSaldoConciliado.Name = "txtSaldoConciliado";
            this.txtSaldoConciliado.Size = new System.Drawing.Size(160, 20);
            this.txtSaldoConciliado.TabIndex = 0;
            // 
            // tabControlAcciones
            // 
            this.tabControlAcciones.Controls.Add(this.tabPage1);
            this.tabControlAcciones.Controls.Add(this.tabPage2);
            this.tabControlAcciones.Controls.Add(this.tabPage3);
            this.tabControlAcciones.Controls.Add(this.tabPage4);
            this.tabControlAcciones.Controls.Add(this.tabPage5);
            this.tabControlAcciones.Controls.Add(this.tabPage8);
            this.tabControlAcciones.Controls.Add(this.tabPage9);
            this.tabControlAcciones.Location = new System.Drawing.Point(12, 176);
            this.tabControlAcciones.Name = "tabControlAcciones";
            this.tabControlAcciones.SelectedIndex = 0;
            this.tabControlAcciones.Size = new System.Drawing.Size(591, 270);
            this.tabControlAcciones.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(583, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cheques(F5)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Location = new System.Drawing.Point(-4, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 37);
            this.panel1.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::panterasoftware.Properties.Resources.abandonar;
            this.btnCancelar.Location = new System.Drawing.Point(731, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::panterasoftware.Properties.Resources.ok;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(464, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(117, 25);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Procesar Cheque";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtMontoCheque);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtBenificiario);
            this.groupBox3.Controls.Add(this.txtConcepto);
            this.groupBox3.Controls.Add(this.dtpFechaCheque);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtNumCheque);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 190);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Cheque";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Monto de Cheque:";
            // 
            // txtMontoCheque
            // 
            this.txtMontoCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoCheque.Location = new System.Drawing.Point(9, 149);
            this.txtMontoCheque.MaxLength = 150;
            this.txtMontoCheque.Name = "txtMontoCheque";
            this.txtMontoCheque.Size = new System.Drawing.Size(160, 20);
            this.txtMontoCheque.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::panterasoftware.Properties.Resources.Search;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(322, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Beneficiario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Concepto:";
            // 
            // txtBenificiario
            // 
            this.txtBenificiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBenificiario.Location = new System.Drawing.Point(9, 110);
            this.txtBenificiario.MaxLength = 150;
            this.txtBenificiario.Name = "txtBenificiario";
            this.txtBenificiario.Size = new System.Drawing.Size(305, 20);
            this.txtBenificiario.TabIndex = 3;
            // 
            // txtConcepto
            // 
            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.Location = new System.Drawing.Point(9, 71);
            this.txtConcepto.MaxLength = 150;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(305, 20);
            this.txtConcepto.TabIndex = 2;
            // 
            // dtpFechaCheque
            // 
            this.dtpFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCheque.Location = new System.Drawing.Point(175, 32);
            this.dtpFechaCheque.Name = "dtpFechaCheque";
            this.dtpFechaCheque.Size = new System.Drawing.Size(139, 20);
            this.dtpFechaCheque.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(175, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Fecha Cheque:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Numero de Cheque:";
            // 
            // txtNumCheque
            // 
            this.txtNumCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCheque.Location = new System.Drawing.Point(9, 32);
            this.txtNumCheque.MaxLength = 150;
            this.txtNumCheque.Name = "txtNumCheque";
            this.txtNumCheque.Size = new System.Drawing.Size(160, 20);
            this.txtNumCheque.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(583, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Depositos(F6)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtMontoDeposito);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtDepositante);
            this.groupBox4.Controls.Add(this.txtConceptoDeposito);
            this.groupBox4.Controls.Add(this.dtpFechaDeposito);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(571, 145);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos del Deposito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Monto:";
            // 
            // txtMontoDeposito
            // 
            this.txtMontoDeposito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoDeposito.Location = new System.Drawing.Point(9, 32);
            this.txtMontoDeposito.MaxLength = 150;
            this.txtMontoDeposito.Name = "txtMontoDeposito";
            this.txtMontoDeposito.Size = new System.Drawing.Size(160, 20);
            this.txtMontoDeposito.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::panterasoftware.Properties.Resources.Search;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(322, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Buscar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Depositante:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Concepto:";
            // 
            // txtDepositante
            // 
            this.txtDepositante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepositante.Location = new System.Drawing.Point(9, 110);
            this.txtDepositante.MaxLength = 150;
            this.txtDepositante.Name = "txtDepositante";
            this.txtDepositante.Size = new System.Drawing.Size(305, 20);
            this.txtDepositante.TabIndex = 3;
            // 
            // txtConceptoDeposito
            // 
            this.txtConceptoDeposito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConceptoDeposito.Location = new System.Drawing.Point(9, 71);
            this.txtConceptoDeposito.MaxLength = 150;
            this.txtConceptoDeposito.Name = "txtConceptoDeposito";
            this.txtConceptoDeposito.Size = new System.Drawing.Size(305, 20);
            this.txtConceptoDeposito.TabIndex = 2;
            // 
            // dtpFechaDeposito
            // 
            this.dtpFechaDeposito.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeposito.Location = new System.Drawing.Point(175, 32);
            this.dtpFechaDeposito.Name = "dtpFechaDeposito";
            this.dtpFechaDeposito.Size = new System.Drawing.Size(139, 20);
            this.dtpFechaDeposito.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Fecha Deposito:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(583, 244);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Retiros(F7)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(583, 244);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Debe(F8)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(583, 244);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Haber(F9)";
            this.tabPage5.UseVisualStyleBackColor = true;
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
            this.toolStripMenu.Size = new System.Drawing.Size(615, 25);
            this.toolStripMenu.TabIndex = 35;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::panterasoftware.Properties.Resources.New;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(82, 22);
            this.btnNuevo.Text = "Nuevo(F1)";
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
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.dgListado);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(583, 244);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Cuentas Por Pagar(F10)";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(542, 244);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "Asiento Contable(F11)";
            this.tabPage9.UseVisualStyleBackColor = true;
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
            this.dgListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListado.Location = new System.Drawing.Point(0, 0);
            this.dgListado.Name = "dgListado";
            this.dgListado.ReadOnly = true;
            this.dgListado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgListado.Size = new System.Drawing.Size(583, 244);
            this.dgListado.TabIndex = 43;
            // 
            // frmControlMovimientosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(615, 447);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.tabControlAcciones);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmControlMovimientosBancarios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Movimientos Bancarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmControlMovimientosBancarios_FormClosed);
            this.Load += new System.EventHandler(this.frmControlMovimientosBancarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControlAcciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControlAcciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumCheque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldoReal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldoConciliado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.DateTimePicker dtpFechaCheque;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTipoCuenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomBanco;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMontoCheque;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBenificiario;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMontoDeposito;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDepositante;
        private System.Windows.Forms.TextBox txtConceptoDeposito;
        private System.Windows.Forms.DateTimePicker dtpFechaDeposito;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFicha;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView dgListado;
        private System.Windows.Forms.TabPage tabPage9;
    }
}