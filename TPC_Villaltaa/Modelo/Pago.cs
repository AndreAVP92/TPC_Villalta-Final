using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pago
    {
        public Int32 IdPago { get; set; }
        public string DescripcionP { get; set; } //TARJETA, EFECTIVO, PAYPAL, LO QUE SEA
        public bool Estado { get; set; }
    }
}
