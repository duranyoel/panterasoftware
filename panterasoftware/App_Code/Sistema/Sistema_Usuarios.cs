using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Sistema
{
    class Sistema_Usuarios : App_Code.Base
    {
        //propiedades privadas
        private int empresa_id;
        private int grupo_id;
        private string apellido;
        private string clave;
        private string usuario;
        private string estatus;

        private DateTime fecha_alta;
        private DateTime fecha_baja;
        private DateTime fecha_session;
               
        //Constructores
        public int EmpresaId
        {
            get { return this.empresa_id; }
            set { this.empresa_id = value; }
        }
        public int GrupoId
        {
            get { return this.grupo_id; }
            set { this.grupo_id = value; }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public string Clave
        {
            get { return this.clave; }
            set { this.clave = value; }
        }
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        public string Estatus
        {
            get { return this.estatus; }
            set { this.estatus = value; }
        }
        public DateTime FechaAlta
        {
            get { return this.fecha_alta; }
            set { this.fecha_alta = value; }
        }
        public DateTime FechaBaja
        {
            get { return this.fecha_baja; }
            set { this.fecha_baja = value; }
        }
        public DateTime FechaSession
        {
            get { return this.fecha_session; }
            set { this.fecha_session = value; }
        }
        public Sistema_Usuarios()
        {
            this.declaracion();
        }
        public Sistema_Usuarios(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
        //Metodos Publicos 
        public void Leer(int id)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(this.sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(this.sel, oConexion);

            oAdaptador.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oConexion.Close();

            this.campos(oDataSet);
        }
        public void Insertar()
        {
            SqlConnection oConexion = new SqlConnection(this.sql);
            SqlCommand oComando = new SqlCommand(this.ins, oConexion);

            // Parametros para insertar
            oComando.Parameters.Add("@empresa_id", SqlDbType.Int).Value = this.empresa_id;
            oComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = this.grupo_id;
            oComando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = this.apellido;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;
            oComando.Parameters.Add("@clave", SqlDbType.NVarChar).Value = this.clave;
            oComando.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = this.usuario;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
            oComando.Parameters.Add("@fecha_alta", SqlDbType.DateTime).Value = this.fecha_alta;
            oComando.Parameters.Add("@fecha_baja", SqlDbType.DateTime).Value = this.fecha_baja;
            oComando.Parameters.Add("@fecha_sesion", SqlDbType.DateTime).Value = this.fecha_session;



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
            SqlConnection oConexion = new SqlConnection(this.sql);
            SqlCommand oComando = new SqlCommand(this.upd, oConexion);

            // Parametros para actualizar
            oComando.Parameters.Add("@id", SqlDbType.Int).Value = this.id;
            oComando.Parameters.Add("@empresa_id", SqlDbType.Int).Value = this.empresa_id;
            oComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = this.grupo_id;
            oComando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = this.apellido;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;
            oComando.Parameters.Add("@clave", SqlDbType.NVarChar).Value = this.clave;
            oComando.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = this.usuario;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
            oComando.Parameters.Add("@fecha_alta", SqlDbType.DateTime).Value = this.fecha_alta;
            oComando.Parameters.Add("@fecha_baja", SqlDbType.DateTime).Value = this.fecha_baja;
            oComando.Parameters.Add("@fecha_sesion", SqlDbType.DateTime).Value = this.fecha_session;
            

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
            SqlConnection oConexion = new SqlConnection(this.sql);
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
            SqlConnection oConexion = new SqlConnection(this.sql);
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
                this.empresa_id = (int)oRow["empresa_id"];
                this.grupo_id = (int)oRow["grupo_id"];
                this.nombre = (string)oRow["nombre"];
                this.apellido = (string)oRow["apellido"];
                this.clave = (string)oRow["clave"];
                this.usuario = (string)oRow["usuario"];
                this.estatus = (string)oRow["estatus"];
                this.fecha_alta = (DateTime)oRow["fecha_alta"];
                this.fecha_baja = (DateTime)oRow["fecha_baja"];
                this.fecha_session = (DateTime)oRow["fecha_sesion"];
                
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
            this.tbl = "sistema_usuarios";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "empresa_id,grupo_id,nombre,apellido,clave,usuario,estatus,fecha_alta,fecha_baja,fecha_sesion) " +
                "VALUES (" +
                    "@empresa_id,@grupo_id,@nombre,@apellido,@clave,@usuario,@estatus,@fecha_alta,@fecha_baja,@fecha_sesion); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "empresa_id = @empresa_id,      " +
                    "grupo_id   = @grupo_id,        " +
                    "nombre     = @nombre,          " +
                    "apellido   = @apellido,        " +
                    "clave      = @clave,           " +
                    "usuario    = @usuario,         " +
                    "estatus    = @estatus,         " +
                    "fecha_alta = @fecha_alta,      " +
                    "fecha_baja = @fecha_baja,      " +
                    "fecha_sesion = @fecha_sesion   " +
                   
                "WHERE (" +
                    "id = @id);";

            this.del =
                "DELETE FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";

            this.err = false;
            this.msg = "";

            this.id = 0;
            this.empresa_id = 0;
            this.grupo_id = 0;

            this.nombre = "";
            this.apellido = "";
            this.clave = "";
            this.usuario = "";
            this.estatus = "";
            this.fecha_alta = DateTime.Now;
            this.fecha_baja = DateTime.Now;
            this.fecha_session = DateTime.Now;
        }
    }
}
