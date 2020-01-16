using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Contrato
    {
        public Int32 IdContrato { get; set; }
        public Cliente Cliente { get; set; }
        public Profesional Profesional { get; set; }
        public Pago Pago { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public Decimal Importe { get; set; }
        public DateTime FechaContrato { get; set; }
        public EstadoContrato EstadoContrato { get; set; }
        public bool Estado { get; set; }   
    }
}
