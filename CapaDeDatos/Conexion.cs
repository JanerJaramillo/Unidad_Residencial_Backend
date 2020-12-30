using System;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class Conexion
    {
        public static MySqlConnection con;
        public static String host;
        public static String database;
        public static String user;
        public static String password;

        public static MySqlConnection obtenerConexion()
        {
            host = "127.0.0.1";
            database = "conjuntoresidencial";
            user = "root";
            password = "";
            con = new MySqlConnection("server=" + host + "; database=" + database + ";Uid=" + user + "; pwd=" + password + ";");
            con.Open();
            return con;
        }

        public static Boolean Execute(String SQL)
        {
            Boolean estado = true;
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la consulta " + e.Message);
                estado = false;
            }
            return estado;
        }

        public static MySqlDataReader Query(String sql)
        {
            MySqlDataReader query = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                query = cmd.ExecuteReader();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta " + ex.Message);
            }
            return query;
        }
    }
}
