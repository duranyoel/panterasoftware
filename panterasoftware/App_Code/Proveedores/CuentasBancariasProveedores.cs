using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Proveedores
{
    class CuentasBancariasProveedores : App_Code.Base
    {
        //Propiedades privadas
        private int proveedor_id;
        private int cuentabancaria_id;

        //Constructores
        public CuentasBancariasProveedores()
        {
            this.declaracion();
        }
        public CuentasBancariasProveedores(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
       
        //Propiedades Publicas
        public int ProveedorId
        {
            get { return this.proveedor_id; }
            set { this.proveedor_id = value; }
        }
        public int CuentaBancariaId
        {
            get { return this.cuentabancaria_id; }
            set { this.cuentabancaria_id = value; }
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
            oComando.Parameters.Add("@proveedor_id", SqlDbType.Int).Value = this.proveedor_id;     
            oComando.Parameters.Add("@cuentabancaria_id", SqlDbType.Int).Value = this.cuentabancaria_id;
            oComando.Parameters.Add("@creado", SqlDbType.DateTime).Value = this.creado;

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
            oComando.Parameters.Add("@proveedor_id", SqlDbType.Int).Value = this.proveedor_id;
            oComando.Parameters.Add("@cuentabancaria_id", SqlDbType.Int).Value = this.cuentabancaria_id;
            oComando.Parameters.Add("@creado", SqlDbType.DateTime).Value = this.creado;


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
                this.proveedor_id = (int)oRow["proveedor_id"];
                this.cuentabancaria_id = (int)oRow["cuentabancaria_id"];
                this.creado = (DateTime)oRow["creado"];
              
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
            this.tbl = "cuentasbancarias_proveedores";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "userlog_id,proveedor_id,cuentabancaria_id,creado) " +
                "VALUES (" +
                    "@userlog_id,@proveedor_id,@cuentabancaria_id,@creado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id     = @userlog_id,     " +
                    "proveedor_id         = @proveedor_id,     " +
                    "cuentabancaria_id    = @cuentabancaria_id,     " +
                    "creado    = @creado,     " +
                   

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
            this.proveedor_id=0;
            this.cuentabancaria_id=0;
            this.creado = DateTime.Now;
         
            
        }
    }
}
