using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panterasoftware.Formularios.Inventario
{
    public partial class frmDepartamentos : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        private static string dest = Application.StartupPath + "/upload/departamentos/";
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        private void frmDepartamentos_Load(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        public void Nuevo()
        {
            this.lblFicha.Text = "0";
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            
            this.txtPrecioMaximo.Text = "0,00";
            this.txtPrecioOferta.Text = "0,00";
            this.txtPrecioMayor.Text = "0,00";
            this.txtPrecioMinimo.Text = "0,00";

            this.txtCVPrecioMaximo.Text = "0,00";
            this.txtCVPrecioMayor.Text = "0,00";
            this.txtCVPrecioMinimo.Text = "0,00";
            this.txtCVPrecioOferta.Text = "0,00";
            
            this.txtCCPrecioMaximo.Text = "0,00";
            this.txtCCPrecioMayor.Text = "0,00";
            this.txtCCPrecioMinimo.Text = "0,00";
            this.txtCCPrecioOferta.Text = "0,00";

            this.campoFoto.Image = Properties.Resources.Factory;
            this.lblNombreFoto.Text = "Nombre";

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.btnEliminar.Enabled = false;

        }
        public void Guardar()
        {
            App_Code.Inventario.Departamentos oRegistro = new App_Code.Inventario.Departamentos(int.Parse(this.lblFicha.Text));

            oRegistro.Codigo = this.txtCodigo.Text.ToString().ToUpper();
            oRegistro.Nombre = this.txtNombre.Text.ToString().ToUpper();

            oRegistro.PrecioMayor = double.Parse(this.txtPrecioMayor.Text.ToString());
            oRegistro.PrecioOferta = double.Parse(this.txtPrecioOferta.Text.ToString());
            oRegistro.PrecioMaximo = double.Parse(this.txtPrecioMaximo.Text.ToString());
            oRegistro.PrecioMinimo = double.Parse(this.txtPrecioMinimo.Text.ToString());

            oRegistro.ComisionVentaPrecioMayor = double.Parse(this.txtCVPrecioMayor.Text.ToString());
            oRegistro.ComisionVentaPrecioOferta = double.Parse(this.txtCVPrecioOferta.Text.ToString());
            oRegistro.ComisionVentaPrecioMaximo = double.Parse(this.txtCVPrecioMaximo.Text.ToString());
            oRegistro.ComisionVentaPrecioMinimo = double.Parse(this.txtCVPrecioMinimo.Text.ToString());

            oRegistro.ComisionCobranzaPrecioMayor = double.Parse(this.txtCCPrecioMayor.Text.ToString());
            oRegistro.ComisionCobranzaPrecioOferta = double.Parse(this.txtCCPrecioOferta.Text.ToString());
            oRegistro.ComisionCobranzaPrecioMaximo = double.Parse(this.txtCCPrecioMaximo.Text.ToString());
            oRegistro.ComisionCobranzaPrecioMinimo = double.Parse(this.txtCCPrecioMinimo.Text.ToString());

            if (this.lblNombreFoto.Text == "Nombre")
            {
                oRegistro.Imagen = "Ninguna";
            }
            else
            {
                oRegistro.Imagen = this.lblNombreFoto.Text;
            }
            
            

            oRegistro.Borrado = false;
            oRegistro.UserLogId = frmPrincipal.id_usuario;
            

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300202");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300203");
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


            }

        }
        public void Presentar(int id)
        {
            App_Code.Inventario.Departamentos oRegistro = new App_Code.Inventario.Departamentos(id);

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo;
            this.txtNombre.Text = oRegistro.Nombre;

            this.txtPrecioMaximo.Text = oRegistro.PrecioMaximo.ToString("#,##0.00");
            this.txtPrecioOferta.Text = oRegistro.PrecioOferta.ToString("#,##0.00");
            this.txtPrecioMayor.Text = oRegistro.PrecioMayor.ToString("#,##0.00");
            this.txtPrecioMinimo.Text = oRegistro.PrecioMinimo.ToString("#,##0.00");

            this.txtCCPrecioMaximo.Text = oRegistro.ComisionCobranzaPrecioMaximo.ToString("#,##0.00");
            this.txtCCPrecioOferta.Text = oRegistro.ComisionCobranzaPrecioOferta.ToString("#,##0.00");
            this.txtCCPrecioMayor.Text = oRegistro.ComisionCobranzaPrecioMayor.ToString("#,##0.00");
            this.txtCCPrecioMinimo.Text = oRegistro.ComisionCobranzaPrecioMinimo.ToString("#,##0.00");

            this.txtCVPrecioMaximo.Text = oRegistro.ComisionVentaPrecioMaximo.ToString("#,##0.00");
            this.txtCVPrecioOferta.Text = oRegistro.ComisionVentaPrecioOferta.ToString("#,##0.00");
            this.txtCVPrecioMayor.Text = oRegistro.ComisionVentaPrecioMayor.ToString("#,##0.00");
            this.txtCVPrecioMinimo.Text = oRegistro.ComisionVentaPrecioMinimo.ToString("#,##0.00");

            if (oRegistro.Imagen == "Ninguna" || oRegistro.Imagen == null)
            {
                this.campoFoto.Image = Properties.Resources.Factory;

            }
            else
            {
                try
                {
                    this.campoFoto.Image = Image.FromFile(dest + oRegistro.Imagen);
                    this.lblNombreFoto.Text = oRegistro.Imagen;
                }
                catch (Exception)
                {
                    this.campoFoto.Image = Properties.Resources.Factory;
                    this.lblNombreFoto.Text = "Ninguna";
                }


            }

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;


            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300204");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }

        }
        private void Borrar()
        {
            try
            {
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300204");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Inventario.Departamentos oRegistro = new App_Code.Inventario.Departamentos(int.Parse(this.lblFicha.Text.ToString()));
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
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300205");
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


                    "FROM departamentos " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +

                            "nombre LIKE '%" + this.txtBuscar.Text + "%') AND (" +
                            "borrado = 0) " +

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
        public void Salir()
        {
            this.Close();
           panterasoftware.Formularios.frmPrincipal.abierto = false;
        }
        private void BuscarFoto()
        {
            if (buscarImagen.ShowDialog() == DialogResult.OK)
            {
                string archivo = buscarImagen.FileName.ToString();
                if (Directory.Exists(dest))
                {

                    Path.Combine(dest, archivo);
                    if (!File.Exists(dest + buscarImagen.SafeFileName))
                    {

                        File.Copy(archivo, dest + buscarImagen.SafeFileName, false);
                    }

                }
                else
                {
                    Directory.CreateDirectory(dest);
                    Path.Combine(dest, archivo);
                    if (!File.Exists(dest + buscarImagen.SafeFileName))
                    {
                        File.Copy(archivo, dest + buscarImagen.SafeFileName, false);
                    }

                }
                this.campoFoto.Image = Image.FromFile(archivo);
                this.lblNombreFoto.Text = buscarImagen.SafeFileName;

            }

        }
        private void frmDepartamentos_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }

        private void dgListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Presentar(int.Parse(this.dgListado.Rows[int.Parse(e.RowIndex.ToString())].Cells[0].Value.ToString()));


            }
            catch (Exception)
            {


            }
        }

        private void frmDepartamentos_KeyDown(object sender, KeyEventArgs e)
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

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            this.BuscarFoto();
        }
    }
}
