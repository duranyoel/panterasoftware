using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panterasoftware.Formularios.Configuracion
{
    public partial class frmConexionEmpresa : Form
    {
        public static int id;
        public static string codigo;
        
        public frmConexionEmpresa()
        {
            InitializeComponent();
        }

        private void frmConexionEmpresa_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "panterasoftware";
            this.txtBd.Text = codigo;
            this.txtBd.Enabled = false;
            this.txtServidor.Text = "localhost";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {

                App_Code.Sistema.Sistema_Empresas oEmpresa = new App_Code.Sistema.Sistema_Empresas(id);
                oEmpresa.CadenaConexion = "" +
                                "Data Source=" + this.txtServidor.Text + ";" +
                                "Initial Catalog=" + this.txtBd.Text + ";" +
                                "User ID=" + this.txtUsuario.Text + ";" +
                                "Password=" + this.txtPass.Text + ";" +
                                "Encrypt=False".ToString();
                oEmpresa.Actualizar();
                MessageBox.Show(oEmpresa.Msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                frmPrincipal oInicio = new frmPrincipal();
                oInicio.CargoDatos(oEmpresa.Codigo);
                oInicio.Refresh();
                oInicio.Show();
                this.Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
