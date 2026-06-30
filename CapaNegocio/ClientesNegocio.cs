using CapaData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaData;
namespace CapaNegocio
{
    public class ClientesNegocio
    {
        CD_Clientes clientes = new CD_Clientes();// creamos el obejto de cd_clientes
        public DataTable ObtenerCliente(string tarjeta)
        {
            
            return clientes.BuscarClientePorTarjeta(tarjeta);
        }

        public bool SumarPuntos(int idCliente, int puntos)
        {
            return clientes.SumarPuntos(idCliente, puntos);
        }

        public bool RegistrarNuevaTarjeta(string numeroTarjeta, string nombre)
        {
            return clientes.RegistrarNuevaTarjeta(numeroTarjeta, nombre);
        }


        public bool CanjearPuntos(int idclientem , int puntosCajear)
        {
            return clientes.CanjearPuntos(idclientem, puntosCajear);

        }
    }
}
