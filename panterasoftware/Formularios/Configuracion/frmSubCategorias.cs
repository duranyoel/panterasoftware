﻿using System;
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
    public partial class frmSubCategorias : Form
    {
        App_Code.Sistema.Sistema_Grupo_Funciones oFuncion = new App_Code.Sistema.Sistema_Grupo_Funciones();
        public frmSubCategorias()
        {
            InitializeComponent();
        }

        private void frmSubCategorias_Load(object sender, EventArgs e)
        {
            this.Nuevo();
            this.Categorias();
        }

        private void frmSubCategorias_FormClosed(object sender, FormClosedEventArgs e)
        {
            panterasoftware.Formularios.frmPrincipal.abierto = false;
        }
        private void Nuevo()
        {
            this.lblFicha.Text = "0";
            this.txtBuscar.Text = "";
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtNombre.Text = "";
            this.btnEliminar.Enabled = false;
        }
        private void Guardar()
        {
            App_Code.Configuracion.SubCategorias oRegistro = new App_Code.Configuracion.SubCategorias(int.Parse(this.lblFicha.Text));

            oRegistro.Nombre = this.txtNombre.Text.ToString().ToUpper();
            oRegistro.Codigo = this.txtCodigo.Text.ToString().ToUpper();
            oRegistro.Descripcion = this.txtDescripcion.Text.ToString().ToUpper();
            oRegistro.CategoriaId = int.Parse(this.cmbCategoria.SelectedValue.ToString());

            try
            {
                if (!Validar())
                {
                    if (oRegistro.Err)
                    {
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200702");
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
                        oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200703");
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
            App_Code.Configuracion.SubCategorias oRegistro = new App_Code.Configuracion.SubCategorias(id);
            App_Code.Configuracion.Categorias oCategoria = new App_Code.Configuracion.Categorias(oRegistro.CategoriaId);
            
            this.lblFicha.Text = oRegistro.Id.ToString("0");
            this.txtCodigo.Text = oRegistro.Codigo;
            this.txtNombre.Text = oRegistro.Nombre;
            this.txtDescripcion.Text = oRegistro.Descripcion;
            this.cmbCategoria.Text = oCategoria.Nombre;

            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200704");
            if (!oFuncion.Err)
            {
                this.btnEliminar.Enabled = true;
            }

        }
        private void Borrar()
        {
            try
            {
                oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200704");
                if (oFuncion.Err)
                {

                    MessageBox.Show("Disculpe Usted No Tiene Acceso a Esta Accion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de Borrar este Registro", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_Code.Configuracion.Categorias oRegistro = new App_Code.Configuracion.Categorias(int.Parse(this.lblFicha.Text.ToString()));
                        oRegistro.Eliminar();
                        this.Nuevo();
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
            oFuncion.Leer(panterasoftware.Formularios.frmPrincipal.id_grupo_usuario, "1200705");
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


                    "FROM subcategoria " +

                    "WHERE (" +
                            "codigo LIKE '%" + this.txtBuscar.Text + "%' OR " +

                            "nombre LIKE '%" + this.txtBuscar.Text + "%') " +

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
        private void Salir()
        {
            this.Close();
        }
        private void Categorias()
        {
            this.cmbCategoria.DataSource = new App_Code.Configuracion.Categorias().Buscar(0,
                    "id,nombre",
                    "",
                    "nombre");
            this.cmbCategoria.DisplayMember = "nombre";
            this.cmbCategoria.ValueMember = "id";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consulta();
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

        private void frmSubCategorias_KeyDown(object sender, KeyEventArgs e)
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
    }
}
