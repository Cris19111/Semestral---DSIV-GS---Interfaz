using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Categoria : Form
    {
        private readonly ApiControl_ api;
        private List<CategoriaDto> categoriasOriginal;

        private CategoriaDto categoriaSeleccionada;

        private const string ENDPOINT_CATEGORIAS = "api/categorias";

        public Categoria()
        {
            InitializeComponent();
            api = new ApiControl_();

        
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todos");
            cmbCategoria.Items.Add("Id");
            cmbCategoria.Items.Add("Nombre");
            cmbCategoria.SelectedIndex = 0;


            txtBuscarProducto.TextChanged += (s, e) => AplicarFiltro();
            cmbCategoria.SelectedIndexChanged += (s, e) => AplicarFiltro();


            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;

            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;


            btnEditarCategoria.Enabled = false;
            btnEliminarCategoria.Enabled = false;


            btnBuscarProducto.Click += (s, e) => AplicarFiltro();
            btnFiltrarProducto.Click += (s, e) => AplicarFiltro();

            btnCrearCategoria.Click += async (s, e) => await CrearCategoriaAsync();
            // btnEditarCategoria.Click += async (s, e) => await EditarCategoriaAsync();
            btnEliminarCategoria.Click += async (s, e) => await EliminarCategoriaAsync();


        }

        private async void Categoria_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoGenerateColumns = true; 
            await CargarCategoriasAsync();

        }

        private async Task CargarCategoriasAsync()
        {
       
            try
            {
                api.SetToken(Session.Token);

                var data = await api.GetAsync<List<CategoriaDto>>(ENDPOINT_CATEGORIAS);

                if (data == null)
                {
                    MessageBox.Show("La API devolvió NULL.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    categoriasOriginal = new List<CategoriaDto>();
                    dgvProductos.DataSource = categoriasOriginal;
                    return;
                }

                categoriasOriginal = data;
                dgvProductos.DataSource = categoriasOriginal;

                categoriaSeleccionada = null;
                btnEditarCategoria.Enabled = false;
                btnEliminarCategoria.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías:\n" + ex.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is CategoriaDto c)
            {
                categoriaSeleccionada = c;
                btnEditarCategoria.Enabled = true;
                btnEliminarCategoria.Enabled = true;
            }
            else
            {
                categoriaSeleccionada = null;
                btnEditarCategoria.Enabled = false;
                btnEliminarCategoria.Enabled = false;
            }
        }

        private void AplicarFiltro()
        {
            if (categoriasOriginal == null) return;

            string filtroTexto = (txtBuscarProducto.Text ?? "").Trim().ToLower();
            string filtroCampo = cmbCategoria.SelectedItem?.ToString() ?? "Todos";

            if (string.IsNullOrWhiteSpace(filtroTexto))
            {
                dgvProductos.DataSource = categoriasOriginal;
                return;
            }

            List<CategoriaDto> filtradas;

            switch (filtroCampo)
            {
                case "Id":
                    filtradas = int.TryParse(filtroTexto, out int id)
                        ? categoriasOriginal.FindAll(c => c.Id == id)
                        : categoriasOriginal;
                    break;

                case "Nombre":
                    filtradas = categoriasOriginal.FindAll(c =>
                        (c.Nombre ?? "").ToLower().Contains(filtroTexto));
                    break;

                default: // Todos
                    filtradas = categoriasOriginal.FindAll(c =>
                        c.Id.ToString().Contains(filtroTexto) ||
                        (c.Nombre ?? "").ToLower().Contains(filtroTexto) ||
                        c.CantidadProductos.ToString().Contains(filtroTexto));
                    break;
            }

            dgvProductos.DataSource = filtradas;
        }


        private async Task EliminarCategoriaAsync()
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ok = MessageBox.Show(
                $"¿Eliminar la categoría #{categoriaSeleccionada.Id} ({categoriaSeleccionada.Nombre})?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (ok != DialogResult.Yes) return;

            try
            {
                api.SetToken(Session.Token);

                // DELETE real
                await api.DeleteAsync($"{ENDPOINT_CATEGORIAS}/{categoriaSeleccionada.Id}");

                MessageBox.Show("Categoría eliminada correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refrescar lista
                await CargarCategoriasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoría:\n" + ex.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Volver_Click(object sender, EventArgs e)
        {
            var home = new Home();
            home.Show();
            Close();
        }
        private async Task CrearCategoriaAsync()
        {
            try
            {
                using (var frm = new CategoriaAdd())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await CargarCategoriasAsync(); // refresca dgv
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario de crear:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
