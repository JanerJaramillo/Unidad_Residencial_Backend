using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeModelo
{
    public class Propietario
    {
        private int idpropietario;
        private int cedula;
        private string nombre;
        private string telefono;
        private string email;
        private string contrasena;

        public int Idpropietario { get => idpropietario; set => idpropietario = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
