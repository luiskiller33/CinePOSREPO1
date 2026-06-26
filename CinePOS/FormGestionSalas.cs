using CapaNegocio;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaData;

namespace CinePOS
{
    public partial class FormGestionSalas : Form
    {
        public FormGestionSalas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void ListarSalas()
        {
            SalaDatos datos = new SalaDatos();
            dgvSalas.DataSource = datos.ListarSalas(); // le asiganmos nuestros datos al grid
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreSala.Text))
                {
                    MessageBox.Show("El nombre de la sala es oblig"); // obligamos a escriri en nombre sala para guardar
                    return;
                }
                SalaNegocio negocio = new SalaNegocio();
                negocio.RegistrarSalaCompleta(txtNombreSala.Text, cmbTipoSala.Text, (int)numFilas.Value, (int)numColumnas.Value);
                MessageBox.Show("Sala y asientos generados correctamente");

                ListarSalas();
                // volvemos a cargar las salas en el grid para ver los cambios
             
            }
            catch(Exception ex) // por si sale algun error 
            {
                MessageBox.Show("error al guardar" + ex.Message);
            }
        }

        private void FormGestionSalas_Load_1(object sender, EventArgs e)
        {
            // cargamos el grid con nuestras salas de la db
            ListarSalas();
            dgvSalas.Columns["Nombre"].HeaderText = "Nombre de Sala";
            dgvSalas.Columns["Tipo"].HeaderText = "Tipo";
            dgvSalas.Columns["TotalFilas"].HeaderText = "Cant. Filas";
            dgvSalas.Columns["AsientosPorFila"].HeaderText = "Asientos/Fila";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreSala.Clear();
            cmbTipoSala.SelectedIndex = -1; // esto nos quita la seleccion del combobox
            numFilas.Value = 5;
            numColumnas.Value = 5;
            txtNombreSala.Focus();

            dgvSalas.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvSalas.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("seguro que deseas eliminar las salas seleccionadas?",

            "confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SalaDatos datos = new SalaDatos();

                    
                    foreach (DataGridViewRow row in dgvSalas.SelectedRows)// buscamos las filas seleccionadas en el grid y las recorrecoms con un for
                    {
                        
                        int id = Convert.ToInt32(row.Cells["ID_Sala"].Value); // y eliminamos una por una pasando le el id de la sala a nuestro metodo para el liminar salas 
                        datos.EliminarSala(id);
                    }

                    MessageBox.Show("Salas eliminadas confirmado");
                    ListarSalas(); // refrescamos el grid para ver los cambios 
                }
            }
            else
            {
                MessageBox.Show("Selecciona al menos una fila");
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormGestionBoletos preciosboletos = new FormGestionBoletos();

            preciosboletos.Show();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdminAsientos asientosadmin = new FormAdminAsientos();
            asientosadmin.Show();
        }
    }
}
