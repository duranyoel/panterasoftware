using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Inventario 
{
    class Monedas : Base
    {
        //Propiedades privadas
        private string simbolo;
        private double cambioventa;
        private double cambiocompra;
        private bool predeterminado;
       
        //Constructores
        public Monedas()
        {
            this.declaracion();
        }
        public Monedas(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
       
        //Propiedades Publicas
        public string Simbolo
        {
            get { return this.simbolo; }
            set { this.simbolo = value; }
        }
        public double CambioVenta
        {
            get { return this.cambioventa; }
            set { this.cambioventa = value; }
        }
        public double CambioCompra
        {
            get { return this.cambiocompra; }
            set { this.cambiocompra = value; }
        }
        public bool Predeterminado
        {
            get { return this.predeterminado; }
            set { this.predeterminado = value; }
        }
       
        
        //Metodos Publicas 
        public void Leer(int id)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(this.sel, oConexion);

            oAdaptador.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oConexion.Close();

            this.campos(oDataSet);
        }
        public void Insertar()
        {
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlCommand oComando = new SqlCommand(this.ins, oConexion);

            // Parametros para insertar
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;     
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;
            
            oComando.Parameters.Add("@simbolo", SqlDbType.NVarChar).Value = this.simbolo;
            oComando.Parameters.Add("@cambioventa", SqlDbType.Float).Value = this.cambioventa;
            oComando.Parameters.Add("@cambiocompra", SqlDbType.Float).Value = this.cambiocompra;
            oComando.Parameters.Add("@predeterminado", SqlDbType.Bit).Value = this.predeterminado;
            oComando.Parameters.Add("@notas", SqlDbType.NVarChar).Value = this.notas;
            oComando.Parameters.Add("@borrado", SqlDbType.Bit).Value = this.borrado;
            oComando.Parameters.Add("@creado", SqlDbType.DateTime).Value = this.creado;
            oComando.Parameters.Add("@modificado", SqlDbType.DateTime).Value = this.modificado;

            // parametro que devuelve el id
            oComando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            // Ejecuta la insercion
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                this.id = (int)oComando.Parameters["@id"].Value;
                oConexion.Close();
                this.err = false;
                this.msg = "Registro insertado.";
            }
            catch // Si ocurre algun problema
            {
                this.err = true;
                this.msg = "Registro no pudo ser insertado.";
                return;
            }

        }
        public void Actualizar()
        {
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlCommand oComando = new SqlCommand(this.upd, oConexion);

            // Parametros para actualizar
            oComando.Parameters.Add("@id", SqlDbType.Int).Value = this.id ;
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;

            oComando.Parameters.Add("@simbolo", SqlDbType.NVarChar).Value = this.simbolo;
            oComando.Parameters.Add("@cambioventa", SqlDbType.Float).Value = this.cambioventa;
            oComando.Parameters.Add("@cambiocompra", SqlDbType.Float).Value = this.cambiocompra;
            oComando.Parameters.Add("@predeterminado", SqlDbType.Bit).Value = this.predeterminado;
            oComando.Parameters.Add("@notas", SqlDbType.NVarChar).Value = this.notas;
            oComando.Parameters.Add("@borrado", SqlDbType.Bit).Value = this.borrado;
            oComando.Parameters.Add("@creado", SqlDbType.DateTime).Value = this.creado;
            oComando.Parameters.Add("@modificado", SqlDbType.DateTime).Value = this.modificado;


            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oConexion.Close();
                this.err = false;
                this.msg = "Registro actualizado.";
            }
            catch
            {
                this.err = true;
                this.msg = "Registro no pudo ser actualizado.";
                return;
            }

        }
        public void Eliminar()
        {
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlCommand oComando = new SqlCommand(this.del, oConexion);

            oComando.Parameters.Add("@id", SqlDbType.Int).Value = this.id;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oConexion.Close();

                this.err = false;
                this.msg = "Registro eliminado.";
            }
            catch
            {
                this.err = true;
                this.msg = "Registro no pudo ser eliminado.";
            }
        }
        public DataTable Buscar(int cantidad, string campos, string filtro, string orden)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT " +
                    (cantidad > 0 ? "TOP(" + cantidad.ToString("0") + ")" : "") + " " +
                    (campos.Length > 0 ? campos : "*") + " " +
                "FROM " + this.tbl + " " +
                    (filtro.Length > 0 ? "WHERE " + filtro : "") + " " +
                    (orden.Length > 0 ? "ORDER BY " + orden : "") +
                ";", oConexion);

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oConexion.Close();

            return oDataSet.Tables["tabla"];
        }

        // Metodos Privados
        private void campos(DataSet oDataSet)
        {
            if (oDataSet.Tables["tabla"].Rows.Count != 0)
            {
                DataRow oRow = oDataSet.Tables["tabla"].Rows[0];
                this.id = (int)oRow["id"];
                this.userlog_id = (int)oRow["userlog_id"];
                this.codigo = (string)oRow["codigo"];
                this.nombre = (string)oRow["nombre"];
                this.simbolo = (string)oRow["simbolo"];
                this.cambioventa = (double)oRow["cambioventa"];
                this.cambiocompra = (double)oRow["cambiocompra"];
                this.predeterminado = (bool)oRow["predeterminado"];
                this.borrado = (bool)oRow["borrado"];
                this.notas = (string)oRow["notas"];
                this.creado = (DateTime)oRow["creado"];
                this.modificado = (DateTime)oRow["modificado"];
              
                this.err = false;
                this.msg = "Registro leido correctamente.";
            }
            else
            {
                this.err = true;
                this.msg = "No hay registro.";
            }
        }
        private void declaracion()
        {
            this.tbl = "monedas";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "userlog_id,codigo,nombre,simbolo, "+
                    "cambioventa,cambiocompra,predeterminado,notas,borrado,creado,modificado) " +
                "VALUES (" +
                    "@userlog_id,@codigo,@nombre,@simbolo,@cambioventa, "+
                    "@cambiocompra,@predeterminado,@notas,@borrado,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id     = @userlog_id,      " +
                    "codigo         = @codigo,      " +
                    "nombre         = @nombre,      " +
                    "simbolo        = @simbolo,   " +
                    "cambioventa    = @cambioventa,     " +
                    "cambiocompra   = @cambiocompra,     " +
                    "predeterminado = @predeterminado,     " +
                    "notas          = @notas,     " +
                    "borrado        = @borrado, "+
                    "creado         = @creado,     " +
                    "modificado     = @modificado     " +
                   

                "WHERE (" +
                    "id = @id);";

            this.del =
                "DELETE FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";

            this.err = false;
            this.msg = "";

            this.id = 0;
            this.userlog_id = 0;
            this.nombre = "";
            this.codigo = "";
            this.simbolo = "";
            this.cambioventa = 0;
            this.cambiocompra = 0;
            this.predeterminado = false;
            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;
         
            
        }
    }
}
