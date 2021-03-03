using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
using panterasoftware.Configuracion;

namespace panterasoftware.Empresa
{
    public partial class frmEmpresa : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public static int empresa = 0;
        private static string dest = Application.StartupPath + "/upload/empresas/";
        public frmEmpresa()
        {
            InitializeComponent();

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEmpresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }
        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            if (empresa > 0)
            {
                this.Presentar();
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200801");
                if (oFuncion.Err)
                {

                    this.btnTasas.Enabled = false;
                    return;
                }
                else
                {
                    this.btnTasas.Enabled = true;
                    return;
                }

            }

        }
        private void Nuevo()
        {
            this.txtPais.Text = "";
            this.txtEstado.Text = "";
            this.txtMunicipio.Text = "";
            this.txtParroquia.Text = "";
            this.txtNombre.Text = "";
            this.txtDomicilio.Text = "";
            this.txtCiudad.Text = "";
            this.txtCodigo.Text = "";
            this.txtCodigo.Enabled = true;
            this.txtCodigoSuc.Text = "";
            this.txtCodPostal.Text = "";
            this.txtDenominacion.Text = "";
            this.txtEmail.Text = "";
            this.txtFax.Text = "";
            this.txtNombreContacto.Text = "";
            this.txtNombreSuc.Text = "";
            this.txtRif.Text = "";
            this.txtTelCel.Text = "";
            this.txtTelContacto.Text = "";
            this.txtTelOfi.Text = "";
            this.txtWeb.Text = "";
            this.txtRegistro.Text = "";
            this.txtRetencionIslr.Text = "0,00";
            this.txtRetencionIva.Text = "0,00";
            this.txtFactor.Text = "0,00";
            this.txtDebito.Text = "0,00";
            this.txtTomo.Text = "";
            this.txtHoja.Text = "";
            this.txtFolio.Text = "";
            this.campoFoto.Image = Properties.Resources.Factory;
            this.lblNombreFoto.Text = "Nombre";
            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.txtDenominacion.BackColor = Color.White;
        }
        private void Aplicar()
        {
            try
            {
                App_Code.Configuracion.Empresa oRegistro = new App_Code.Configuracion.Empresa(empresa);
                App_Code.Sistema.Sistema_Empresas oEmpresa = new App_Code.Sistema.Sistema_Empresas(oRegistro.Id);

                oEmpresa.Nombre = this.txtNombre.Text;

                oRegistro.Pais = this.txtPais.Text.ToString().ToUpper();
                oRegistro.Estado = this.txtEstado.Text.ToString().ToUpper();
                oRegistro.Municipio = this.txtMunicipio.Text.ToString().ToUpper();
                oRegistro.Parroquia = this.txtParroquia.Text.ToString().ToUpper();
                oRegistro.Nombre = this.txtNombre.Text;
                oRegistro.Direccion = this.txtDomicilio.Text.ToString().ToUpper();
                oRegistro.Denominacion_Social = this.txtDenominacion.Text.ToString().ToUpper();
                oRegistro.Rif = this.txtRif.Text.ToString().ToUpper();
                oRegistro.Telefono = this.txtTelOfi.Text;
                oRegistro.TelefonoCel = this.txtTelCel.Text;
                oRegistro.Sucursal = this.txtNombreSuc.Text;
                oRegistro.Cod_Sucursal = this.txtCodigoSuc.Text.ToString().ToUpper();
                oRegistro.Contacto = this.txtNombreContacto.Text.ToString().ToUpper();
                oRegistro.TelefonoContacto = this.txtTelContacto.Text;
                oRegistro.Fax = this.txtFax.Text;
                oRegistro.Email = this.txtEmail.Text;
                oRegistro.WebSite = this.txtWeb.Text;
                oRegistro.Registro = this.txtRegistro.Text;
                oRegistro.Codigo = this.txtCodigo.Text.ToString().ToUpper();
                oRegistro.Ciudad = this.txtCiudad.Text.ToString().ToUpper();
                oRegistro.Cod_Postal = this.txtCodPostal.Text;
                oRegistro.Retencion_Iva = decimal.Parse(this.txtRetencionIva.Text.ToString());
                oRegistro.Retencion_Islr = decimal.Parse(this.txtRetencionIslr.Text.ToString());
                oRegistro.Factor_Cambio = decimal.Parse(this.txtFactor.Text.ToString());
                oRegistro.Debito_Bancario = decimal.Parse(this.txtDebito.Text.ToString());
                oRegistro.Imagen = "";
                oRegistro.Tomo = this.txtTomo.Text;
                oRegistro.Hoja = this.txtHoja.Text;
                oRegistro.Folio = this.txtFolio.Text;
                if (this.lblNombreFoto.Text == "Nombre")
                {
                    oRegistro.Imagen = "Ninguna";
                }
                else
                {
                    oRegistro.Imagen = this.lblNombreFoto.Text;
                }


                if (!Validar())
                {
                    oRegistro.Actualizar();
                    oEmpresa.Actualizar();
                    MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Al Intentar Guardar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Presentar()
        {
            App_Code.Configuracion.Empresa oRegistro = new App_Code.Configuracion.Empresa(empresa);
            //Datos
            this.txtPais.Text = oRegistro.Pais;
            this.txtEstado.Text = oRegistro.Estado;
            this.txtMunicipio.Text = oRegistro.Municipio;
            this.txtParroquia.Text = oRegistro.Parroquia;
            this.txtNombre.Text = oRegistro.Nombre;
            this.txtDomicilio.Text = oRegistro.Direccion;
            this.txtCiudad.Text = oRegistro.Ciudad;
            this.txtCodigo.Text = oRegistro.Codigo;
            this.txtCodigo.Enabled = false;
            this.txtCodigoSuc.Text = oRegistro.Cod_Sucursal;
            this.txtCodPostal.Text = oRegistro.Cod_Postal;
            this.txtDenominacion.Text = oRegistro.Denominacion_Social;
            this.txtEmail.Text = oRegistro.Email;
            this.txtFax.Text = oRegistro.Fax;
            this.txtNombreContacto.Text = oRegistro.Contacto;
            this.txtNombreSuc.Text = oRegistro.Sucursal;
            this.txtRif.Text = oRegistro.Rif;
            this.txtTelCel.Text = oRegistro.TelefonoCel;
            this.txtTelContacto.Text = oRegistro.Telefono;
            this.txtTelOfi.Text = oRegistro.Telefono;
            this.txtWeb.Text = oRegistro.WebSite;
            this.txtRegistro.Text = oRegistro.Registro;
            this.txtRetencionIslr.Text = oRegistro.Retencion_Islr.ToString("#,##0.00");
            this.txtRetencionIva.Text = oRegistro.Retencion_Iva.ToString("#,##0.00");
            this.txtFactor.Text = oRegistro.Factor_Cambio.ToString("#,##0.00");
            this.txtDebito.Text = oRegistro.Debito_Bancario.ToString("#,##0.00");
            this.txtTomo.Text = oRegistro.Tomo;
            this.txtHoja.Text = oRegistro.Hoja;
            this.txtFolio.Text = oRegistro.Folio;
            this.Tasas();
            this.ConsultaDeposito();
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
        }
        private bool Validar()
        {
            if (this.txtCodigo.Text.Length == 0)
            {
                this.txtCodigo.BackColor = Color.Red;
                return true;
            }
            if (this.txtNombre.Text.Length == 0)
            {
                this.txtNombre.BackColor = Color.Red;
                return true;
            }
            if (txtDenominacion.Text.Length == 0)
            {
                this.txtDenominacion.BackColor = Color.Red;
                return true;
            }
            return false;
        }
        private void ConsultaDeposito()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300301");
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

                    "FROM depositos " +

                    "ORDER BY " +
                        "nombre;", oConexion);

                oConexion.Open();
                oAdaptador.Fill(oDataSet, "tabla");
                oTabla = oDataSet.Tables["tabla"];
                oConexion.Close();
                this.dgDepositos.DataSource = oTabla;

                //Encabezado
                this.dgDepositos.Columns[0].HeaderText = "Ficha";
                this.dgDepositos.Columns[1].HeaderText = "Codigo";
                this.dgDepositos.Columns[2].HeaderText = "Nombre";
                this.dgDepositos.Columns[3].HeaderText = "Telefono";

            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aplicar();
        }
        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            this.BuscarFoto();
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

        private void btnTasas_Click(object sender, EventArgs e)
        {
            Configuracion.frmTasas oTasas = new frmTasas();
            oTasas.ShowDialog();
        }
        private void Tasas()
        {
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200805");
            if (oFuncion.Err)
            {


                return;
            }
            else
            {
                DataTable oTabla = new DataTable();
                DataSet oDataSet = new DataSet();
                SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
                SqlDataAdapter oAdaptador = new SqlDataAdapter(
                    "SELECT  " +
                        "id, " +
                        "nombre, " +
                        "tasa " +

                    "FROM tasas " +

                    "ORDER BY " +
                        "id, " +
                        "nombre;", oConexion);

                oConexion.Open();
                oAdaptador.Fill(oDataSet, "tabla");
                oTabla = oDataSet.Tables["tabla"];
                oConexion.Close();
                this.dgTasas.DataSource = oTabla;

                //Nombres de las columnas
                this.dgTasas.Columns[0].HeaderText = "Ficha";
                this.dgTasas.Columns[1].HeaderText = "Nombre";
                this.dgTasas.Columns[2].HeaderText = "Tasa";
                this.dgTasas.Columns[2].DefaultCellStyle.Format = "N2";
                this.dgTasas.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            }
        }
    }
}
