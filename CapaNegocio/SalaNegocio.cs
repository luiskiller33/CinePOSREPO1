using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaData;
using CapaEntidad;

namespace CapaNegocio
{
    public class SalaNegocio
    {
        SalaDatos datos = new SalaDatos();

        public void RegistrarSalaCompleta(string nombre, string tipo, int filas, int columnas)
        {
            int idSalaGen = datos.InsertarSala(nombre, tipo);

            for(int i = 1; i<= filas; i++)
            {
                string nombfila = ((char)('A' + i - 1)).ToString(); // codigo ASII para avanzar de letra

                for (int j= 1; j<=columnas; j++)
                {

                 
                    // del codigo ascii vamos sumando el indice del caracter en una unidad

                    // a-b-c-d etc...


                    datos.InsertarAsiento(idSalaGen, nombfila, j);
                }

            }



        }



        public List<Sala> Listar()
        {
            return datos.Listar();
        }

        public string ObtenerTipoSala(int idSala)
        {
            // desde este metodo llama a capa datos para hacer un select en la tabla sala

            SalaDatos cdSalas = new SalaDatos();

            return cdSalas.ObtenerTipo(idSala);
        }

    }
}
