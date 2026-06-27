using System;
using System.Collections.Generic;
using System.Data.SQLite;
using CapaEntidad;

namespace CapaData
{
    public class CD_Venta
    {
        private string cadena = new Conexion().CrearConexion().ConnectionString;

        public bool Registrar(Venta objVenta, List<Asiento> asientosSeleccionados, out int idVentaGenerado)
        {
            idVentaGenerado = 0;
            bool respuesta = false;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                using (SQLiteTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // aqui insertamos la venra
                        string queryVenta = @"INSERT INTO Ventas (ID_Usuario, FechaVenta, Total) 
                                              VALUES (@idUsuario, @fecha, @total); 
                                              SELECT last_insert_rowid();";

                        using (SQLiteCommand cmd = new SQLiteCommand(queryVenta, con))
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", objVenta.ID_Usuario);
                            cmd.Parameters.AddWithValue("@fecha", objVenta.FechaVenta);
                            cmd.Parameters.AddWithValue("@total", objVenta.Total);
                            idVentaGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        //recorremos cada uno de los asientos con el precio proveniente del obejto creado en FormVentas con el calculo hecho 
                        foreach (Asiento a in asientosSeleccionados)
                        {
                            // Insertar Boleto
                            string queryBoleto = @"INSERT INTO Boletos (ID_Funcion, ID_Asiento, Estado, Precio) 
                                                   VALUES (@idFunc, @idAs, 1, @precio); 
                                                   SELECT last_insert_rowid();";

                            int idBoletoGenerado = 0;
                            using (SQLiteCommand cmdB = new SQLiteCommand(queryBoleto, con))
                            {
                                cmdB.Parameters.AddWithValue("@idFunc", objVenta.ID_Funcion);
                                cmdB.Parameters.AddWithValue("@idAs", a.ID_Asiento);
                                cmdB.Parameters.AddWithValue("@precio", a.PrecioAplicado);
                                idBoletoGenerado = Convert.ToInt32(cmdB.ExecuteScalar());
                            }

                            // insertar el detalle de la venta aqui esto es por cada asiento-boleto= cada detalle venta
                            string queryDetalle = @"INSERT INTO Detalle_Venta (ID_Venta, ID_Boleto, PrecioUnitario) 
                                                    VALUES (@idV, @idB, @precio)";
                            using (SQLiteCommand cmdD = new SQLiteCommand(queryDetalle, con))
                            {
                                cmdD.Parameters.AddWithValue("@idV", idVentaGenerado);
                                cmdD.Parameters.AddWithValue("@idB", idBoletoGenerado);
                                cmdD.Parameters.AddWithValue("@precio", a.PrecioAplicado);
                                cmdD.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        respuesta = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex; // excepcion por si algun insert en alguna de las 3 tablas falla 
                    }
                }
            }
            return respuesta;
        }
    }
}