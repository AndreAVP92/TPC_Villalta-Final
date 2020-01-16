using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Administrador
    {
        public Int16 IdAdmin { get; set; }
        public Usuario UsuarioA { get; set; }
        public bool Estado { get; set; }
    }
}
