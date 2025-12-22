using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using Semestral___DSIV_GS.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Categoria : Form
    {
        private readonly ApiControl_ api;
        private List<FolderApi.Categoria> categoriasOriginal;
        private FolderApi.Categoria categoriaSeleccionada;
        private const string ENDPOINT_CATEGORIAS = "api/categorias";

        
        public Categoria()
        {
            InitializeComponent();
            api = new ApiControl_();

            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todos");
            cmbCategoria.Items.Add("Id");
            cmbCategoria.Items.Add("Nombre");
            cmbCategoria.Items.Add("PadreId"); 
            cmbCategoria.SelectedIndex = 0;

            txtBuscarProducto.TextChanged += (s, e) => AplicarFiltro();
            cmbCategoria.SelectedIndexChanged += (s, e) => AplicarFiltro();

            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;

            ConfigurarColumnasDgv();
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;

            btnEditarCategoria.Enabled = false;
            btnEliminarCategoria.Enabled = false;

            btnBuscarProducto.Click += (s, e) => AplicarFiltro();
            btnFiltrarProducto.Click += (s, e) => { txtBuscarProducto.Clear(); AplicarFiltro(); };

            btnCrearCategoria.Click += async (s, e) => await CrearCategoriaAsync();
            btnEditarCategoria.Click += async (s, e) => await EditarCategoriaAsync();
            btnEliminarCategoria.Click += async (s, e) => await EliminarCategoriaAsync();
        }

        // Configura columnas personalizadas para el DataGridView de categorías
        private void ConfigurarColumnasDgv()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FolderApi.Categoria.Id),
                HeaderText = "Id",
                Name = "colId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FolderApi.Categoria.Nombre),
                HeaderText = "Nombre",
                Name = "colNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FolderApi.Categoria.CategoriaPadreId),
                HeaderText = "PadreId",
                Name = "colPadreId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FolderApi.Categoria.CantidadProductos),
                HeaderText = "Cant. Productos",
                Name = "colCantidadProductos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        // Evento Load: carga las categorías al iniciar el formulario
        private async void Categoria_Load(object sender, EventArgs e) => await CargarCategoriasAsync();

        // Obtiene las categorías desde la API y actualiza la vista
        private async Task CargarCategoriasAsync()
        {
            try
            {
                api.SetToken(Session.Token);
                var data = await api.GetAsync<List<FolderApi.Categoria>>(ENDPOINT_CATEGORIAS);
                categoriasOriginal = data ?? new List<FolderApi.Categoria>();
                dgvProductos.DataSource = categoriasOriginal;

                categoriaSeleccionada = null;
                btnEditarCategoria.Enabled = false;
                btnEliminarCategoria.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías:\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja cambio de selección en el DataGridView y habilita botones según selección
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is FolderApi.Categoria c)
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

        // Aplica el filtro seleccionado sobre la lista original y muestra resultados
        private void AplicarFiltro()
        {
            if (categoriasOriginal == null) return;

            string txt = (txtBuscarProducto.Text ?? "").Trim().ToLower();
            string campo = cmbCategoria.SelectedItem?.ToString() ?? "Todos";

            if (string.IsNullOrWhiteSpace(txt))
            {
                dgvProductos.DataSource = categoriasOriginal;
                return;
            }

            List<FolderApi.Categoria> filtradas;
            switch (campo)
            {
                case "Id":
                    filtradas = int.TryParse(txt, out int id)
                        ? categoriasOriginal.FindAll(c => c.Id == id)
                        : categoriasOriginal;
                    break;
                case "Nombre":
                    filtradas = categoriasOriginal.FindAll(c => (c.Nombre ?? "").ToLower().Contains(txt));
                    break;
                case "PadreId":
                    filtradas = int.TryParse(txt, out int pid)
                        ? categoriasOriginal.FindAll(c => (c.CategoriaPadreId ?? 0) == pid)
                        : categoriasOriginal.FindAll(c => (c.CategoriaPadreId?.ToString() ?? "").Contains(txt));
                    break;
                default:
                    filtradas = categoriasOriginal.FindAll(c =>
                        c.Id.ToString().Contains(txt) ||
                        (c.Nombre ?? "").ToLower().Contains(txt) ||
                        (c.CategoriaPadreId?.ToString() ?? "").Contains(txt) ||
                        c.CantidadProductos.ToString().Contains(txt));
                    break;
            }
            dgvProductos.DataSource = filtradas;
        }

        // Elimina la categoría seleccionada después de confirmar con el usuario
        private async Task EliminarCategoriaAsync()
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ok = MessageBox.Show(
                $"¿Eliminar la categoría #{categoriaSeleccionada.Id} ({categoriaSeleccionada.Nombre})?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ok != DialogResult.Yes) return;

            try
            {
                api.SetToken(Session.Token);
                await api.DeleteAsync($"{ENDPOINT_CATEGORIAS}/{categoriaSeleccionada.Id}");
                MessageBox.Show("Categoría eliminada correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarCategoriasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoría:\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón volver: vuelve al formulario principal
        private void Volver_Click(object sender, EventArgs e)
        {
            var home = new Home();
            home.Show();
            Close();
        }

        // Abre el formulario para crear una nueva categoría
        private async Task CrearCategoriaAsync()
        {
            try
            {
                using (var frm = new CategoriaAdd())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        await CargarCategoriasAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario de crear:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abre el formulario para editar la categoría seleccionada
        private async Task EditarCategoriaAsync()
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                
                using (var frm = new CategoriaMod(categoriaSeleccionada) )
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        await CargarCategoriasAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario de edición:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
