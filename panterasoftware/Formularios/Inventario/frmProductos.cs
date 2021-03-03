using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panterasoftware.Formularios.Inventario
{
    public partial class frmProductos : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        private static string dest = Application.StartupPath + "/upload/productos/";
        double costoproveedorsinimpuesto = 0;
        double costofinalconimpuestoyotroscostos = 0;
        double costofinalsinimpuestoyotroscostos = 0;

        double costounidadconimpuestoyotroscostos = 0;
        double costounidadsinimpuestoyotroscostos = 0;
        double costoproveedorconimpuesto = 0;
        double utilidadmaxima = 0;
        double utilidadoferta = 0;
        double utilidadmayor = 0;
        double utilidadminimo = 0;
        double otrocostos = 0;

        double ivaventa = 0;

        double ivacompra = 0;
        double cantidadempaque = 0;

        double valorimpuesto = 0;
        double costofinalconimpuesto = 0;
        double costounidadsinimpuesto = 0;
        double costounidadconimpuesto = 0;

        //calculo utilidad maxima
        double preciomaximosinimpuestofinal = 0;
        double preciomaximoconimpuestofinal = 0;
        double calculoutilidadmaxima = 0;
        double calculoivapreciomaximo = 0;
        double preciomaximofinal = 0;


        double precioofertasinimpuestofinal = 0;
        double precioofertaconimpuestofinal = 0;
        double calculoutilidadoferta = 0;
        double calculoivapreciooferta = 0;
        double precioofertafinal = 0;


        double preciomayorsinimpuestofinal = 0;
        double preciomayorconimpuestofinal = 0;
        double calculoutilidadmayor = 0;
        double calculoivapreciomayor = 0;
        double preciomayorfinal = 0;


        double preciominimosinimpuestofinal = 0;
        double preciominimoconimpuestofinal = 0;
        double calculoutilidadminimo = 0;
        double calculoivapreciominimo = 0;
        double preciominimofinal = 0;

        public frmProductos()
        {
            InitializeComponent();



        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Nuevo();
            this.Departamentos();
            this.Marcas();
            this.UnidadMedida();
            this.IvaCompra();
            this.IvaVenta();
        }
        private void Nuevo()
        {
            this.lblFicha.Text = "0";
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";

            this.txtCostoProveedorSinImpuesto.Text = "0,00";
            this.txtCostoProveedorConImpuesto.Text = "0,00";
            this.txtCostoCalculadoConImpuesto.Text = "0,00";
            this.txtCostoCalculadoSinImpuesto.Text = "0,00";
            this.txtCostoPromedioConImpuesto.Text = "0,00";
            this.txtCostoPromedioSinImpuesto.Text = "0,00";
            this.txtOtrosCostos.Text = "0,00";
            this.txtUltimoCostoConImpuesto.Text = "0,00";
            this.txtUltimoCostoSinImpuesto.Text = "0,00";
            this.txtContenidoempaque.Text = "0";
            this.txtCostoUnidadConImpuesto.Text = "0,00";
            this.txtCostoUnidadSinImpuesto.Text = "0,00";


            this.chkUtilidadDepartamento.Checked = true;

            this.txtPrecioMaximoConimpuesto.Text = "0,00";
            this.txtPrecioMaximoSinImpuesto.Text = "0,00";
            this.txtPrecioMayorConImpuesto.Text = "0,00";
            this.txtPrecioMayorSinImpuesto.Text = "0,00";
            this.txtPrecioMinimoConImpuesto.Text = "0,00";
            this.txtPrecioMinimoSinImpuesto.Text = "0,00";
            this.txtPrecioOfertaConImpuesto.Text = "0,00";
            this.txtPrecioOfertaSinImpuesto.Text = "0,00";

            this.txtUtilidadMaxima.Text = "0,00";
            this.txtUtilidadMayor.Text = "0,00";
            this.txtUtilidadMinimo.Text = "0,00";
            this.txtUtilidadOferta.Text = "0,00";

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;
            this.btnEliminar.Enabled = false;
        }
        private void Guardar()
        {
            App_Code.Inventario.Productos oRegistro = new App_Code.Inventario.Productos(int.Parse(this.lblFicha.Text));



            oRegistro.Nombre = this.txtNombre.Text.ToUpper();
            oRegistro.NombreCorto = this.txtNombreCorto.Text.ToUpper();

            oRegistro.Codigo = this.txtCodigo.Text.ToUpper();


            oRegistro.Borrado = false;
            oRegistro.UserLogId = frmPrincipal.id_usuario;


            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300502");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300503");
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
            App_Code.Inventario.Marcas oRegistro = new App_Code.Inventario.Marcas(id);

            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo;
            this.txtNombre.Text = oRegistro.Nombre;

            this.txtCodigo.BackColor = Color.White;
            this.txtNombre.BackColor = Color.White;


            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300504");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;

            }
        }
        private void Borrar()
        {
            try
            {
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300504");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Inventario.Marcas oRegistro = new App_Code.Inventario.Marcas(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Borrado = true;
                        oRegistro.Actualizar();
                        this.Nuevo();
                        //this.Consulta();
                        MessageBox.Show(oRegistro.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {


            }
        }
        //private void Consulta()
        //{
        //    oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300505");
        //    if (oFuncion.Err)
        //    {

        //        MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        return;
        //    }
        //    else
        //    {
        //        DataTable oTabla = new DataTable();
        //        DataSet oDataSet = new DataSet();
        //        SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
        //        SqlDataAdapter oAdaptador = new SqlDataAdapter(
        //            "SELECT " +
        //                "id, " +
        //                "codigo, " +
        //                "nombre " +


        //            "FROM marcas " +

        //            "WHERE (" +
        //                    "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +

        //                    "nombre LIKE '%" + this.txtBuscar.Text + "%') AND (" +
        //                    "borrado = 0) " +

        //            "ORDER BY " +
        //                "codigo, " +
        //                "nombre;", oConexion);

        //        oConexion.Open();
        //        oAdaptador.Fill(oDataSet, "tabla");
        //        oTabla = oDataSet.Tables["tabla"];
        //        oConexion.Close();
        //        this.dgListado.DataSource = oTabla;

        //        //Encabezado
        //        this.dgListado.Columns[0].HeaderText = "Ficha";
        //        this.dgListado.Columns[1].HeaderText = "Codigo";
        //        this.dgListado.Columns[2].HeaderText = "Nombre";

        //    }
        //}
        private bool Validar()
        {
            if (this.txtCodigo.Text.Length == 0)
            {
                this.txtCodigo.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un codigo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodigo.Focus();
                return true;
            }
            if (this.txtNombre.Text.Length == 0)
            {
                this.txtNombre.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return true;
            }
            if (this.txtContenidoempaque.Text == "")
            {
                this.txtContenidoempaque.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un valor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtContenidoempaque.Focus();
                return true;
            }
            return false;
        }
        private void Salir()
        {
            this.Close();
        }
        private void Departamentos()
        {
            this.cmbDepartamentos.DataSource = new App_Code.Inventario.Departamentos().Buscar(0,
                    "id,'('+ codigo +')' + nombre AS nombre",
                    "",
                    "nombre");
            this.cmbDepartamentos.DisplayMember = "nombre";
            this.cmbDepartamentos.ValueMember = "id";
        }
        private void Marcas()
        {
            this.cmbMarcas.DataSource = new App_Code.Inventario.Marcas().Buscar(0,
                    "id,'('+ codigo +')' + nombre AS nombre",
                    "",
                    "nombre");
            this.cmbMarcas.DisplayMember = "nombre";
            this.cmbMarcas.ValueMember = "id";
        }
        private void UnidadMedida()
        {
            this.cmbUnidadMedida.DataSource = new App_Code.Inventario.UnidadesDeMedidas().Buscar(0,
                    "id,'('+ codigo +')' + nombre AS nombre",
                    "",
                    "nombre");
            this.cmbUnidadMedida.DisplayMember = "nombre";
            this.cmbUnidadMedida.ValueMember = "id";
        }
        private void IvaCompra()
        {
            this.cmbIvaCompra.DataSource = new App_Code.Empresa.Tasas().Buscar(0,
                    "id,tasa",
                    "",
                    "tasa");
            this.cmbIvaCompra.DisplayMember = "tasa";
            this.cmbIvaCompra.ValueMember = "id";
        }
        private void IvaVenta()
        {
            this.cmbIvaVenta.DataSource = new App_Code.Empresa.Tasas().Buscar(0,
                    "id,tasa",
                    "",
                    "tasa");
            this.cmbIvaVenta.DisplayMember = "tasa";
            this.cmbIvaVenta.ValueMember = "id";
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
        private void CalcularCostosYPrecio()
        {
            try
            {


                costoproveedorsinimpuesto = double.Parse(this.txtCostoProveedorSinImpuesto.Text.ToString());

                otrocostos = double.Parse(this.txtOtrosCostos.Text.ToString());

                utilidadmaxima = double.Parse(this.txtUtilidadMaxima.Text);
                utilidadoferta = double.Parse(this.txtUtilidadOferta.Text);
                utilidadmayor = double.Parse(this.txtUtilidadMayor.Text);
                utilidadminimo = double.Parse(this.txtUtilidadMinimo.Text);

                ivaventa = double.Parse(this.cmbIvaVenta.Text);

                ivacompra = double.Parse(this.cmbIvaCompra.Text);
                cantidadempaque = double.Parse(this.txtContenidoempaque.Text);

                //calculo del iva de compra
                valorimpuesto = costoproveedorsinimpuesto * ivacompra / 100;

                //costo proveedor con impuesto

                if (otrocostos > 0)
                {
                    valorimpuesto = (costoproveedorsinimpuesto + otrocostos) * ivacompra / 100;
                    costofinalconimpuestoyotroscostos = costoproveedorsinimpuesto + valorimpuesto;
                    this.txtCostoProveedorConImpuesto.Text = costofinalconimpuestoyotroscostos.ToString("#,##0.00");
                }
                else
                {
                    costoproveedorconimpuesto = costoproveedorsinimpuesto + valorimpuesto;
                    this.txtCostoProveedorConImpuesto.Text = costoproveedorconimpuesto.ToString("#,##0.00");
                }

                //calculo de costos por unidad
                if (this.cantidadempaque > 0)
                {
                    if (otrocostos > 0)
                    {
                        valorimpuesto = (costoproveedorsinimpuesto + otrocostos) * ivacompra / 100;
                        costounidadconimpuestoyotroscostos = (costoproveedorsinimpuesto + valorimpuesto) / cantidadempaque;
                        costounidadsinimpuestoyotroscostos = costoproveedorsinimpuesto / cantidadempaque;

                        
                        this.txtCostoUnidadSinImpuesto.Text = costounidadsinimpuestoyotroscostos.ToString("#,##0.00");
                        this.txtCostoUnidadConImpuesto.Text = costounidadconimpuestoyotroscostos.ToString("#,##0.00");

                    }
                    else
                    {
                        costounidadconimpuesto = (costoproveedorsinimpuesto + valorimpuesto) / cantidadempaque;
                        costounidadsinimpuesto = costoproveedorsinimpuesto / cantidadempaque;
                        this.txtCostoUnidadSinImpuesto.Text = costounidadsinimpuesto.ToString("#,##0.00");
                        this.txtCostoUnidadConImpuesto.Text = costounidadconimpuesto.ToString("#,##0.00");
                    }



                }
                else
                {

                    this.txtCostoUnidadSinImpuesto.Text = "0,00";
                    this.txtCostoUnidadConImpuesto.Text = "0,00";


                }


                //costo proveedor
                if (!this.txtCostoProveedorSinImpuesto.Focused)
                {
                    //this.txtCostoProveedorSinImpuesto.Text = costofinalconimpuesto.ToString();
                }
                if (!this.txtCostoProveedorConImpuesto.Focused)
                {
                    //this.txtCostoProveedorConImpuesto.Text = costoproveedorconimpuesto.ToString("#,##0.00");
                }



                ////costos calculado
                //this.txtCostoCalculadoSinImpuesto.Text = costoproveedorsinimpuesto.ToString("#,##0.00");
                //this.txtCostoCalculadoConImpuesto.Text = costofinalconimpuesto.ToString("#,##0.00");

                ////ultimo costo
                //this.txtUltimoCostoSinImpuesto.Text = costoproveedorsinimpuesto.ToString("#,##0.00");
                //this.txtUltimoCostoConImpuesto.Text = costofinalconimpuesto.ToString("#,##0.00");

                ////costo promedio
                //this.txtCostoPromedioSinImpuesto.Text = costoproveedorsinimpuesto.ToString("#,##0.00");
                //this.txtCostoPromedioConImpuesto.Text = costofinalconimpuesto.ToString("#,##0.00");



                ///*Inicio bloque de calculo de precios maximo -----------------------------*/

                //if (!this.txtPrecioMaximoSinImpuesto.Focused)
                //{
                //    this.txtPrecioMaximoSinImpuesto.Text = costoproveedorsinimpuesto.ToString("#,##0.00");
                //}


                ////calculo utilidad maxima
                //calculoutilidadmaxima = costoproveedorsinimpuesto * utilidadmaxima / 100;
                //calculoivapreciomaximo = costoproveedorsinimpuesto * ivaventa / 100;

                ////valido si la utilidad maxima es mayor a 0
                //if (utilidadmaxima > 0)
                //{
                //    //realizo los calculos con una utilidad mayor a 0


                //    preciomaximosinimpuestofinal = costoproveedorsinimpuesto + calculoutilidadmaxima;
                //    calculoivapreciomaximo = preciomaximosinimpuestofinal * ivaventa / 100;
                //    preciomaximoconimpuestofinal = preciomaximosinimpuestofinal + calculoivapreciomaximo;

                //    if (!this.txtPrecioMaximoSinImpuesto.Focused)
                //    {
                //        this.txtPrecioMaximoSinImpuesto.Text = preciomaximosinimpuestofinal.ToString("#,##0.00");
                //    }

                //    this.txtPrecioMaximoConimpuesto.Text = preciomaximoconimpuestofinal.ToString();
                //}
                //else
                //{
                //    //realizo los calculos con una utilidad igual a 0
                //    preciomaximofinal = costoproveedorsinimpuesto + calculoutilidadmaxima + calculoivapreciomaximo;
                //    if (!this.txtPrecioMaximoSinImpuesto.Focused)
                //    {
                //        this.txtPrecioMaximoSinImpuesto.Text = costoproveedorsinimpuesto.ToString();
                //    }

                //    this.txtPrecioMaximoConimpuesto.Text = preciomaximofinal.ToString();
                //}


                ///*Fin bloque de calculo de precio maximo---------------------------------------*/




                ////costo de precios

                //this.txtPrecioMayorSinImpuesto.Text = costoproveedorsinimpuesto.ToString();
                //this.txtPrecioOfertaSinImpuesto.Text = costoproveedorsinimpuesto.ToString();
                //this.txtPrecioMinimoSinImpuesto.Text = costoproveedorsinimpuesto.ToString();


                //this.txtOtrosCostos.Text = otrocostos.ToString();



                ////calculos de precios con utilidad oferta

                //calculoutilidadoferta = costoproveedorsinimpuesto * utilidadoferta / 100;
                //calculoivapreciooferta = costoproveedorsinimpuesto * ivaventa / 100;

                //if (utilidadoferta > 0)
                //{
                //    //realizo los calculos con una utilidad mayor a 0

                //    precioofertasinimpuestofinal = costoproveedorsinimpuesto + calculoutilidadoferta;
                //    calculoivapreciooferta = precioofertasinimpuestofinal * ivaventa / 100;
                //    precioofertaconimpuestofinal = precioofertasinimpuestofinal + calculoivapreciooferta;



                //    this.txtPrecioOfertaSinImpuesto.Text = precioofertasinimpuestofinal.ToString();
                //    this.txtPrecioOfertaConImpuesto.Text = precioofertaconimpuestofinal.ToString();
                //}
                //else
                //{
                //    //realizo los calculos con una utilidad igual a 0
                //    precioofertafinal = costoproveedorsinimpuesto + calculoutilidadoferta + calculoivapreciooferta;

                //    this.txtPrecioOfertaSinImpuesto.Text = costoproveedorsinimpuesto.ToString();

                //    this.txtPrecioOfertaConImpuesto.Text = precioofertafinal.ToString();
                //}

                ////calculos de precios con utilidad mayor

                //calculoutilidadmayor = costoproveedorsinimpuesto * utilidadmayor / 100;
                //calculoivapreciomayor = costoproveedorsinimpuesto * ivaventa / 100;

                //if (utilidadoferta > 0)
                //{
                //    //realizo los calculos con una utilidad mayor a 0

                //    preciomayorsinimpuestofinal = costoproveedorsinimpuesto + calculoutilidadmayor;
                //    calculoivapreciomayor = preciomayorsinimpuestofinal * ivaventa / 100;
                //    preciomayorconimpuestofinal = preciomayorsinimpuestofinal + calculoivapreciomayor;



                //    this.txtPrecioMayorSinImpuesto.Text = preciomayorsinimpuestofinal.ToString();
                //    this.txtPrecioMayorConImpuesto.Text = preciomayorconimpuestofinal.ToString();
                //}
                //else
                //{
                //    //realizo los calculos con una utilidad igual a 0
                //    preciomayorfinal = costoproveedorsinimpuesto + calculoutilidadmayor + calculoivapreciomayor;

                //    this.txtPrecioMayorSinImpuesto.Text = costoproveedorsinimpuesto.ToString();

                //    this.txtPrecioMayorConImpuesto.Text = preciomayorfinal.ToString();
                //}

                ////calculos de precios con utilidad minimo

                //calculoutilidadminimo = costoproveedorsinimpuesto * utilidadminimo / 100;
                //calculoivapreciominimo = costoproveedorsinimpuesto * ivaventa / 100;

                //if (utilidadoferta > 0)
                //{
                //    //realizo los calculos con una utilidad mayor a 0

                //    preciominimosinimpuestofinal = costoproveedorsinimpuesto + calculoutilidadminimo;
                //    calculoivapreciominimo = preciominimosinimpuestofinal * ivaventa / 100;
                //    preciominimoconimpuestofinal = preciominimosinimpuestofinal + calculoivapreciominimo;



                //    this.txtPrecioMinimoSinImpuesto.Text = preciominimosinimpuestofinal.ToString();
                //    this.txtPrecioMinimoConImpuesto.Text = preciominimoconimpuestofinal.ToString();
                //}
                //else
                //{
                //    //realizo los calculos con una utilidad igual a 0
                //    preciominimofinal = costoproveedorsinimpuesto + calculoutilidadminimo + calculoivapreciominimo;

                //    this.txtPrecioMinimoSinImpuesto.Text = costoproveedorsinimpuesto.ToString();

                //    this.txtPrecioMinimoConImpuesto.Text = preciominimofinal.ToString();
                //}


            }
            catch (Exception e)
            {
                //MessageBox.Show("Disculpe Hubo un error" + e, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            this.BuscarFoto();
        }

        private void campoFoto_Click(object sender, EventArgs e)
        {
            this.BuscarFoto();
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

        private void frmProductos_KeyDown(object sender, KeyEventArgs e)
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
                //case Keys.F4:
                //    this.Consulta();
                //    break;

                case Keys.Escape:
                    this.Salir();
                    break;
                default:
                    break;
            }
        }

        private void frmProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }



        private void cmbIvaCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void chkUtilidadDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                App_Code.Inventario.Departamentos oDepartamentos = new App_Code.Inventario.Departamentos(int.Parse(this.cmbDepartamentos.SelectedValue.ToString()));


                if (this.chkUtilidadDepartamento.Checked)
                {
                    this.txtUtilidadMaxima.Text = oDepartamentos.PrecioMaximo.ToString();
                    this.txtUtilidadMayor.Text = oDepartamentos.PrecioMayor.ToString();
                    this.txtUtilidadMinimo.Text = oDepartamentos.PrecioMinimo.ToString();
                    this.txtUtilidadOferta.Text = oDepartamentos.PrecioOferta.ToString();
                    this.txtUtilidadMaxima.ReadOnly = true;
                    this.txtUtilidadMayor.ReadOnly = true;
                    this.txtUtilidadMinimo.ReadOnly = true;
                    this.txtUtilidadOferta.ReadOnly = true;
                }
                else
                {
                    this.txtUtilidadMaxima.Text = oDepartamentos.PrecioMaximo.ToString();
                    this.txtUtilidadMayor.Text = oDepartamentos.PrecioMayor.ToString();
                    this.txtUtilidadMinimo.Text = oDepartamentos.PrecioMinimo.ToString();
                    this.txtUtilidadOferta.Text = oDepartamentos.PrecioOferta.ToString();
                    this.txtUtilidadMaxima.ReadOnly = false;
                    this.txtUtilidadMayor.ReadOnly = false;
                    this.txtUtilidadMinimo.ReadOnly = false;
                    this.txtUtilidadOferta.ReadOnly = false;
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void cmbIvaVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                App_Code.Inventario.Departamentos oDepartamentos = new App_Code.Inventario.Departamentos(int.Parse(this.cmbDepartamentos.SelectedValue.ToString()));


                if (this.chkUtilidadDepartamento.Checked)
                {
                    this.txtUtilidadMaxima.Text = oDepartamentos.PrecioMaximo.ToString();
                    this.txtUtilidadMayor.Text = oDepartamentos.PrecioMayor.ToString();
                    this.txtUtilidadMinimo.Text = oDepartamentos.PrecioMinimo.ToString();
                    this.txtUtilidadOferta.Text = oDepartamentos.PrecioOferta.ToString();
                    this.txtUtilidadMaxima.ReadOnly = true;
                    this.txtUtilidadMayor.ReadOnly = true;
                    this.txtUtilidadMinimo.ReadOnly = true;
                    this.txtUtilidadOferta.ReadOnly = true;
                }
                else
                {
                    this.txtUtilidadMaxima.Text = oDepartamentos.PrecioMaximo.ToString();
                    this.txtUtilidadMayor.Text = oDepartamentos.PrecioMayor.ToString();
                    this.txtUtilidadMinimo.Text = oDepartamentos.PrecioMinimo.ToString();
                    this.txtUtilidadOferta.Text = oDepartamentos.PrecioOferta.ToString();
                    this.txtUtilidadMaxima.ReadOnly = false;
                    this.txtUtilidadMayor.ReadOnly = false;
                    this.txtUtilidadMinimo.ReadOnly = false;
                    this.txtUtilidadOferta.ReadOnly = false;
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }



        private void txtCostoProveedorSinImpuesto_TextChanged(object sender, EventArgs e)
        {
            this.CalcularCostosYPrecio();
        }



        private void txtContenidoempaque_Leave(object sender, EventArgs e)
        {
            if (!this.Validar())
            {
                this.txtContenidoempaque.BackColor = Color.White;
            }
        }

        private void txtContenidoempaque_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOtrosCostos_TextChanged(object sender, EventArgs e)
        {
            this.CalcularCostosYPrecio();
        }



        private void txtOtrosCostos_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMaximoSinImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioOfertaSinImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMayorSinImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMinimoSinImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtUtilidadMaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtUtilidadOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtUtilidadMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtUtilidadMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMaximoConimpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioOfertaConImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMayorConImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMinimoConImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CalcularCostosYPrecio();
        }

        private void txtPrecioMaximoSinImpuesto_Leave(object sender, EventArgs e)
        {
            //this.CalcularCostosYPrecio();
        }

        private void txtPrecioMaximoSinImpuesto_TextChanged(object sender, EventArgs e)
        {
            //this.CalcularCostosYPrecio();
        }

        private void txtCostoProveedorSinImpuesto_Leave(object sender, EventArgs e)
        {
            double valor = double.Parse(this.txtCostoProveedorSinImpuesto.Text);
            this.txtCostoProveedorSinImpuesto.Text = valor.ToString("#,##0.00");
            this.CalcularCostosYPrecio();
        }

        private void txtOtrosCostos_Leave(object sender, EventArgs e)
        {
            double valor = double.Parse(this.txtOtrosCostos.Text);
            this.txtOtrosCostos.Text = valor.ToString("#,##0.00");
            this.CalcularCostosYPrecio();
        }
    }

}
