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
    public partial class FormVentaBoletos2 : Form
    {
        private readonly int _idFuncion;

        private Funcion objFuncion;
        private List<Asiento> asientosSeleccionados = new List<Asiento>();
        
        private List<Asiento> asientosDB = new List<Asiento>();
        private List<int> asientosOcupadosIds = new List<int>();

        private int countDisponibles = 0;
        private int countOcupados = 0;
        private int countDesactivados = 0;

        private int CantBlts = 0;
        private int CantBltAdto = 0;
        private int CantBltNiño = 0;
        private int CantBltGeneral = 0;


        public FormVentaBoletos2(int idfuncion) // el constructor este va a recibir el ID de la funcion
        {
            InitializeComponent();

            _idFuncion = idfuncion; // cuando presiono el btn de la de la funcion filtrada el constructor recibe el id
        }
        private void CargarDatosIniciales()
        {
            FuncionNegocio fNeg = new FuncionNegocio();
            objFuncion = fNeg.ObtenerDetalle(_idFuncion);

            AsientoNegocio aNeg = new AsientoNegocio();
            var todosLosAsientos = aNeg.obtenerAsientos(objFuncion.ID_Sala);

           
            asientosOcupadosIds = new CD_Boletos().ListarAsientosOcupados(_idFuncion);

            countDesactivados = todosLosAsientos.Count(a => a.Estado == 1);

            countOcupados = asientosOcupadosIds.Count;

            countDisponibles = todosLosAsientos.Count - countDesactivados - countOcupados;

            NumDisponibles.Text = Convert.ToString(countDisponibles);
            NumOcupados.Value = countOcupados;
            NumDesactivados.Value = countDesactivados;
        }

        public void ConfigInterfaz()
        {
            FuncionNegocio fneg = new FuncionNegocio();
            objFuncion = fneg.ObtenerDetalle(_idFuncion);

            if (objFuncion == null) return;

            // correccion  en CapaNegocio que ejecuta un Select en la tabla Salas para obetner el toipo  de sala
            SalaNegocio sNeg = new SalaNegocio();
            string tipoReal = sNeg.ObtenerTipoSala(objFuncion.ID_Sala); // guardamos el tipo de sala detectadop en un string tiporeal

            // messagebox para detecart rapidamente que funciona 
            MessageBox.Show($"Detectando: Sala={objFuncion.NombreSala}, ID_Sala={objFuncion.ID_Sala}, TipoEncontrado={tipoReal}");

            PreciosNegocio pNeg = new PreciosNegocio();
            var precios = pNeg.ObtenerPrecios(tipoReal); // ahora si buscamos precios por tipo segun lo que encuientre nuestro metodod SalaNegocio

            if (precios == null)
            {
                MessageBox.Show($"No se encontraron precios en la BD para el tipo: '{tipoReal}'");
                return;
            }

            bool esEspecial = precios.PrecioEspecial > 0;

            PnlEdad.Visible = !esEspecial;
            PnlGeneral.Visible = esEspecial;

            if (esEspecial)
            {
                lblPrecioGeneral.Text = $"${precios.PrecioEspecial:N2} c/u";
            }
            else
            {
                lblPrecioAdulto.Text = $"${precios.PrecioAdulto:N2} (Adulto)";

                lblPrecioNiño.Text = $"${precios.PrecioNino:N2} (Niño)";
            }
        }
        private void BtnAsiento_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Asiento asiento = (Asiento)btn.Tag;
            CantBltAdto = Convert.ToInt32(UpDownAdto.Value);
            CantBltNiño = Convert.ToInt32(UpDownNiño.Value);
            CantBltGeneral = Convert.ToInt32(UpDownGeneral.Value);
            CantBlts = CantBltAdto + CantBltNiño + CantBltGeneral;

            // Pintamos de colores los botones
            if (btn.BackColor == Color.Gold)
            {
                btn.BackColor = Color.Lime; // lima si es deseleccionado 
                asientosSeleccionados.Remove(asiento);
            }
            else 
            {
                if (asientosSeleccionados.Count >= CantBlts) // verificar que no se seleccionen más asientos de los que se van a pagar
                {
                    MessageBox.Show($"Ya seleccionó los {CantBlts} asientos indicados.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                btn.BackColor = Color.Gold; // Color seleccion
                asientosSeleccionados.Add(asiento); 
            }
            // aqui puede ir la logica para actualizar el totañ segun la catnidadd seleccionadad de asients
        }
        private void GenerarMapa()
        {
            flyasientos.Controls.Clear();

            asientosSeleccionados.Clear();

            
            AsientoNegocio aNeg = new AsientoNegocio();

            asientosDB = aNeg.obtenerAsientos(objFuncion.ID_Sala);

            List<int> ocupadosIds = new CD_Boletos().ListarAsientosOcupados(_idFuncion);

            string filaActual = "";

            foreach (Asiento a in asientosDB) // creamos cada uno de los botonoes
            {

                if (filaActual != "" && a.Fila != filaActual)
                {

                    // para esto buscamos el utimo control creado y le damos un salto 
                    if (flyasientos.Controls.Count > 0)
                    {
                        flyasientos.SetFlowBreak(flyasientos.Controls[flyasientos.Controls.Count - 1], true);
                    }
                }
                Button btn = new Button();
                btn.Size = new Size(40, 40);
                btn.Text = $"{a.Fila}{a.Numero}";
                btn.Tag = a;

                //Aplicamos estados
                if (a.Estado == 1) // desactivadp 
                {
                    btn.BackColor = Color.DimGray;
                    btn.Enabled = false;
                }
                else if (ocupadosIds.Contains(a.ID_Asiento)) //ocuapdo
                {
                    btn.BackColor = Color.Yellow;
                    btn.Enabled = false;
                }
                else // dissponibles
                {
                    btn.BackColor = Color.Lime;
                    btn.Click += BtnAsiento_Click;
                }

                flyasientos.Controls.Add(btn);
                flyasientos.Controls.Add(btn);
                filaActual = a.Fila;
            }
        }

        private void FormVentaBoletos2_Load(object sender, EventArgs e)
        {
            
            ConfigInterfaz(); // configuramos la visibilidad de los paneles segun el tipo de sala 

            // 2. Obtener la lista de asientos de la BD (esencial antes de generar el mapa)
            AsientoNegocio aNeg = new AsientoNegocio(); // Obtener la lista de asinetos de la base de datos prevvia a generar le mapa 

            asientosDB = aNeg.obtenerAsientos(objFuncion.ID_Sala);
           
            GenerarMapa();
            
            CargarDatosIniciales();

        }

        private void BtnLimpiarAsientos_Click(object sender, EventArgs e)
        {
            asientosSeleccionados.Clear();

            GenerarMapa();
        }

        private void BtnLimpiarCant_Click(object sender, EventArgs e)
        {
            UpDownAdto.Value = 0;
            UpDownNiño.Value = 0;
            UpDownGeneral.Value = 0;
            asientosSeleccionados.Clear();
            GenerarMapa();
        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {
            if (asientosSeleccionados.Count != CantBlts)
            {
                MessageBox.Show($"Por favor, seleccione exactamente {CantBlts} asientos en el mapa antes de continuar.",
                                "Asientos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
