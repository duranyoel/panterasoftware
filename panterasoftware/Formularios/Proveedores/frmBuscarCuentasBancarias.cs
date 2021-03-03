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
    public partial class frmBuscarCuentasBancarias : Form
    {
        public frmBuscarCuentasBancarias()
        {
            InitializeComponent();
        }
        public void Consulta()
        {
            DataTable oTabla = new DataTable();
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT   " +
                    "cuentas_bancarias.id, " +
                    "cuentas_bancarias.codigo, " +
                    "cuentas_bancarias.nombres, " +
                    "cuentas_bancarias.apellidos, " +
                    "cuentas_bancarias.rif, " +
                    "cuentas_bancarias.tipo_cuenta, " +
                    "cuentas_bancarias.numero_cuenta, " +
                    "bancos.nombre AS banco " +
                "FROM      cuentas_bancarias " +
                    "INNER JOIN bancos ON cuentas_bancarias.id = bancos.id " +
                "WHERE (NOT EXISTS " +
                    "(SELECT   id " +
                    "FROM  cuentasbancarias_proveedores " +
                    "WHERE   (" +
                        "cuentas_bancarias.id = cuentasbancarias_proveedores.cuentabancaria_id) AND (" +
                        "proveedor_id = " + int.Parse(this.lblProveedor.Text) + "))) AND (" +

                "cuentas_bancarias.codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +
                "cuentas_bancarias.apellidos LIKE '%" + this.txtBuscar.Text + "%' OR " +
                "cuentas_bancarias.numero_cuenta LIKE '%" + this.txtBuscar.Text + "%' OR " +
                "bancos.nombre LIKE '%" + this.txtBuscar.Text + "%' OR " +
                "cuentas_bancarias.nombres LIKE '%" + this.txtBuscar.Text + "%') AND (" +
                "bancos.borrado =  0) "+

                "ORDER BY " +
                    "cuentas_bancarias.id;", oConexion);

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oTabla = oDataSet.Tables["tabla"];
            oConexion.Close();
            this.dgListado.DataSource = oTabla;

            //Encabezado
            this.dgListado.Columns[0].HeaderText = "Ficha";
            this.dgListado.Columns[1].HeaderText = "Codigo";
            this.dgListado.Columns[2].HeaderText = "Nombres";
            this.dgListado.Columns[3].HeaderText = "Apellidos";
            this.dgListado.Columns[4].HeaderText = "Rif";
            this.dgListado.Columns[5].HeaderText = "Tipo De Cuenta";
            this.dgListado.Columns[6].HeaderText = "Numero De Cuenta";
            this.dgListado.Columns[7].HeaderText = "Banco";

        }

        private void frmBuscarCuentasBancarias_Load(object sender, EventArgs e)
        {
            this.Consulta();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.Consulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscarCuentasBancarias_KeyDown(object sender, KeyEventArgs e)
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

        private void dgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Formularios
                Formularios.Proveedores.frmControlDeProveedores oFrmProveedor = new frmControlDeProveedores();
                App_Code.Proveedores.CuentasBancariasProveedores oCuenta = new App_Code.Proveedores.CuentasBancariasProveedores();
                panterasoftware.Formularios.frmPrincipal oPrincipal = new frmPrincipal();

                //valores a insertar 
                oCuenta.ProveedorId = int.Parse(this.lblProveedor.Text);
                oCuenta.CuentaBancariaId = int.Parse(this.dgListado.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString());
                oCuenta.Creado = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                oCuenta.UserLogId = panterasoftware.Formularios.frmPrincipal.id_usuario;
                oCuenta.Insertar();
                oFrmProveedor.Presentar(int.Parse(this.lblProveedor.Text));
                oFrmProveedor.ConsultaCuentasBancarias();
                oFrmProveedor.Refresh();
                MessageBox.Show(oCuenta.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Consulta();
            }
            catch (Exception)
            {


            }


        }
    }
}
