using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace panterasoftware.Configuracion
{
    public partial class frmSelEmpresa : Form
    {
        public frmSelEmpresa()
        {
            InitializeComponent();
        }

        private void frmSelEmpresa_Load(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void Buscar()
        {
            DataTable oTabla = new DataTable();
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(new App_Code.Base().Sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT  " +
                    "id, " +
                    "codigo, " +
                    "nombre " +

                "FROM sistema_empresas " +

                "ORDER BY " +
                    "id, " +
                    "nombre;", oConexion);

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oTabla = oDataSet.Tables["tabla"];
            oConexion.Close();
            this.dgEmpresas.DataSource = oTabla;

            //Nombres de las columnas
            this.dgEmpresas.Columns[0].HeaderText = "Ficha";
            this.dgEmpresas.Columns[1].HeaderText = "Codigo";
            this.dgEmpresas.Columns[2].HeaderText = "Nombre";


        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Formularios.frmLogin oLogin = new Formularios.frmLogin();
            oLogin.Show();
            this.Close();
        }

        private void frmSelEmpresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnCrearNuevaEmpresa_Click(object sender, EventArgs e)
        {
            panterasoftware.Empresa.frmEmpresa oRegistro = new panterasoftware.Empresa.frmEmpresa();
            oRegistro.Show();
            this.Close();
        }

        private void dgEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                panterasoftware.Formularios.frmPrincipal oInicio = new panterasoftware.Formularios.frmPrincipal();
                App_Code.Sistema.Sistema_Empresas oEmpresa = new App_Code.Sistema.Sistema_Empresas(int.Parse(this.dgEmpresas.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));

                SqlConnection oConexion = new SqlConnection(oEmpresa.CadenaConexion);
                oConexion.Open();
                if (oConexion.State == ConnectionState.Open)
                {
                    oInicio.CargoDatos(oEmpresa.Codigo);
                    oInicio.Show();
                    this.Close();
                }

            }
            catch (Exception)
            {
                panterasoftware.Formularios.frmPrincipal oInicio = new panterasoftware.Formularios.frmPrincipal();
                App_Code.Sistema.Sistema_Empresas oEmpresa = new App_Code.Sistema.Sistema_Empresas(int.Parse(this.dgEmpresas.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));
                MessageBox.Show("A ocurrido un fallo al intentar conectar a la base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Formularios.Configuracion.frmConexionEmpresa oConexion = new Formularios.Configuracion.frmConexionEmpresa();
                Formularios.Configuracion.frmConexionEmpresa.id = oEmpresa.Id;
                Formularios.Configuracion.frmConexionEmpresa.codigo = oEmpresa.Codigo;
                oConexion.Show();
                this.Hide();

            }
        }
    }
}
