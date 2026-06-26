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
    public partial class FormAdminAsientos : Form
    {
        public FormAdminAsientos()
        {
            InitializeComponent();
        }
        private void FormAdminAsientos_Resize(object sender, EventArgs e)
        {
            CentrarMapa();
        }

        private void CentrarMapa()
        {
            // calcular las coordenadas x,y para que el mapa de los asientos quede en medio
            int x = (panel2.Width - flpMapaAsientos.Width) / 2;

            int y = (panel2.Height - flpMapaAsientos.Height) / 2;

            
            if (x > 0) flpMapaAsientos.Left = x;

            if (y > 0) flpMapaAsientos.Top = y;
        }

        private void CargarMapaBloqueo(int idSala)
        {
            flpMapaAsientos.Controls.Clear();

            AsientoNegocio objNegocio = new AsientoNegocio();

            List<Asiento> lista = objNegocio.obtenerAsientos(idSala);

            string filaActual = ""; // este string vacio se ira actualizando para avisar del salto de linea 

            foreach (Asiento a in lista)
            {
                // si cambiamos la letra fila forzamos el salto a la siguiente fila
                if (filaActual != "" && a.Fila != filaActual)
                {
                    
                    // para esto buscamos el utimo control creado y le damos un salto 
                    if (flpMapaAsientos.Controls.Count > 0)
                    {
                        flpMapaAsientos.SetFlowBreak(flpMapaAsientos.Controls[flpMapaAsientos.Controls.Count - 1], true);
                    }
                }

                Button btn = new Button();
                int tamanoBoton = (flpMapaAsientos.Width > 800) ? 40 : 30;

                btn.Text = a.Fila + a.Numero;

                btn.Size = new Size(tamanoBoton, tamanoBoton);
                btn.Tag = a;

                // para los colores segun el estado 
                btn.BackColor = (a.Estado == 1) ? Color.Gray : Color.Lime;

                btn.Click += (s, e) => {
                    Asiento asientoSeleccionado = (Asiento)((Button)s).Tag;
                    int nuevoEstado = (asientoSeleccionado.Estado == 1) ? 0 : 1;

                    if (objNegocio.ModificarEstados(asientoSeleccionado.ID_Asiento, nuevoEstado))
                    {
                        CargarMapaBloqueo(idSala); // refrescamos
                    }
                };

                flpMapaAsientos.Controls.Add(btn);
                filaActual = a.Fila; // actualizamos la filaactual para seguir haciendo los saltos de linea

                CentrarMapa();
            }
        }

        private void cmbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbSala.SelectedItem == null) return;

            
            Sala salaSeleccionada = (Sala)cmbSala.SelectedItem;

            
            int idSalaSeleccionada = salaSeleccionada.ID_Sala;

            
            CargarMapaBloqueo(idSalaSeleccionada);


        }

        private void FormAdminAsientos_Load(object sender, EventArgs e)
        {
            SalaNegocio negocio = new SalaNegocio();



            cmbSala.DataSource = negocio.Listar();




            cmbSala.DisplayMember = "Nombre"; // queremos uqe muestre el nombre de la sala no el id
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
