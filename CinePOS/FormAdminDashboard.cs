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
    public partial class FormAdminDashboard : Form
    {
        public string usuariologueado { get;set; }

        public FormAdminDashboard()
        {
            InitializeComponent();
            label2.Text = "Bienvenido: " + usuariologueado;
        }

        private void AbrirFormPanel(object formhijo) // creamos este metodo para abrir cualquier form
        {

           
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form; // inicializamos el objeto metido en el metodo(formhijo) 
            fh.TopLevel = false; // para que sea una ventana metoda en el panellcontenedor blanco y no una ventana aparte
            fh.FormBorderStyle = FormBorderStyle.None; // quitamos borde
            fh.Dock = DockStyle.Fill; // para que aproveche todo el espacio 

            this.panelContenedor.Controls.Add(fh);

            this.panelContenedor.Tag = fh;

            fh.Show();


        }
        private void AbrirFormPanel2(object formhijo) // creamos este metodo para abrir cualquier form
        {


            if (this.pnlContenedor2.Controls.Count > 0)
            {
                this.pnlContenedor2.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form; // inicializamos el objeto metido en el metodo(formhijo) 
            fh.TopLevel = false; // para que sea una ventana metoda en el panellcontenedor blanco y no una ventana aparte
            fh.FormBorderStyle = FormBorderStyle.None; // quitamos borde
            fh.Dock = DockStyle.Fill; // para que aproveche todo el espacio 

            this.pnlContenedor2.Controls.Add(fh);

            this.pnlContenedor2.Tag = fh;

            fh.Show();


        }

        // aqui solo agregamos los botones que agregamos en el diseñador grafico, les añadimos su evento y usamos el metodo creado para abrir los formsdentro del panel contenedor 

        private void btnPelis_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FormGestionPeliculas());


        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FormGestionSalas());

        }


        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FormGestionFunciones());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormPanel2(new FormCartelera());
        }


        // estos dos penultimos eventos son para cerrar la aplicacion definitivamente

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormAdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // para agregar el texto del usuario en el label
        private void FormAdminDashboard_Load(object sender, EventArgs e)
        {
            label2.Text = "Bienvenido: " + usuariologueado;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormPanel2(new FormRegistroVentas());

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlContenedor2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
