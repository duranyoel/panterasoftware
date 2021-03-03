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

namespace panterasoftware.Formularios.Proveedores
{
    public partial class frmControlDeProveedores : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public int proveedor_id = 0;

        public frmControlDeProveedores()
        {
            InitializeComponent();
        }
        private void frmControlDeProveedores_Load(object sender, EventArgs e)
        {
            if (proveedor_id == 0)
            {
                this.Nuevo();
            }
            else
            {
                this.Presentar(proveedor_id);

            }
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Grupos();

        }
        private void frmControlDeProveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }
        public void Nuevo()
        {
            this.lblFicha.Text = "0";
            this.proveedor_id = 0;
            //this.cmbDenominacion.Text = "No Contribuyente";
            //this.cmbDenominacion.SelectionStart = 0;
            //this.cmbEstatus.Text = "Activo";
            this.cmbEstatus.SelectedItem = "Activo";
            this.cmbDenominacion.SelectedItem = "No Contribuyente";
            this.dgListadoCuentasBancarias.DataBindings.Clear();
            this.dgListadoCuentasBancarias.Refresh();
            this.dgListadoCuentasBancarias.ClearSelection();


            this.lblCuentas.Text = "0";
            this.txtCreado.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            this.txtModificado.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");


            //Identificación
            this.txtCodigo.Text = "";
            this.txtRif.Text = "";
            this.txtDenominacionSocial.Text = "";
            this.txtNombre.Text = "";


            //Contacto
            this.txtContacto.Text = "";
            this.txtDomicilio.Text = "";
            this.txtTelOfi.Text = "";
            this.txtTelCel.Text = "";
            this.txtFax.Text = "";

            this.txtEmail.Text = "";
            this.txtWeb.Text = "";
            this.txtPais.Text = "";
            this.txtEstado.Text = "";
            this.txtMunicipio.Text = "";
            this.txtParroquia.Text = "";
            this.txtCiudad.Text = "";
            this.txtCodPostal.Text = "";

            //Balance
            this.txtFechaUltCompra.Text = "01/01/1999 12:00";
            this.txtFechaUltPago.Text = "01/01/1999 12:00";//DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

            this.txtDebitos.Text = "00,0";
            this.txtCreditos.Text = "00,0";
            this.txtSaldos.Text = "00,0";
            this.txtAnticipos.Text = "00,0";

            //Notas
            this.txtNotas.Text = "";

            //Contabilidad 
            this.txtVentas1.Text = "00,0";
            this.txtVentas2.Text = "00,0";
            this.txtVentas3.Text = "00,0";
            this.txtVentas4.Text = "00,0";
            this.txtVentasG.Text = "00,0";
            this.txtCobranzas1.Text = "00,0";
            this.txtCobranzas2.Text = "00,0";
            this.txtCobranzas3.Text = "00,0";
            this.txtCobranzas4.Text = "00,0";
            this.txtCobranzasG.Text = "00,0";
            this.txtRetencionIva.Text = "00,0";
            this.txtRetencionIsrl.Text = "00,0";

            this.btnEliminar.Enabled = false;
            this.btnAgregarCuentaAProveedor.Enabled = false;
            this.btnNuevaCuenta.Enabled = false;
            this.btnEliminarCuenta.Enabled = false;
            this.txtRif.BackColor = Color.White;
            this.txtEmail.BackColor = Color.White;


        }
        public void Guardar()
        {
            App_Code.Proveedores.Proveedores oRegistro = new App_Code.Proveedores.Proveedores(int.Parse(this.lblFicha.Text));

            //Datos Identificación
            oRegistro.Codigo = this.txtCodigo.Text.ToString();
            oRegistro.Rif = this.txtRif.Text.ToString().ToUpper();

            oRegistro.Nombre = this.txtNombre.Text.ToString().ToUpper();
            oRegistro.GrupoId = int.Parse(this.cmbGrupo.SelectedValue.ToString());
            oRegistro.RazonSocial = this.txtDenominacionSocial.Text.ToString().ToUpper();

            //Contacto
            oRegistro.Contacto = this.txtContacto.Text.ToString().ToUpper();
            oRegistro.Pais = this.txtPais.Text.ToString().ToUpper();
            oRegistro.Estado = this.txtEstado.Text.ToString().ToUpper();
            oRegistro.Municipio = this.txtMunicipio.Text.ToString().ToUpper();
            oRegistro.Parroquia = this.txtParroquia.Text.ToString().ToUpper();
            oRegistro.DirFiscal = this.txtDomicilio.Text.ToString().ToUpper();
            oRegistro.TelefonoOficina = this.txtTelOfi.Text.ToString().ToUpper();
            oRegistro.TelefonoCelular = this.txtTelCel.Text.ToString().ToUpper();
            oRegistro.Fax = this.txtFax.Text.ToString();
            oRegistro.Email = this.txtEmail.Text.ToString();
            oRegistro.Website = this.txtWeb.Text.ToString();
            oRegistro.CodigoPostal = this.txtCodPostal.Text.ToString();
            oRegistro.Ciudad = this.txtCiudad.Text.ToString().ToUpper();


            //Balance
            oRegistro.FechaUltimaCompra = DateTime.Parse(this.txtFechaUltCompra.Text.ToString());
            oRegistro.FechaUltimoPago = DateTime.Parse(this.txtFechaUltPago.Text.ToString());
            oRegistro.Debitos = double.Parse(this.txtDebitos.Text.ToString());
            oRegistro.Creditos = double.Parse(this.txtCreditos.Text.ToString());
            oRegistro.Saldos = double.Parse(this.txtSaldos.Text.ToString());
            oRegistro.Anticipos = double.Parse(this.txtAnticipos.Text.ToString());

            //Ventas
            oRegistro.Ventas1 = double.Parse(this.txtVentas1.Text.ToString());
            oRegistro.Ventas2 = double.Parse(this.txtVentas2.Text.ToString());
            oRegistro.Ventas3 = double.Parse(this.txtVentas3.Text.ToString());
            oRegistro.Ventas4 = double.Parse(this.txtVentas4.Text.ToString());
            oRegistro.VentasG = double.Parse(this.txtVentasG.Text.ToString());

            //Compras
            oRegistro.Cobranza1 = double.Parse(this.txtCobranzas1.Text.ToString());
            oRegistro.Cobranza2 = double.Parse(this.txtCobranzas2.Text.ToString());
            oRegistro.Cobranza3 = double.Parse(this.txtCobranzas3.Text.ToString());
            oRegistro.Cobranza4 = double.Parse(this.txtCobranzas4.Text.ToString());
            oRegistro.CobranzaG = double.Parse(this.txtCobranzasG.Text.ToString());

            //Impuestos 
            oRegistro.RetencionIva = double.Parse(this.txtRetencionIva.Text.ToString());
            oRegistro.RetencionIslr = double.Parse(this.txtRetencionIsrl.Text.ToString());

            //Notas
            oRegistro.Notas = this.txtNotas.Text.ToString().ToUpper();
            oRegistro.Advertencia = this.txtAdvertencia.Text.ToString().ToUpper();
            
            oRegistro.Estatus = this.cmbEstatus.SelectedText.ToString();
            oRegistro.DenominacionFiscal = this.cmbDenominacion.SelectedText.ToString();
            oRegistro.Borrado = false;
            oRegistro.UserLogId = panterasoftware.Formularios.frmPrincipal.id_usuario;
            

            try
            {
                if (!Validar())
                {




                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200102");
                        if (oFuncion.Err)
                        {

                            MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            oRegistro.Creado = DateTime.Parse(this.txtCreado.Text.ToString());
                            oRegistro.Modificado = DateTime.Parse(this.txtModificado.Text.ToString());
                            oRegistro.Insertar();
                        }

                    }
                    else
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200103");
                        if (oFuncion.Err)
                        {

                            MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            oRegistro.Modificado = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                            oRegistro.Actualizar();

                        }


                    }
                    MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Presentar(oRegistro.Id);
                }
            }
            catch (Exception)
            {

                
            }
        }
        public void Presentar(int id)
        {
            App_Code.Proveedores.Proveedores oRegistro = new App_Code.Proveedores.Proveedores(id);
            App_Code.Proveedores.Grupos oGrupo = new App_Code.Proveedores.Grupos(oRegistro.GrupoId);
            //this.txtCodigo.Enabled = false;
            this.txtRif.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo.ToString();
            this.txtNombre.Text = oRegistro.Nombre.ToString();
            this.cmbGrupo.Text = oGrupo.Nombre.ToString();

            this.txtDenominacionSocial.Text = oRegistro.RazonSocial.ToString();
            this.txtRif.Text = oRegistro.Rif.ToString();

            //Contacto
            this.txtContacto.Text = oRegistro.Contacto.ToString();
            this.txtPais.Text = oRegistro.Pais.ToString();
            this.txtEstado.Text = oRegistro.Estado.ToString();
            this.txtMunicipio.Text = oRegistro.Municipio.ToString();
            this.txtParroquia.Text = oRegistro.Parroquia.ToString();
            this.txtCiudad.Text = oRegistro.Ciudad.ToString();
            this.txtDomicilio.Text = oRegistro.DirFiscal.ToString();
            this.txtTelOfi.Text = oRegistro.TelefonoOficina.ToString();
            this.txtTelCel.Text = oRegistro.TelefonoCelular.ToString();
            this.txtFax.Text = oRegistro.Fax.ToString();
            this.txtEmail.Text = oRegistro.Email.ToString();
            this.txtWeb.Text = oRegistro.Website.ToString();
            this.txtCodPostal.Text = oRegistro.CodigoPostal.ToString();

            //Balance
            this.txtFechaUltCompra.Text = oRegistro.FechaUltimaCompra.ToString("dd/MM/yyyy hh:mm tt");
            this.txtFechaUltPago.Text = oRegistro.FechaUltimoPago.ToString("dd/MM/yyyy hh:mm tt");
            this.txtDebitos.Text = oRegistro.Debitos.ToString("#,##0.00");
            this.txtCreditos.Text = oRegistro.Creditos.ToString("#,##0.00");
            this.txtSaldos.Text = oRegistro.Saldos.ToString("#,##0.00");
            this.txtAnticipos.Text = oRegistro.Anticipos.ToString("#,##0.00");

            //Ventas
            this.txtVentas1.Text = oRegistro.Ventas1.ToString("#,##0.00");
            this.txtVentas2.Text = oRegistro.Ventas2.ToString("#,##0.00");
            this.txtVentas3.Text = oRegistro.Ventas3.ToString("#,##0.00");
            this.txtVentas4.Text = oRegistro.Ventas4.ToString("#,##0.00");
            this.txtVentasG.Text = oRegistro.VentasG.ToString("#,##0.00");


            //Compras
            this.txtCobranzas1.Text = oRegistro.Cobranza1.ToString("#,##0.00");
            this.txtCobranzas2.Text = oRegistro.Cobranza2.ToString("#,##0.00");
            this.txtCobranzas3.Text = oRegistro.Cobranza3.ToString("#,##0.00");
            this.txtCobranzas4.Text = oRegistro.Cobranza4.ToString("#,##0.00");
            this.txtCobranzasG.Text = oRegistro.CobranzaG.ToString("#,##0.00");


            //Impuestos 
            this.txtRetencionIva.Text = oRegistro.RetencionIva.ToString("#,##0.00");
            this.txtRetencionIsrl.Text = oRegistro.RetencionIslr.ToString("#,##0.00");


            //Notas
            this.txtNotas.Text = oRegistro.Notas.ToString();
            this.txtAdvertencia.Text = oRegistro.Advertencia.ToString();
            this.txtCreado.Text = oRegistro.Creado.ToString("dd/MM/yyyy hh:mm tt");
            this.txtModificado.Text = oRegistro.Modificado.ToString("dd/MM/yyyy hh:mm tt");
            this.cmbEstatus.Text = oRegistro.Estatus.ToString();
            this.cmbDenominacion.Text = oRegistro.DenominacionFiscal.ToString();

            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200104");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }
            this.proveedor_id = oRegistro.Id;
            this.btnAgregarCuentaAProveedor.Enabled = true;
            this.ConsultaCuentasBancarias();
            

        }
        private void Borrar()
        {
            try
            {
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200104");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Proveedores.Proveedores oRegistro = new App_Code.Proveedores.Proveedores(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Borrado = true;
                        oRegistro.Actualizar();
                        this.Nuevo();
                        MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {

               
            }
        }
        public void Consulta()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200105");
            if (oFuncion.Err)
            {

                MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                frmBuscarProveedores oProveedor = new frmBuscarProveedores();
                
                oProveedor.Show();
                //this.Dispose();
            }

        }
        private void BuscarAgenciaBanco()
        {
            panterasoftware.Administracion.frmBancos oBancos = new panterasoftware.Administracion.frmBancos();
            oBancos.ShowDialog();
        }
        public void ConsultaCuentasBancarias()
        {

            DataTable oTabla = new DataTable();
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(

                "SELECT " +
                    "cuentas_bancarias.id, " +
                    "cuentasbancarias_proveedores.id, " +
                    "bancos.nombre AS banco, " +
                    "cuentas_bancarias.tipo_cuenta, " +
                    "cuentas_bancarias.numero_cuenta, " +
                    "cuentas_bancarias.rif, " +
                    "cuentas_bancarias.nombres, " +
                    "cuentas_bancarias.apellidos " +
                "FROM " +
                    "cuentasbancarias_proveedores " +

                "INNER JOIN cuentas_bancarias ON cuentasbancarias_proveedores.cuentabancaria_id = cuentas_bancarias.id " +
                "INNER JOIN bancos ON cuentas_bancarias.banco_id = bancos.id " +
                "WHERE   (cuentasbancarias_proveedores.proveedor_id = " + int.Parse(this.lblFicha.Text) + ")", oConexion);

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oTabla = oDataSet.Tables["tabla"];
            oConexion.Close();
            this.dgListadoCuentasBancarias.DataSource = oTabla;

            //Encabezado
            this.dgListadoCuentasBancarias.Columns[0].HeaderText = "Id";
            this.dgListadoCuentasBancarias.Columns[1].HeaderText = "Id Cuenta";
            this.dgListadoCuentasBancarias.Columns[2].HeaderText = "Banco";
            this.dgListadoCuentasBancarias.Columns[3].HeaderText = "Tipo";
            this.dgListadoCuentasBancarias.Columns[4].HeaderText = "Numero";
            this.dgListadoCuentasBancarias.Columns[5].HeaderText = "Rif/Cedula";
            this.dgListadoCuentasBancarias.Columns[6].HeaderText = "Nombres";
            this.dgListadoCuentasBancarias.Columns[7].HeaderText = "Apellidos";
            //this.dgListadoCuentasBancarias.Columns[7].HeaderText = "Numero";


        }
        private bool Validar()
        {
            if (this.txtCodigo.Text.Length == 0)
            {
                this.txtCodigo.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un codigo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtNombre.Text.Length == 0)
            {
                this.txtNombre.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtDenominacionSocial.Text.Length == 0)
            {
                this.txtDenominacionSocial.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese una denominación social", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (this.lblFicha.Text == "0")
            {
                DataTable oTabla = new App_Code.Proveedores.Proveedores().Buscar(
                   1,
                   "id",
                   "(rif = '" + this.txtRif.Text + "')",
                   "");
                if (oTabla.Rows.Count > 0)
                {
                    this.txtRif.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ya el rif existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            else
            {
                DataTable oTabla = new App_Code.Proveedores.Proveedores().Buscar(
                   1,
                   "id",
                   "(rif = '" + this.txtRif.Text + "') AND (id <> '" + this.lblFicha.Text + "')",
                   "");
                if (oTabla.Rows.Count > 0)
                {
                    this.txtRif.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ya el rif existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;
        }
        private void Salir()
        {
            this.Close();
        }
        private void Grupos()
        {
            this.cmbGrupo.DataSource = new App_Code.Proveedores.Grupos().Buscar(0,
                    "id,nombre",
                    "",
                    "nombre");
            this.cmbGrupo.DisplayMember = "nombre";
            this.cmbGrupo.ValueMember = "id";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }

        private void btnAgregarAgencia_Click(object sender, EventArgs e)
        {
            this.BuscarAgenciaBanco();
        }

        private void frmControlDeProveedores_KeyDown(object sender, KeyEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Borrar();
        }


        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {

            panterasoftware.Formularios.Proveedores.frmBuscarCuentasBancarias oCuentas = new frmBuscarCuentasBancarias();
            oCuentas.lblProveedor.Text = this.lblFicha.Text;
            oCuentas.ShowDialog();
        }

        private void btnNuevaCuenta_Click(object sender, EventArgs e)
        {
            panterasoftware.Administracion.frmCuentasBancarias oCuenta = new Administracion.frmCuentasBancarias();

            oCuenta.ShowDialog();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            App_Code.Proveedores.CuentasBancariasProveedores oCuentaProveedor = new App_Code.Proveedores.CuentasBancariasProveedores(int.Parse(this.lblCuentas.Text.ToString()));

            if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oCuentaProveedor.Eliminar();
                this.ConsultaCuentasBancarias();
            }


        }

        private void dgListadoCuentasBancarias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                panterasoftware.Administracion.frmCuentasBancarias oCuenta = new Administracion.frmCuentasBancarias();
                oCuenta.ShowDialog();
                oCuenta.Presentar(int.Parse(this.dgListadoCuentasBancarias.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));
                oCuenta.gbCorrelativos.Enabled = false;
                oCuenta.gbDatosCuenta.Enabled = false;
                oCuenta.gbDatosTitular.Enabled = false;
                oCuenta.gbListado.Enabled = false;
                oCuenta.btnGuardar.Enabled = false;
                oCuenta.btnNuevo.Enabled = false;
            }
            catch (Exception)
            {


            }

        }

        private void dgListadoCuentasBancarias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.lblCuentas.Text = this.dgListadoCuentasBancarias.Rows[int.Parse(e.RowIndex.ToString())].Cells[1].Value.ToString();
                this.btnNuevaCuenta.Enabled = true;
                this.btnEliminarCuenta.Enabled = true;
            }
            catch (Exception)
            {


            }
        }

        private void dgListadoCuentasBancarias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
