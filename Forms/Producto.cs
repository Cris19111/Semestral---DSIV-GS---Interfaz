using Semestral___DSIV_GS.FolderApi;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Producto : Form
    {
        private ApiControl_ api;

        public Producto()
        {
            InitializeComponent();
            api = new ApiControl_();
        }

        private async void Producto_Load(object sender, EventArgs e)
        {
            await CargarProductos();
        }

        private async Task CargarProductos()
        {
            try
            {
                var response =
                    await api.GetAsync<ArticulosResponse>("api/articulos");

                dgvProductos.DataSource = response.articulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void Volver_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private async void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            await CargarProductos();
        }

        private void txtBuscar(object sender, EventArgs e)
        {

        }

        private void cmbCategoria(object sender, EventArgs e)
        {

        }

        private void btnFiltrar(object sender, EventArgs e)
        {

        }
    }
}
