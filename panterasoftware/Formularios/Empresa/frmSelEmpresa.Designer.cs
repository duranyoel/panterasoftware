namespace panterasoftware.Configuracion
{
    partial class frmSelEmpresa
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
            this.dgEmpresas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCrearNuevaEmpresa = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpresas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEmpresas
            // 
            this.dgEmpresas.AllowUserToAddRows = false;
            this.dgEmpresas.AllowUserToDeleteRows = false;
            this.dgEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEmpresas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgEmpresas.BackgroundColor = System.Drawing.Color.White;
            this.dgEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmpresas.Location = new System.Drawing.Point(12, 67);
            this.dgEmpresas.Name = "dgEmpresas";
            this.dgEmpresas.ReadOnly = true;
            this.dgEmpresas.Size = new System.Drawing.Size(560, 340);
            this.dgEmpresas.TabIndex = 0;
            this.dgEmpresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpresas_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empresas Registradas En El  Sistema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Por favor selecciones la empresa con la que desea comenzar a trabajar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCrearNuevaEmpresa);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Location = new System.Drawing.Point(-3, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 51);
            this.panel1.TabIndex = 12;
            // 
            // btnCrearNuevaEmpresa
            // 
            this.btnCrearNuevaEmpresa.AutoSize = true;
            this.btnCrearNuevaEmpresa.BackColor = System.Drawing.SystemColors.Control;
            this.btnCrearNuevaEmpresa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCrearNuevaEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearNuevaEmpresa.Image = global::panterasoftware.Properties.Resources.New;
            this.btnCrearNuevaEmpresa.Location = new System.Drawing.Point(350, 11);
            this.btnCrearNuevaEmpresa.Name = "btnCrearNuevaEmpresa";
            this.btnCrearNuevaEmpresa.Size = new System.Drawing.Size(139, 25);
            this.btnCrearNuevaEmpresa.TabIndex = 12;
            this.btnCrearNuevaEmpresa.Text = "Crear Nueva Empresa";
            this.btnCrearNuevaEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrearNuevaEmpresa.UseVisualStyleBackColor = false;
            this.btnCrearNuevaEmpresa.Click += new System.EventHandler(this.btnCrearNuevaEmpresa_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::panterasoftware.Properties.Resources.abandonar;
            this.btnCancelar.Location = new System.Drawing.Point(495, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 25);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmSelEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgEmpresas);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelEmpresa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Empresa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSelEmpresa_FormClosed);
            this.Load += new System.EventHandler(this.frmSelEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpresas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmpresas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCrearNuevaEmpresa;
    }
}