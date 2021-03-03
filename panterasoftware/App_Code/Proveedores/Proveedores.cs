using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Proveedores
{
    class Proveedores : App_Code.Base
    {
        //Propiedades privadas
        private int grupo_id;
        private string pais;
        private string estado;
        private string municipio;
        private string parroquia;
        private string rif;
        private string razon_social;
        private string dir_fiscal;
        private string contacto;
        private string telefono_ofi;
        private string telefono_cel;
        private string fax;
        private string email;
        private string website;
        private string denominacion_fiscal;
        private string ciudad;
        private string codigo_postal;
       
        private string advertencia;
        private string estatus;
        private string codigo_cobrar;
        private string codigo_ingresos;
        private string codigo_anticipos;

        private double retencion_iva;
        private double retencion_islr;
        private double anticipos;
        private double debitos;
        private double creditos;
        private double saldo;
        private double disponible;
        private double ventas_g;
        private double ventas_1;
        private double ventas_2;
        private double ventas_3;
        private double ventas_4;
        private double cobranza_g;
        private double cobranza_1;
        private double cobranza_2;
        private double cobranza_3;
        private double cobranza_4;



        private bool estatus_vendedor;
        private bool estatus_ventas;
        private bool estatus_cobranza;
        private bool estatus_departamento;

        protected DateTime fecha_ult_compra;
        protected DateTime fecha_ult_pago;

        //Constructores
        public Proveedores()
        {
            this.declaracion();
        }
        public Proveedores(int id)
        {
            this.declaracion();
            this.Leer(id);

        }

        //Propiedades Publicas
        public string Contacto
        {
            get { return this.contacto; }
            set { this.contacto = value; }
        }
        public int GrupoId
        {
            get { return this.grupo_id; }
            set { this.grupo_id = value; }
        }
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
        public string Rif
        {
            get { return this.rif; }
            set { this.rif = value; }
        }
        public string RazonSocial
        {
            get { return this.razon_social; }
            set { this.razon_social = value; }
        }
        public string DirFiscal
        {
            get { return this.dir_fiscal; }
            set { this.dir_fiscal = value; }
        }
        public string Ciudad
        {
            get { return this.ciudad; }
            set { this.ciudad = value; }
        }
        public string TelefonoOficina
        {
            get { return this.telefono_ofi; }
            set { this.telefono_ofi = value; }
        }
        public string TelefonoCelular
        {
            get { return this.telefono_cel; }
            set { this.telefono_cel = value; }
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
        public string Website
        {
            get { return this.website; }
            set { this.website = value; }
        }
        public string DenominacionFiscal
        {
            get { return this.denominacion_fiscal; }
            set { this.denominacion_fiscal = value; }
        }
        public string CodigoPostal
        {
            get { return this.codigo_postal; }
            set { this.codigo_postal = value; }
        }

        
        public string Advertencia
        {
            get { return this.advertencia; }
            set { this.advertencia = value; }
        }
        public string Estatus
        {
            get { return this.estatus; }
            set { this.estatus = value; }
        }
        public string CodigoCobrar
        {
            get { return this.codigo_cobrar; }
            set { this.codigo_cobrar = value; }
        }
        public string CodigoAnticipos
        {
            get { return this.codigo_anticipos; }
            set { this.codigo_anticipos = value; }
        }
        public bool EstatusVendedor
        {
            get { return this.estatus_vendedor; }
            set { this.estatus_vendedor = value; }
        }
        public bool EstatusVentas
        {
            get { return this.estatus_ventas; }
            set { this.estatus_ventas = value; }
        }
        public bool EstatusCobranza
        {
            get { return this.estatus_cobranza; }
            set { this.estatus_cobranza = value; }
        }
        public bool EstatusDepartamento
        {
            get { return this.estatus_departamento; }
            set { this.estatus_departamento = value; }
        }
        public DateTime FechaUltimaCompra
        {
            get { return this.fecha_ult_compra; }
            set { this.fecha_ult_compra = value; }
        }
        public DateTime FechaUltimoPago
        {
            get { return this.fecha_ult_pago; }
            set { this.fecha_ult_pago = value; }
        }
        public double RetencionIva
        {
            get { return this.retencion_iva; }
            set { this.retencion_iva = value; }
        }
        public double RetencionIslr
        {
            get { return this.retencion_islr; }
            set { this.retencion_islr = value; }
        }
        public double Anticipos
        {
            get { return this.anticipos; }
            set { this.anticipos = value; }
        }
        public double Debitos
        {
            get { return this.debitos; }
            set { this.debitos = value; }
        }
        public double Creditos
        {
            get { return this.creditos; }
            set { this.creditos = value; }
        }
        public double Saldos
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }
        public double Disponible
        {
            get { return this.disponible; }
            set { this.disponible = value; }
        }
        public double VentasG
        {
            get { return this.ventas_g; }
            set { this.ventas_g = value; }
        }
        public double Ventas1
        {
            get { return this.ventas_1; }
            set { this.ventas_1 = value; }
        }
        public double Ventas2
        {
            get { return this.ventas_2; }
            set { this.ventas_2 = value; }
        }
        public double Ventas3
        {
            get { return this.ventas_3; }
            set { this.ventas_3 = value; }
        }
        public double Ventas4
        {
            get { return this.ventas_4; }
            set { this.ventas_4 = value; }
        }
        public double CobranzaG
        {
            get { return this.cobranza_g; }
            set { this.cobranza_g = value; }
        }
        public double Cobranza1
        {
            get { return this.cobranza_1; }
            set { this.cobranza_1 = value; }
        }
        public double Cobranza2
        {
            get { return this.cobranza_2; }
            set { this.cobranza_2 = value; }
        }
        public double Cobranza3
        {
            get { return this.cobranza_3; }
            set { this.cobranza_3 = value; }
        }
        public double Cobranza4
        {
            get { return this.cobranza_4; }
            set { this.cobranza_4 = value; }
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

            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = this.grupo_id;
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@pais", SqlDbType.NVarChar).Value = this.pais;
            oComando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = this.estado;
            oComando.Parameters.Add("@municipio", SqlDbType.NVarChar).Value = this.municipio;
            oComando.Parameters.Add("@parroquia", SqlDbType.NVarChar).Value = this.parroquia;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;
            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@rif", SqlDbType.NVarChar).Value = this.rif;
            oComando.Parameters.Add("@razon_social", SqlDbType.NVarChar).Value = this.razon_social;
            oComando.Parameters.Add("@dir_fiscal", SqlDbType.NVarChar).Value = this.dir_fiscal;
            oComando.Parameters.Add("@ciudad", SqlDbType.NVarChar).Value = this.ciudad;
            oComando.Parameters.Add("@telefono_ofi", SqlDbType.NVarChar).Value = this.telefono_ofi;
            oComando.Parameters.Add("@telefono_cel", SqlDbType.NVarChar).Value = this.telefono_cel;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@denominacion_fiscal", SqlDbType.NVarChar).Value = this.denominacion_fiscal;
            oComando.Parameters.Add("@codigo_postal", SqlDbType.NVarChar).Value = this.codigo_postal;
            oComando.Parameters.Add("@notas", SqlDbType.NVarChar).Value = this.notas;
            oComando.Parameters.Add("@advertencia", SqlDbType.NVarChar).Value = this.advertencia;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
            oComando.Parameters.Add("@codigo_cobrar", SqlDbType.NVarChar).Value = this.codigo_cobrar;
            oComando.Parameters.Add("@codigo_ingresos", SqlDbType.NVarChar).Value = this.codigo_ingresos;
            oComando.Parameters.Add("@codigo_anticipos", SqlDbType.NVarChar).Value = this.codigo_anticipos;

            oComando.Parameters.Add("@retencion_iva", SqlDbType.Float).Value = this.retencion_iva;
            oComando.Parameters.Add("@retencion_islr", SqlDbType.Float).Value = this.retencion_islr;
            oComando.Parameters.Add("@anticipos", SqlDbType.Float).Value = this.anticipos;
            oComando.Parameters.Add("@debitos", SqlDbType.Float).Value = this.debitos;
            oComando.Parameters.Add("@creditos", SqlDbType.Float).Value = this.creditos;
            oComando.Parameters.Add("@saldo", SqlDbType.Float).Value = this.saldo;
            oComando.Parameters.Add("@disponible", SqlDbType.Float).Value = this.disponible;
            oComando.Parameters.Add("@ventas_g", SqlDbType.Float).Value = this.ventas_g;
            oComando.Parameters.Add("@ventas_1", SqlDbType.Float).Value = this.ventas_1;
            oComando.Parameters.Add("@ventas_2", SqlDbType.Float).Value = this.ventas_2;
            oComando.Parameters.Add("@ventas_3", SqlDbType.Float).Value = this.ventas_3;
            oComando.Parameters.Add("@ventas_4", SqlDbType.Float).Value = this.ventas_4;
            oComando.Parameters.Add("@cobranza_g", SqlDbType.Float).Value = this.cobranza_g;
            oComando.Parameters.Add("@cobranza_1", SqlDbType.Float).Value = this.cobranza_1;
            oComando.Parameters.Add("@cobranza_2", SqlDbType.Float).Value = this.cobranza_2;
            oComando.Parameters.Add("@cobranza_3", SqlDbType.Float).Value = this.cobranza_3;
            oComando.Parameters.Add("@cobranza_4", SqlDbType.Float).Value = this.cobranza_4;

            oComando.Parameters.Add("@estatus_vendedor", SqlDbType.Bit).Value = this.estatus_vendedor;
            oComando.Parameters.Add("@estatus_ventas", SqlDbType.Bit).Value = this.estatus_ventas;
            oComando.Parameters.Add("@estatus_cobranza", SqlDbType.Bit).Value = this.estatus_cobranza;
            oComando.Parameters.Add("@estatus_departamento", SqlDbType.Bit).Value = this.estatus_departamento;
            oComando.Parameters.Add("@borrado", SqlDbType.Bit).Value = this.borrado;

            oComando.Parameters.Add("@fecha_ult_compra", SqlDbType.DateTime).Value = this.fecha_ult_compra;
            oComando.Parameters.Add("@fecha_ult_pago", SqlDbType.DateTime).Value = this.fecha_ult_pago;
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
            oComando.Parameters.Add("@id", SqlDbType.Int).Value = this.id;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = this.grupo_id;
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@pais", SqlDbType.NVarChar).Value = this.pais;
            oComando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = this.estado;
            oComando.Parameters.Add("@municipio", SqlDbType.NVarChar).Value = this.municipio;
            oComando.Parameters.Add("@parroquia", SqlDbType.NVarChar).Value = this.parroquia;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;
            oComando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = this.contacto;
            oComando.Parameters.Add("@rif", SqlDbType.NVarChar).Value = this.rif;
            oComando.Parameters.Add("@razon_social", SqlDbType.NVarChar).Value = this.razon_social;
            oComando.Parameters.Add("@dir_fiscal", SqlDbType.NVarChar).Value = this.dir_fiscal;
            oComando.Parameters.Add("@ciudad", SqlDbType.NVarChar).Value = this.ciudad;
            oComando.Parameters.Add("@telefono_ofi", SqlDbType.NVarChar).Value = this.telefono_ofi;
            oComando.Parameters.Add("@telefono_cel", SqlDbType.NVarChar).Value = this.telefono_cel;
            oComando.Parameters.Add("@fax", SqlDbType.NVarChar).Value = this.fax;
            oComando.Parameters.Add("@email", SqlDbType.NVarChar).Value = this.email;
            oComando.Parameters.Add("@website", SqlDbType.NVarChar).Value = this.website;
            oComando.Parameters.Add("@denominacion_fiscal", SqlDbType.NVarChar).Value = this.denominacion_fiscal;
            oComando.Parameters.Add("@codigo_postal", SqlDbType.NVarChar).Value = this.codigo_postal;
            oComando.Parameters.Add("@notas", SqlDbType.NVarChar).Value = this.notas;
            oComando.Parameters.Add("@advertencia", SqlDbType.NVarChar).Value = this.advertencia;
            oComando.Parameters.Add("@estatus", SqlDbType.NVarChar).Value = this.estatus;
            oComando.Parameters.Add("@codigo_cobrar", SqlDbType.NVarChar).Value = this.codigo_cobrar;
            oComando.Parameters.Add("@codigo_ingresos", SqlDbType.NVarChar).Value = this.codigo_ingresos;
            oComando.Parameters.Add("@codigo_anticipos", SqlDbType.NVarChar).Value = this.codigo_anticipos;

            oComando.Parameters.Add("@retencion_iva", SqlDbType.Float).Value = this.retencion_iva;
            oComando.Parameters.Add("@retencion_islr", SqlDbType.Float).Value = this.retencion_islr;
            oComando.Parameters.Add("@anticipos", SqlDbType.Float).Value = this.anticipos;
            oComando.Parameters.Add("@debitos", SqlDbType.Float).Value = this.debitos;
            oComando.Parameters.Add("@creditos", SqlDbType.Float).Value = this.creditos;
            oComando.Parameters.Add("@saldo", SqlDbType.Float).Value = this.saldo;
            oComando.Parameters.Add("@disponible", SqlDbType.Float).Value = this.disponible;
            oComando.Parameters.Add("@ventas_g", SqlDbType.Float).Value = this.ventas_g;
            oComando.Parameters.Add("@ventas_1", SqlDbType.Float).Value = this.ventas_1;
            oComando.Parameters.Add("@ventas_2", SqlDbType.Float).Value = this.ventas_2;
            oComando.Parameters.Add("@ventas_3", SqlDbType.Float).Value = this.ventas_3;
            oComando.Parameters.Add("@ventas_4", SqlDbType.Float).Value = this.ventas_4;
            oComando.Parameters.Add("@cobranza_g", SqlDbType.Float).Value = this.cobranza_g;
            oComando.Parameters.Add("@cobranza_1", SqlDbType.Float).Value = this.cobranza_1;
            oComando.Parameters.Add("@cobranza_2", SqlDbType.Float).Value = this.cobranza_2;
            oComando.Parameters.Add("@cobranza_3", SqlDbType.Float).Value = this.cobranza_3;
            oComando.Parameters.Add("@cobranza_4", SqlDbType.Float).Value = this.cobranza_4;

            oComando.Parameters.Add("@estatus_vendedor", SqlDbType.Bit).Value = this.estatus_vendedor;
            oComando.Parameters.Add("@estatus_ventas", SqlDbType.Bit).Value = this.estatus_ventas;
            oComando.Parameters.Add("@estatus_cobranza", SqlDbType.Bit).Value = this.estatus_cobranza;
            oComando.Parameters.Add("@estatus_departamento", SqlDbType.Bit).Value = this.estatus_departamento;
            oComando.Parameters.Add("@borrado", SqlDbType.Bit).Value = this.borrado;

            oComando.Parameters.Add("@fecha_ult_compra", SqlDbType.DateTime).Value = this.fecha_ult_compra;
            oComando.Parameters.Add("@fecha_ult_pago", SqlDbType.DateTime).Value = this.fecha_ult_pago;
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
                this.codigo = (string)oRow["codigo"];
                this.grupo_id = (int)oRow["grupo_id"];
                this.userlog_id = (int)oRow["userlog_id"];
                this.dir_fiscal = (string)oRow["dir_fiscal"];
                this.pais = (string)oRow["pais"];
                this.estado = (string)oRow["estado"];
                this.municipio = (string)oRow["municipio"];
                this.parroquia = (string)oRow["parroquia"];
                this.nombre = (string)oRow["nombre"];
                this.contacto = (string)oRow["contacto"];
                this.rif = (string)oRow["rif"];
                this.razon_social = (string)oRow["razon_social"];
                this.dir_fiscal = (string)oRow["dir_fiscal"];
                this.ciudad = (string)oRow["ciudad"];
                this.telefono_ofi = (string)oRow["telefono_ofi"];
                this.telefono_cel = (string)oRow["telefono_cel"];
                this.fax = (string)oRow["fax"];
                this.email = (string)oRow["email"];
                this.website = (string)oRow["website"];
                this.denominacion_fiscal = (string)oRow["denominacion_fiscal"];
                this.codigo_postal = (string)oRow["codigo_postal"];
                this.notas = (string)oRow["notas"];
                this.advertencia = (string)oRow["advertencia"];
                this.estatus = (string)oRow["estatus"];
                this.codigo_cobrar = (string)oRow["codigo_cobrar"];
                this.codigo_ingresos = (string)oRow["codigo_ingresos"];
                this.codigo_anticipos = (string)oRow["codigo_anticipos"];

                this.retencion_iva = (double)oRow["retencion_iva"];
                this.retencion_islr = (double)oRow["retencion_islr"];
                this.anticipos = (double)oRow["anticipos"];
                this.debitos = (double)oRow["debitos"];
                this.creditos = (double)oRow["creditos"];
                this.saldo = (double)oRow["saldo"];
                this.disponible = (double)oRow["retencion_iva"];
                this.ventas_g = (double)oRow["ventas_g"];
                this.ventas_1 = (double)oRow["ventas_1"];
                this.ventas_2 = (double)oRow["ventas_2"];
                this.ventas_3 = (double)oRow["ventas_3"];
                this.ventas_4 = (double)oRow["ventas_4"];
                this.cobranza_g = (double)oRow["cobranza_g"];
                this.cobranza_1 = (double)oRow["cobranza_1"];
                this.cobranza_2 = (double)oRow["cobranza_2"];
                this.cobranza_3 = (double)oRow["cobranza_3"];
                this.cobranza_4 = (double)oRow["cobranza_4"];

                this.estatus_vendedor = (bool)oRow["estatus_vendedor"];
                this.estatus_ventas = (bool)oRow["estatus_ventas"];
                this.estatus_cobranza = (bool)oRow["estatus_cobranza"];
                this.estatus_departamento = (bool)oRow["estatus_departamento"];
                this.borrado = (bool)oRow["borrado"];

                this.fecha_ult_compra = (DateTime)oRow["fecha_ult_compra"];
                this.fecha_ult_pago = (DateTime)oRow["fecha_ult_pago"];
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
            this.tbl = "proveedores";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "codigo,grupo_id,userlog_id,pais,estado,municipio,parroquia,nombre,contacto,rif,razon_social,dir_fiscal,ciudad," +
                    "telefono_ofi,telefono_cel,fax,email,website,denominacion_fiscal,codigo_postal,notas," +
                    "advertencia,estatus,codigo_cobrar,codigo_ingresos,codigo_anticipos,retencion_iva,retencion_islr,anticipos," +
                    "debitos,creditos,saldo,disponible,ventas_g,ventas_1,ventas_2,ventas_3,ventas_4," +
                    "cobranza_g,cobranza_1,cobranza_2,cobranza_3,cobranza_4,estatus_vendedor,borrado," +
                    "estatus_ventas,estatus_cobranza,estatus_departamento,fecha_ult_compra,fecha_ult_pago,creado,modificado) " +
                "VALUES (" +
                    "@codigo,@grupo_id,@userlog_id,@pais,@estado,@municipio,@parroquia,@nombre,@contacto,@rif,@razon_social,@dir_fiscal,@ciudad," +
                    "@telefono_ofi,@telefono_cel,@fax,@email,@website,@denominacion_fiscal,@codigo_postal,@notas," +
                    "@advertencia,@estatus,@codigo_cobrar,@codigo_ingresos,@codigo_anticipos,@retencion_iva,@retencion_islr,@anticipos," +
                    "@debitos,@creditos,@saldo,@disponible,@ventas_g,@ventas_1,@ventas_2,@ventas_3,@ventas_4," +
                    "@cobranza_g,@cobranza_1,@cobranza_2,@cobranza_3,@cobranza_4,@estatus_vendedor,@borrado," +
                    "@estatus_ventas,@estatus_cobranza,@estatus_departamento,@fecha_ult_compra,@fecha_ult_pago,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "codigo         = @codigo,       " +
                    "grupo_id       = @grupo_id,     " +
                    "userlog_id     = @userlog_id,   " +
                    "pais           = @pais,         " +
                    "estado         = @estado,       " +
                    "municipio      = @municipio,    " +
                    "parroquia      = @parroquia,    " +
                    "nombre         = @nombre,       " +
                    "contacto       = @contacto,     "+
                    "rif            = @rif,          " +
                    "razon_social   = @razon_social, " +
                    "dir_fiscal     = @dir_fiscal,      " +
                    "ciudad         = @ciudad,        " +
                    "telefono_ofi   = @telefono_ofi,    " +
                    "telefono_cel   = @telefono_cel,    " +
                    "fax            = @fax,             " +
                    "email          = @email,           " +
                    "website        = @website,         " +
                    "denominacion_fiscal    = @denominacion_fiscal, " +
                    "codigo_postal  = @codigo_postal,   " +
                    "notas           = @notas,            " +
                    "advertencia    = @advertencia,     " +
                    "estatus        = @estatus,         " +
                    "codigo_cobrar  = @codigo_cobrar,   " +
                    "codigo_ingresos = @codigo_ingresos, " +
                    "codigo_anticipos   = @codigo_anticipos, " +
                    "retencion_iva  = @retencion_iva,   " +
                    "retencion_islr = @retencion_islr,  " +
                    "anticipos      = @anticipos,       " +
                    "debitos        = @debitos,         " +
                    "creditos       = @creditos,        " +
                    "saldo          = @saldo,           " +
                    "disponible     = @disponible,      " +
                    "ventas_g       = @ventas_g,        " +
                    "ventas_1       = @ventas_1,        " +
                    "ventas_2       = @ventas_2,        " +
                    "ventas_3       = @ventas_3,        " +
                    "ventas_4       = @ventas_4,        " +
                    "cobranza_g     = @cobranza_g,      " +
                    "cobranza_1     = @cobranza_1,      " +
                    "cobranza_2     = @cobranza_2,      " +
                    "cobranza_3     = @cobranza_3,      " +
                    "cobranza_4     = @cobranza_4,      " +
                    "estatus_vendedor = @estatus_vendedor,  " +
                    "estatus_ventas   = @estatus_ventas,    " +
                    "estatus_cobranza   = @estatus_cobranza,    " +
                    "estatus_departamento = @estatus_departamento,  " +
                    "borrado        = @borrado,         " +
                    "fecha_ult_compra   = @fecha_ult_compra,    " +
                    "fecha_ult_pago = @fecha_ult_pago,  " +
                    "modificado     = @modificado " +


                "WHERE (" +
                    "id = @id);";

            this.del =
                "DELETE FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";

            this.err = false;
            this.msg = "";

            this.id = 0;
            this.grupo_id = 0;
            this.userlog_id = 0;
            this.pais = "";
            this.estado = "";
            this.municipio = "";
            this.parroquia = "";
            this.codigo = "";
            this.nombre = "";
            this.contacto = "";
            this.rif = "";
            this.razon_social = "";
            this.dir_fiscal = "";
            this.ciudad = "";
            this.telefono_ofi = "";
            this.telefono_cel = "";
            this.fax = "";
            this.email = "";
            this.website = "";
            this.denominacion_fiscal = "";
            this.codigo_postal = "";
            this.notas = "";
            this.advertencia = "";
            this.estatus = "";
            this.codigo_cobrar = "";
            this.codigo_ingresos = "";
            this.codigo_anticipos = "";

            this.retencion_islr = 0;
            this.retencion_iva = 0;
            this.anticipos = 0;
            this.debitos = 0;
            this.creditos = 0;
            this.saldo = 0;
            this.disponible = 0;
            this.ventas_g = 0;
            this.ventas_1 = 0;
            this.ventas_2 = 0;
            this.ventas_3 = 0;
            this.ventas_4 = 0;
            this.cobranza_g = 0;
            this.cobranza_1 = 0;
            this.cobranza_2 = 0;
            this.cobranza_3 = 0;
            this.cobranza_4 = 0;
            this.estatus_vendedor = false;
            this.estatus_ventas = false;
            this.estatus_cobranza = false;
            this.estatus_departamento = false;
            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;

        }
    }
}
