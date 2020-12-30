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
    [Route("Apartamento")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ApartamentoController : ApiController
    {
        public static string SQL;

        [Route("Apartamento/InsertarApartamento")]
        [HttpPost]
        public void InsertarApartamento([FromBody] Apartamento apto, int codigoTorre)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("insert into apartamento(codigo,numero_apto,piso," +
                    "cant_habitaciones,precio_venta,precio_alquiler,idtorre) " +
                "values('{0}',{1},{2},{3},{4},{5},{6})", apto.Codigo, apto.Numero_apto, apto.Piso, apto.Cant_habitaciones, 
                apto.Precio_venta, apto.Precio_alquiler, ApartamentoProcess.ValidarTorre(codigoTorre)), Conexion.obtenerConexion());
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Apartamento/ActualizarApartamento")]
        [HttpPost]
        public void ActualizarApartamento([FromBody] Apartamento apartamento, int codigoTorre, string codigoApartamento)
        {
            try
            {
                SQL = "update apartamento set numero_apto=" + apartamento.Numero_apto + ",piso=" + apartamento.Piso + ", " +
                    "cant_habitaciones=" + apartamento.Cant_habitaciones + ", precio_venta=" + apartamento.Precio_venta + ", " +
                    "precio_alquiler=" + apartamento.Precio_alquiler + ", idtorre=" + ApartamentoProcess.ValidarTorre(codigoTorre) + 
                    " Where idapartamento =" + ApartamentoProcess.ValidarApartamento(codigoApartamento) + "";
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

        [Route("Apartamento/EliminarApartamento")]
        [HttpDelete]
        public void EliminarApartamento(int id)
        {
            try
            {
                SQL = "delete from apartamento Where idapartamento=" + id + "";
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

        [Route("Apartamento/ListarApartamentos")]
        [HttpGet]
        public List<Apartamento> ListarApartamentos()
        {
            List<Apartamento> apartamento = ApartamentoProcess.ListarApartamentos();
            return apartamento;
        }

        [Route("Apartamento/BuscarApartamento")]
        [HttpGet]
        public Apartamento BuscarApartamento(string codigo)
        {
            Apartamento apartamento = ApartamentoProcess.BuscarApartamento(codigo);
            return apartamento;
        }

        [Route("Apartamento/BuscarIDApartamento")]
        [HttpGet]
        public Apartamento BuscarIDApartamento(int idapartamento)
        {
            Apartamento apartamento = ApartamentoProcess.BuscarIDApartamento(idapartamento);
            return apartamento;
        }

        [Route("Apartamento/BuscarNumeroApto")]
        [HttpGet]
        public Apartamento BuscarNumeroApto(int numero, int codigo)
        {
            Apartamento apartamento = ApartamentoProcess.BuscarNumeroApto(numero, codigo);
            return apartamento;
        }
    }
}
