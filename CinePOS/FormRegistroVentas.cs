using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinePOS
{
    public partial class FormRegistroVentas : Form
    {
        RegVentasNegocio RegVentNeg = new RegVentasNegocio();
        public FormRegistroVentas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void CargarRegVentasRango()
        {
            if (dtpFechaIni.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.");
                return;
            }

            // capturamos los valores de la fecha en ambos dtp
            string fInicio = dtpFechaIni.Value.ToString("yyyy-MM-dd");
            string fFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

            // obtenemos los datos de la db
            DataTable dt = RegVentNeg.ObtenerRegistrosVentasFechaRango(fInicio, fFin);

            //actualizam dgv
            dgvVentas.DataSource = dt;
            dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";

            decimal totalPeriodo = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalPeriodo += Convert.ToDecimal(row["Total"]);
            }
            if (dt.Rows.Count == 0)
            {
                lblTotalCajaxDia.Text = "Total del periodo: $0.00 (Sin ventas)";
            }
            else
            {
                lblTotalCajaxDia.Text = $"Total del periodo: {totalPeriodo:C2}";
            }

        }

        private void CargarRankingPelis()
        {
            string fInicio = dtpFechaIni.Value.ToString("yyyy-MM-dd");
            string fFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");

            DataTable dtRanking = RegVentNeg.ObtenerRankingPelis(fInicio, fFin);
            RankingPelis.DataSource = dtRanking;

            // Formato de moneda para el ranking
            RankingPelis.Columns["IngresoTotal"].DefaultCellStyle.Format = "C2";
            RankingPelis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            CargarRegVentasRango();
            CargarRankingPelis();

        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CargarRegVentasRango();
            CargarRankingPelis();
        }

        private void FormRegistroVentas_Load(object sender, EventArgs e)
        {
            CargarRegVentasRango();
            CargarRankingPelis();
        }

        private void btnAplicarRangosFecha_Click(object sender, EventArgs e)
        {
            CargarRegVentasRango();
            CargarRankingPelis();
        }

        private void buscarID_TextChanged(object sender, EventArgs e)
        {
            if (dgvVentas.DataSource is DataTable dt)
            {
                // Si el buscador está vacío, quitamos el filtro
                if (string.IsNullOrEmpty(buscarID.Text))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Filtramos por la columna ID_Venta
                    // Usamos 'Convert(ID_Venta, 'System.String')' porque el ID es numérico
                    dt.DefaultView.RowFilter = string.Format("Convert(ID_Venta, 'System.String') LIKE '%{0}%'", buscarID.Text);
                }
            }
        }
    }
}
