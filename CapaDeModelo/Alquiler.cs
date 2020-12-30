using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeModelo
{
    public class Alquiler
    {
        private int idalquiler;
        private int referencia;
        private string fecha_inicio;
        private string fecha_fin;
        private int idapartamento;
        private int idpropietario;

        public int Idalquiler { get => idalquiler; set => idalquiler = value; }
        public int Referencia { get => referencia; set => referencia = value; }
        public string Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        public string Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
        public int Idapartamento { get => idapartamento; set => idapartamento = value; }
        public int Idpropietario { get => idpropietario; set => idpropietario = value; }
    }
}
