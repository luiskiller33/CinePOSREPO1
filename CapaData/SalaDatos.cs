using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite; 
using CapaEntidad;

namespace CapaData
{
    public class SalaDatos
    {
        Conexion conexion = new Conexion();

        public int InsertarSala(string nombre, string tipo)
        {
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                
                string query = "INSERT INTO Salas (Nombre, Tipo) VALUES (@nombre, @tipo); SELECT last_insert_rowid();";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@tipo", tipo);

                con.Open();
                // ExecuteScalar me devuelve un unico valor
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void InsertarAsiento(int idSala, string fila, int numero)
        {
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = "INSERT INTO Asientos (ID_Sala, Fila, Numero) VALUES (@id, @fila, @num)";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idSala);
                cmd.Parameters.AddWithValue("@fila", fila);
                cmd.Parameters.AddWithValue("@num", numero);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarSalas()
        {
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                string query = @"
            SELECT S.ID_Sala, S.Nombre, S.Tipo, 
                   COUNT(DISTINCT A.Fila) AS TotalFilas, 
                   MAX(A.Numero) AS AsientosPorFila
            FROM Salas S
            LEFT JOIN Asientos A ON S.ID_Sala = A.ID_Sala
            GROUP BY S.ID_Sala, S.Nombre, S.Tipo";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);

                DataTable dt = new DataTable();


                da.Fill(dt);


                return dt;
            }

        }

        public void EliminarSala(int idSala)
        {
            using (SQLiteConnection con = conexion.CrearConexion())
            {
                con.Open();

                
                using (SQLiteCommand pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
                {
                    pragma.ExecuteNonQuery();
                }

                
                string query = "DELETE FROM Salas WHERE ID_Sala = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idSala);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Sala> Listar()
        {
            List<Sala> lista = new List<Sala>();
            using (SQLiteConnection con = new Conexion().CrearConexion())
            {
                string query = @"SELECT S.ID_Sala, S.Nombre, S.Tipo
                         FROM Salas S";

                SQLiteCommand cmd = new SQLiteCommand(query, con);
                con.Open();

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Sala()
                        {


                            ID_Sala = Convert.ToInt32(dr["ID_Sala"]),

                            Nombre = dr["Nombre"].ToString(),
                            Tipo = dr["Tipo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string ObtenerTipo(int idSala) // para FormVentas
        {
            string tipo = "";
            using (SQLiteConnection con = new Conexion().CrearConexion())
            {
                con.Open();
                string query = "SELECT Tipo FROM Salas WHERE ID_Sala = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idSala);
                    object resultado = cmd.ExecuteScalar();


                    tipo = resultado != null ? resultado.ToString() : "2D";
                }
            }
            return tipo;
        }











    }
}