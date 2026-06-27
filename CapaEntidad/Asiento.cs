using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Asiento
    {
        public int ID_Asiento { get; set; }
        public int ID_Sala { get; set; }

        public string Fila { get; set; }

        public int Numero { get; set; }

        public int Estado { get; set; }

        public decimal PrecioAplicado { get; set; } // esta propiedad se usa en FormVentas y lo asigna (no se obtiene de la tabla Asientos de la DB)




    }

    public class AsientoEstado : Asiento // este metodo no se usa todavia(no considerar en la logica del codigo) 

    {
        public bool EstaOcupado { get; set; }
    }
}
