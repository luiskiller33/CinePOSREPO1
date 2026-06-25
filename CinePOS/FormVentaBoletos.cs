using CapaData;
using CapaEntidad;
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
    public partial class FormVentaBoletos : Form
    {
        private int _idFuncion;
        private Funcion objFuncion;
        private int CantBltAdto = 0;
        private int CantBltEspecial = 0;
        private int CantBltGeneral = 0;
        private List<Asiento> asientosDB = new List<Asiento>();
        private List<Asiento> asientosSeleccionados = new List<Asiento>();

        public FormVentaBoletos(int idFuncion)
        {
            InitializeComponent();

            _idFuncion = idFuncion;
        }

        private void FormVentaBoletos_Load(object sender, EventArgs e)
        {
            PnlBltEdad.Parent = this;
            PnlBltGeneral.Parent = this;
            PnlSeatMap.Parent = this;
            PnlSeatMap.Location = PnlBltEdad.Location;
            PnlSeatMap.Visible = false;
            VentaTipoSala();

        }
        private void VentaTipoSala()
        {
            FuncionNegocio negocio = new FuncionNegocio();
            objFuncion = negocio.ObtenerDetalle(_idFuncion);

            if (objFuncion != null && objFuncion.TipoSala != null)
            {
                AsientoNegocio asientoNegocio = new AsientoNegocio();
                List<Asiento> totalAsientos = asientoNegocio.obtenerAsientos(objFuncion.ID_Sala);

                CD_Boletos cdBoletos = new CD_Boletos();
                List<int> asientosYaVendidos = cdBoletos.ListarAsientosOcupados(_idFuncion);

                PreciosNegocio preciosNegocio = new PreciosNegocio();
                PreciosPorTipo preciosSala = preciosNegocio.ObtenerPrecios(objFuncion.TipoSala);

                int lugaresDisponibles = totalAsientos.Count - asientosYaVendidos.Count;

                UpDownAdto.Maximum = lugaresDisponibles;
                UpDownEspecial.Maximum = lugaresDisponibles;
                UpDownGeneral.Maximum = lugaresDisponibles;

                if (objFuncion != null)
                {
                    string tipoSala = objFuncion.TipoSala != null ? objFuncion.TipoSala.Trim().ToUpper() : "";

                    if (tipoSala == "3D" || tipoSala == "4DX")
                    {
                        PnlBltEdad.Visible = false;
                        PnlBltGeneral.Visible = true;
                        if (preciosSala != null)
                        {
                            LblPrecioGeneral.Text = $"{preciosSala.PrecioEspecial:C2} c/u";
                        }
                    }
                    else
                    {
                        PnlBltGeneral.Visible = false;
                        PnlBltEdad.Visible = true;
                        if (preciosSala != null)
                        {
                            LblPrecioAdto.Text = $"{preciosSala.PrecioAdulto:C2} c/u";
                            LblPrecioEspecial.Text = $"{preciosSala.PrecioNino:C2} c/u";
                        }
                    }
                    //NO AGARRA EL TIPO DE SALA. CORREGIR 
                    //NO MUESTRA EL TEXTO DE PRECIOS. CORREGIR
                }
            }
        }
        private void CargarMapaVenta()
        {
            FlpSeatMap.Controls.Clear();
            asientosSeleccionados.Clear();

            AsientoNegocio negocio = new AsientoNegocio();
            asientosDB = negocio.obtenerAsientos(objFuncion.ID_Sala);

            CD_Boletos cdBoletos = new CD_Boletos();
            List<int> asientosOcupados = cdBoletos.ListarAsientosOcupados(_idFuncion);

            string filaActual = "";

            foreach (Asiento a in asientosDB)
            {
                if (filaActual != "" && a.Fila != filaActual)
                {
                    if (FlpSeatMap.Controls.Count > 0)
                    {
                        FlpSeatMap.SetFlowBreak(FlpSeatMap.Controls[FlpSeatMap.Controls.Count - 1], true);
                    }
                }
                Button btn = new Button();
                int tamanoBoton = (FlpSeatMap.Width > 800) ? 45 : 40;

                btn.Text = a.Fila + a.Numero;

                btn.Size = new Size(tamanoBoton, tamanoBoton);
                btn.Tag = a;

                if (a.Estado == 1)
                {
                    btn.BackColor = Color.Gray;
                    btn.Enabled = false;
                }
                else if (asientosOcupados.Contains(a.ID_Asiento))
                {
                    btn.Enabled = false;
                }
                else
                {
                    btn.BackColor = Color.Lime;
                    btn.Click += new EventHandler(BtnAsiento_Click);
                }
                FlpSeatMap.Controls.Add(btn);
                filaActual = a.Fila;
            }

        }
        private void BtnAsiento_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            Asiento asientoInfo = (Asiento)btnClick.Tag;

            if (btnClick.BackColor == Color.Gold)
            {
                btnClick.BackColor = Color.Lime;
                asientosSeleccionados.Remove(asientoInfo);
            }
            else
            {
                int totalBoletosPagados = CantBltAdto + CantBltEspecial + CantBltGeneral;

                if (asientosSeleccionados.Count >= totalBoletosPagados)
                {
                    MessageBox.Show($"Ya seleccionó los {totalBoletosPagados} asientos indicados.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                btnClick.BackColor = Color.Gold;
                asientosSeleccionados.Add(asientoInfo);
            }
        }

        private void BtnNextEdad_Click(object sender, EventArgs e)
        {
            PnlSeatMap.Visible = true;
            PnlSeatMap.BringToFront();
            CantBltAdto = Convert.ToInt32(UpDownAdto.Value);
            CantBltEspecial = Convert.ToInt32(UpDownEspecial.Value);
            int BltTotal = CantBltAdto + CantBltEspecial;
            if (BltTotal == 0)
            {
                MessageBox.Show("No puedes continuar si la cantidad de boletos es 0. Por favor, introduce cuántas entradas deseas vender.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarMapaVenta();
        }

        private void BtnNextGeneral_Click(object sender, EventArgs e)
        {
            PnlSeatMap.Visible = true;
            PnlSeatMap.BringToFront();
            CantBltGeneral = Convert.ToInt32(UpDownGeneral.Value);
            if (CantBltGeneral == 0)
            {
                MessageBox.Show("No puedes continuar si la cantidad de boletos es 0. Por favor, introduce cuántas entradas deseas vender.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarMapaVenta();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            asientosSeleccionados.Clear();

            PnlSeatMap.Visible = false;
            PreciosNegocio preciosNegocio = new PreciosNegocio();
            PreciosPorTipo preciosSala = preciosNegocio.ObtenerPrecios(objFuncion.TipoSala);

            if (objFuncion != null)
            {
                string tipoSala = objFuncion.TipoSala != null ? objFuncion.TipoSala.Trim().ToUpper() : "";

                if (tipoSala == "3D" || tipoSala == "4DX")
                {
                    PnlBltEdad.Visible = false;
                    PnlBltGeneral.Visible = true;
                    PnlBltGeneral.BringToFront();
                    if (preciosSala != null)
                    {
                        LblPrecioGeneral.Text = $"{preciosSala.PrecioEspecial:C2} c/u";
                    }
                }
                else
                {
                    PnlBltGeneral.Visible = false;
                    PnlBltEdad.Visible = true;
                    PnlBltEdad.BringToFront();
                    if (preciosSala != null)
                    {
                        LblPrecioAdto.Text = $"{preciosSala.PrecioAdulto:C2} c/u";
                        LblPrecioEspecial.Text = $"{preciosSala.PrecioNino:C2} c/u";
                    }
                }
                //NO AGARRA EL TIPO DE SALA. FALTA CORREGIR 
                //NO MUESTRA EL TEXTO DE PRECIOS. CORREGIR
            }
        }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            int totalBoletosPagados = CantBltAdto + CantBltEspecial + CantBltGeneral;

            if (asientosSeleccionados.Count != totalBoletosPagados)
            {
                MessageBox.Show($"Por favor, seleccione exactamente {totalBoletosPagados} asientos en el mapa antes de continuar.",
                                "Asientos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}