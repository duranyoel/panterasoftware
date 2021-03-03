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

namespace panterasoftware.Sistema
{
    public partial class frmGruposFunciones : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmGruposFunciones()
        {
            InitializeComponent();
        }

        private void frmGruposFunciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void frmGruposFunciones_Load(object sender, EventArgs e)
        {
            this.Grupos();
            this.Modulos();
        }
        private void Modulos()
        {
            this.cmbModulo.DataSource = new App_Code.Sistema.Sistema_Modulos().Buscar(0,
                    "id,nombre",
                    "",
                    "nombre");
            this.cmbModulo.DisplayMember = "nombre";
            this.cmbModulo.ValueMember = "id";
        }
        private void Grupos()
        {
            this.cmbGrupos.DataSource = new App_Code.Sistema.Sistema_Grupos().Buscar(0,
                    "id,nombre",
                    "",
                    "nombre");
            this.cmbGrupos.DisplayMember = "nombre";
            this.cmbGrupos.ValueMember = "id";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void Salir()
        {
            this.Close();

        }

        private void frmGruposFunciones_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Salir();
                    break;
                default:
                    break;
            }
        }
        private void BuscarNoAsignados()
        {
            DataTable oTabla = new DataTable();
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(new App_Code.Base().Sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT "+
                    "sistema_funciones.id, "+
                    "sistema_funciones.codigo, "+
                    "sistema_funciones.nombre "
                + "FROM sistema_funciones "
                + "INNER JOIN sistema_modulos ON sistema_funciones.modulo_id = sistema_modulos.id "
                + "WHERE NOT "
                + "EXISTS ( "
                    + "SELECT sistema_grupo_funciones.funcion_id, sistema_grupo_funciones.grupo_id, sistema_grupos.nombre "
                        + "FROM sistema_grupo_funciones "
                        + "INNER JOIN sistema_grupos ON sistema_grupo_funciones.grupo_id = sistema_grupos.id "
                    + "WHERE "
                    + "(sistema_funciones.id = sistema_grupo_funciones.funcion_id) AND "
                    + "(sistema_grupos.id = '" + this.cmbGrupos.SelectedValue.ToString() + "')) "
                + "AND (sistema_modulos.id = '" + this.cmbModulo.SelectedValue.ToString() + "')", oConexion);

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oTabla = oDataSet.Tables["tabla"];
            oConexion.Close();
            this.dgFuncionesSinAsignar.DataSource = oTabla;

            //Nombres de las columnas
            this.dgFuncionesSinAsignar.Columns[0].HeaderText = "Ficha";
            this.dgFuncionesSinAsignar.Columns[1].HeaderText = "Codigo";
            this.dgFuncionesSinAsignar.Columns[2].HeaderText = "Nombre";

        }
        private void BuscarAsignados()
        {
            DataTable oTabla = new DataTable();
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(new App_Code.Base().Sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT sistema_grupo_funciones.id,sistema_funciones.codigo, sistema_funciones.nombre\n"
                + "FROM sistema_grupo_funciones\n"
                + "INNER JOIN sistema_funciones ON sistema_grupo_funciones.funcion_id = sistema_funciones.id\n"
                + "INNER JOIN sistema_grupos ON sistema_grupo_funciones.grupo_id = sistema_grupos.id\n"
                + "INNER JOIN sistema_modulos ON sistema_funciones.modulo_id = sistema_modulos.id \n"
                + "WHERE (sistema_modulos.id ='" + this.cmbModulo.SelectedValue.ToString() + "') AND ("
                + "sistema_grupos.id = '" + this.cmbGrupos.SelectedValue.ToString() + "')", oConexion);

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oTabla = oDataSet.Tables["tabla"];
            oConexion.Close();
            this.dgFuncionesAsignadas.DataSource = oTabla;

            //Nombres de las columnas
            this.dgFuncionesAsignadas.Columns[0].HeaderText = "Ficha";
            this.dgFuncionesAsignadas.Columns[1].HeaderText = "Codigo";
            this.dgFuncionesAsignadas.Columns[2].HeaderText = "Nombre";
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarNoAsignados();
                this.BuscarAsignados();
            }
            catch (Exception)
            {


            }
        }

        private void cmbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarNoAsignados();
                this.BuscarAsignados();
            }
            catch (Exception)
            {


            }
        }

        private void dgFuncionesSinAsignar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                App_Code.Sistema.Sistema_Grupo_Funciones oRegistro = new App_Code.Sistema.Sistema_Grupo_Funciones(int.Parse(this.cmbGrupos.SelectedValue.ToString()), int.Parse(this.dgFuncionesSinAsignar.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));
                oRegistro.GrupoId = int.Parse(this.cmbGrupos.SelectedValue.ToString());
                oRegistro.FuncionId = int.Parse(this.dgFuncionesSinAsignar.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString());

                if (oRegistro.Err)
                {
                    oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200602");
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
                this.BuscarAsignados();
                this.BuscarNoAsignados();
            }
            catch (Exception)
            {


            }
        }

        private void dgFuncionesAsignadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                App_Code.Sistema.Sistema_Grupo_Funciones oRegistro = new App_Code.Sistema.Sistema_Grupo_Funciones(int.Parse(this.dgFuncionesAsignadas.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));

                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200603");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    oRegistro.Eliminar();
                }
                this.BuscarAsignados();
                this.BuscarNoAsignados();
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
