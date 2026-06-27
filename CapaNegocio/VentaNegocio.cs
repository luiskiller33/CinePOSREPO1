using CapaData;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class VentaNegocio
    {
        public bool Registrar(Venta objVenta, List<Asiento> asientos, out int idVenta)
        {
            return new CD_Venta().Registrar(objVenta, asientos, out idVenta);
        }
    }
}
