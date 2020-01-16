using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PortFolio
    {
        public Int32 IdPortFolio { get; set; }
        public Profesional Profesional { get; set; }
        public ImagenPortfolio ImagenPortFolio { get; set; }
        public bool Estado { get; set; }
    }
}
