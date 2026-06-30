using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaData
{
    public class CD_Clientes

    {
        Conexion conexion = new Conexion();
        public DataTable BuscarClientePorTarjeta(string numeroTarjeta)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = "SELECT ID_Cliente, Nombre, PuntosAcumulados FROM Clientes WHERE TarjetaLealtad = @tarjeta";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tarjeta", numeroTarjeta);
                    con.Open();
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }

        public bool SumarPuntos(int idCliente, int puntos)
        {
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = "UPDATE Clientes SET PuntosAcumulados = PuntosAcumulados + @puntos WHERE ID_Cliente = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@puntos", puntos);
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RegistrarNuevaTarjeta(string numeroTarjeta, string nombre)
        {
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = "INSERT INTO Clientes (Nombre, TarjetaLealtad, PuntosAcumulados) VALUES (@nombre, @tarjeta, 0)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@tarjeta", numeroTarjeta);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CanjearPuntos(int idCliente, int PuntosCanjear)
        {
            using(SQLiteConnection con = conexion.CrearConexion())
            {
                string query = "UPDATE Clientes SET PuntosAcumulados = PuntosAcumulados - @puntos WHERE ID_Cliente = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@puntos", PuntosCanjear);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}
