using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace panterasoftware.Administracion
{
    public partial class frmCuentasBancarias : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmCuentasBancarias()
        {
            InitializeComponent();
        }

        private void frmCuentasBancarias_Load(object sender, EventArgs e)
        {
            this.Nuevo();
            this.Bancos();
        }

        private void frmCuentasBancarias_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void Nuevo()
        {
            this.lblFicha.Text = "0";
            this.txtBuscar.Text = "";
            this.cmbEstatus.Text = "Activa";
            this.cmbNaturaleza.Text = "Natural";
            this.cmbTipoCuenta.Text = "Ahorro";

            this.txtCodigo.Text = "";
            this.txtCodigoContable.Text = "";
            this.txtRif.Text = "";
            this.txtDireccion.Text = "";
            this.txtEmail.Text = "";
            this.txtIdb.Text = "0";
            this.txtNombre.Text = "";
            this.txtNotaCredito.Text = "0";
            this.txtNotaDebito.Text = "0";
            this.txtNumCheque.Text = "0";
            this.txtNumCuenta.Text = "";
            this.txtTelOfi.Text = "";
            this.txtApellidos.Text = "";
            this.txtFax.Text = "";

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.txtRif.BackColor = Color.White;
            this.txtApellidos.BackColor = Color.White;
            this.txtEmail.BackColor = Color.White;
            this.dtpFecha.ResetText();
            this.btnEliminar.Enabled = false;
            this.dgListado.ClearSelection();

        }
        private void Guardar()
        {
            App_Code.Administracion.CuentasBancarias oRegistro = new App_Code.Administracion.CuentasBancarias(int.Parse(this.lblFicha.Text));
           
            //Datos Del Titular
            oRegistro.Nombre = this.txtNombre.Text.ToUpperInvariant();
            oRegistro.Apellidos = this.txtApellidos.Text.ToUpperInvariant();
            oRegistro.Rif = this.txtRif.Text.ToString().ToUpperInvariant();
            oRegistro.Codigo = this.txtCodigo.Text.ToUpperInvariant();
            oRegistro.Fax = this.txtFax.Text;
            oRegistro.Telefono = this.txtTelOfi.Text; 
            oRegistro.Email = this.txtEmail.Text;
            oRegistro.Direccion = this.txtDireccion.Text.ToUpperInvariant();
          
            //Datos De la Cuenta
            oRegistro.Estatus = this.cmbEstatus.SelectedItem.ToString();
            oRegistro.NumeroCuenta = this.txtNumCuenta.Text;
            oRegistro.FechaApertura = DateTime.Parse(this.dtpFecha.Text.ToString());
            oRegistro.TipoCuenta = this.cmbTipoCuenta.SelectedItem.ToString();
            oRegistro.Idb = decimal.Parse(this.txtIdb.Text.ToString());
            oRegistro.NaturalezaCuenta = this.cmbNaturaleza.SelectedItem.ToString();
            oRegistro.CodigoContable = this.txtCodigoContable.Text;
            oRegistro.Estatus = this.cmbEstatus.SelectedItem.ToString();
            oRegistro.BancoId = int.Parse(this.cmbBanco.SelectedValue.ToString());

            //Correlativos
            oRegistro.NumeroDebito = int.Parse(this.txtNotaDebito.Text.ToString());
            oRegistro.NumeroCredito = int.Parse(this.txtNotaCredito.Text.ToString());
            oRegistro.UltimoCheque = int.Parse(this.txtNumCheque.Text.ToString());

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400102");
                        if (oFuncion.Err)
                        {

                            MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            oRegistro.Insertar();
                        }

                    }
                    else
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400103");
                        if (oFuncion.Err)
                        {

                            MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            oRegistro.Actualizar();
                        }


                    }
                    MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Consulta();
                    this.Presentar(oRegistro.Id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Presentar(int id)
        {
            
            App_Code.Administracion.CuentasBancarias oRegistro = new App_Code.Administracion.CuentasBancarias(id);
            App_Code.Administracion.Bancos oBanco = new App_Code.Administracion.Bancos(oRegistro.BancoId);

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo.ToString();
            this.txtNombre.Text = oRegistro.Nombre.ToString();
            this.txtApellidos.Text = oRegistro.Apellidos.ToString();
            this.txtRif.Text = oRegistro.Rif.ToString();
            this.txtFax.Text = oRegistro.Fax;
            this.txtTelOfi.Text = oRegistro.Telefono;   
            this.txtEmail.Text = oRegistro.Email;    
            this.cmbEstatus.Text = oRegistro.Estatus;
            this.txtDireccion.Text = oRegistro.Direccion;

            //Datos de la cuenta
            this.txtNumCuenta.Text = oRegistro.NumeroCuenta.ToString();
            this.dtpFecha.Text = oRegistro.FechaApertura.ToString("dd/MM/yyyy");
            this.cmbTipoCuenta.Text = oRegistro.TipoCuenta.ToString();
            this.txtIdb.Text = oRegistro.Idb.ToString();
            this.cmbNaturaleza.Text = oRegistro.NaturalezaCuenta.ToString();
            this.txtCodigoContable.Text = oRegistro.CodigoContable.ToString();
            this.cmbEstatus.Text = oRegistro.Estatus.ToString();
            this.cmbBanco.Text = oBanco.Nombre.ToString();

            //Correlativos
            this.txtNotaDebito.Text = oRegistro.NumeroDebito.ToString();
            this.txtNotaCredito.Text = oRegistro.NumeroCredito.ToString();
            this.txtNumCheque.Text = oRegistro.UltimoCheque.ToString();

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.txtRif.BackColor = Color.White;
            this.txtApellidos.BackColor = Color.White;
            this.txtEmail.BackColor = Color.White;

            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400104");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }
        }
        private void Borrar()
        {
            try
            {
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400104");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Administracion.CuentasBancarias oRegistro = new App_Code.Administracion.CuentasBancarias(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Eliminar();
                        this.Nuevo();
                        MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Consulta()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400105");
            if (oFuncion.Err)
            {

                MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                DataTable oTabla = new DataTable();
                DataSet oDataSet = new DataSet();
                SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
                SqlDataAdapter oAdaptador = new SqlDataAdapter(
                    "SELECT " +
                        "id, " +
                        "codigo, " +
                        "rif, " +
                        "nombres, " +
                        "apellidos, "+
                        "numero_cuenta, "+
                        "tipo_cuenta "+


                    "FROM cuentas_bancarias " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "apellidos LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "nombres LIKE '%" + this.txtBuscar.Text + "%') " +

                    "ORDER BY " +
                        "codigo, " +
                        "nombres;", oConexion);

                oConexion.Open();
                oAdaptador.Fill(oDataSet, "tabla");
                oTabla = oDataSet.Tables["tabla"];
                oConexion.Close();
                this.dgListado.DataSource = oTabla;

                //Encabezado
                this.dgListado.Columns[0].HeaderText = "Ficha";
                this.dgListado.Columns[1].HeaderText = "Codigo";
                this.dgListado.Columns[2].HeaderText = "Rif/Cedula";
                this.dgListado.Columns[3].HeaderText = "Nombres";
                this.dgListado.Columns[4].HeaderText = "Apellidos";
                this.dgListado.Columns[5].HeaderText = "Numero";
                this.dgListado.Columns[6].HeaderText = "Tipo";

            }
        }
        private bool Validar()
        {
            if (this.txtCodigo.Text.Length == 0)
            {
                this.txtCodigo.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un codigo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            
            if (this.txtRif.Text.Length == 0)
            {
                this.txtRif.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un rif/cedula", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtNombre.Text.Length == 0)
            {
                this.txtNombre.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtIdb.Text.Length == 0)
            {
                this.txtIdb.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un idb", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtNotaDebito.Text.Length == 0)
            {
                this.txtNotaDebito.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un valor en  nota de debito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtNotaCredito.Text.Length == 0)
            {
                this.txtNotaCredito.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un valor en  nota de credito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtNumCheque.Text.Length == 0)
            {
                this.txtNumCheque.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un valor en  numero de cheque", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            App_Code.Base oBase = new App_Code.Base();
            if (!oBase.IsValidEmail(this.txtEmail.Text.ToString())){
                this.txtEmail.BackColor = Color.Red;
                MessageBox.Show("Disculpe email erroneo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
        private void Salir()
        {
            this.Close();
        }
        
       
        private void Bancos()
        {
            this.cmbBanco.DataSource = new App_Code.Administracion.Bancos().Buscar(0,
                    "id,'('+ codigo +')' + nombre AS nombre",
                    "",
                    "nombre"); 
            this.cmbBanco.DisplayMember = "nombre";
            this.cmbBanco.ValueMember = "id";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Borrar();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }

        private void frmCuentasBancarias_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.Nuevo();
                    break;
                case Keys.F2:
                    this.Guardar();
                    break;
                case Keys.F3:
                    this.Borrar();
                    break;
                case Keys.F4:
                    this.Consulta();
                    break;

                case Keys.Escape:
                    this.Salir();
                    break;
                default:
                    break;
            }
        }

        private void dgListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Presentar(int.Parse(this.dgListado.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));
                this.btnEliminar.Enabled = true;
            }
            catch (Exception)
            {


            }
        }

        
    }
}
