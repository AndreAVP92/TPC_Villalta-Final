using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public Int32 IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int Telefono { get; set; }
        public Foto Foto { get; set; }
        public char Rol { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public string EstadoConexion { get; set; }
        public DateTime FechaRegistro { get; set; }

    
        public bool Estado { get; set; }
    }
}
