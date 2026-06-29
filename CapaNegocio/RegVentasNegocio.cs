using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaData;
namespace CapaNegocio
{
    public class RegVentasNegocio
    {
        CD_RegistroVentas ventasReg = new CD_RegistroVentas();

        public DataTable ObtenerRegistrosVentasFechaRango(string fecha,string fecha2)
        {
            return ventasReg.ObtenerVentasPorRango(fecha,fecha2);
        } 

        public DataTable ObtenerRankingPelis(string fech1, string fech2)
        {
            return ventasReg.ObtenerRankingPelis(fech1, fech2);

        }

    }
}
