using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Empresa
{
    class Transporte:Base
    {
        //Propiedades privadas
        private string contrato;
        private string placa;
        private string telefono;
        private string direccion;
        
        

        //Constructores
        public Transporte()
        {
            this.declaracion();
        }
        public Transporte(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
       
        //Propiedades Publicas
        public string Contrato
        {
            get { return this.contrato; }
            set { this.contrato = value; }
        }
        public string Placa
        {
            get { return this.placa; }
            set { this.placa = value; }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
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
            oComando.Parameters.Add("@contrato", SqlDbType.NVarChar).Value = this.contrato;
            oComando.Parameters.Add("@placa", SqlDbType.NVarChar).Value = this.placa; 
            oComando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = this.direccion;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
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
            oComando.Parameters.Add("@contrato", SqlDbType.NVarChar).Value = this.contrato;
            oComando.Parameters.Add("@placa", SqlDbType.NVarChar).Value = this.placa;
            oComando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = this.direccion;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
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
                this.contrato = (string)oRow["contrato"];
                this.placa  = (string)oRow["placa"];
                this.direccion = (string)oRow["direccion"];
                this.telefono = (string)oRow["telefono"];
                this.borrado = (bool)oRow["borrado"];
                
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
            this.tbl = "transportes";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "userlog_id,codigo,nombre,contrato,placa,direccion,telefono,borrado,creado,modificado) " +
                "VALUES (" +
                    "@userlog_id,@codigo,@nombre,@contrato,@placa,@direccion,@telefono,@borrado,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id     = @userlog_id,      " +
                    "codigo         = @codigo,      " +
                    "nombre         = @nombre,      " +
                    "contrato       = @contrato,      " +
                    "placa          = @placa,      " +
                    "direccion      = @direccion,   " +
                    "telefono       = @telefono,     " +
                    "borrado        = @borrado, " +
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
            this.contrato = "";
            this.placa = "";
            this.direccion = "";
            this.telefono = "";
            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;
            
        }
    }
}
