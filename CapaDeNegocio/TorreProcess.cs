using System;
using System.Collections.Generic;
using CapaDeDatos;
using CapaDeModelo;
using MySql.Data.MySqlClient;

namespace CapaDeNegocio
{
    public class TorreProcess
    {
        public static string SQL;
        
        public static List<Torre> ListarTorres()
        {
            try
            {
                List<Torre> torre = new List<Torre>();
                Conexion.obtenerConexion();
                SQL = "select * from torre";
                MySqlDataReader req = Conexion.Query(SQL);
                while (req.Read())
                {
                    Torre ob = new Torre();
                    ob.Idtorre = req.GetInt32("idtorre");
                    ob.Codigo = req.GetInt32("codigo");
                    ob.Nombre = req["nombre"].ToString();
                    ob.Cantidad_apto = req.GetInt32("cantidad_apto");
                    torre.Add(ob);
                }
                req.Close();
                return torre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Torre BuscarTorre(int codigo)
        {
            try
            {
                Conexion.obtenerConexion();
                SQL = "Select * from torre where codigo =" + codigo + "";
                MySqlDataReader req = Conexion.Query(SQL);
                Torre ob = null;
                if (req.Read())
                {
                    ob = new Torre();
                    ob.Idtorre = req.GetInt32("idtorre");
                    ob.Codigo = req.GetInt32("codigo");
                    ob.Nombre = req["nombre"].ToString();
                    ob.Cantidad_apto = req.GetInt32("cantidad_apto");
                }
                req.Close();
                return ob;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Torre BuscarIDTorre(int idtorre)
        {
            try
            {
                Conexion.obtenerConexion();
                SQL = "Select * from torre where idtorre =" + idtorre + "";
                MySqlDataReader req = Conexion.Query(SQL);
                Torre ob = null;
                if (req.Read())
                {
                    ob = new Torre();
                    ob.Idtorre = req.GetInt32("idtorre");
                    ob.Codigo = req.GetInt32("codigo");
                    ob.Nombre = req["nombre"].ToString();
                    ob.Cantidad_apto = req.GetInt32("cantidad_apto");
                }
                req.Close();
                return ob;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int ValidarTorre(int codigo)
        {
            try
            {
                int idTorre = 0;
                Conexion.obtenerConexion();
                SQL = "select idtorre from torre where codigo=" + codigo + "";
                MySqlDataReader req = Conexion.Query(SQL);
                if (req.Read())
                {
                    idTorre = req.GetInt32("idtorre");
                }
                else
                {
                    Console.WriteLine("Codigo no existe");
                }
                req.Close();
                return idTorre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
