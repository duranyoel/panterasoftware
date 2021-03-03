using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Inventario
{
    class Productos : Base
    {
        //Propiedades privadas
        private int ivacompra, ivaventa, marca_id,departamento_id, dias_garantia,moneda_id,largo,ancho,alto,peso,contenido_empaque, unidad_id;
        private string referencia, imagen, comentarios, modelo, estatus,serial,tipoproducto;
        private double costo_proveedor, costo_varios, costo,costo_promedio,costo_calculado,ultimo_costo, 
            preciomayor, preciomaximo, preciooferta, preciominimo;
        //cc = comision cobranza, cv = comision venta


        //Constructores
        public Productos()
        {
            this.declaracion();
        }
        public Productos(int id)
        {
            this.declaracion();
            this.Leer(id);

        }

        //Propiedades Publicas
        //Costos
        public string NombreCorto
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Estatus
        {
            get { return this.estatus; }
            set { this.estatus = value; }
        }
        public string Comentarios
        {
            get { return this.comentarios; }
            set { this.comentarios = value; }
        }
        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public string Serial
        {
            get { return this.serial; }
            set { this.serial = value; }
        }
        public string TipoProducto
        {
            get { return this.tipoproducto; }
            set { this.tipoproducto = value; }
        }

        public double CostoProveedor
        {
            get { return this.costo_proveedor; }
            set { this.costo_proveedor = value; }
        }
        public double CostoVarios
        {
            get { return this.costo_varios; }
            set { this.costo_varios = value; }
        }
        public double Costo
        {
            get { return this.costo; }
            set { this.costo = value; }
        }
        public double CostoPromedio
        {
            get { return this.costo_promedio; }
            set { this.costo_promedio = value; }
        }
        public double CostoCalculado
        {
            get { return this.costo_calculado; }
            set { this.costo_calculado = value; }
        }
        public double UltimoCosto
        {
            get { return this.ultimo_costo; }
            set { this.ultimo_costo = value; }
        }
        //Precios
        public double PrecioMinimo
        {
            get { return this.preciominimo; }
            set { this.preciominimo = value; }
        }
        public double PrecioMaximo
        {
            get { return this.preciomaximo; }
            set { this.preciomaximo = value; }
        }
        public double PrecioMayor
        {
            get { return this.preciomayor; }
            set { this.preciomayor = value; }
        }
        public double PrecioOferta
        {
            get { return this.preciooferta; }
            set { this.preciooferta = value; }
        }

        public string Imagen
        {
            get { return this.imagen; }
            set { this.imagen = value; }
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
            oComando.Parameters.Add("@id", SqlDbType.Int).Value = this.id;
            oComando.Parameters.Add("@userlog_id", SqlDbType.Int).Value = this.userlog_id;
            oComando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = this.codigo;
            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;


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
            this.tbl = "productos";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "userlog_id,codigo,nombre,borrado,creado,modificado) " +
                "VALUES (" +
                    "@userlog_id,@codigo,@nombre,@borrado,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id     = @userlog_id,      " +
                    "codigo         = @codigo,      " +
                    "nombre         = @nombre,      " +

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

            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;


        }
    }
}
