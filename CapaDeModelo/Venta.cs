using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeModelo
{
    public class Venta
    {
        private int idventa;
        private int referencia;
        private string fecha_venta;
        private int idapartamento;
        private int idpropietario;

        public int Idventa { get => idventa; set => idventa = value; }
        public int Referencia { get => referencia; set => referencia = value; }
        public string Fecha_venta { get => fecha_venta; set => fecha_venta = value; }
        public int Idapartamento { get => idapartamento; set => idapartamento = value; }
        public int Idpropietario { get => idpropietario; set => idpropietario = value; }
    }
}
