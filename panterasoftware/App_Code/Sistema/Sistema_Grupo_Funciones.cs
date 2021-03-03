using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panterasoftware.App_Code.Sistema
{
    class Sistema_Grupo_Funciones : App_Code.Base
    {
        //propiedades privadas
        private int grupo_id;
        private int funcion_id;
        
               
        //Constructores
        public int GrupoId
        {
            get { return this.grupo_id; }
            set { this.grupo_id = value; }
        }
        public int FuncionId
        {
            get { return this.funcion_id; }
            set { this.funcion_id = value; }
        }
        public Sistema_Grupo_Funciones()
        {
            this.declaracion();
        }
        public Sistema_Grupo_Funciones(int id)
        {
            this.declaracion();
            this.Leer(id);

        }
        public Sistema_Grupo_Funciones(int id_grupo,int id_funcion)
        {
            this.declaracion();
            this.Leer(id_grupo,id_funcion);

        }
        public Sistema_Grupo_Funciones(int grupo_id, string codigo)
        {
            this.declaracion();
            this.Leer(grupo_id,codigo);

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
        public void Leer(int id_grupo, int id_funcion)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(this.sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                 "SELECT TOP(1) * " +
                 "FROM " + this.tbl + " " +
                 "WHERE (" +
                     "grupo_id = @grupo_id) AND (funcion_id=@funcion_id);"
                 , oConexion);

            oAdaptador.SelectCommand.Parameters.Add("@grupo_id", SqlDbType.Int).Value = id_grupo;
            oAdaptador.SelectCommand.Parameters.Add("@funcion_id", SqlDbType.Int).Value = id_funcion;
            oConexion.Open();
            oAdaptador.Fill(oDataSet, "tabla");
            oConexion.Close();

            this.campos(oDataSet);
        }
        public void Leer( int grupo_id, string codigo)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(this.sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(
                "SELECT "+
                    "sistema_grupo_funciones.* "+
                  
                   
                   
                "FROM sistema_grupo_funciones "+
                    "INNER JOIN sistema_usuarios ON sistema_grupo_funciones.grupo_id = sistema_usuarios.grupo_id "+
                    "INNER JOIN sistema_funciones ON sistema_grupo_funciones.funcion_id = sistema_funciones.id "+
                "WHERE ("+
                    "sistema_usuarios.grupo_id = @grupo_id) AND ("+
                    "sistema_funciones.codigo = @codigo) AND ("+
                    "sistema_funciones.estatus = 'Activo');"
                 , oConexion);

            oAdaptador.SelectCommand.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id;
            oAdaptador.SelectCommand.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo;
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
            oComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = this.grupo_id;
            oComando.Parameters.Add("@funcion_id", SqlDbType.Int).Value = this.funcion_id;
           

           
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
            oComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = this.grupo_id;
            oComando.Parameters.Add("@funcion_id", SqlDbType.Int).Value = this.funcion_id;
            

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
                this.grupo_id =(int)oRow["grupo_id"];
                this.funcion_id = (int)oRow["funcion_id"];
                                
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
            this.tbl = "sistema_grupo_funciones";
            this.sel =
                "SELECT TOP(1) * " +
                "FROM " + this.tbl + " " +
                "WHERE (" +
                    "id = @id);";
            this.ins =
                "INSERT INTO " + this.tbl + " (" +
                    "grupo_id, funcion_id) " +
                "VALUES (" +
                    "@grupo_id,@funcion_id); " +

                "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";

            this.upd =
                "UPDATE " + this.tbl + " " +

                "SET " +
                    "grupo_id    = @grupo_id, "+
                    "funcion_id  = @funcion_id " +
                   
                   
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
            this.funcion_id = 0;
           

        }
    }
}
