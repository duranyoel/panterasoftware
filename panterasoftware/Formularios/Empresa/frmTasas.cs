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

namespace panterasoftware.Configuracion
{
    public partial class frmTasas : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmTasas()
        {
            InitializeComponent();
        }

        private void frmTasas_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void frmTasas_Load(object sender, EventArgs e)
        {
            this.Nuevo();
        }
        private void Nuevo()
        {
           
            this.txtNombre.Text = "";
            this.lblFicha.Text = "0";
            this.txtValor.Text = "0,00";
            this.btnEliminar.Enabled = false;
            this.txtValor.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
          
        }
        private void Guardar()
        {
            App_Code.Empresa.Tasas oRegistro = new App_Code.Empresa.Tasas(int.Parse(this.lblFicha.Text));

            try
            {
                if (!Validar())
                {
                    oRegistro.Valor = decimal.Parse(this.txtValor.Text.ToString());
                    oRegistro.Nombre = this.txtNombre.Text.ToString().ToUpper();

                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200802");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200803");
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
            App_Code.Empresa.Tasas oRegistro = new App_Code.Empresa.Tasas(id);
           

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtValor.Text = oRegistro.Valor.ToString("#,##0.00");
            this.txtNombre.Text = oRegistro.Nombre.ToString();
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200804");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }

        }
        private void Borrar()
        {
            try
            {

                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200804");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Empresa.Tasas oRegistro = new App_Code.Empresa.Tasas(int.Parse(this.lblFicha.Text.ToString()));
                       
                        this.Nuevo();
                        oRegistro.Eliminar();
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
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200805");
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
                       
                        "nombre, " +
                        "tasa " +

                    "FROM tasas " +

                    "WHERE (" +
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
                this.dgListado.Columns[1].HeaderText = "Nombre";
                this.dgListado.Columns[2].HeaderText = "Tasa";
                this.dgListado.Columns[2].DefaultCellStyle.Format = "N2";
                this.dgListado.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
               
            }
        }
        private bool Validar()
        {
            if (this.txtValor.Text.Length == 0 || this.txtNombre.Text.Length == 0)
            {
                if (this.txtValor.Text.Length == 0)
                {
                    this.txtValor.BackColor = Color.Red;
                    MessageBox.Show("Disculpe ingrese un valor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmTasas_KeyDown(object sender, KeyEventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }
    }
}
