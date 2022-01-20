using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasIEI.Modelos
{
    class Biblioteca
    {
        public String nombre { get; set; }
        public int telefono { get; set; }
        public String email { get; set; }
        public String direccion { get; set; }
        public int codigoPostal { get; set; }
        public float longitud { get; set; }
        public float latitud { get; set; }
        public String tipo { get; set; }
        public String descripcion { get; set; }
    }
}
