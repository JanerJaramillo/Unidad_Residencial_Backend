using System;
using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Web.Http.Cors;
using CapaDeDatos;
using CapaDeModelo;
using CapaDeNegocio;

namespace CapaDePresentacion.Controllers
{
    [Route("Torre")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class TorreController : ApiController
    {
        public static string SQL;

        [Route("Torre/InsertarTorre")]
        [HttpPost]
        public void InsertarTorre([FromBody] Torre torre)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("insert into torre(codigo,nombre,cantidad_apto) " +
                "values({0},'{1}',{2})", torre.Codigo, torre.Nombre, torre.Cantidad_apto), Conexion.obtenerConexion());
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Torre/ActualizarTorre")]
        [HttpPost]
        public void ActualizarTorre([FromBody] Torre torre, int codigo)
        {
            try
            {
                SQL = "update torre set nombre='" + torre.Nombre + "',cantidad_apto='" + torre.Cantidad_apto + 
                    "' Where idtorre =" + TorreProcess.ValidarTorre(codigo) + "";
                if (Conexion.Execute(SQL))
                {
                    Console.WriteLine("Registro Actualizado");
                }
                else
                {
                    Console.WriteLine("Error al Actualizar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Torre/EliminarTorre")]
        [HttpDelete]
        public void EliminarTorre(int id)
        {
            try
            {
                SQL = "delete from torre Where idtorre=" + id + "";
                if (Conexion.Execute(SQL))
                {
                    Console.WriteLine("Registro Eliminado");
                }
                else
                {
                    Console.WriteLine("Error al Eliminar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Torre/ListarTorres")]
        [HttpGet]
        public List<Torre> ListarTorres()
        {
            List<Torre> torre = TorreProcess.ListarTorres();
            return torre;
        }

        [Route("Torre/BuscarTorre")]
        [HttpGet]
        public Torre BuscarTorre(int codigo)
        {
            Torre torre = TorreProcess.BuscarTorre(codigo);
            return torre;
        }

        [Route("Torre/BuscarIDTorre")]
        [HttpGet]
        public Torre BuscarIDTorre(int idtorre)
        {
            Torre torre = TorreProcess.BuscarIDTorre(idtorre);
            return torre;
        }
    }
}
