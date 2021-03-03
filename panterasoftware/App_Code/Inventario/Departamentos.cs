using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Inventario
{
    class Departamentos : Base
    {
        //Propiedades privadas
        //cc = comision cobranza, cv = comision venta
        
        private double preciomayor, preciomaximo, preciooferta, preciominimo;
        private double ccpreciomayor, ccpreciomaximo, ccpreciooferta, ccpreciominimo;
        private double cvpreciomayor, cvpreciomaximo, cvpreciooferta, cvpreciominimo;
        private string imagen;

       
        //Constructores
        public Departamentos()
        {
            this.declaracion();
        }
        public Departamentos(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
       
        //Propiedades Publicas
        //Comision Ventas
        public double ComisionVentaPrecioMaximo
        {
            get { return this.cvpreciomaximo; }
            set { this.cvpreciomaximo = value; }
        }
        public double ComisionVentaPrecioMayor
        {
            get { return this.cvpreciomayor; }
            set { this.cvpreciomayor = value; }
        }
        public double ComisionVentaPrecioOferta
        {
            get { return this.cvpreciooferta; }
            set { this.cvpreciooferta = value; }
        }
        public double ComisionVentaPrecioMinimo
        {
            get { return this.cvpreciominimo; }
            set { this.cvpreciominimo = value; }
        }
       //Comision Cobranzas
        public double ComisionCobranzaPrecioMinimo
        {
            get { return this.ccpreciominimo; }
            set { this.ccpreciominimo = value; }
        }
        public double ComisionCobranzaPrecioMaximo
        {
            get { return this.ccpreciomaximo; }
            set { this.ccpreciomaximo = value; }
        }
        public double ComisionCobranzaPrecioMayor
        {
            get { return this.ccpreciomayor; }
            set { this.ccpreciomayor = value; }
        }
        public double ComisionCobranzaPrecioOferta
        {
            get { return this.ccpreciooferta; }
            set { this.ccpreciooferta = value; }
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
            
           
            oComando.Parameters.Add("@preciomaximo", SqlDbType.Float).Value = this.preciomaximo;
            oComando.Parameters.Add("@preciooferta", SqlDbType.Float).Value = this.preciooferta;
            oComando.Parameters.Add("@preciomayor", SqlDbType.Float).Value = this.preciomayor;
            oComando.Parameters.Add("@preciominimo", SqlDbType.Float).Value = this.preciominimo;

            oComando.Parameters.Add("@ccpreciomaximo", SqlDbType.Float).Value = this.ccpreciomaximo;
            oComando.Parameters.Add("@ccpreciooferta", SqlDbType.Float).Value = this.ccpreciooferta;
            oComando.Parameters.Add("@ccpreciomayor", SqlDbType.Float).Value = this.ccpreciomayor;
            oComando.Parameters.Add("@ccpreciominimo", SqlDbType.Float).Value = this.ccpreciominimo;

            oComando.Parameters.Add("@cvpreciomaximo", SqlDbType.Float).Value = this.cvpreciomaximo;
            oComando.Parameters.Add("@cvpreciooferta", SqlDbType.Float).Value = this.cvpreciooferta;
            oComando.Parameters.Add("@cvpreciomayor", SqlDbType.Float).Value = this.cvpreciomayor;
            oComando.Parameters.Add("@cvpreciominimo", SqlDbType.Float).Value = this.cvpreciominimo;
            oComando.Parameters.Add("@imagen", SqlDbType.NVarChar).Value = this.imagen;

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

            oComando.Parameters.Add("@preciomaximo", SqlDbType.Float).Value = this.preciomaximo;
            oComando.Parameters.Add("@preciooferta", SqlDbType.Float).Value = this.preciooferta;
            oComando.Parameters.Add("@preciomayor", SqlDbType.Float).Value = this.preciomayor;
            oComando.Parameters.Add("@preciominimo", SqlDbType.Float).Value = this.preciominimo;

            oComando.Parameters.Add("@ccpreciomaximo", SqlDbType.Float).Value = this.ccpreciomaximo;
            oComando.Parameters.Add("@ccpreciooferta", SqlDbType.Float).Value = this.ccpreciooferta;
            oComando.Parameters.Add("@ccpreciomayor", SqlDbType.Float).Value = this.ccpreciomayor;
            oComando.Parameters.Add("@ccpreciominimo", SqlDbType.Float).Value = this.ccpreciominimo;

            oComando.Parameters.Add("@cvpreciomaximo", SqlDbType.Float).Value = this.cvpreciomaximo;
            oComando.Parameters.Add("@cvpreciooferta", SqlDbType.Float).Value = this.cvpreciooferta;
            oComando.Parameters.Add("@cvpreciomayor", SqlDbType.Float).Value = this.cvpreciomayor;
            oComando.Parameters.Add("@cvpreciominimo", SqlDbType.Float).Value = this.cvpreciominimo;
            oComando.Parameters.Add("@imagen", SqlDbType.NVarChar).Value = this.imagen;
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

                this.preciomaximo = (double)oRow["preciomaximo"];
                this.preciooferta = (double)oRow["preciooferta"];
                this.preciomayor = (double)oRow["preciomayor"];
                this.preciominimo = (double)oRow["preciominimo"];

                this.ccpreciomaximo = (double)oRow["ccpreciomaximo"];
                this.ccpreciooferta = (double)oRow["ccpreciooferta"];
                this.ccpreciomayor = (double)oRow["ccpreciomayor"];
                this.ccpreciominimo = (double)oRow["ccpreciominimo"];

                this.cvpreciomaximo = (double)oRow["cvpreciomaximo"];
                this.cvpreciooferta = (double)oRow["cvpreciooferta"];
                this.cvpreciomayor = (double)oRow["cvpreciomayor"];
                this.cvpreciominimo = (double)oRow["cvpreciominimo"];
                this.imagen = (string)oRow["imagen"];
                
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
            this.tbl = "departamentos";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "userlog_id,codigo,nombre, "+
                    "preciomaximo,"+
                    "preciooferta,"+
                    "preciomayor, "+
                    "preciominimo, "+
                    "ccpreciomaximo," +
                    "ccpreciooferta," +
                    "ccpreciomayor, " +
                    "ccpreciominimo, " +
                    "cvpreciomaximo," +
                    "cvpreciooferta," +
                    "cvpreciomayor, " +
                    "cvpreciominimo, " +
                    "imagen, " +
                    "borrado,creado,modificado) " +
                "VALUES (" +
                    "@userlog_id,@codigo,@nombre, "+
                    "@preciomaximo," +
                    "@preciooferta," +
                    "@preciomayor, " +
                    "@preciominimo, " +
                    "@ccpreciomaximo," +
                    "@ccpreciooferta," +
                    "@ccpreciomayor, " +
                    "@ccpreciominimo, " +
                    "@cvpreciomaximo," +
                    "@cvpreciooferta," +
                    "@cvpreciomayor, " +
                    "@cvpreciominimo, " +
                    "@imagen, " +
                    "@borrado,@creado,@modificado); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "userlog_id     = @userlog_id,      " +
                    "codigo         = @codigo,      " +
                    "nombre         = @nombre,      " +
                    "preciomaximo   = @preciomaximo,   " +
                    "preciooferta   = @preciooferta,   " +
                    "preciomayor    = @preciomayor,   " +
                    "preciominimo   = @preciominimo,   " +
                    "ccpreciomaximo   = @ccpreciomaximo,   " +
                    "ccpreciooferta   = @ccpreciooferta,   " +
                    "ccpreciomayor    = @ccpreciomayor,   " +
                    "ccpreciominimo   = @ccpreciominimo,   " +
                    "cvpreciomaximo   = @cvpreciomaximo,   " +
                    "cvpreciooferta   = @cvpreciooferta,   " +
                    "cvpreciomayor    = @cvpreciomayor,   " +
                    "cvpreciominimo   = @cvpreciominimo,   " +
                    "imagen         = @imagen, " +
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
            this.preciomaximo = 0;
            this.preciooferta = 0;
            this.preciomayor = 0;
            this.preciominimo = 0;

            this.ccpreciomaximo = 0;
            this.ccpreciooferta = 0;
            this.ccpreciomayor = 0;
            this.ccpreciominimo = 0;

            this.cvpreciomaximo = 0;
            this.cvpreciooferta = 0;
            this.cvpreciomayor = 0;
            this.cvpreciominimo = 0;
            this.imagen = "";

            this.borrado = false;
            this.creado = DateTime.Now;
            this.modificado = DateTime.Now;
         
            
        }
    }
}
