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
    public partial class frmFunciones : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmFunciones()
        {
            InitializeComponent();
        }

        private void frmFunciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void frmFunciones_Load(object sender, EventArgs e)
        {
            this.Nuevo();
            this.Modulos();
        }
        private void Nuevo()
        {
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.lblFicha.Text = "0";
            this.cmbEstatus.Text = "Activo";
            this.btnEliminar.Enabled = false;
            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.txtCodigo.Enabled = true;


        }
        private void Guardar()
        {
            App_Code.Sistema.Sistema_Funciones oRegistro = new App_Code.Sistema.Sistema_Funciones(int.Parse(this.lblFicha.Text));

            oRegistro.Codigo = this.txtCodigo.Text.ToString();
            oRegistro.Nombre = this.txtNombre.Text.ToString();
            oRegistro.ModuloId = int.Parse(this.cmbModulo.SelectedValue.ToString());
            oRegistro.Estatus = this.cmbEstatus.SelectedItem.ToString();

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200102");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200103");
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
            App_Code.Sistema.Sistema_Funciones oRegistro = new App_Code.Sistema.Sistema_Funciones(id);
            App_Code.Sistema.Sistema_Modulos oModulo = new App_Code.Sistema.Sistema_Modulos(oRegistro.ModuloId);
            App_Code.Sistema.Sistema_Grupos oGrupo = new App_Code.Sistema.Sistema_Grupos(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario);
            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo.ToString();
            this.txtNombre.Text = oRegistro.Nombre.ToString();
            this.cmbModulo.Text = oModulo.Nombre;
            this.cmbEstatus.Text = oRegistro.Estatus;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;

            if (oGrupo.Codigo == "00004")
            {
                this.txtCodigo.Enabled = true;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200104");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }
        }
        private void Borrar()
        {
            try
            {

                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200104");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Sistema.Sistema_Funciones oRegistro = new App_Code.Sistema.Sistema_Funciones(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Estatus = "Bloqueado";
                        oRegistro.Actualizar();
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
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200105");
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
                        "nombre, " +
                        "estatus " +

                    "FROM sistema_funciones " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "estatus LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "nombre LIKE '%" + this.txtBuscar.Text + "%') " +

                    "ORDER BY " +
                        "codigo, " +
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
                this.dgListado.Columns[3].HeaderText = "Estatus";
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
            if (this.txtNombre.Text.Length == 0)
            {
                this.txtNombre.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.lblFicha.Text == "0")
            {
                DataTable oTabla = new App_Code.Sistema.Sistema_Funciones().Buscar(
                1,
                "id",
                "codigo = '" + this.txtCodigo.Text + "'",
                "");
                if (oTabla.Rows.Count > 0)
                {
                    this.txtCodigo.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ya el codigo existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }else
            {
                DataTable oTabla = new App_Code.Sistema.Sistema_Funciones().Buscar(
                   1,
                   "id",
                   "(codigo = '" + this.txtCodigo.Text + "') AND (id <> '" + this.lblFicha.Text + "')",
                   "");
                if (oTabla.Rows.Count > 0)
                {
                    this.txtCodigo.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ya el usuario existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            


            return false;
        }
        private void Salir()
        {
            this.Close();

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            this.Consulta();

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

        private void frmFunciones_KeyDown(object sender, KeyEventArgs e)
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
    }
}
