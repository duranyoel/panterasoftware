using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace panterasoftware.App_Code.Configuracion
{
    class Empresa : Base
    {
        //propiedades privadas
        private string pais;
        private string estado;
        private string municipio;
        private string parroquia;

        private string direccion;
        private string denominacion_social;
        private string rif;
        private string telefono;
        private string telefonocel;
        private string sucursal;
        private string cod_sucursal;
        private string contacto;
        private string telefonocontacto;
        private string fax;
        private string email;
        private string website;
        private string registro;
        
        private string ciudad;
        private string cod_postal;
        private string imagen;
        private string tomo;
        private string folio;
        private string hoja;
        private decimal retencion_iva, retencion_islr, debito_bancario, factor_cambio;

        //Constructores
        public Empresa()
        {
            this.declaracion();
        }
        public Empresa(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
        public Empresa(string codigo)
        {
            this.declaracion();
            this.Leer(codigo);

        }

        //Propiedades Publicas
        public string Pais
        {
            get { return this.pais; }
            set { this.pais = value; }
        }
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string Municipio
        {
            get { return this.municipio; }
            set { this.municipio = value; }
        }
        public string Parroquia
        {
            get { return this.parroquia; }
            set { this.parroquia = value; }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        public string Denominacion_Social
        {
            get { return this.denominacion_social; }
            set { this.denominacion_social = value; }
        }
        public string Rif
        {
            get { return this.rif; }
            set { this.rif = value; }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        public string TelefonoCel
        {
            get { return this.telefonocel; }
            set { this.telefonocel = value; }
        }
        public string Sucursal
        {
            get { return this.sucursal; }
            set { this.sucursal = value; }
        }
        public string Cod_Sucursal
        {
            get { return this.cod_sucursal; }
            set { this.cod_sucursal = value; }
        }
        public string Contacto
        {
            get { return this.contacto; }
            set { this.contacto = value; }
        }
        public string TelefonoContacto
        {
            get { return this.telefonocontacto; }
            set { this.telefonocontacto = value; }
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
        public string Registro
        {
            get { return this.registro; }
            set { this.registro = value; }
        }
        public string Ciudad
        {
            get { return this.ciudad; }
            set { this.ciudad = value; }
        }
        public string Cod_Postal
        {
            get { return this.cod_postal; }
            set { this.cod_postal = value; }
        }
        public decimal Retencion_Iva
        {
            get { return this.retencion_iva; }
            set { this.retencion_iva = value; }
        }
        public decimal Retencion_Islr
        {
            get { return this.retencion_islr; }
            set { this.retencion_islr = value; }
        }
        public decimal Factor_Cambio
        {
            get { return this.factor_cambio; }
            set { this.factor_cambio = value; }
        }
        public decimal Debito_Bancario
        {
            get { return this.debito_bancario; }
            set { this.debito_bancario = value; }
        }
        public string Imagen
        {
            get { return this.imagen; }
            set { this.imagen = value; }
        }
        public string Tomo
        {
            get { return this.tomo; }
            set { this.tomo = value; }
        }
        public string Hoja
        {
            get { return this.hoja; }
            set { this.hoja = value; }
        }
        public string Folio
        {
            get { return this.folio; }
            set { this.folio = value; }
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
        public void Leer(string codigo)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(panterasoftware.Formularios.frmPrincipal.conexion);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                 "SELECT TOP(1) * " +
                 "FROM " + this.tbl + " " +
                 "WHERE (" +
                     "codigo = @codigo);"
                 , oConexion);

            oAdaptador.SelectCommand.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
            
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
            oComando.Parameters.Add("@pais", SqlDbType.NVarChar).Value = this.pais;
            oComando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = this.estado;
            oComando.Parameters.Add("@municipio", SqlDbType.NVarChar).Value = this.municipio;
            oComando.Parameters.Add("@parroquia", SqlDbType.NVarChar).Value = this.parroquia;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;
            oComando.Parameters.Add("@direccion", SqlDbType.NText).Value = this.direccion;
            oComando.Parameters.Add("@denominacion_social", SqlDbType.NVarChar).Value = this.denominacion_social;
            oComando.Parameters.Add("@rif", SqlDbType.NVarChar).Value = this.rif;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
            oComando.Parameters.Add("@telefonocel", SqlDbType.NVarChar).Value = this.telefonocel;
            oComando.Parameters.Add("@sucursal", SqlDbType.NVarChar).Value = this.sucursal;
            oComando.Parameters.Add("@codigo_sucursal", SqlDbType.NVarChar).Value = this.cod_sucursal;

            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@telefonocontacto", SqlDbType.NVarChar).Value = this.telefonocontacto;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@registro", SqlDbType.NVarChar).Value = this.registro;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;

            oComando.Parameters.Add("@ciudad", SqlDbType.NVarChar).Value = this.ciudad;
            oComando.Parameters.Add("@codigo_postal", SqlDbType.NVarChar).Value = this.cod_postal;


            oComando.Parameters.Add("@retencion_iva", SqlDbType.Decimal).Value = this.retencion_iva;
            oComando.Parameters.Add("@retencion_islr", SqlDbType.Decimal).Value = this.retencion_islr;
            oComando.Parameters.Add("@factor_cambio", SqlDbType.Decimal).Value = this.factor_cambio;
            oComando.Parameters.Add("@debito_bancario", SqlDbType.Decimal).Value = this.debito_bancario;

            oComando.Parameters.Add("@imagen", SqlDbType.NVarChar).Value = this.imagen;
            oComando.Parameters.Add("@tomo", SqlDbType.NVarChar).Value = this.tomo;
            oComando.Parameters.Add("@hoja", SqlDbType.NVarChar).Value = this.hoja;
            oComando.Parameters.Add("@folio", SqlDbType.NVarChar).Value = this.folio;
           

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
            oComando.Parameters.Add("@pais", SqlDbType.NVarChar).Value = this.pais;
            oComando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = this.estado;
            oComando.Parameters.Add("@municipio", SqlDbType.NVarChar).Value = this.municipio;
            oComando.Parameters.Add("@parroquia", SqlDbType.NVarChar).Value = this.parroquia;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value=this.nombre;
            oComando.Parameters.Add("@direccion", SqlDbType.NText).Value=this.direccion;
            oComando.Parameters.Add("@denominacion_social",SqlDbType.NVarChar).Value=this.denominacion_social;
            oComando.Parameters.Add("@rif", SqlDbType.NVarChar).Value=this.rif;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value=this.telefono;
            oComando.Parameters.Add("@telefonocel", SqlDbType.NVarChar).Value = this.telefonocel;
            oComando.Parameters.Add("@sucursal", SqlDbType.NVarChar).Value = this.sucursal;
            oComando.Parameters.Add("@codigo_sucursal", SqlDbType.NVarChar).Value = this.cod_sucursal;

            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@telefonocontacto", SqlDbType.NVarChar).Value = this.telefonocontacto;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@registro", SqlDbType.NVarChar).Value = this.registro;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value=this.codigo;

            oComando.Parameters.Add("@ciudad", SqlDbType.NVarChar).Value = this.ciudad;
            oComando.Parameters.Add("@codigo_postal", SqlDbType.NVarChar).Value = this.cod_postal;


            oComando.Parameters.Add("@retencion_iva", SqlDbType.Decimal).Value = this.retencion_iva;
            oComando.Parameters.Add("@retencion_islr", SqlDbType.Decimal).Value = this.retencion_islr;
            oComando.Parameters.Add("@factor_cambio", SqlDbType.Decimal).Value = this.factor_cambio;
            oComando.Parameters.Add("@debito_bancario", SqlDbType.Decimal).Value = this.debito_bancario;

            oComando.Parameters.Add("@imagen", SqlDbType.NVarChar).Value = this.imagen;
            oComando.Parameters.Add("@tomo", SqlDbType.NVarChar).Value = this.tomo;
            oComando.Parameters.Add("@hoja", SqlDbType.NVarChar).Value = this.hoja;
            oComando.Parameters.Add("@folio", SqlDbType.NVarChar).Value = this.folio;


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
                this.pais = (string)oRow["pais"];
                this.estado = (string)oRow["estado"];
                this.municipio = (string)oRow["municipio"];
                this.parroquia = (string)oRow["parroquia"];
                this.nombre = (string)oRow["nombre"];
                this.direccion = (string)oRow["direccion"];
                this.denominacion_social = (string)oRow["denominacion_social"];
                
                this.rif = (string)oRow["rif"];
                this.telefono = (string)oRow["telefono"];
                this.telefonocel = (string)oRow["telefonocel"];
                this.sucursal = (string)oRow["sucursal"];
                this.cod_sucursal = (string)oRow["codigo_sucursal"];

                this.contacto = (string)oRow["contacto"];
                this.telefonocontacto = (string)oRow["telefonocontacto"];
                this.fax = (string)oRow["fax"];
                this.email = (string)oRow["email"];
                this.website = (string)oRow["website"];
                this.registro = (string)oRow["registro"];
                this.codigo = (string)oRow["codigo"];
                
                this.ciudad = (string)oRow["ciudad"];
                this.cod_postal = (string)oRow["codigo_postal"];


                this.retencion_iva = (decimal)oRow["retencion_iva"];
                this.retencion_islr = (decimal)oRow["retencion_islr"];
                this.factor_cambio = (decimal)oRow["factor_cambio"];
                this.debito_bancario = (decimal)oRow["debito_bancario"];

                this.imagen = (string)oRow["imagen"];
                this.tomo = (string)oRow["tomo"];
                this.hoja = (string)oRow["hoja"];
                this.folio = (string)oRow["folio"];
            
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
            this.tbl = "empresas";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "pais,estado,municipio,parroquia,nombre,direccion,denominacion_social, rif, telefono,telefonocel, sucursal, codigo_sucursal, contacto," +
                    "telefonocontacto,fax, email, website, registro, codigo, ciudad, codigo_postal," +
                    "retencion_iva, retencion_islr, factor_cambio, debito_bancario,imagen,tomo,hoja,folio) " +
                "VALUES (" +
                    "@pais,@estado,@municipio,@parroquia,@nombre, @direccion,@denominacion_social, @rif, @telefono,@telefonocel, @sucursal, @codigo_sucursal, @contacto," +
                    "@telefonocontacto,@fax, @email, @website, @registro, @codigo, @ciudad, @codigo_postal," +
                    "@retencion_iva, @retencion_islr, @factor_cambio, @debito_bancario,@imagen,@tomo,@hoja,@folio); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "pais       = @pais,     " +
                    "estado     = @estado,     " +
                    "municipio  = @municipio,     " +
                    "parroquia  = @parroquia,     " +
                    "nombre     = @nombre,    " +
                    "denominacion_social = @denominacion_social,     " +
                    "direccion  = @direccion, " +
                    "rif        = @rif,    " +
                    "telefono   = @telefono,      " +
                    "telefonocel   = @telefonocel,      " +
                    "sucursal   = @sucursal,      " +
                    "codigo_sucursal   = @codigo_sucursal,  " +

                    "contacto   = @contacto, " +
                    "telefonocontacto   = @telefonocontacto,      " +
                    "fax        = @fax, " +
                    "email      = @email, " +
                    "website    = @website, " +
                    "registro   = @registro, " +
                    "codigo     = @codigo, " +

                    "ciudad     = @ciudad, " +
                    "codigo_postal   = @codigo_postal, " +

                    "imagen     = @imagen, " +

                    "retencion_iva   = @retencion_iva, " +
                    "retencion_islr  = @retencion_islr, " +
                    "factor_cambio   = @factor_cambio, " +
                    "debito_bancario = @debito_bancario, " +
                    "tomo           = @tomo, " +
                    "hoja           = @hoja, " +
                    "folio          = @folio " +

                "WHERE (" +
                    "id = @id);";

            this.del =
                "DELETE FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";

            this.err = false;
            this.msg = "";

            this.id = 0;
            this.pais="";
            this.estado="";
            this.municipio="";
            this.parroquia = "";
            this.nombre = "";
            this.denominacion_social = "";
            this.direccion = "";
            this.rif = "";
            this.telefono = "";
            this.telefonocel = "";
            this.sucursal = "";
            this.cod_sucursal = "";

            this.contacto = "";
            this.telefonocontacto = "";
            this.fax = "";
            this.email = "";
            this.website = "";
            this.registro = "";
            this.codigo = "";
            
            this.ciudad = "";
            this.cod_postal = "";

            this.imagen = "";
            this.tomo = "";
            this.hoja = "";
            this.folio = "";
           
            this.retencion_iva = 0;
            this.retencion_islr = 0;
            this.factor_cambio = 0;
            this.debito_bancario = 0;
            
        }
    }
}
