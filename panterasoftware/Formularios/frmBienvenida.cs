using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace panterasoftware
{
    partial class frmBienvenida : Form
    {
        public static int valor = 0;
        public frmBienvenida()
        {
            InitializeComponent();
            this.Text = String.Format("{0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = "Bienvenido a su sistema automatizado de inventario y administración, por favor ingrese con su codigo de usuario y clave." +
                                           "Este sistema cuenta con una sola licencia de por vida, solo para esta versión.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion



        private void frmBienvenida_Load(object sender, EventArgs e)
        {
            this.timer1.Start();

            this.barraProgreso.Increment(1);
            this.barraProgreso.Maximum = 100;
            this.label1.Text = "Versión:" + AssemblyVersion;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.barraProgreso.Increment(1);
            valor = valor + 1;
            if (valor == 105)
            {
                this.label1.Text = "Verificando Conexión A Base De Datos";
                try
                {

                    SqlConnection oConexion = new SqlConnection(new App_Code.Base().Sql);
                    oConexion.Open();

                    if (oConexion.State == ConnectionState.Open)
                    {
                        Formularios.frmLogin oLogin = new Formularios.frmLogin();
                        oLogin.Show();
                        this.Hide();
                    }




                }
                catch (Exception)
                {
                    Configuracion.frmConfConexion oConexion = new Configuracion.frmConfConexion();
                    oConexion.Show();
                    this.Hide();

                }
            }

        }

        private void barraProgreso_Click(object sender, EventArgs e)
        {
            ProgressBar pbar = new ProgressBar();
        }

    }
}
