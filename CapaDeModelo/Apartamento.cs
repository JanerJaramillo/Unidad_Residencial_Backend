using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeModelo
{
    public class Apartamento
    {
        private int idapartamento;
        private string codigo;
        private int numero_apto;
        private int piso;
        private int cant_habitaciones;
        private int precio_venta;
        private int precio_alquiler;
        private int idtorre;
        private int codigoTorre;
        private string nombreTorre;

        public int Idapartamento { get => idapartamento; set => idapartamento = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int Numero_apto { get => numero_apto; set => numero_apto = value; }
        public int Piso { get => piso; set => piso = value; }
        public int Cant_habitaciones { get => cant_habitaciones; set => cant_habitaciones = value; }
        public int Precio_venta { get => precio_venta; set => precio_venta = value; }
        public int Precio_alquiler { get => precio_alquiler; set => precio_alquiler = value; }
        public int Idtorre { get => idtorre; set => idtorre = value; }
        public int CodigoTorre { get => codigoTorre; set => codigoTorre = value; }
        public string NombreTorre { get => nombreTorre; set => nombreTorre = value; }
    }
}
