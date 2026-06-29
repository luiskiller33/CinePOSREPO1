using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaData
{
    public class CD_RegistroVentas
    {
        private Conexion conexion = new Conexion();
        public DataTable ObtenerVentasPorRango(string fechaInicio, string fechaFin)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = @"SELECT V.ID_Venta, V.FechaVenta, V.Total, 
                                P.Titulo AS NombrePelicula, 
                                S.Nombre AS NombreSala
                         FROM Ventas V
                         INNER JOIN Detalle_Venta DV ON V.ID_Venta = DV.ID_Venta
                         INNER JOIN Boletos B ON DV.ID_Boleto = B.ID_Boleto
                         INNER JOIN Funciones F ON B.ID_Funcion = F.ID_Funcion
                         INNER JOIN Peliculas P ON F.ID_Pelicula = P.ID_Pelicula
                         INNER JOIN Salas S ON F.ID_Sala = S.ID_Sala
                         WHERE date(V.FechaVenta) BETWEEN date(@fInicio) AND date(@fFin)
                         GROUP BY V.ID_Venta";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fFin", fechaFin);
                    con.Open();
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }


        public DataTable ObtenerRankingPelis(string fechaInicio, string fechaFin)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                // aqui consultamos el precio de cada boleto vendido de cada pelicula 
                string query = @"SELECT 
                            P.Titulo AS Pelicula, 
                            COUNT(DV.ID_Detalle) AS BoletosVendidos, 
                            SUM(DV.PrecioUnitario) AS IngresoTotal
                         FROM Peliculas P
                         INNER JOIN Funciones F ON P.ID_Pelicula = F.ID_Pelicula
                         INNER JOIN Boletos B ON F.ID_Funcion = B.ID_Funcion
                         INNER JOIN Detalle_Venta DV ON B.ID_Boleto = DV.ID_Boleto
                         INNER JOIN Ventas V ON DV.ID_Venta = V.ID_Venta
                         WHERE date(V.FechaVenta) BETWEEN date(@fInicio) AND date(@fFin)
                         GROUP BY P.Titulo
                         ORDER BY IngresoTotal DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fFin", fechaFin);

                    con.Open();
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}
