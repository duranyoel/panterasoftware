using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panterasoftware.Formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                DataTable oTabla = new App_Code.Sistema.Sistema_Usuarios().Buscar(
                1,
                "id,nombre,apellido,grupo_id,empresa_id,estatus",
                "(usuario = '" + this.txtUsuario.Text + "') AND (clave = '" + this.txtClave.Text + "')",
                "");
                if (oTabla.Rows.Count > 0)
                {
                    if ((oTabla.Rows[0]["estatus"].ToString()) == "Bloqueado")
                    {
                        MessageBox.Show("Disculpe usuario bloqueado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        App_Code.Sistema.Sistema_Grupos oGrupo = new App_Code.Sistema.Sistema_Grupos(int.Parse(oTabla.Rows[0]["grupo_id"].ToString()));
                        frmPrincipal.id_usuario = int.Parse(oTabla.Rows[0]["id"].ToString());
                        frmPrincipal.usuario = oTabla.Rows[0]["apellido"].ToString().ToUpper() + " " + oTabla.Rows[0]["nombre"].ToString().ToUpper();
                        frmPrincipal.id_grupo_usuario = int.Parse(oTabla.Rows[0]["grupo_id"].ToString());
                        if (oGrupo.Nombre == "Administrador" || oGrupo.Nombre == "Desarrollo")
                        {
                            panterasoftware.Configuracion.frmSelEmpresa oEmpresa = new panterasoftware.Configuracion.frmSelEmpresa();
                            oEmpresa.Show();
                            this.Hide();
                        }
                        else
                        {
                            App_Code.Sistema.Sistema_Empresas oEmpresa = new App_Code.Sistema.Sistema_Empresas(int.Parse(oTabla.Rows[0]["empresa_id"].ToString()));
                            frmPrincipal oPrincipal = new frmPrincipal();
                            frmPrincipal.id_empresa = oEmpresa.Id;
                            frmPrincipal.codigo = oEmpresa.Codigo;

                            oPrincipal.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Disculpe usuario o contraseña incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private bool Validar()
        {
            if (this.txtUsuario.Text.Length == 0)
            {
                this.txtUsuario.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese un usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (this.txtClave.Text.Length == 0)
            {
                this.txtClave.BackColor = Color.Red;
                MessageBox.Show("Disculpe ingrese su clave", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }
     
    }
}
