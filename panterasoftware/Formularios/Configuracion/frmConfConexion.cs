using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace panterasoftware.Configuracion
{
    public partial class frmConfConexion : Form
    {
        public frmConfConexion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "App.config");
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
                Configuration oConfig = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                oConfig.ConnectionStrings.ConnectionStrings["panterasoftware.Properties.Settings.Setting"].ConnectionString = "" +
                                "Data Source=" + this.txtServidor.Text + ";" +
                                "Initial Catalog=" + this.txtBd.Text + ";" +
                                "User ID=" + this.txtUsuario.Text + ";" +
                                "Password=" + this.txtPass.Text + ";" +
                                "Encrypt=False".ToString();
                oConfig.ConnectionStrings.ConnectionStrings["panterasoftware.Properties.Settings.Setting"].ProviderName = "System.Data.SqlClient";
                oConfig.Save(ConfigurationSaveMode.Modified);
                
                MessageBox.Show("La aplicación procedera a cerrarse intente de nuevo para probar la conexión", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }
        private bool Validar()
        {
            if (this.txtBd.Text.Length == 0 || this.txtUsuario.Text.Length == 0 ||
                this.txtServidor.Text.Length == 0 || this.txtPass.Text.Length == 0)
            {
                MessageBox.Show("Disculpe no puede haber campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void frmConfConexion_FormClosed(object sender, FormClosedEventArgs e)
        {
           panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void frmConfConexion_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "panterasoftware";
            this.txtBd.Text = "panterasoftware";
            this.txtServidor.Text = "localhost";
        }
    }
}
