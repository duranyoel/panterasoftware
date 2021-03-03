using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Administracion
{
    class Bancos : Base
    {
        //Propiedades privadas
       
       
        private string direccion;
        private string contacto;
        private string telefono;
        private string fax;
        private string email;
        private string website;
        private string estatus;
       


        //Constructores
        public Bancos()
        {
            this.declaracion();
        }
        public Bancos(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
       
        //Propiedades Publicas
        
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        public string Contacto
        {
            get { return this.contacto; }
            set { this.contacto = value; }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string WebSite
        {
            get { return this.website; }
            set { this.website = value; }
        }
        public string Estatus
        {
            get { return this.estatus; }
            set { this.estatus = value; }
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
            
            oComando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = this.direccion;
            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
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
           
            oComando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = this.direccion;
            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
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
               
                this.direccion = (string)oRow["direccion"];
                this.contacto = (string)oRow["contacto"];
                this.telefono = (string)oRow["telefono"];
                this.fax = (string)oRow["fax"];
                this.email = (string)oRow["email"];
                this.website = (string)oRow["website"];
                this.estatus = (string)oRow["estatus"];
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
            this.tbl = "bancos";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "userlog_id,codigo,nombre,direccion," +
                    "contacto,telefono,fax,email,website,estatus,borrado,creado,modificado) " +
                "VALUES (" +
                    "@userlog_id,@codigo,@nombre,@direccion," +
                    "@contacto,@telefono,@fax,@email,@website,@estatus,@borrado,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id             = @userlog_id,      " +
                    "codigo                 = @codigo,      " +
                    "nombre                 = @nombre,      " +
                    
                    "direccion              = @direccion, " +
                    "contacto               = @contacto,    " +
                    "telefono               = @telefono,    " +
                    "fax                    = @fax,         " +
                    "email                  = @email,       " +
                    "website                = @website,     " +
                    "estatus                = @estatus,      " +
                    "borrado                = @borrado, " +
                    "creado                 = @creado,     " +
                    "modificado             = @modificado     " +

                   

                "WHERE (" +
                    "id = @id);";

            this.del =
                "DELETE FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";

            this.err = false;
            this.msg = "";

            this.id = 0;
            
            this.nombre = "";
            this.codigo = "";
            
            this.direccion = "";
            this.contacto = "";
            this.telefono = "";
            this.fax = "";
            this.email = "";
            this.website = "";
            this.estatus = "";
            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;
            
        }
    }
}
