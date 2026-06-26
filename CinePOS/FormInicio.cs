using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaData;


namespace CinePOS
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion con = new Conexion(); // usamos la clase conexion usando summetodo pruba conexion para verificar que si estamos hablando con la db

            
            if (con.PruebConex())// aqui confirmamos que todo bien 
            {
                
                MessageBox.Show("Conexión a la base de datos exitosa", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else// para el error
            {
                
                MessageBox.Show("No se pudo conectar a la base de datos SQLite. Revisa la ruta o el archivo.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)// este es el evento del boton de la derecha, el de la izquierda todavia no se habilita pq no hay funcionalidad ahi todavia
        {
            FormAdminLogin login = new FormAdminLogin(); // inicializamos el form para hacer el login en la base de datos 


            this.Hide(); //solo se oculta, falta añador el aplication.close() en FormDashboard



            // i el usuario se loguea correctamenteabrimos el panel de 

            if (login.ShowDialog() == DialogResult.OK)
            {
                FormAdminDashboard admin = new FormAdminDashboard();

                admin.usuariologueado = login.usuariologueado; // transferimos la informacion del login validada(el nombre del usuario como esta en la DB) a la propuedad que esta en FormAdminDashboard

                
             

                admin.Show();
                
            }
            else
            {
                this.Show();

            }




        }
    }
}


