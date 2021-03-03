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

namespace panterasoftware.Administracion
{
    public partial class frmBancos : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmBancos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void Nuevo()
        {
            this.lblFicha.Text = "0";
            this.txtBuscar.Text = "";
            

            this.txtCodigo.Text = "";
           
            this.txtContacto.Text = "";
            this.txtDireccion.Text = "";
            this.txtEmail.Text = "";
            this.cmbEstatus.Text = "Activo";
            this.txtTelOfi.Text = "";
            this.txtFax.Text = "";
            this.txtWebSite.Text = "";
           
            this.btnEliminar.Enabled = false;
            this.dgListado.ClearSelection();

        }
        private void Guardar()
        {
            App_Code.Administracion.Bancos oRegistro = new App_Code.Administracion.Bancos(int.Parse(this.lblFicha.Text));

            oRegistro.Nombre = this.txtNombre.Text.ToUpper();
            oRegistro.Codigo = this.txtCodigo.Text;
            oRegistro.Contacto = this.txtContacto.Text.ToUpper();
            oRegistro.Telefono = this.txtTelOfi.Text;
            oRegistro.Fax = this.txtFax.Text;
            oRegistro.Email = this.txtEmail.Text;
            oRegistro.WebSite = this.txtWebSite.Text;
            oRegistro.Estatus = this.cmbEstatus.SelectedItem.ToString();
            oRegistro.Direccion = this.txtDireccion.Text.ToUpper();
            oRegistro.UserLogId = panterasoftware.Formularios.frmPrincipal.id_usuario;

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400202");
                        if (oFuncion.Err)
                        {

                            MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            oRegistro.Creado = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                            oRegistro.Modificado = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                            oRegistro.Insertar();
                        }

                    }
                    else
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400203");
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
                    this.Consulta();
                    this.Presentar(oRegistro.Id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void Presentar(int id)
        {
            App_Code.Administracion.Bancos oRegistro = new App_Code.Administracion.Bancos(id);

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo;
            this.txtNombre.Text = oRegistro.Nombre.ToUpper();
            this.txtContacto.Text = oRegistro.Contacto.ToUpper();
            this.txtTelOfi.Text = oRegistro.Telefono;
            this.txtFax.Text = oRegistro.Fax;
            this.txtEmail.Text = oRegistro.Email;
            this.txtWebSite.Text = oRegistro.WebSite;
            this.cmbEstatus.Text = oRegistro.Estatus;
            this.txtDireccion.Text = oRegistro.Direccion;

            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400204");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;

        }
        private void Borrar()
        {
            try
            {
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400204");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Administracion.Bancos oRegistro = new App_Code.Administracion.Bancos(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Borrado = true;
                        oRegistro.Actualizar();
                        this.Nuevo();
                        this.Consulta();
                        MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {

                
            }
        }
        private void Consulta()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400205");
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
                        "nombre " +


                    "FROM bancos " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +

                            "nombre LIKE '%" + this.txtBuscar.Text + "%') AND (" +
                            "borrado = 0 ) "+

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
            return false;
        }
        private void Salir()
        {
            this.Close();
        }
        private void frmBancos_Load(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void frmBancos_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Borrar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void frmBancos_KeyDown(object sender, KeyEventArgs e)
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
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400204");
                if (!oFuncion.Err)
                {
                    this.btnEliminar.Enabled = true;

                }
               
            }
            catch (Exception)
            {


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }

        
    }
}
