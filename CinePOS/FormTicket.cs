using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinePOS
{
    public partial class FormTicket : Form
    {
        private int IDVENTA;
        public FormTicket(int idVenta)
        {
            InitializeComponent();


            IDVENTA = idVenta;


        }

        private void CargarTicket(int idventa)
        {
            TicketNegocio Tneg = new TicketNegocio();
            DataTable dt = Tneg.ObtenerDetalleTicket(idventa);

            if (dt == null)
            {
                MessageBox.Show("Error: El DataTable es nulo.");
            }
            else if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"No se encontraron registros para el folio: {idventa}");
            }
            else
            {
                txtTicket.Text = FormatearTicket(dt);


                txtTicket.Font = new Font("Courier New", 10, FontStyle.Regular); // fuente espaciada

               
                txtTicket.SelectAll();
                txtTicket.SelectionAlignment = HorizontalAlignment.Left;
                txtTicket.DeselectAll();
            }






        }

        private string FormatearTicket(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            // Encabezado
            sb.AppendLine("********************************");
            sb.AppendLine("            CINE POS             ");
            sb.AppendLine("********************************");
            sb.AppendLine($"Folio: {dt.Rows[0]["ID_Venta"]}");
            sb.AppendLine($"Fecha: {dt.Rows[0]["FechaVenta"]}");
            sb.AppendLine("--------------------------------");
            sb.AppendLine($"Pelicula: {dt.Rows[0]["NombrePelicula"]}");
            sb.AppendLine($"Sala:     {dt.Rows[0]["NombreSala"]}");
            sb.AppendLine("--------------------------------");
            sb.AppendLine("ASIENTOS:");

            // Formato de columnas: Fila/Asiento a la izquierda, Precio a la derecha
            // {0,-10} significa: alinea a la izquierda ocupando 10 espacios
            // {1,15:C2} significa: alinea a la derecha ocupando 15 espacios y formatea como moneda
            foreach (DataRow row in dt.Rows)
            {
                string asiento = $"{row["Fila"]}{row["AsientoNumero"]}";
                decimal precio = Convert.ToDecimal(row["PrecioBoleto"]);

                sb.AppendLine(string.Format("{0,-15} {1,15:C2}", $"Asiento {asiento}", precio));
            }

            sb.AppendLine("--------------------------------");
            sb.AppendLine(string.Format("{0,-15} {1,15:C2}", "TOTAL:", dt.Rows[0]["TotalVenta"]));
            sb.AppendLine("********************************");
            sb.AppendLine("    ¡GRACIAS POR SU COMPRA!     ");

            return sb.ToString();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Font fuenteTicket = new Font("Courier New", 10);

            // se dibuja el texto del richbox en la hoja
            // empezamos la impresuon e nlas coordenadas x,y ambas seteadas en 10
            e.Graphics.DrawString(txtTicket.Text, fuenteTicket, Brushes.Black, 10, 10);
        }



        private void FormTicket_Load(object sender, EventArgs e)
        {
            CargarTicket(IDVENTA);



        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            // Configuramos el evento que "dibuja" el contenido en la hoja
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            try
            {
                // Esto abre el diálogo de selección de impresora (Windows estándar)
                PrintDialog pDialog = new PrintDialog();
                pDialog.Document = pd;

                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print(); // ¡Aquí se envía a la impresora!
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }
    }
}
