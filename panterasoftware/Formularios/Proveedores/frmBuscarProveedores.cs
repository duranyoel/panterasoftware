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
    public partial class frmBuscarProveedores : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmBuscarProveedores()
        {
            InitializeComponent();
        }

        private void frmBuscarProveedores_Load(object sender, EventArgs e)
        {
            this.Consulta();
        }
        public void Consulta()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200205");
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
                        "nombre, " +
                        "rif, " +
                        "razon_social, " +
                        "telefono_ofi, " +
                        "pais, " +
                        "estado, " +
                        "municipio, " +
                        "parroquia " +

                    "FROM proveedores " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "nombre LIKE '%" + this.txtBuscar.Text + "%') AND (" +
                            "borrado = 0) " +

                    "ORDER BY " +
                        "nombre;", oConexion);

                oConexion.Open();
                oAdaptador.Fill(oDataSet, "tabla");
                oTabla = oDataSet.Tables["tabla"];
                oConexion.Close();
                this.dgListado.DataSource = oTabla;

                //Encabezado
                this.dgListado.Columns[0].HeaderText = "Ficha";
                this.dgListado.Columns[1].HeaderText = "Codigo";
                this.dgListado.Columns[2].HeaderText = "Nombre";
                this.dgListado.Columns[3].HeaderText = "Rif";
                this.dgListado.Columns[4].HeaderText = "Razón Social";
                this.dgListado.Columns[5].HeaderText = "Telefono Oficina";
                this.dgListado.Columns[6].HeaderText = "Pais";
                this.dgListado.Columns[7].HeaderText = "Estado";
                this.dgListado.Columns[8].HeaderText = "Municipio";
                this.dgListado.Columns[9].HeaderText = "Parroquia";

            }
        }
        public void Presentar(int id)
        {
            Formularios.Proveedores.frmControlDeProveedores oProveedor = new frmControlDeProveedores();
            App_Code.Proveedores.Proveedores oRegistro = new App_Code.Proveedores.Proveedores(id);
            App_Code.Proveedores.Grupos oGrupo = new App_Code.Proveedores.Grupos(oRegistro.GrupoId);
            //this.txtCodigo.Enabled = false;
            oProveedor.txtRif.BackColor = Color.White;
            oProveedor.txtNombre.BackColor = Color.White;
            oProveedor.lblFicha.Text = oRegistro.Id.ToString("0");
            oProveedor.txtCodigo.Text = oRegistro.Codigo.ToString();
            oProveedor.txtNombre.Text = oRegistro.Nombre.ToString();
            oProveedor.cmbGrupo.Text = oGrupo.Nombre.ToString();

            oProveedor.txtDenominacionSocial.Text = oRegistro.RazonSocial.ToString();
            oProveedor.txtRif.Text = oRegistro.Rif.ToString();

            //Contacto
            oProveedor.txtContacto.Text = oRegistro.Contacto.ToString();
            oProveedor.txtPais.Text = oRegistro.Pais.ToString();
            oProveedor.txtEstado.Text = oRegistro.Estado.ToString();
            oProveedor.txtMunicipio.Text = oRegistro.Municipio.ToString();
            oProveedor.txtParroquia.Text = oRegistro.Parroquia.ToString();
            oProveedor.txtCiudad.Text = oRegistro.Ciudad.ToString();
            oProveedor.txtDomicilio.Text = oRegistro.DirFiscal.ToString();
            oProveedor.txtTelOfi.Text = oRegistro.TelefonoOficina.ToString();
            oProveedor.txtTelCel.Text = oRegistro.TelefonoCelular.ToString();
            oProveedor.txtFax.Text = oRegistro.Fax.ToString();
            oProveedor.txtEmail.Text = oRegistro.Email.ToString();
            oProveedor.txtWeb.Text = oRegistro.Website.ToString();
            oProveedor.txtCodPostal.Text = oRegistro.CodigoPostal.ToString();

            //Balance
            oProveedor.txtFechaUltCompra.Text = oRegistro.FechaUltimaCompra.ToString("dd/MM/yyyy hh:mm tt");
            oProveedor.txtFechaUltPago.Text = oRegistro.FechaUltimoPago.ToString("dd/MM/yyyy hh:mm tt");
            oProveedor.txtDebitos.Text = oRegistro.Debitos.ToString("#,##0.00");
            oProveedor.txtCreditos.Text = oRegistro.Creditos.ToString("#,##0.00");
            oProveedor.txtSaldos.Text = oRegistro.Saldos.ToString("#,##0.00");
            oProveedor.txtAnticipos.Text = oRegistro.Anticipos.ToString("#,##0.00");

            //Ventas
            oProveedor.txtVentas1.Text = oRegistro.Ventas1.ToString("#,##0.00");
            oProveedor.txtVentas2.Text = oRegistro.Ventas2.ToString("#,##0.00");
            oProveedor.txtVentas3.Text = oRegistro.Ventas3.ToString("#,##0.00");
            oProveedor.txtVentas4.Text = oRegistro.Ventas4.ToString("#,##0.00");
            oProveedor.txtVentasG.Text = oRegistro.VentasG.ToString("#,##0.00");


            //Compras
            oProveedor.txtCobranzas1.Text = oRegistro.Cobranza1.ToString("#,##0.00");
            oProveedor.txtCobranzas2.Text = oRegistro.Cobranza2.ToString("#,##0.00");
            oProveedor.txtCobranzas3.Text = oRegistro.Cobranza3.ToString("#,##0.00");
            oProveedor.txtCobranzas4.Text = oRegistro.Cobranza4.ToString("#,##0.00");
            oProveedor.txtCobranzasG.Text = oRegistro.CobranzaG.ToString("#,##0.00");


            //Impuestos 
            oProveedor.txtRetencionIva.Text = oRegistro.RetencionIva.ToString("#,##0.00");
            oProveedor.txtRetencionIsrl.Text = oRegistro.RetencionIslr.ToString("#,##0.00");


            //Notas
            oProveedor.txtNotas.Text = oRegistro.Notas.ToString();
            oProveedor.txtAdvertencia.Text = oRegistro.Advertencia.ToString();
            oProveedor.txtCreado.Text = oRegistro.Creado.ToString("dd/MM/yyyy hh:mm tt");
            oProveedor.txtModificado.Text = oRegistro.Modificado.ToString("dd/MM/yyyy hh:mm tt");
            oProveedor.cmbEstatus.Text = oRegistro.Estatus.ToString();
            oProveedor.cmbDenominacion.Text = oRegistro.DenominacionFiscal.ToString();

            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200104");
            if (!oFuncion.Err)
            {
                oProveedor.btnEliminar.Enabled = true;

            }
            oProveedor.proveedor_id = oRegistro.Id;
            oProveedor.btnAgregarCuentaAProveedor.Enabled = true;
            oProveedor.ConsultaCuentasBancarias();
           
            this.Close();

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscarProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F4:
                    this.Consulta();
                    break;

                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void dgListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            this.Presentar(int.Parse(this.dgListado.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));

        }

        private void dgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
