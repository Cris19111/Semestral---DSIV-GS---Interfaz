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
            cmbCategoria.Items.Add("PadreId"); // <- NUEVO
            cmbCategoria.SelectedIndex = 0;

            txtBuscarProducto.TextChanged += (s, e) => AplicarFiltro();
            cmbCategoria.SelectedIndexChanged += (s, e) => AplicarFiltro();

            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;

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

        private void ConfigurarColumnasDgv()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CategoriaDto.Id),
                HeaderText = "Id",
                Name = "colId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CategoriaDto.Nombre),
                HeaderText = "Nombre",
                Name = "colNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CategoriaDto.CategoriaPadreId),
                HeaderText = "PadreId",
                Name = "colPadreId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CategoriaDto.CantidadProductos),
                HeaderText = "Cant. Productos",
                Name = "colCantidadProductos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private async void Categoria_Load(object sender, EventArgs e) => await CargarCategoriasAsync();

        private async Task CargarCategoriasAsync()
        {
            try
            {
                api.SetToken(Session.Token);
                var data = await api.GetAsync<List<CategoriaDto>>(ENDPOINT_CATEGORIAS);
                categoriasOriginal = data ?? new List<CategoriaDto>();
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

            string txt = (txtBuscarProducto.Text ?? "").Trim().ToLower();
            string campo = cmbCategoria.SelectedItem?.ToString() ?? "Todos";

            if (string.IsNullOrWhiteSpace(txt))
            {
                dgvProductos.DataSource = categoriasOriginal;
                return;
            }

            List<CategoriaDto> filtradas;
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
                        await CargarCategoriasAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario de crear:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                // FIX: quitar ';' y pasar la categoría seleccionada al form
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
