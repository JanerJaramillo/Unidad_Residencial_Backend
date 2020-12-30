using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeModelo;
using MySql.Data.MySqlClient;

namespace CapaDeNegocio
{
    public class ApartamentoProcess
    {
        public static string SQL;

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

        public static int ValidarApartamento(string codigo)
        {
            try
            {
                int idApartamento = 0;
                Conexion.obtenerConexion();
                SQL = "select idapartamento from apartamento where codigo='" + codigo + "'";
                MySqlDataReader req = Conexion.Query(SQL);
                if (req.Read())
                {
                    idApartamento = req.GetInt32("idapartamento");
                }
                else
                {
                    Console.WriteLine("Codigo no existe");
                }
                req.Close();
                return idApartamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Apartamento> ListarApartamentos()
        {
            try
            {
                List<Apartamento> apartamento = new List<Apartamento>();
                Conexion.obtenerConexion();
                SQL = "select a.idapartamento, a.codigo, a.numero_apto, a.piso, a.cant_habitaciones, a.precio_venta, a.precio_alquiler, " +
                    "t.codigo as codigoTorre, t.nombre from torre t inner join apartamento a on t.idtorre=a.idtorre";
                MySqlDataReader req = Conexion.Query(SQL);
                while (req.Read())
                {
                    Apartamento ob = new Apartamento();
                    ob.Idapartamento = req.GetInt32("idapartamento");
                    ob.Codigo = req["codigo"].ToString();
                    ob.Numero_apto = req.GetInt32("numero_apto");
                    ob.Piso = req.GetInt32("piso");
                    ob.Cant_habitaciones = req.GetInt32("cant_habitaciones");
                    ob.Precio_venta = req.GetInt32("precio_venta");
                    ob.Precio_alquiler = req.GetInt32("precio_alquiler");
                    ob.CodigoTorre = req.GetInt32("codigoTorre");
                    ob.NombreTorre = req["nombre"].ToString();
                    apartamento.Add(ob);
                }
                req.Close();
                return apartamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Apartamento BuscarApartamento(string codigo)
        {
            try
            {
                Conexion.obtenerConexion();
                SQL = "select a.idapartamento, a.codigo, a.numero_apto, a.piso, a.cant_habitaciones, a.precio_venta, a.precio_alquiler, " +
                    "t.codigo as codigoTorre from torre t inner join apartamento a on t.idtorre=a.idtorre " +
                    "where a.codigo ='" + codigo + "'";
                MySqlDataReader req = Conexion.Query(SQL);
                Apartamento ob = null;
                if (req.Read())
                {
                    ob = new Apartamento();
                    ob.Idapartamento = req.GetInt32("idapartamento");
                    ob.Codigo = req["codigo"].ToString();
                    ob.Numero_apto = req.GetInt32("numero_apto");
                    ob.Piso = req.GetInt32("piso");
                    ob.Cant_habitaciones = req.GetInt32("cant_habitaciones");
                    ob.Precio_venta = req.GetInt32("precio_venta");
                    ob.Precio_alquiler = req.GetInt32("precio_alquiler");
                    ob.CodigoTorre = req.GetInt32("codigoTorre");
                }
                req.Close();
                return ob;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Apartamento BuscarIDApartamento(int idapartamento)
        {
            try
            {
                Conexion.obtenerConexion();
                SQL = "select a.idapartamento, a.codigo, a.numero_apto, a.piso, a.cant_habitaciones, a.precio_venta, a.precio_alquiler, " +
                    "t.codigo as codigoTorre from torre t inner join apartamento a on t.idtorre=a.idtorre " +
                    "where idapartamento=" + idapartamento + "";
                MySqlDataReader req = Conexion.Query(SQL);
                Apartamento ob = null;
                if (req.Read())
                {
                    ob = new Apartamento();
                    ob.Idapartamento = req.GetInt32("idapartamento");
                    ob.Codigo = req["codigo"].ToString();
                    ob.Numero_apto = req.GetInt32("numero_apto");
                    ob.Piso = req.GetInt32("piso");
                    ob.Cant_habitaciones = req.GetInt32("cant_habitaciones");
                    ob.Precio_venta = req.GetInt32("precio_venta");
                    ob.Precio_alquiler = req.GetInt32("precio_alquiler");
                    ob.CodigoTorre = req.GetInt32("codigoTorre");
                }
                req.Close();
                return ob;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Apartamento BuscarNumeroApto(int numero, int codigo)
        {
            try
            {
                Conexion.obtenerConexion();
                SQL = "Select a.idtorre, a.numero_apto from torre t inner join apartamento a on t.idtorre=a.idtorre " +
                    "where a.numero_apto =" + numero + " and t.codigo=" + codigo + "";
                MySqlDataReader req = Conexion.Query(SQL);
                Apartamento ob = null;
                if (req.Read())
                {
                    ob = new Apartamento();
                    ob.Idtorre = req.GetInt32("idtorre");
                    ob.Numero_apto = req.GetInt32("numero_apto");
                }
                req.Close();
                return ob;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
