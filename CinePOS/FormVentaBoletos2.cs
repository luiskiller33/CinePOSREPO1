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

        private decimal PrecioTotalAdto = 0;
        private decimal PrecioTotalNiño = 0;
        private decimal PrecioTotalGeneral = 0;
        private decimal PrecioTotal = 0;



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

            LblNumDisponibles.Text = Convert.ToString(countDisponibles);
            LblNumOcupados.Text = Convert.ToString(countOcupados);
            LblNumDeshabilitados.Text = Convert.ToString(countDesactivados);

            UpDownGeneral.Maximum = countDisponibles;
            UpDownAdto.Maximum = countDisponibles;
            UpDownNiño.Maximum = countDisponibles;

            LblTotal.Text = $"{PrecioTotal:C2}";
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
                lblPrecioGeneral.Text = $"{precios.PrecioEspecial:C2} c/u";
            }
            else
            {
                lblPrecioAdulto.Text = $"{precios.PrecioAdulto:C2} (Adulto)";

                lblPrecioNiño.Text = $"{precios.PrecioNino:C2} (Niño)";
            }
        }

        private void ActualizarContadoresTiempoReal()
        {
            int ocupados = 0;
            int disponibles = 0;
            int desactivados = 0;

            foreach(Control c in flyasientos.Controls)
            {
                if(c is Button btn)
                {
                    if (btn.BackColor == Color.Red) ocupados++;
                    else if (btn.BackColor == Color.Gold) ocupados++; // Los seleccionados cuentan como ocupados momentáneamente
                    else if (btn.BackColor == Color.DimGray) desactivados++;
                    else if (btn.BackColor == Color.Lime) disponibles++;
                }
            }

            LblNumDisponibles.Text = disponibles.ToString();
            LblNumOcupados.Text = ocupados.ToString();
            LblNumDeshabilitados.Text = desactivados.ToString();


        }
        private void BtnAsiento_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Asiento asiento = (Asiento)btn.Tag;

            // 1. Recalculamos cuántos boletos puede comprar el usuario
            CantBlts = (int)(UpDownAdto.Value + UpDownNiño.Value + UpDownGeneral.Value);

            if (CantBlts == 0)
            {
                MessageBox.Show("Primero indique cuántos boletos desea comprar.");
                return;
            }

            // 2. Lógica de Selección
            if (btn.BackColor == Color.Lime) // Seleccionando
            {
                if (asientosSeleccionados.Count >= CantBlts)
                {
                    MessageBox.Show($"Solo puede seleccionar {CantBlts} asientos.");
                    return;
                }
                btn.BackColor = Color.Gold;
                asientosSeleccionados.Add(asiento);
            }
            else if (btn.BackColor == Color.Gold) // Deseleccionando
            {
                btn.BackColor = Color.Lime;
                asientosSeleccionados.Remove(asiento);
            }

            ActualizarContadoresTiempoReal();

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
                if (a.Estado == 1) // desactivado 
                {
                    btn.BackColor = Color.DimGray;
                    btn.Enabled = false;
                }
                else if (ocupadosIds.Contains(a.ID_Asiento)) //ocuapdo
                {
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;
                }
                else // dissponibles
                {
                    btn.BackColor = Color.Lime;
                    btn.Click += BtnAsiento_Click;
                }

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
            ActualizarContadoresTiempoReal();
            CargarDatosIniciales();

        }

        private void BtnLimpiarAsientos_Click(object sender, EventArgs e)
        {
            // 1. Limpiamos la lista lógica
            asientosSeleccionados.Clear();

            // 2. En lugar de recrear todo el mapa (que es lento), recorremos lo que ya está en pantalla
            foreach (Control c in flyasientos.Controls)
            {
                if (c is Button btn && btn.BackColor == Color.Gold)
                {
                    btn.BackColor = Color.Lime; // Solo devolvemos los seleccionados a su color original
                }
            }

            // 3. Actualizamos los contadores visuales inmediatamente
            ActualizarContadoresTiempoReal();

            // 4. Aseguramos que el total se mantenga o resetee si es necesario
            // Si al limpiar asientos también quieres limpiar las cantidades, llama a ActualizarTodo();
            ActualizarTodo();
        }

        private void BtnLimpiarCant_Click(object sender, EventArgs e)
        {
            UpDownAdto.Value = 0;
            UpDownNiño.Value = 0;
            UpDownGeneral.Value = 0;
            ActualizarContadoresTiempoReal();
            asientosSeleccionados.Clear();
            CargarDatosIniciales();
            GenerarMapa();
        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {
            // seleccionar almenos un boleto
            if (CantBlts <= 0)
            {
                MessageBox.Show("favor de seleccionar al menos un boleto para comprar.", "cantidad invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (asientosSeleccionados.Count != CantBlts) // aqui validamos que la cantidad de asientos seleccionados coincida con la de los numericupdonw

            { 
                MessageBox.Show($"Selecciona exactamente: {CantBlts} asientos en el mapa.", "asientos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ignar precios a cada asiento (para que CD_Venta sepa qué valor insertar)
            // hacemos esto poruqe la clase asiento no guarda el precio tal cual, si no que se calcula en ese instante 
            
            FuncionNegocio fNeg = new FuncionNegocio();
            objFuncion = fNeg.ObtenerDetalle(_idFuncion);
            SalaNegocio sNeg = new SalaNegocio();
            string tipoReal = sNeg.ObtenerTipoSala(objFuncion.ID_Sala);
            PreciosNegocio pNeg = new PreciosNegocio();
            var precios = pNeg.ObtenerPrecios(tipoReal);

            // asignacion de precios a la lista antes de enviarlos a la DB 
            int index = 0;
            for (int i = 0; i < CantBltAdto; i++) asientosSeleccionados[index++].PrecioAplicado = precios.PrecioAdulto;
            for (int i = 0; i < CantBltNiño; i++) asientosSeleccionados[index++].PrecioAplicado = precios.PrecioNino;
            for (int i = 0; i < CantBltGeneral; i++) asientosSeleccionados[index++].PrecioAplicado = precios.PrecioEspecial;

            
            Venta nuevaVenta = new Venta // usamos nuestro objeto venta
            {
                ID_Usuario = 1, // seteamos el ID del usuario a 1 en este caso el mio pero la idea es que este se agarre directamente segun el usuario uqe ingresa 
                ID_Funcion = _idFuncion,
                FechaVenta = DateTime.Now, // seteamos la fecha a la de ese momento exacto 
                Total = PrecioTotal

            };

            //ahora si usamos la capanegocio para registrar los datos en las tablas Boletos, Ventas, DetalleVenta
            VentaNegocio vNeg = new VentaNegocio();
            int idGenerado = 0;
            if (vNeg.Registrar(nuevaVenta, asientosSeleccionados, out idGenerado))
            {
                MessageBox.Show($"VENTA REALIZADA. FOLIO: {idGenerado}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Hubo error al realizar venta, intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTodo()
        {
            // objetos para obtener precios frescos 
            SalaNegocio sNeg = new SalaNegocio();
            string tipoReal = sNeg.ObtenerTipoSala(objFuncion.ID_Sala);

            PreciosNegocio pNeg = new PreciosNegocio();

            var precios = pNeg.ObtenerPrecios(tipoReal);

            if (precios == null)
            {
                LblTotal.Text = "Total: $0.00";
                return;
            }
            if (CantBlts == 0) PrecioTotal = 0;

            
            // ahora calculamos los totales
            CantBltAdto = (int)UpDownAdto.Value;
            CantBltNiño = (int)UpDownNiño.Value;
            CantBltGeneral = (int)UpDownGeneral.Value;
            CantBlts = CantBltAdto + CantBltNiño + CantBltGeneral;

            PrecioTotal = (CantBltAdto * precios.PrecioAdulto) +
                          (CantBltNiño * precios.PrecioNino) +
                          (CantBltGeneral * precios.PrecioEspecial);

            //actualizamos la interfaz grafica

            LblTotal.Text = $"{PrecioTotal:C2}";


             
        }

        private void UpDownAdto_ValueChanged(object sender, EventArgs e) => ActualizarTodo();

        private void UpDownNiño_ValueChanged(object sender, EventArgs e) => ActualizarTodo();

        private void UpDownGeneral_ValueChanged(object sender, EventArgs e) => ActualizarTodo();


    }
}
