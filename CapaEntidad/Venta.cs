using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int ID_Venta { get; set; }
        public int ID_Usuario { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }

        public int ID_Funcion { get; set; } // nos va a servir para saber a que funcion pertenece la venta.

        public int ID_Cliente { get; set; }

    }
}
