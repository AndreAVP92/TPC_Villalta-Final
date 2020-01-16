using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        public Int32 IdCliente { get; set; }
        public Usuario UsuarioC { get; set; }
        public Decimal ValoracionC { get; set; }
        public bool Estado { get; set; }
    }
}
