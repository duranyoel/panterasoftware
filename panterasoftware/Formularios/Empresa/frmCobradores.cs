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

namespace panterasoftware.Empresa
{
    public partial class frmCobradores : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmCobradores()
        {
            InitializeComponent();
        }

        private void frmCobradores_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void frmCobradores_Load(object sender, EventArgs e)
        {
            this.Nuevo();
        }
        private void Nuevo()
        {

            this.txtNombre.Text = "";
            this.lblFicha.Text = "0";
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtRif.Text = "";
            this.txtDireccion.Text = "";
            this.txtComision.Text = "0,00";
            this.txtContrato.Text = "";
            this.txtTelOfi.Text = "";
            this.btnEliminar.Enabled = false;
            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;

        }
        private void Guardar()
        {
            App_Code.Empresa.Cobradores oRegistro = new App_Code.Empresa.Cobradores(int.Parse(this.lblFicha.Text));

            try
            {
                if (!Validar())
                {
                    oRegistro.Codigo = this.txtCodigo.Text.ToString().ToUpper();
                    oRegistro.Nombre = this.txtNombre.Text.ToString().ToUpper();
                    oRegistro.Apellido = this.txtApellido.Text.ToString().ToUpper();
                    oRegistro.Rif = this.txtRif.Text.ToString().ToUpper();
                    oRegistro.Direccion = this.txtDireccion.Text.ToString().ToUpper();
                    oRegistro.Comision = decimal.Parse(this.txtComision.Text.ToString());
                    oRegistro.Contrato = this.txtContrato.Text.ToString().ToUpper();
                    oRegistro.Telefono = this.txtTelOfi.Text.ToString();

                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201002");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201003");
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
        private void Presentar(int id)
        {
            App_Code.Empresa.Cobradores oRegistro = new App_Code.Empresa.Cobradores(id);


            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo.ToString();
            this.txtNombre.Text = oRegistro.Nombre.ToString();
            this.txtApellido.Text = oRegistro.Apellido.ToString();
            this.txtRif.Text = oRegistro.Rif.ToString();
            this.txtDireccion.Text = oRegistro.Direccion.ToString();
            this.txtComision.Text = oRegistro.Comision.ToString("#,##0.00");
            this.txtContrato.Text = oRegistro.Contrato.ToString();
            this.txtTelOfi.Text = oRegistro.Telefono.ToString();
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201004");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }

        }
        private void Borrar()
        {
            try
            {

                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201004");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Empresa.Cobradores oRegistro = new App_Code.Empresa.Cobradores(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Eliminar();
                        this.Nuevo();
                        this.Consulta();
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
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201005");
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
                        "telefono " +

                    "FROM cobradores " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "ci_rif LIKE '%" + this.txtBuscar.Text + "%' OR " +
                            "nombre LIKE '%" + this.txtBuscar.Text + "%') " +

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
                this.dgListado.Columns[3].HeaderText = "Telefono";

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
                    return true;
                }
                if (this.txtNombre.Text.Length == 0)
                {
                    this.txtNombre.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ingrese un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }


            }
            return false;
        }
        private void Salir()
        {
            this.Close();

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

        private void frmCobradores_KeyDown(object sender, KeyEventArgs e)
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
