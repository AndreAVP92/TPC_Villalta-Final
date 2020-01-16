using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ImagenPortfolio
    {
        public Int32 IdImagen { get; set; }
        public string UrlImagen_IP { get; set; }
        public string Descripcion_IP { get; set; }
        public bool Estado { get; set; }
    }
}
