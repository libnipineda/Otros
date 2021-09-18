using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace IPC2_Practica.BD
{
    public class BaseDeDatos
    {

        public SqlConnection Conexion()
        {
            SqlConnection connect = new SqlConnection(); //conexion con la base de datos.
            connect.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;
            return connect;
        }

        public int Login(string user, string contraseña)
        {
            /*Significado de valores
             *  -1 -> id y password no coinciden
             *  0 -> error al intentar conectar con la bd.
             *  1 -> login de tipo admin
             */
            int valores = -1;
            SqlConnection connect = Conexion();

            try
            {
                connect.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("Select idUsuario,nombre,contraseña from usuario where nombre ='" + user + "' and contraseña ='" + contraseña + "'", connect); //query para la consulta
                DataTable tabla = new DataTable(); // se crea para contener los valores obtenidos por la consulta
                consulta.Fill(tabla);// se agregan a la tabla todas las filas que tiene la consulta
                if (tabla.Rows.Count == 0)
                {
                    valores = -1;
                }
                else
                {
                    valores = Int32.Parse(tabla.Rows[0]["idUsuario"].ToString());
                }
                connect.Close();
            }
            catch (Exception)
            {//Si pierde conexion
                connect.Close();
                valores = -2;
            }
            return valores;
        }

        public int permisos(string user)
        {
            int datos = 0;
            SqlConnection connect = Conexion();

            try
            {
                connect.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select idUsuario from usuario where nombre = '" + user + "';", connect); //query de consulta
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);

                if (tabla.Rows.Count == 0)
                {
                    datos = 0; // no existe usuario
                }
                else
                {
                    datos = Int32.Parse(tabla.Rows[0]["idUsuario"].ToString());
                }
                connect.Close();
            }
            catch (Exception)
            {
                connect.Close();
            }
            return datos;
        }

        public DataTable BuscarTipoProd(string tipo)
        {            
            SqlConnection connect = Conexion();

            try
            {
                connect.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select idTipo from tipo where nombreT= '" + tipo +"';", connect);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connect.Close();
                return tabla;
            }
            catch (Exception)
            {
                connect.Close();
                return null;
            }            
        }

        public DataTable BuscarMaterial(string  material)
        {            
            SqlConnection connect = Conexion();

            try
            {
                connect.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select idMaterial from material where nombreM= '" + material + "';", connect);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connect.Close();
                return tabla;
            }
            catch (Exception)
            {
                connect.Close();
                return null;
            }            
        }


        public DataTable BuscarColor(string color)
        {            
            SqlConnection connect = Conexion();

            try
            {
                connect.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select idColor from color where nombre= '" + color + "';", connect);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connect.Close();
                return tabla;                
            }
            catch (Exception)
            {
                connect.Close();
                return null;
            }            
        }

        public int RegistrarProd(string cod, string desc, double cost, int tip, string mat, string col )
        {
            /*Estados
             * 0 -> no se realizo el registro
             * 1 -> error de conexion en la BD.
             * 2 -> Se realizo el registro.
             */
            int estado = 0;
            SqlConnection con = Conexion();
            SqlCommand query = new SqlCommand("insert into producto (codigo,descripcion,costoU,codTipo,codMaterial,codColor) values (@cod,@des,@cosU,@ctipo,@cmaterial,@ccolor)");
            query.Connection = con;
            try
            {
                con.Open();
                // parametro codigo
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@cod";
                par.Value = cod;
                query.Parameters.Add(par);

                // parametro descripcion
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@des";
                parameter.Value = desc;
                query.Parameters.Add(parameter);

                // parametro costo unidad
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@cosU";
                par1.Value = cost;
                query.Parameters.Add(par1);

                // parametro tipo
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@ctipo";
                parameter1.Value = tip;
                query.Parameters.Add(parameter1);

                // parametro material
                SqlParameter par2 = new SqlParameter();
                par2.ParameterName = "@cmaterial";
                par2.Value = mat;
                query.Parameters.Add(par2);

                // parametro color
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@ccolor";
                para.Value = col;
                query.Parameters.Add(para);

                query.ExecuteNonQuery();
                con.Close();
                estado = 2;
            }
            catch (Exception)
            {
                con.Close();
                estado = 1;                
            }

            return estado;
        }

        public DataTable buscarProd(string cod)
        {
            SqlConnection connection = Conexion();

            try
            {
                connection.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select codigo,descripcion,costoU as 'costo unitario',codTipo as 'tipo',codMaterial as 'material',codColor as 'color' from producto where codigo = '" + cod + "';",connection);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connection.Close();
                return tabla;
            }
            catch (Exception)
            {
                connection.Close();
                return null;                
            }
        }
       
        public int ActualizarProd(string cod,string desc, double cost, int tip, string mat, string col)
        {
            /*Estados
            * 0 -> no se realizo el registro
            * 1 -> error de conexion en la BD.
            * 2 -> Se realizo la actualizacion.
            */
            int estado = 0;
            SqlConnection con = Conexion();
            SqlCommand query = new SqlCommand("update producto set descripcion = @des ,costoU = @cosU,codTipo = @ctipo ,codMaterial = @cmaterial,codColor = @ccolor where codigo = '"+ cod +"';");
            query.Connection = con;
            try
            {
                con.Open();                
                // parametro descripcion
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@des";
                parameter.Value = desc;
                query.Parameters.Add(parameter);

                // parametro costo unidad
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@cosU";
                par1.Value = cost;
                query.Parameters.Add(par1);

                // parametro tipo
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@ctipo";
                parameter1.Value = tip;
                query.Parameters.Add(parameter1);

                // parametro material
                SqlParameter par2 = new SqlParameter();
                par2.ParameterName = "@cmaterial";
                par2.Value = mat;
                query.Parameters.Add(par2);

                // parametro color
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@ccolor";
                para.Value = col;
                query.Parameters.Add(para);

                query.ExecuteNonQuery();
                con.Close();
                estado = 2;
            }
            catch (Exception)
            {
                con.Close();
                estado = 1;
            }

            return estado;
        }

        public int EliminarProd(string cod)
        {
            /*Estados
            * 0 -> no se realizo el registro
            * 1 -> error de conexion en la BD.
            * 2 -> Se realizo la eliminacion.
            */
            int estado = 0;
            SqlConnection con = Conexion();
            con.Open();
            try
            {
                SqlCommand query = new SqlCommand("delete from producto where codigo = '" + cod + "';", con);
                query.ExecuteNonQuery();
                con.Close();
                estado = 2;
            }
            catch (Exception)
            {
                con.Close();
                estado = 1;
                throw;
            }
            return estado;
        }

        public DataTable VerTipo(string tipo)
        {
            SqlConnection connection = Conexion();

            try
            {
                connection.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select codigo,descripcion,costoU as 'costo unitario',codTipo as 'tipo',codMaterial as 'material',codColor as 'color' from producto where codigo = '" + tipo + "';", connection);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connection.Close();
                return tabla;
            }
            catch (Exception)
            {
                connection.Close();
                return null;                
            }
        }

        public DataTable Consulta1(int tipo)
        {
            SqlConnection connection = Conexion();

            try
            {
                connection.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select codigo,descripcion,costoU as 'costo unitario',codTipo as 'tipo',codMaterial as 'material',codColor as 'color' from producto where codTipo = '" + tipo + "';", connection);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connection.Close();
                return tabla;
            }
            catch (Exception)
            {
                connection.Close();
                return null;                
            }
        }

        public DataTable Consulta2(string material)
        {
            SqlConnection connection = Conexion();

            try
            {
                connection.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select codigo,descripcion,costoU as 'costo unitario',codTipo as 'tipo',codMaterial as 'material',codColor as 'color' from producto where codMaterial = '" + material + "';", connection);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connection.Close();
                return tabla;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public DataTable Consulta3(string color)
        {
            SqlConnection connection = Conexion();

            try
            {
                connection.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select codigo,descripcion,costoU as 'costo unitario',codTipo as 'tipo',codMaterial as 'material',codColor as 'color' from producto where codColor = '" + color + "';", connection);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                connection.Close();
                return tabla;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public DataTable ObtenerIDProd(string cod)
        {
            SqlConnection connection = Conexion();

            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter("select idProducto from producto where codigo = '" + cod +"';",connection);
                DataTable tabla = new DataTable();
                query.Fill(tabla);
                connection.Close();
                return tabla;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public int RegistrarInv(double costo,int cant, int prod, int user)
        {
            /*Estados
             * 0 -> no se realizo el registro
             * 1 -> error de conexion en la BD.
             * 2 -> Se realizo el registro.
             */
            int estado = 0;
            SqlConnection con = Conexion();
            SqlCommand query = new SqlCommand("insert into inventario (costoUA,cantidad,codProd,codUser) values (@cos,@can,@cprod,@cuser)");
            query.Connection = con;

            try
            {
                con.Open();

                // parametro codigo
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@cos";
                par.Value = costo;
                query.Parameters.Add(par);

                // parametro cantidad
                SqlParameter par1 = new SqlParameter();
                par1.ParameterName = "@can";
                par1.Value = cant;
                query.Parameters.Add(par1);

                // parametro codigo producto
                SqlParameter par2 = new SqlParameter();
                par2.ParameterName = "@cprod";
                par2.Value = prod;
                query.Parameters.Add(par2);

                // parametro codigo usuario
                SqlParameter par3 = new SqlParameter();
                par3.ParameterName = "@cuser";
                par3.Value = user;
                query.Parameters.Add(par3);

                query.ExecuteNonQuery();
                con.Close();
                estado = 2;
            }
            catch (Exception)
            {
                con.Close();
                estado = 1;
            }
            return estado;
        }
    }
}