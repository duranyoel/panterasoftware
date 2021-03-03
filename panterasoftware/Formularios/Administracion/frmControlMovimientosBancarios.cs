using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panterasoftware.Administracion
{
    public partial class frmControlMovimientosBancarios : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmControlMovimientosBancarios()
        {
            InitializeComponent();
        }

        private void frmControlMovimientosBancarios_FormClosed(object sender, FormClosedEventArgs e)
        {
           panterasoftware.Formularios.frmPrincipal.abierto = false;
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmControlMovimientosBancarios_Load(object sender, EventArgs e)
        {
            this.Nuevo();
        }
        private void Nuevo()
        {
            //Seccion de banco
            this.lblFicha.Text = "0";
            this.txtNumCuenta.Text = "";
            this.txtNomBanco.Text = "";
            this.txtTipoCuenta.Text = "";
            this.txtNumCuenta.Enabled = false;
            this.txtNomBanco.Enabled = false;
            this.txtTipoCuenta.Enabled = false;

            //Seccion de saldo
            this.txtSaldoConciliado.Text = "0";
            this.txtSaldoReal.Text = "0";

            //Cheque
            this.txtNumCheque.Text = "0";
            this.txtConcepto.Text ="";
            this.txtBenificiario.Text = "";
            this.txtMontoCheque.Text = "";

            //Depositos
            this.txtMontoDeposito.Text = "";
            this.txtConceptoDeposito.Text = "";
            this.txtDepositante.Text = "";


        }
        private void Guardar()
        {

        }
        private void Presentar(int id)
        {

        }
        private void Borrar()
        {

        }
        private void Salir()
        {
            this.Close();
        }

    }
}
