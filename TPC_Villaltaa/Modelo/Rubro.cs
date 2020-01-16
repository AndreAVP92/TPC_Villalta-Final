using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Rubro
    {
        public Int32 IdRubro { get; set; }
        public string DescripcionR { get; set; }    
        public bool Estado { get; set; }

        public override string ToString()
        {
            return DescripcionR;
        }
    }
}
