using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaData;
using CapaEntidad;

namespace CapaNegocio
{
    public class TicketNegocio
    {
        private CD_Ticket GenTicket =  new CD_Ticket();
        public DataTable ObtenerDetalleTicket(int idventa)
        {
            return GenTicket.ObtenerDetalleTicket(idventa);

        }

    }
}
