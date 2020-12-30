using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeModelo
{
    public class Torre
    {
        private int idtorre;
        private int codigo;
        private string nombre;
        private int cantidad_apto;

        public int Idtorre { get => idtorre; set => idtorre = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad_apto { get => cantidad_apto; set => cantidad_apto = value; }
    }
}
