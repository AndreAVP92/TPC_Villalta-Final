using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reclamo
    {
        public Int32 IdReclamo { get; set; }
        public Contrato Contrato { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaReclamo { get; set; }
        public bool Estado { get; set; }
    }
}
