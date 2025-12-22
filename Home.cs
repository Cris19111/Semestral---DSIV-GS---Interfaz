using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Home : Form
    {
        // Constructor: inicializa componentes del formulario Home
        public Home()
        {
            InitializeComponent();
        }

        // Abre la ventana de historial de ventas
        private void btnVentas_Click(object sender, EventArgs e)
        {
            Historial ventana = new Historial();
            ventana.Show();
            this.Hide();
        }

        // Abre la ventana de productos
        private void btn_productos_Click(object sender, EventArgs e)
        {
            Producto venta = new Producto();
            venta.Show();
            this.Hide();
        }

        // Cierra la sesión y vuelve al formulario de login
        private void lbl_logout_Click(object sender, EventArgs e)
        {

            DialogResult salir = MessageBox.Show("Desea cerrar seccion", "Salir", MessageBoxButtons.YesNo);
            if (salir == DialogResult.Yes)
            {
                this.Close();
                Form1 ventana = new Form1();
                ventana.Show();
            }

        }

        // Abre la ventana de categorías
        private void btn_categorias_Click(object sender, EventArgs e)
        {
            Categoria venta = new Categoria();
            venta.Show();
            this.Close();
        }

        // Abre la ventana de órdenes
        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            Ordenes ventana = new Ordenes();
            ventana.Show();
            this.Close();
        }
    }
}
