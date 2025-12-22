using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using Semestral___DSIV_GS.Forms;
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
    public partial class Ordenes : Form
    {
        private ApiControl_ api = new ApiControl_();
        private List<OrdenDto> ordenesOriginal;

        public Ordenes()
        {
            InitializeComponent();
        }



        private void Volver_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoGenerateColumns = true;
        }

        private async Task CargarOrdenesAsync(int usuarioId)
        {
            try
            {
                api.SetToken(Session.Token);


                var orden = await api.GetAsync<OrdenDto>($"api/ordenes/{usuarioId}");

                ordenesOriginal = new List<OrdenDto>();
                if (orden != null) ordenesOriginal.Add(orden);

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = ordenesOriginal;

                if (ordenesOriginal.Count == 0)
                    MessageBox.Show("No hay orden en proceso para ese usuario.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar órdenes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnFiltro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                MessageBox.Show("Ingrese un ID de usuario");
                return;
            }

            if (!int.TryParse(txtFiltro.Text, out int usuarioId))
            {
                MessageBox.Show("El ID debe ser un número válido");
                return;
            }

            await CargarOrdenesAsync(usuarioId);
        }
    }
}
