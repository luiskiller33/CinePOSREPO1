using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaData
{
    public class CD_Ticket
    {
        Conexion conexion = new Conexion();
        public DataTable ObtenerDetalleTicket(int idVenta)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = @"SELECT 
                            V.ID_Venta, 
                            V.FechaVenta, 
                            V.Total AS TotalVenta, 
                            P.Titulo AS NombrePelicula, 
                            S.Nombre AS NombreSala, 
                            A.Fila, 
                            A.Numero AS AsientoNumero, 
                            B.Precio AS PrecioBoleto
                         FROM Ventas V
                         INNER JOIN Detalle_Venta DV ON V.ID_Venta = DV.ID_Venta
                         INNER JOIN Boletos B ON DV.ID_Boleto = B.ID_Boleto
                         INNER JOIN Asientos A ON B.ID_Asiento = A.ID_Asiento
                         INNER JOIN Funciones F ON B.ID_Funcion = F.ID_Funcion
                         INNER JOIN Peliculas P ON F.ID_Pelicula = P.ID_Pelicula
                         INNER JOIN Salas S ON F.ID_Sala = S.ID_Sala
                         WHERE V.ID_Venta = @idVenta";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    try
                    {
                        con.Open();
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception) { dt = null; }
                }
            }
            return dt;
        }


    }





    
}
