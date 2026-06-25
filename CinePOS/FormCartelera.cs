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
    public partial class FormCartelera : Form
    {
        private CarteleraNegocio negocio = new CarteleraNegocio();
        public FormCartelera()
        {
            InitializeComponent();
        }

        private void FormCartelera_Load(object sender, EventArgs e)
        {
            

            DataTable peliculas = negocio.ObtenerCartelera();
            

            
            listBox1.DataSource = peliculas;

            listBox1.DisplayMember = "Titulo";

            listBox1.ValueMember = "ID_Pelicula";


        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null) return;

            //aqui ya esa el id cada que cambiamos de pelicula en el listbox
            DataRowView row = (DataRowView)listBox1.SelectedItem;
            int idPelicula = Convert.ToInt32(row["ID_Pelicula"]);

            CargarDetallesPelicula(idPelicula);
            GenerarBotonesFecha();

            
            CargarHorariosFiltrados(DateTime.Today, idPelicula);// pasamos el id como parametro para hacer los inerjoin






        }
        private void CargarDetallesPelicula(int idPelicula)
        {
            // buscamos la primera función de esta película para obtener su detalle
            
            var funciones = negocio.ObtenerHorarios(idPelicula);

            if (funciones.Count > 0)
            {
                // usamos el id de la primera función para traer el detalle de la peli
                Funcion info = negocio.ObtenerDetallesPeicula(funciones[0].ID_Funcion);

                // asiganmoscontroles
                lblTitulo.Text = info.NombrePelicula;
                lblClasificacion.Text = "Clasificación: " + info.Clasificacion;
                lblSinopsis.Text = info.Sinopsis;
                lblDuracion.Text = "Duración: " + info.Duracion + " min";
                posterPeli.ImageLocation = info.RutaPoster;
                
            }
        }
        private void CargarHorariosFiltrados(DateTime fecha, int idPelicula)
        {
            flpHorarios.Controls.Clear();
            var todas = negocio.ObtenerHorarios(idPelicula);
            string fechaBuscada = fecha.ToString("yyyy-MM-dd");

            // filtramos funciones del día seleccionado
            var filtradas = todas.Where(f => f.FechaHora.ToString("yyyy-MM-dd") == fechaBuscada).ToList();

            // agrupamos por tipo de sala VIP ya se a 2d,3d,3dx
            var funcionesPorTipo = filtradas.GroupBy(f => f.TipoSala);

            foreach (var grupoTipo in funcionesPorTipo)
            {
                // encabezado del tipo sala
                Label lblTipo = new Label();
                lblTipo.Text = "- " + grupoTipo.Key.ToUpper() + " -";


                lblTipo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTipo.AutoSize = true;

                lblTipo.Margin = new Padding(0, 15, 0, 5);
                flpHorarios.Controls.Add(lblTipo);

                //  las funciones de ese tipo por NombreSala las agrupamos
                var salasEnEsteTipo = grupoTipo.GroupBy(f => f.NombreSala);

                foreach (var grupoSala in salasEnEsteTipo)
                {
                    

                    //botones para los horarios
                    foreach (var f in grupoSala)
                    {
                        Button btnHorario = new Button();
                        // mostrar hora y nombre de lasaba en e lboton 
                        btnHorario.Text = f.FechaHora.ToString("HH:mm") + "\n" + f.NombreSala;
                        btnHorario.Size = new Size(90, 50);
                        btnHorario.TextAlign = ContentAlignment.MiddleCenter;
                        btnHorario.Tag = f.ID_Funcion;

                        btnHorario.Click += (s, ev) => {
                            FormVentaBoletos2 frm = new FormVentaBoletos2(f.ID_Funcion);
                            frm.ShowDialog();
                        };
                        flpHorarios.Controls.Add(btnHorario);
                    }
                }
            }
        }



        private void GenerarBotonesFecha()
        {
            if (listBox1.SelectedItem == null) return;
            PanelFechas.Controls.Clear();

            DataRowView row = (DataRowView)listBox1.SelectedItem;
            int idPelicula = Convert.ToInt32(row["ID_Pelicula"]);

            var todasLasFunciones = negocio.ObtenerHorarios(idPelicula);

            

            var fechasDisponibles = todasLasFunciones
                                        .Select(f => f.FechaHora.ToString("yyyy-MM-dd"))
                                        .Distinct()
                                        .OrderBy(d => d)
                                        .ToList();

            foreach (string fechaStr in fechasDisponibles)
            {
                DateTime fecha = DateTime.Parse(fechaStr); // volvemos a convertir a datetime para el btn
                Button btnFecha = new Button();
                btnFecha.Text = fecha.ToString("dd/MMM");
                btnFecha.Tag = fecha;
                btnFecha.AutoSize = true;
                btnFecha.Margin = new Padding(5);

                btnFecha.Click += (s, e) => {
                    DateTime fechaSeleccionada = (DateTime)((Button)s).Tag;
                    CargarHorariosFiltrados(fechaSeleccionada, idPelicula);
                };
                PanelFechas.Controls.Add(btnFecha);
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
