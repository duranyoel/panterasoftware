using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Administracion
{
    class CuentasBancarias : Base
    {
        //Propiedades privadas
        private int banco_id;
        private string apellidos;
        private string tipo_cuenta;
        private string numero_cuenta;
        private string codigo_contable;
        private string direccion;
        private string contacto;
        private string telefono;
        private string fax;
        private string email;
        private string website;
        private string estatus;
        private string naturaleza_cuenta;
        private string rif;

        private DateTime fecha_apertura;
        private DateTime fecha_conciliacion;
        private DateTime fecha_alta;

        private decimal saldo;
        private decimal saldo_conciliado;
        private decimal total_debitos;
        private decimal total_creditos;
        private decimal idb;

        private int ult_numero_cheque;
        private int numero_nota_debito;
        private int numero_nota_credito;


        //Constructores
        public CuentasBancarias()
        {
            this.declaracion();
        }
        public CuentasBancarias(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
       
        //Propiedades Publicas
        public int BancoId
        {
            get { return this.banco_id; }
            set { this.banco_id = value; }
        }        
        public string Apellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }        
        public string TipoCuenta
        {
            get { return this.tipo_cuenta; }
            set { this.tipo_cuenta = value; }
        }
        public string NumeroCuenta
        {
            get { return this.numero_cuenta; }
            set { this.numero_cuenta = value; }
        }
        public string CodigoContable
        {
            get { return this.codigo_contable; }
            set { this.codigo_contable = value; }
        }
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
        public string NaturalezaCuenta
        {
            get { return this.naturaleza_cuenta; }
            set { this.naturaleza_cuenta = value; }
        }
        public string Rif
        {
            get { return this.rif; }
            set { this.rif = value; }
        }

        public DateTime FechaApertura
        {
            get { return this.fecha_apertura; }
            set { this.fecha_apertura = value; }
        }
        public DateTime FechaConciliacion
        {
            get { return this.fecha_conciliacion; }
            set { this.fecha_conciliacion = value; }
        }
        public DateTime FechaAlta
        {
            get { return this.fecha_alta; }
            set { this.fecha_alta = value; }
        }
        public decimal Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }
        public decimal SaldoConciliado
        {
            get { return this.saldo_conciliado; }
            set { this.saldo_conciliado = value; }
        }
        public decimal TotalDebitos
        {
            get { return this.total_debitos; }
            set { this.total_debitos = value; }
        }
        public decimal TotalCreditos
        {
            get { return this.total_creditos; }
            set { this.total_creditos = value; }
        }
        public decimal Idb
        {
            get { return this.idb; }
            set { this.idb = value; }
        }
        public int UltimoCheque
        {
            get { return this.ult_numero_cheque; }
            set { this.ult_numero_cheque = value; }
        }
        public int NumeroDebito
        {
            get { return this.numero_nota_debito; }
            set { this.numero_nota_debito = value; }
        }
        public int NumeroCredito
        {
            get { return this.numero_nota_credito; }
            set { this.numero_nota_credito = value; }
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
            oComando.Parameters.Add("@banco_id", SqlDbType.Int).Value = this.banco_id;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;     
            oComando.Parameters.Add("@nombres", SqlDbType.NVarChar).Value = this.nombre;     
            oComando.Parameters.Add("@apellidos", SqlDbType.NVarChar).Value = this.apellidos;
            oComando.Parameters.Add("@tipo_cuenta", SqlDbType.NVarChar).Value = this.tipo_cuenta;
            oComando.Parameters.Add("@numero_cuenta", SqlDbType.NVarChar).Value = this.numero_cuenta;
            oComando.Parameters.Add("@codigo_contable", SqlDbType.NVarChar).Value = this.codigo_contable;
            oComando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = this.direccion;
            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
            oComando.Parameters.Add("@naturaleza_cuenta", SqlDbType.NVarChar).Value = this.naturaleza_cuenta;
            oComando.Parameters.Add("@fecha_apertura", SqlDbType.Date).Value = this.fecha_apertura;
            oComando.Parameters.Add("@fecha_conciliacion", SqlDbType.Date).Value = this.fecha_conciliacion;
            oComando.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = this.fecha_alta;
            oComando.Parameters.Add("@saldo", SqlDbType.Decimal).Value = this.saldo;
            oComando.Parameters.Add("@saldo_conciliado", SqlDbType.Decimal).Value = this.saldo_conciliado;
            oComando.Parameters.Add("@total_debitos", SqlDbType.Decimal).Value = this.total_debitos;
            oComando.Parameters.Add("@total_creditos", SqlDbType.Decimal).Value = this.total_creditos;
            oComando.Parameters.Add("@idb", SqlDbType.Decimal).Value = this.idb;
            oComando.Parameters.Add("@ultimo_numero_chq", SqlDbType.Int).Value = this.ult_numero_cheque;
            oComando.Parameters.Add("@numero_nota_credito", SqlDbType.Int).Value = this.numero_nota_credito;
            oComando.Parameters.Add("@numero_nota_debito", SqlDbType.Int).Value = this.numero_nota_debito;
            oComando.Parameters.Add("@rif", SqlDbType.NVarChar).Value = this.rif;


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
            oComando.Parameters.Add("@banco_id", SqlDbType.Int).Value = this.banco_id;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@nombres", SqlDbType.NVarChar).Value = this.nombre;
            oComando.Parameters.Add("@apellidos", SqlDbType.NVarChar).Value = this.apellidos;
            oComando.Parameters.Add("@tipo_cuenta", SqlDbType.NVarChar).Value = this.tipo_cuenta;
            oComando.Parameters.Add("@numero_cuenta", SqlDbType.NVarChar).Value = this.numero_cuenta;
            oComando.Parameters.Add("@codigo_contable", SqlDbType.NVarChar).Value = this.codigo_contable;
            oComando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = this.direccion;
            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = this.telefono;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
            oComando.Parameters.Add("@naturaleza_cuenta", SqlDbType.NVarChar).Value = this.naturaleza_cuenta;
            oComando.Parameters.Add("@fecha_apertura", SqlDbType.Date).Value = this.fecha_apertura;
            oComando.Parameters.Add("@fecha_conciliacion", SqlDbType.Date).Value = this.fecha_conciliacion;
            oComando.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = this.fecha_alta;
            oComando.Parameters.Add("@saldo", SqlDbType.Decimal).Value = this.saldo;
            oComando.Parameters.Add("@saldo_conciliado", SqlDbType.Decimal).Value = this.saldo_conciliado;
            oComando.Parameters.Add("@total_debitos", SqlDbType.Decimal).Value = this.total_debitos;
            oComando.Parameters.Add("@total_creditos", SqlDbType.Decimal).Value = this.total_creditos;
            oComando.Parameters.Add("@idb", SqlDbType.Decimal).Value = this.idb;
            oComando.Parameters.Add("@ultimo_numero_chq", SqlDbType.Int).Value = this.ult_numero_cheque;
            oComando.Parameters.Add("@numero_nota_credito", SqlDbType.Int).Value = this.numero_nota_credito;
            oComando.Parameters.Add("@numero_nota_debito", SqlDbType.Int).Value = this.numero_nota_debito;
            oComando.Parameters.Add("@rif", SqlDbType.NVarChar).Value = this.rif;

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
                this.banco_id = (int)oRow["banco_id"];
                this.codigo = (string)oRow["codigo"];
                this.nombre = (string)oRow["nombres"];
                this.apellidos = (string)oRow["apellidos"];
                this.tipo_cuenta = (string)oRow["tipo_cuenta"];
                this.numero_cuenta = (string)oRow["numero_cuenta"];
                this.codigo_contable = (string)oRow["codigo_contable"];
                this.direccion = (string)oRow["direccion"];
                this.contacto = (string)oRow["contacto"];
                this.telefono = (string)oRow["telefono"];
                this.fax = (string)oRow["fax"];
                this.email = (string)oRow["email"];
                this.website = (string)oRow["website"];
                this.estatus = (string)oRow["estatus"];
                this.naturaleza_cuenta = (string)oRow["naturaleza_cuenta"];
                this.fecha_apertura = (DateTime)oRow["fecha_apertura"];
                this.fecha_conciliacion = (DateTime)oRow["fecha_conciliacion"];
                this.fecha_alta = (DateTime)oRow["fecha_alta"];
                this.saldo = (decimal)oRow["saldo"];
                this.saldo_conciliado = (decimal)oRow["saldo_conciliado"];
                this.total_debitos = (decimal)oRow["total_debitos"];
                this.total_creditos = (decimal)oRow["total_creditos"];
                this.ult_numero_cheque = (int)oRow["ultimo_numero_chq"];
                this.numero_nota_debito = (int)oRow["numero_nota_debito"];
                this.numero_nota_credito = (int)oRow["numero_nota_credito"];
                this.rif = (string)oRow["rif"];
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
            this.tbl = "cuentas_bancarias";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "banco_id,codigo,nombres,apellidos,tipo_cuenta,numero_cuenta,codigo_contable,direccion,"+
                    "contacto,telefono,fax,email,website,estatus,naturaleza_cuenta,fecha_apertura,"+
                    "fecha_conciliacion,fecha_alta,saldo,saldo_conciliado,total_debitos,total_creditos,"+
                    "idb,ultimo_numero_chq,numero_nota_debito,numero_nota_credito,rif) " +
                "VALUES (" +
                    "@banco_id,@codigo,@nombres,@apellidos,@tipo_cuenta,@numero_cuenta,@codigo_contable,@direccion," +
                    "@contacto,@telefono,@fax,@email,@website,@estatus,@naturaleza_cuenta,@fecha_apertura," +
                    "@fecha_conciliacion,@fecha_alta,@saldo,@saldo_conciliado,@total_debitos,@total_creditos," +
                    "@idb,@ultimo_numero_chq,@numero_nota_debito,@numero_nota_credito,@rif); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "banco_id               = @banco_id,      " +
                    "codigo                 = @codigo,      " +
                    "nombres                = @nombres,      " +
                    "apellidos              = @apellidos,     " +
                    "tipo_cuenta            = @tipo_cuenta, " +
                    "numero_cuenta          = @numero_cuenta, " +
                    "codigo_contable        = @codigo_contable, " +
                    "direccion              = @direccion, " +
                    "contacto               = @contacto,    " +
                    "telefono               = @telefono,    " +
                    "fax                    = @fax,         " +
                    "email                  = @email,       " +
                    "website                = @website,     " +
                    "estatus                = @estatus,     " +
                    "naturaleza_cuenta      = @naturaleza_cuenta,  " +
                    "fecha_apertura         = @fecha_apertura,  " +
                    "fecha_conciliacion     = @fecha_conciliacion, "+
                    "fecha_alta             = @fecha_alta, "+
                    "saldo                  = @saldo,   "+
                    "saldo_conciliado       = @saldo_conciliado, "+
                    "total_debitos          = @total_debitos, "+
                    "total_creditos         = @total_creditos,  " +
                    "idb                    = @idb, "+
                    "ultimo_numero_chq      = @ultimo_numero_chq, "+
                    "numero_nota_debito     = @numero_nota_debito, "+
                    "numero_nota_credito    = @numero_nota_credito, " +
                    "rif    = @rif " +

                   

                "WHERE (" +
                    "id = @id);";

            this.del =
                "DELETE FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";

            this.err = false;
            this.msg = "";

            this.id = 0;
            this.banco_id = 0;
            this.nombre = "";
            this.codigo = "";
            this.apellidos = "";
            this.tipo_cuenta = "";
            this.numero_cuenta = "";
            this.codigo_contable = "";
            this.direccion = "";
            this.contacto = "";
            this.telefono = "";
            this.fax = "";
            this.email = "";
            this.website = "";
            this.estatus = "";
            this.naturaleza_cuenta = "";
            this.rif = "";
            this.fecha_apertura = DateTime.Now;
            this.fecha_conciliacion = DateTime.Now;
            this.fecha_alta = DateTime.Now;
            this.saldo = 0;
            this.saldo_conciliado = 0;
            this.total_debitos = 0;
            this.total_creditos = 0;
            this.idb = 0;
            this.ult_numero_cheque = 0;
            this.numero_nota_debito = 0;
            this.numero_nota_credito = 0;
            
        }
    }
}
