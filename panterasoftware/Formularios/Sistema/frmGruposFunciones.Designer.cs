namespace panterasoftware.Sistema
{
    partial class frmGruposFunciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgFuncionesSinAsignar = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgFuncionesAsignadas = new System.Windows.Forms.DataGridView();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionesSinAsignar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionesAsignadas)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbModulo
            // 
            this.cmbModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(12, 57);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(160, 21);
            this.cmbModulo.TabIndex = 34;
            this.cmbModulo.SelectedIndexChanged += new System.EventHandler(this.cmbModulo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Modulo:";
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGrupos.FormattingEnabled = true;
            this.cmbGrupos.Location = new System.Drawing.Point(178, 57);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(160, 21);
            this.cmbGrupos.TabIndex = 36;
            this.cmbGrupos.SelectedIndexChanged += new System.EventHandler(this.cmbGrupos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Grupo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgFuncionesSinAsignar);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 479);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funciones Sin Asignar";
            // 
            // dgFuncionesSinAsignar
            // 
            this.dgFuncionesSinAsignar.AllowUserToAddRows = false;
            this.dgFuncionesSinAsignar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgFuncionesSinAsignar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFuncionesSinAsignar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFuncionesSinAsignar.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgFuncionesSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFuncionesSinAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFuncionesSinAsignar.Location = new System.Drawing.Point(3, 16);
            this.dgFuncionesSinAsignar.Name = "dgFuncionesSinAsignar";
            this.dgFuncionesSinAsignar.ReadOnly = true;
            this.dgFuncionesSinAsignar.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgFuncionesSinAsignar.Size = new System.Drawing.Size(376, 460);
            this.dgFuncionesSinAsignar.TabIndex = 2;
            this.dgFuncionesSinAsignar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFuncionesSinAsignar_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgFuncionesAsignadas);
            this.groupBox1.Location = new System.Drawing.Point(400, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 476);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones Asignadas";
            // 
            // dgFuncionesAsignadas
            // 
            this.dgFuncionesAsignadas.AllowUserToAddRows = false;
            this.dgFuncionesAsignadas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            this.dgFuncionesAsignadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgFuncionesAsignadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFuncionesAsignadas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgFuncionesAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFuncionesAsignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFuncionesAsignadas.Location = new System.Drawing.Point(3, 16);
            this.dgFuncionesAsignadas.Name = "dgFuncionesAsignadas";
            this.dgFuncionesAsignadas.ReadOnly = true;
            this.dgFuncionesAsignadas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dgFuncionesAsignadas.Size = new System.Drawing.Size(376, 457);
            this.dgFuncionesAsignadas.TabIndex = 2;
            this.dgFuncionesAsignadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFuncionesAsignadas_CellDoubleClick);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(794, 25);
            this.toolStripMenu.TabIndex = 39;
            this.toolStripMenu.Text = "toolStrip1";
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
            // frmGruposFunciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbGrupos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGruposFunciones";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Funciones a Grupos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGruposFunciones_FormClosed);
            this.Load += new System.EventHandler(this.frmGruposFunciones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGruposFunciones_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionesSinAsignar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionesAsignadas)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGrupos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.DataGridView dgFuncionesSinAsignar;
        private System.Windows.Forms.DataGridView dgFuncionesAsignadas;
    }
}