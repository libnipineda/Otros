using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace IPC2.Base_De_Datos
{
    public class Data
    {
        int estado = 0;

        public SqlConnection Conexion()
        {
            SqlConnection connect = new SqlConnection(); // conexion con la base de datos.
            connect.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            return connect;
        }

        public int Login(string usuario, string contraseña)
        {
            /*Significado de valores
             *  -1 -> id y password no coinciden
             *  0 -> error al intentar conectar con la bd.
             *  1 -> login de tipo admin
             *  2 -> login de tipo agente turistico
             *  3 -> login de tipo tecnico   
             *  4 -> login de tipo usuario
            */
            int valores = -1;
            SqlConnection connect = Conexion();
            try
            {
                connect.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("Select nickname,contraseña,codTipoU from usuario where nickname ='" + usuario + "' and contraseña ='" + contraseña + "'", connect);
                DataTable tabla = new DataTable(); // se crea para contener los valores obtenidos por la consulta
                consulta.Fill(tabla); // se agregan a la tabla todas las filas que tiene la consulta
                if (tabla.Rows.Count == 0)
                {
                    valores = -1;
                }
                else
                {
                    valores = Int32.Parse(tabla.Rows[0]["codTipoU"].ToString());
                }
                connect.Close();
            }
            catch (Exception)
            { // excepcion  si se pierde conexion
                connect.Close();
                valores = -2;
            }
            return valores;
        }

        public int Permisos(string usuario)
        {
            int datos = 0;
            SqlConnection connection = Conexion();
            try
            {
                connection.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select codTipoU from usuario where nickname = '" + usuario + "'", connection);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                if (tabla.Rows.Count == 0)
                {
                    datos = 0; // no existe usuario
                }
                else
                {
                    datos = Int32.Parse(tabla.Rows[0]["codTipoU"].ToString());
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return datos;
        }

        public int CrearU(string nombre,  string email, string telefono, string user,string cont, int tipo)
        {
            /* Estados, este metodo se utiliza para registrar usuarios en la plataforma.
             * 0 -> no se realizo el registro.
             * 1 -> error de conexion bd.
             * 2 -> se realizo el registro.
             */          
            SqlConnection con = Conexion();            
            try
            {
                con.Open();
                SqlCommand query = new SqlCommand("insert into usuario(nombre,email,telefono,nickname,contraseña,codTipoU) values('" + nombre + "','" + email + "','" + telefono + "','" +
                user + "','" + cont + "','" + tipo + "')", con);
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

        public DataTable ObtenerU(string usuario)
        { // Metodo para obtener valores para el formulario Administrador/Home.aspx
            SqlConnection con = Conexion();
            try
            {
                con.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select nombre,email,nickname,idUsuario from usuario where nickname='" + usuario+"';",con);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                con.Close();
                return tabla;
            }
            catch (Exception)
            {
                con.Close();                
            }
            return null;
        }
        
        public DataTable DatosU(string usuario)
        { //Metodo para desplegar informacion del usuario que se busco, lo utiliza Administrador/MEUsuario.aspx
            SqlConnection con = Conexion();
            try
            {
                con.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("select idUsuario,nombre,email,telefono,nickname from usuario where nickname='" + usuario + "';", con);
                DataTable tabla = new DataTable();
                consulta.Fill(tabla);
                con.Close();
                return tabla;
            }
            catch (Exception)
            {
                con.Close();
                return null;
            }
        }

        public int ActualizarU(string codigo,string nombre, string email, string telefono, string user, string cont, int tipo)
        {
            /* Estados, este metodo se utiliza para registrar usuario tipo estudiante en la plataforma.
             * 0 -> no se realizo la actualizacion.
             * 1 -> error de conexion bd.
             * 2 -> se realizo la actualizacion.
             */            
            SqlConnection conexion = Conexion();
            string instruccion = "UPDATE usuario SET nombre = '"+nombre+"', email = '"+email +"', telefono = '"+telefono+
                "', nickname ='" +user+"', contraseña ='"+cont+"', codTipoU = '"+tipo+"' WHERE idUsuario = '" + codigo + "';";            
            try
            {
                conexion.Open();
                SqlCommand actualizar = new SqlCommand(instruccion, conexion);
                actualizar.ExecuteNonQuery();
                conexion.Close();
                estado = 2;
            }
            catch (Exception)
            {
                conexion.Close();
                estado = 1;                
            }
            return estado;
        }

        public int EliminarU(string codigo)
        {
            /* Estados, este metodo se utiliza para registrar usuario tipo estudiante en la plataforma.
             * 0 -> no se realizo la eliminacion.
             * 1 -> error de conexion bd.
             * 2 -> se realizo la eliminacion.
             */            
            SqlConnection con = Conexion();
            SqlCommand query = new SqlCommand("delete from usuario Where idUsuario='" + codigo + "';", con);
            try
            {
                con.Open();
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

        public int InsertarE(string nombre, string direccion, string telefono, string correo, int tipoE)
        {
            /* Estados, este metodo se utiliza para registrar la empresa en la plataforma.
             * 0 -> no se realizo la eliminacion.
             * 1 -> error de conexion bd.
             * 2 -> se inserto la informacion con exito.
             */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO empresa(nombre,direccion,telefono,email,codTipoE) values ('"+nombre+"','"+direccion+"','" +telefono+"','"+correo+"','"+tipoE+"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info,connection);
                query.ExecuteNonQuery();
                connection.Close();
                estado = 2;
            }
            catch (Exception)
            {
                connection.Close();
                estado = 1;
            }
            return estado;
        }

        public int InsertarT(string nombre, string direccion, string telefono, string correo, int user)
        {
            /* Estados, este metodo se utiliza para registrar sitios turisticos en la plataforma.
             * 0 -> no se realizo la eliminacion.
             * 1 -> error de conexion bd.
             * 2 -> se inserto la informacion con exito.
             */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO SitioT(nombre,direccion,telefono,email,codUsuario) values ('" + nombre + "','" + direccion + "','" + telefono + "','" + correo + "','"+user+ "');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                estado = 2;
            }
            catch (Exception)
            {
                connection.Close();
                estado = 1;
            }
            return estado;
        }

        public DataTable BuscarE(string empresa)
        {
            SqlConnection con = Conexion();
            string info = "SELECT idEmpresa,codTipoE FROM empresa WHERE nombre='"+empresa+"';";
            try
            {
                con.Open();
                SqlDataAdapter query = new SqlDataAdapter(info,con);
                DataTable tabla = new DataTable();
                query.Fill(tabla);
                con.Close();
                return tabla;
            }
            catch (Exception)
            {
                con.Close();
                return null;
            }            
        }        

        public DataTable BuscarS(string sitio)
        {
            SqlConnection connect = Conexion();
            string datos = "SELECT idSitioT,nombre FROM SitioT WHERE nombre='"+sitio+"';";
            try
            {
                connect.Open();
                SqlDataAdapter query = new SqlDataAdapter(datos,connect);
                DataTable tabla = new DataTable();
                query.Fill(tabla);
                connect.Close();
                return tabla;
            }
            catch (Exception)
            {
                connect.Close();
                return null;
            }
        }

        public int Detalle1(int codR, int codS)
        {
            /* Estados, este metodo se utiliza para registrar en la entidad detalle.
             * 0 -> no se inserto los datos.
             * 1 -> error de conexion bd.
             * 2 -> se inserto la informacion con exito.
             */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO detalle(codRegion,codSitio) values ('" + codR + "','" + codS + "');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                estado = 2;
            }
            catch (Exception)
            {
                connection.Close();
                estado = 1;
            }
            return estado;
        }

        public int Detalle(int codR, int codE)
        {
            /* Estados, este metodo se utiliza para registrar en la entidad detalle.
             * 0 -> no se inserto los datos.
             * 1 -> error de conexion bd.
             * 2 -> se inserto la informacion con exito.
             */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO detalle(codRegion,codEmpresa) values ('" + codR + "','"  + codE + "');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                estado = 2;
            }
            catch (Exception)
            {
                connection.Close();
                estado = 1;
            }
            return estado;
        }

        public DataTable ObtenerEmpresa(string nombre)
        {
            SqlConnection con = Conexion();
            string info = "SELECT nombre,direccion,telefono,email FROM empresa WHERE nombre='" + nombre + "';";
            try
            {
                con.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, con);
                DataTable tabla = new DataTable();
                query.Fill(tabla);
                con.Close();
                return tabla;
            }
            catch (Exception)
            {
                con.Close();
                return null;
            }
        }

        public DataTable ObtenerSitio(string nombre)
        {
            SqlConnection con = Conexion();
            string info = "SELECT idSitioT,nombre,direccion,telefono,email FROM SitioT WHERE nombre='" + nombre + "';";
            try
            {
                con.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, con);
                DataTable tabla = new DataTable();
                query.Fill(tabla);
                con.Close();
                return tabla;
            }
            catch (Exception)
            {
                con.Close();
                return null;
            }
        }

        public int ActualizarS(string codigo,string nombre, string direccion, string tel, string email)
        {/* Estados, este metodo se utiliza para registrar sitios turisticos en la plataforma.
             * 0 -> no se realizo la actualizacion del sitio turistico.
             * 1 -> error de conexion bd.
             * 2 -> se inserto la informacion con exito.
             */
            SqlConnection connection = Conexion();
            string info = "UPDATE SitioT SET nombre='"+nombre+"', direccion='"+direccion+"', telefono='"+tel+"', email='"+email+"' WHERE idSitioT='"+codigo+"';";
            try
            {                
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                estado = 2;
            }
            catch (Exception)
            {
                connection.Close();
                estado = 1;
            }
            return estado;
        }

        public int EliminarS(string codigo)
        {/* * 0 -> no se realizo la eliminación del sitio turistico.
                * 1 -> error de conexion bd.
                * 2 -> se inserto la informacion con exito.
                */
            SqlConnection connection = Conexion();
            SqlCommand query = new SqlCommand("delete from SitioT Where iSitioT='" + codigo + "';", connection);
            try
            {
                connection.Open();                
                query.ExecuteNonQuery();
                connection.Close();
                estado = 2;
            }
            catch (Exception)
            {
                connection.Close();
                estado = 1;
            }
            return estado;

        }

        public DataTable AgenteE(string tecnico, string empresa)
        {            
            SqlConnection connection = Conexion();
            string info = "select usuario.idUsuario, usuario.nombre, usuario.telefono, usuario.codTipoU, empresa.nombre,empresa.telefono,empresa.direccion, empresa.email, empresa.codTipoE"+
                "from usuario full outer join Empresa on usuario.idUsuario='"+tecnico+ "' and empresa.idEmpresa = '"+empresa+"' where usuario.idUsuario='"+tecnico+ "' and empresa.idEmpresa = '"+empresa+ "';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public int InsertarEva(string estado, string codU, string codE, string codC, string codS, string codM)
        {
            int bandera = 0;
            /*0->no se realizo la eliminación del sitio turistico.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO Evaluacion(estado,codUsuario,codEmpresa,codCatalogo,codServicio,codMuseo) VALUES('"+estado+"','"+codU+"','"+codE+"','"+codC+"','"+
               codS+"','"+codM+"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public int Recibo(string estado, string cod, string cod1, string cod2)
        {
            int bandera = 0;
            /*0->no se realizo la eliminación del sitio turistico.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO recibo(estado_pago,codDetS,codDetC,codDetMuse) VALUES ('"+estado+"','"+cod+"','"+cod1+"','"+cod2+"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public int Recorrido(string nombre, string fechaI, string fechaF)
        {
            int bandera = 0;
            /*0->no se realizo la eliminación del sitio turistico.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO recorrido(nombre,fecha_in,fecha_fin) VALUES ('"+nombre+"','"+fechaI+"','"+fechaF+"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public DataTable Revision(string empresa)
        {
            SqlConnection connection = Conexion();
            string info = "select empresa.idEmpresa,empresa.nombre,empresa.telefono,empresa.email,recibo.idRecibo from empresa  full outer join recibo on Recibo.codDetC = empresa.codTipoE or " +
                "recibo.codDetS = empresa.codTipoE or recibo.codMuse = empresa.codTipoE  where empresa.nombre = '"+empresa+"' and recibo.estado_pago = 'inscrito';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public int ActualizarEva(string nombre, string codE)
        {
            int bandera = 0;
            /*0->no se realizo la eliminación del sitio turistico.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "UPDATE evaluacion SET estado='"+nombre+"' WHERE codEmpresa='"+codE+"';";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public int Servicio(string name, string codigo)
        {
            int bandera = 0;
            /*0->no se inserto los servicios de la empresa.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO servicio(nombre,codEmpresa) VALUES('"+name+"','"+codigo+"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public int Catalogo(string name,string codigo)
        {
            int bandera = 0;
            /*0->no se inserto los catalogos de la empresa.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO catalogo(nombre,codEmpresa) VALUES('" + name + "','" + codigo + "');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public int Museo(string hora,string horaF,string precio,string codigo)
        {
            int bandera = 0;
            /*0->no se inserto los datos del museo.
             * 1->error de conexion bd.
             * 2->se inserto la informacion con exito.
           */
            SqlConnection connection = Conexion();
            string info = "INSERT INTO museo(hora,hora_fin,precio, codEmpresa) VALUES('"+hora+"','"+horaF+"','"+precio+"','"+codigo +"');";
            try
            {
                connection.Open();
                SqlCommand query = new SqlCommand(info, connection);
                query.ExecuteNonQuery();
                connection.Close();
                bandera = 2;
            }
            catch (Exception)
            {
                connection.Close();
                bandera = 1;
            }
            return bandera;
        }

        public DataTable ConsultaS(string codigo)
        {
            SqlConnection connection = Conexion();
            string valor = "SELECT nombre from servicio WHERE codEmpresa='"+codigo+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(valor, connection);
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

        public DataTable ConsultaC(string codigo)
        {
            SqlConnection connection = Conexion();
            string valor = "SELECT nombre FROM catalogo WHERE codEmpresa='"+codigo+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(valor, connection);
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

        public DataTable ConsultaM(string codigo)
        {
            SqlConnection connection = Conexion();
            string valor = "SELECT hora,hora_fin,precio FROM museo WHERE codEmpresa='"+codigo+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(valor, connection);
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

        public DataTable BuscarU(string usuario)
        {
            SqlConnection connection = Conexion();
            string valor = "SELECT idUsuario,codTipoU FROM usuario WHERE nombre = '"+usuario+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(valor, connection);
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

        public DataTable BusquedaJoin(string region, string sitio)
        {
            SqlConnection connection = Conexion();
            string info = "select sitioT.nombre,sitiot.idSitioT from SitioT full outer join detalle on"+
                "detalle.codSitio = sitiot.idSitioT where detalle.codRegion ='"+region+ "' and sitiot.nombre ='"+sitio+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public DataTable BusquedaJoin1(string region, string empresa)
        {
            SqlConnection connection = Conexion();
            string info = "select empresa.nombre,empresa.idEmpresa from empresa full outer join detalle on detalle.codEmpresa = empresa.idEmpresa" +
                "where detalle.codRegion ='"+region+ "' and empresa.nombre ='"+empresa+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public DataTable Region(string nombre)
        {
            SqlConnection connection = Conexion();
            string info = "select idRegion from region where nombre='"+nombre+"';";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public DataTable Informacion()
        {
            SqlConnection connection = Conexion();
            string info = "SELECT gusta,favorito,comentario,codS,codE FROM informacion;";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public DataTable Compartir()
        {
            SqlConnection connection = Conexion();
            string info = "SELECT comentario,usuario,codS,codE FROM compartir;";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public DataTable Notificacion()
        {
            SqlConnection connection = Conexion();
            string info = "SELECT comentario,usuario,codS,codE FROM notificacion;";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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

        public DataTable Noticia()
        {
            SqlConnection connection = Conexion();
            string info = "select comentario,imagen,titulo,codS,codE from noticia;";
            try
            {
                connection.Open();
                SqlDataAdapter query = new SqlDataAdapter(info, connection);
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
    }
}