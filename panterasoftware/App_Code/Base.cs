using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;

namespace panterasoftware.App_Code
{
    class Base
    {
        //propiedades privadas
        protected string sql;
        
        protected string tbl;
        protected string sel;
        protected string ins;
        protected string upd;
        protected string del;
        protected bool err;
        protected string msg;
        protected int nro;

        protected int id;
        protected int userlog_id;
        

        protected string notas;


        protected DateTime emision;
        protected DateTime creado;
        protected DateTime modificado;
        protected double monto;
        protected string codigo;
        protected string nombre;
        protected bool invalid = false;
        protected bool borrado;
        

        //Constructores

        public Base()
        {
            this.declaracion();
        }
        public Base(int id)
        {

            this.declaracion();
            this.Leer(id);
        }

        //Propiedades Publicas 
        public string Sql
        {
            get { return this.sql; }
        }
     
        public bool Err
        {
            get { return this.err; }
            set { this.err = value; }
        }
        public string Msg
        {
            get { return this.msg; }
            set { this.msg = value; }
        }
        public int Nro
        {
            get
            {

                DataSet oDataSet = new DataSet();
                SqlConnection  oConexion = new SqlConnection(this.sql);
                SqlDataAdapter oAdaptador = new SqlDataAdapter(
                    "SELECT " +
                        "COUNT(id) AS count " +
                    "FROM  " + this.tbl + ";", oConexion);

                oConexion.Open();
                oAdaptador.Fill(oDataSet,"tabla");
                oConexion.Close();

                return (int)oDataSet.Tables["tabla"].Rows[0]["count"];
            }

        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int UserLogId
        {
            get { return this.userlog_id; }
            set { this.userlog_id = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Notas
        {
            get { return this.notas; }
            set { this.notas = value; }
        }

        public DateTime Emision
        {
            get { return this.emision; }
            set { this.emision = value; }
        }
        public DateTime Creado
        {
            get { return this.creado; }
            set { this.creado = value; }
        }
        public DateTime Modificado
        {
            get { return this.modificado; }
            set { this.modificado = value; }
        }

        public double Monto
        {
            get { return this.monto; }
            set { this.monto = value; }
        }
        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public bool Borrado
        {
            get { return this.borrado; }
            set { this.borrado = value; }
        }

        // Metodos Publicos
        public void Nuevo()
        {
            this.declaracion();
        }

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
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;

            oComando.Parameters.Add("@emision", SqlDbType.DateTime).Value = this.emision;
            oComando.Parameters.Add("@notas", SqlDbType.NVarChar).Value = this.notas;
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@monto", SqlDbType.Float).Value = this.monto;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@creado", SqlDbType.DateTime).Value = this.creado;
            oComando.Parameters.Add("@modificado", SqlDbType.DateTime).Value = this.modificado;
            oComando.Parameters.Add("@borrado", SqlDbType.Bit).Value = this.borrado;

            // parametro que devuelve el id
            oComando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            // Ejecuta la insercion
            try
            {
                oConexion.Open();
                oComando.ExecuteScalar();
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
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;

            oComando.Parameters.Add("@emision", SqlDbType.DateTime).Value = this.emision;
            oComando.Parameters.Add("@notas", SqlDbType.NVarChar).Value = this.notas;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@monto", SqlDbType.Float).Value = this.monto;
            oComando.Parameters.Add("@creado", SqlDbType.DateTime).Value = this.creado;
            oComando.Parameters.Add("@modificado", SqlDbType.DateTime).Value = this.modificado;
            oComando.Parameters.Add("@borrado", SqlDbType.Bit).Value = this.borrado;


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
            SqlCommand oComando = new SqlCommand(this.ins, oConexion);

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

                this.nombre = (string)oRow["nombre"];

                this.notas = (string)oRow["notas"];


                this.emision = (DateTime)oRow["emision"];
                this.creado = (DateTime)oRow["creado"];
                this.modificado = (DateTime)oRow["modificado"];
                this.monto = (double)oRow["monto"];
                this.codigo = (string)oRow["codigo"];
                this.userlog_id=(int)oRow["userlog_id"];
                this.borrado=(bool)oRow["borrado"];

                this.err = false;
                this.msg = "Registro leido correctamente.";
            }
            else
            {
                this.err = true;
                this.msg = "No hay registro.";
            }
        }

        public void declaracion()
        {

            this.sql = ConfigurationManager.ConnectionStrings["panterasoftware.Properties.Settings.Setting"].ToString();
            this.tbl = "tabla";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    " userlog_id,nombre,  referencia,  emision,  notas,  imagen,  monto,codigo,borrado,creado,modificado) " +
                "VALUES (" +
                    "@userlog_id,@nombre, @referencia, @emision, @notas, @imagen, @monto,@codigo,@borrado,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id = @userlog_id, "+
                    "nombre     = @nombre,     " +
                    "referencia = @referencia, " +
                    "emision    = @emision,    " +
                    "notas      = @notas,      " +
                    "imagen     = @imagen,     " +
                    "monto      = @monto,      " +
                    "codigo     = @codigo,     " +
                    "borrado    = @borrado,    " +
                    "creado     = @creado,     " +
                    "modificado = @modificado  " +

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
            this.emision = DateTime.Now;

            this.nombre = "";

            this.notas = "";

            this.monto = 0;

            this.codigo = "";
            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;

        }


        //Metodos varios para ser aplicados en formularios
        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
