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
    public partial class frmUsuarios : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Formularios.frmPrincipal.abierto = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.Nuevo();
            this.Grupos();
            

        }
        //Propiedades
        private void Nuevo()
        {
            this.txtUsuario.Text = "";
            this.txtNombres.Text = "";
            this.txtApellidos.Text = "";
            this.txtBuscar.Text = "";
            this.txtClave.Text = "";
            this.txtRepClave.Text = "";
            this.cmbEstatus.Text = "Activo";
            this.lblFicha.Text = "0";
            this.btnEliminar.Enabled = false;
            this.txtUsuario.BackColor = Color.White;
            this.txtNombres.BackColor = Color.White;
            this.dgListado.ClearSelection();
            this.dgFuncionesAsignadas.ClearSelection();

        }
        private void Guardar()
        {
            App_Code.Sistema.Sistema_Usuarios oRegistro = new App_Code.Sistema.Sistema_Usuarios(int.Parse(this.lblFicha.Text));

            oRegistro.EmpresaId = panterasoftware.Formularios.frmPrincipal.id_empresa;
            oRegistro.GrupoId = int.Parse(this.cmbGrupos.SelectedValue.ToString());
            oRegistro.Apellido = this.txtApellidos.Text.ToString().ToUpper();
            oRegistro.Nombre = this.txtNombres.Text.ToString().ToUpper();
            oRegistro.Clave = this.txtClave.Text.ToString();
            oRegistro.Usuario = this.txtUsuario.Text.ToString();
            oRegistro.Estatus = this.cmbEstatus.SelectedItem.ToString();

            oRegistro.FechaAlta = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200302");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200303");
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
                    //this.Consulta();
                    this.Presentar(oRegistro.Id);
                }
            }
            catch (Exception)
            {


            }

        }
        private void Presentar(int id)
        {
            App_Code.Sistema.Sistema_Usuarios oRegistro = new App_Code.Sistema.Sistema_Usuarios(id);
            App_Code.Sistema.Sistema_Grupos oGrupo = new App_Code.Sistema.Sistema_Grupos(oRegistro.GrupoId);

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtApellidos.Text = oRegistro.Apellido;
            this.txtNombres.Text = oRegistro.Nombre;
            this.txtClave.Text = oRegistro.Clave;
            this.txtRepClave.Text = oRegistro.Clave;
            this.txtUsuario.Text = oRegistro.Usuario;
            this.cmbEstatus.Text = oRegistro.Estatus;
            this.BuscarAsignados();
            this.txtUsuario.BackColor = Color.White;
            this.txtNombres.BackColor = Color.White;
            this.cmbGrupos.Text = oGrupo.Nombre;
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200304");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }
        }
        private void Borrar()
        {
            try
            {

                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200304");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Sistema.Sistema_Usuarios oRegistro = new App_Code.Sistema.Sistema_Usuarios(int.Parse(this.lblFicha.Text));
                        oRegistro.FechaBaja = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                        oRegistro.Estatus = "Bloqueado";
                        oRegistro.Actualizar();
                        this.Nuevo();
                        MessageBox.Show(oRegistro.Msg + ", El usuario a sido bloqueado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        private bool Validar()
        {
            if (this.txtUsuario.Text.Length == 0 || this.txtNombres.Text.Length == 0)
            {

                this.txtNombres.BackColor = Color.Red;
                this.txtUsuario.BackColor = Color.Red;
                MessageBox.Show("Disculpe verifique los campos en rojo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }
            if (this.txtClave.Text != this.txtRepClave.Text)
            {
                MessageBox.Show("Disculpe las contraseñas no coinciden", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.lblFicha.Text == "0")
            {
                DataTable oTabla = new App_Code.Sistema.Sistema_Usuarios().Buscar(
                   1,
                   "id",
                   "(usuario = '" + this.txtUsuario.Text + "')",
                   "");
                if (oTabla.Rows.Count > 0)
                {
                    this.txtUsuario.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ya el usuario existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            else
            {
                DataTable oTabla = new App_Code.Sistema.Sistema_Usuarios().Buscar(
                   1,
                   "id",
                   "(usuario = '" + this.txtUsuario.Text + "') AND (id <> '" + this.lblFicha.Text + "')",
                   "");
                if (oTabla.Rows.Count > 0)
                {
                    this.txtUsuario.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ya el usuario existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }
        private void Consulta()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200305");
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
                        "sistema_usuarios.id, " +
                        "sistema_usuarios.nombre, " +
                        "sistema_usuarios.apellido, " +
                        "sistema_usuarios.usuario, " +
                        "sistema_usuarios.estatus, " +
                        "sistema_empresas.nombre AS empresa " +

                    "FROM sistema_usuarios " +
                        "INNER JOIN sistema_empresas ON sistema_usuarios.empresa_id = sistema_empresas.id " +

                    "WHERE (" +
                            "sistema_usuarios.usuario LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "sistema_usuarios.apellido LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "sistema_usuarios.estatus LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "sistema_usuarios.nombre LIKE '%" + this.txtBuscar.Text + "%') "+

                    "ORDER BY " +
                        "sistema_usuarios.id, " +
                        "sistema_usuarios.nombre;", oConexion);

                oConexion.Open();
                oAdaptador.Fill(oDataSet, "tabla");
                oTabla = oDataSet.Tables["tabla"];
                oConexion.Close();
                this.dgListado.DataSource = oTabla;

                //Encabezado
                this.dgListado.Columns[0].HeaderText = "Ficha";

                this.dgListado.Columns[1].HeaderText = "Nombre";
                this.dgListado.Columns[2].HeaderText = "Apellido";
                this.dgListado.Columns[3].HeaderText = "Usuario";
                this.dgListado.Columns[4].HeaderText = "Estatus";
                this.dgListado.Columns[5].HeaderText = "Empresa";
            }
        }
        private void Salir()
        {
            this.Close();
            panterasoftware.Formularios.frmPrincipal.abierto = false;
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
       
        private void BuscarAsignados()
        {
            DataTable oTabla = new DataTable();
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(new App_Code.Base().Sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT " +
                    "sistema_funciones.id, " +
                    "sistema_funciones.codigo, " +
                    "sistema_funciones.nombre " +

                "FROM sistema_funciones " +

                "INNER JOIN sistema_grupo_funciones ON sistema_funciones.id = sistema_grupo_funciones.funcion_id " +

                "WHERE (" +
                    "sistema_grupo_funciones.grupo_id = '" + this.cmbGrupos.SelectedValue.ToString() + "') " +

                "GROUP BY " +
                    "sistema_funciones.codigo, " +
                    "sistema_funciones.nombre, " +
                    "sistema_funciones.id ", oConexion);

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

        private void cmbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.BuscarAsignados();
            }
            catch (Exception)
            {

            }
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

        private void frmUsuarios_KeyDown(object sender, KeyEventArgs e)
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

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
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
    }
}
