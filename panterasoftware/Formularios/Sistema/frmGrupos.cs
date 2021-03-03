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

namespace panterasoftware.Sistema
{
    public partial class frmGrupos : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmGrupos()
        {
            InitializeComponent();
        }

        private void frmGrupos_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void frmGrupos_Load(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        //Propiedades
        private void Nuevo()
        {
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.lblFicha.Text = "0";
            this.btnEliminar.Enabled = false;
            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;

            this.Consulta();
        }
        private void Guardar()
        {
            App_Code.Sistema.Sistema_Grupos oRegistro = new App_Code.Sistema.Sistema_Grupos(int.Parse(this.lblFicha.Text));

            oRegistro.Codigo = this.txtCodigo.Text.ToString().ToUpper();
            oRegistro.Nombre = this.txtNombre.Text.ToString().ToUpper();

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200502");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200503");
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

            }

        }
        private void Presentar(int id)
        {
            App_Code.Sistema.Sistema_Grupos oRegistro = new App_Code.Sistema.Sistema_Grupos(id);

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo;
            this.txtNombre.Text = oRegistro.Nombre;
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200504");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }
        }
        private void Borrar()
        {
            try
            {

                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200504");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        App_Code.Sistema.Sistema_Grupos oRegistro = new App_Code.Sistema.Sistema_Grupos(int.Parse(this.lblFicha.Text.ToString()));
                        if (oRegistro.Nombre == "Administrador" || oRegistro.Nombre == "Desarrollo")
                        {
                            MessageBox.Show("Disculpe Usted No Puede Borrar Grupos Predeterminados Del Sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            oRegistro.Eliminar();
                            this.Nuevo();
                            MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }

                }


            }
            catch (Exception)
            {
            }

        }
        private bool Validar()
        {
            if (this.txtCodigo.Text.Length == 0 || this.txtNombre.Text.Length == 0)
            {
                if (this.txtCodigo.Text.Length == 0)
                {
                    this.txtCodigo.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ingrese un codigo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (this.txtNombre.Text.Length == 0)
                {
                    this.txtNombre.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ingrese un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            return false;
        }
        private void Consulta()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200505");
            if (oFuncion.Err)
            {

                MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                DataTable oTabla = new DataTable();
                DataSet oDataSet = new DataSet();
                SqlConnection oConexion = new SqlConnection(new App_Code.Base().Sql);
                SqlDataAdapter oAdaptador = new SqlDataAdapter(
                    "SELECT " +
                        "id, " +
                        "codigo, " +
                        "nombre " +

                    "FROM sistema_grupos " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "nombre LIKE '%" + this.txtBuscar.Text + "%') " +

                    "ORDER BY " +
                        "id, " +
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
            }
        }
        private void Salir()
        {
            this.Close();
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
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

        private void frmGrupos_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
    }
}
