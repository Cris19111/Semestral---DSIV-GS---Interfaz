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
        public Home()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormHistorial ventana = new FormHistorial();
            ventana.Show();
            this.Hide();
        }

        private void btn_productos_Click(object sender, EventArgs e)
        {
            Producto venta = new Producto();
            venta.Show();
            this.Hide();
        }

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

        private void btn_categorias_Click(object sender, EventArgs e)
        {
            Categoria venta = new Categoria();
            venta.Show();
            this.Close();
        }
    }
}
