using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;

namespace panterasoftware.Formularios
{
    public partial class frmPrincipal : Form
    {
        public static bool abierto = false;
        public static string conexion = "";
        public static string ip_equipo = "";
        public static string nombre_maquina = "";
        public static string usuario = "";
        public static int id_grupo_usuario = 0;
        public static int id_usuario = 0;
        public static int id_empresa = 0;
        public static string codigo;
        private static string dest = Application.StartupPath + "/upload/empresas/";
        public string sql = "";
        public string Sql
        {
            get { return this.sql; }
        }
        public frmPrincipal()
        {
            InitializeComponent();
        }
        public void CargoDatos(string codigo)
        {
            //Busquedad de los datos de la empresa seleccionada 
            DataTable oEmpresa = new App_Code.Sistema.Sistema_Empresas().Buscar(
                                    1,
                                    "id,nombre,cadena_conexion,codigo",
                                    "codigo = '" + codigo + "'",
                                    "");

            if (oEmpresa.Rows.Count > 0)
            {
                DataRow oRow = oEmpresa.Rows[0];
                conexion = oRow["cadena_conexion"].ToString();
                sql = oRow["cadena_conexion"].ToString();

                MessageBox.Show("Conexión a Base de Datos Exitosa Bienvenido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                App_Code.Configuracion.Empresa oE = new App_Code.Configuracion.Empresa((string)oRow["codigo"]);
                App_Code.Sistema.Sistema_Grupos oGrupo = new App_Code.Sistema.Sistema_Grupos(id_grupo_usuario);
                this.lblGrupo.Text = oGrupo.Nombre;
                this.lblIdGrupo.Text = oGrupo.Id.ToString();
                this.lblIdEmpresa.Text = oE.Id.ToString();
                id_empresa = oE.Id;
                codigo = oE.Codigo.ToString();

                this.Text = oE.Nombre.ToUpper() + " - Rif: " + oE.Rif.ToUpper() + " (" + oE.Codigo.ToString() + ")";
                if (oE.Imagen == "Ninguna" || oE.Imagen == null)
                {
                    this.campoImagen.Image = Properties.Resources.Factory;
                }
                else
                {
                    try
                    {
                        this.campoImagen.Image = Image.FromFile(dest + oE.Imagen);

                    }
                    catch (Exception)
                    {
                        this.campoImagen.Image = Properties.Resources.Factory;

                    }


                }

                this.lblIdU.Text = id_usuario.ToString();
                this.lblNombreUsuario.Text = usuario;
                this.lblIdEmpresa.Text = id_empresa.ToString();



            }

        }
        private void ValidarPermisos()
        {
            App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
            #region(Sistema)

            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200101");
            if (oFuncion.Err)
            {
                this.controlFuncionesToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200201");
            if (oFuncion.Err)
            {
                this.controlDeModulosToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200301");
            if (oFuncion.Err)
            {
                this.controlDeUsuariosToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200401");
            if (oFuncion.Err)
            {
                this.controlCategoriasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200501");
            if (oFuncion.Err)
            {
                this.controlDeGruposToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200601");
            if (oFuncion.Err)
            {
                this.controlAsignarPermisosAGruposToolStripMenuItem.Visible = false;
            }

            #endregion
            #region(Configuracion)
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200701");
            if (oFuncion.Err)
            {
                this.subCategoriasToolStripMenuItem.Visible = false;
            }
            #endregion
            #region(Empresa)
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200801");
            if (oFuncion.Err)
            {
                this.tasasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200901");
            if (oFuncion.Err)
            {
                this.agenciasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201001");
            if (oFuncion.Err)
            {
                this.controlDeCobradoresToolStripMenuItem.Visible = false;
            }
            
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201201");
            if (oFuncion.Err)
            {
                this.controlMediosDePagoYCobroToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201301");
            if (oFuncion.Err)
            {
                this.controlDeTransportesToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1201303");
            if (oFuncion.Err)
            {
                this.editarEmpresaActualToolStripMenuItem.Visible = false;
            }

            #endregion
            #region(Admnistracion)
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400101");
            if (oFuncion.Err)
            {
                this.planDeCuentasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0400201");
            if (oFuncion.Err)
            {
                this.controlDeBancosToolStripMenuItem.Visible = false;
            }
            #endregion
            #region(Proveedores)
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200201");
            if (oFuncion.Err)
            {
                this.controlDeGruposProveedoresMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200101");
            if (oFuncion.Err)
            {
                this.controlDeProveedoresToolStripMenuItem.Visible = false;
                this.tsbMenuControlProveedores.Enabled = false;
            }
            #endregion
            #region(Inventario)
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300101");
            if (oFuncion.Err)
            {
                this.controlDeMonedasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300201");
            if (oFuncion.Err)
            {
                this.departamentosToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300301");
            if (oFuncion.Err)
            {
                this.depositosToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300401");
            if (oFuncion.Err)
            {
                this.unidadesDeMedidasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300501");
            if (oFuncion.Err)
            {
                this.marcasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300601");
            if (oFuncion.Err)
            {
                this.coloresToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300701");
            if (oFuncion.Err)
            {
                this.tallasToolStripMenuItem.Visible = false;
            }
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300801");
            if (oFuncion.Err)
            {
                this.tsbMenuControlDeInventario.Visible = false;
                this.productosTerminadosToolStripMenuItem.Visible = false;

            }

            #endregion

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            string strHostName = string.Empty;
            // Getting Ip address of local machine…
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
            nombre_maquina = strHostName;
            for (int i = 0; i < hostIPs.Length; i++)
            {
                ip_equipo = hostIPs[i].ToString();

            }
            this.lblEquipo.Text = strHostName.ToUpper();
            this.lblIp.Text = ip_equipo.ToString();

            this.CargoDatos(codigo);
            this.ValidarPermisos();


        }
        private void empresaToolStripMenu_Click(object sender, EventArgs e)
        {

        }
        private void editarEmpresaActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panterasoftware.Empresa.frmEmpresa oEmpresa = new panterasoftware.Empresa.frmEmpresa();

            if (abierto == false)
            {
                panterasoftware.Empresa.frmEmpresa.empresa = id_empresa;
                oEmpresa.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void seleccionarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panterasoftware.Configuracion.frmSelEmpresa oEmpresa = new panterasoftware.Configuracion.frmSelEmpresa();

            if (abierto == false)
            {
                oEmpresa.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void tasasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panterasoftware.Configuracion.frmTasas oTasa = new panterasoftware.Configuracion.frmTasas();
            if (abierto == false)
            {
                oTasa.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
        private void configurarConexónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panterasoftware.Configuracion.frmConfConexion oConexion = new panterasoftware.Configuracion.frmConfConexion();
            if (abierto == false)
            {
                oConexion.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panterasoftware.Configuracion.frmCategorias oCategorias = new panterasoftware.Configuracion.frmCategorias();
            if (abierto == false)
            {
                oCategorias.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void subCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panterasoftware.Configuracion.frmSubCategorias oSubCategoria = new panterasoftware.Configuracion.frmSubCategorias();
            if (abierto == false)
            {
                oSubCategoria.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void mediosDePagoYCobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empresa.frmMediosDePago oMedios = new Empresa.frmMediosDePago();
            if (abierto == false)
            {
                oMedios.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void agenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empresa.frmAgencias oAgencias = new Empresa.frmAgencias();
            if (abierto == false)
            {
                oAgencias.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void controlFuncionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.frmFunciones oFunciones = new Sistema.frmFunciones();
            if (abierto == false)
            {
                oFunciones.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void controlDeGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.frmGrupos oGrupos = new Sistema.frmGrupos();
            if (abierto == false)
            {
                oGrupos.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void asignarPermisosAGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.frmGruposFunciones oGrupoFunciones = new Sistema.frmGruposFunciones();
            if (abierto == false)
            {
                oGrupoFunciones.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void editarUsuarioActualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void btnMenuSalir_Click(object sender, EventArgs e)
        {
            if (abierto == true)
            {
                MessageBox.Show("Disculpe debe de tener todos los formularios cerrados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Application.Exit();
            }
        }

        private void planDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmPlanCuentas oPlanCuenta = new Administracion.frmPlanCuentas();
            if (abierto == false)
            {
                oPlanCuenta.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void controlDeMovimientosBancariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmControlMovimientosBancarios oMovimientos = new Administracion.frmControlMovimientosBancarios();
            if (abierto == false)
            {
                oMovimientos.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void controlDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.frmUsuarios oUsuario = new Sistema.frmUsuarios();
            if (abierto == false)
            {
                oUsuario.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void controlDeModulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.frmModulos oModulos = new Sistema.frmModulos();
            if (abierto == false)
            {
                oModulos.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButtonMenuCerrar_Click(object sender, EventArgs e)
        {
            Formularios.frmLogin oLogin = new Formularios.frmLogin();
            oLogin.Show();
            this.Hide();
        }

        private void controlDeCobradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empresa.frmCobradores oRegistro = new Empresa.frmCobradores();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void controlDeTransportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empresa.frmTransporte oRegistro = new Empresa.frmTransporte();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void controlDeCuentasBancariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmCuentasBancarias oBancos = new Administracion.frmCuentasBancarias();
            if (abierto == false)
            {
                oBancos.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void controlDeBancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmBancos oRegistro = new Administracion.frmBancos();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void controlDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmControlDeProveedores oRegistro = new Formularios.Proveedores.frmControlDeProveedores();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void controlDeGruposProveedoresMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmControlGrupos oRegistro = new Formularios.Proveedores.frmControlGrupos();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
            switch (e.KeyCode)
            {
                case Keys.F1:
                    oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0300801");
                    Formularios.Inventario.frmProductos oRegistroProductos = new Formularios.Inventario.frmProductos();
                    if (abierto == false)
                    {
                        oRegistroProductos.Show();
                        abierto = true;
                    }
                    else
                    {
                        MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case Keys.F2:
                    //Formularios.Proveedores.frmControlDeProveedores oRegistro = new Formularios.Proveedores.frmControlDeProveedores();
                    //if (abierto == false)
                    //{
                    //    oRegistro.Show();
                    //    abierto = true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                    break;
                case Keys.F3:
                    oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "0200101");
                    Formularios.Proveedores.frmControlDeProveedores oRegistro = new Formularios.Proveedores.frmControlDeProveedores();
                    if (!oFuncion.Err)
                    {
                        
                        if (abierto == false)
                        {
                            oRegistro.Show();
                            abierto = true;
                        }
                        else
                        {
                            MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    
                    break;
                //case Keys.F4:
                //    Formularios.Proveedores.frmControlDeProveedores oRegistro = new Formularios.Proveedores.frmControlDeProveedores();
                //    if (abierto == false)
                //    {
                //        oRegistro.Show();
                //        abierto = true;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //    break;

                //case Keys.Escape:
                //    Formularios.Proveedores.frmControlDeProveedores oRegistro = new Formularios.Proveedores.frmControlDeProveedores();
                //    if (abierto == false)
                //    {
                //        oRegistro.Show();
                //        abierto = true;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //    break;
                default:
                    break;
            }
        }

        private void tsbMenuControlProveedores_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmControlDeProveedores oRegistro = new Formularios.Proveedores.frmControlDeProveedores();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        

        #region(Inventario)
        private void monedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmMonedas oRegistro = new Formularios.Inventario.frmMonedas();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmDepartamentos oRegistro = new Formularios.Inventario.frmDepartamentos();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void unidadesDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmUnidadesDeMedida oRegistro = new Formularios.Inventario.frmUnidadesDeMedida();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void depositosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmDepositos oDeposito = new Formularios.Inventario.frmDepositos();
            if (abierto == false)
            {
                oDeposito.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmMarcas oRegistro = new Formularios.Inventario.frmMarcas();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void productosTerminadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmProductos oRegistro = new Formularios.Inventario.frmProductos();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void tallasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmTallas oRegistro = new Formularios.Inventario.frmTallas();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void coloresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Inventario.frmColores oRegistro = new Formularios.Inventario.frmColores();
            if (abierto == false)
            {
                oRegistro.Show();
                abierto = true;
            }
            else
            {
                MessageBox.Show("Disculpe ya hay un formulario abierto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsbMenuControlDeInventario_Click(object sender, EventArgs e)
        {

        }








        #endregion


    }
}
