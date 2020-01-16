using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Profesional
    {
        public Int32 IdProfesional { get; set; }
        public Int64 CuitCuil { get; set; }
        public Decimal ValoracionP { get; set; }
        public Usuario UsuarioP { get; set; }
        public Rubro Rubro { get; set; } //hacer un list
        public bool Estado { get; set; }

        public override string ToString()
        {
            return UsuarioP.NombreUsuario;
        }
    }
}
