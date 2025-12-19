// File: Forms/Categoria.cs
using Semestral___DSIV_GS.Clases;      // Si tienes modelos propios, quita CategoriaDto de abajo.
using Semestral___DSIV_GS.FolderApi;   // ApiControl_
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Categoria : Form
    {
        private readonly ApiControl_ _api = new ApiControl_();
        private readonly BindingSource _bsCategorias = new BindingSource();
        private List<CategoriaDto> _categoriasOriginal = new List<CategoriaDto>();
        private readonly DebounceTimer _debounceBuscar = new DebounceTimer(200);

        private const string ENDPOINT_CATEGORIAS = "api/categorias"; // Ajusta si tu ruta difiere

        public Categoria()
        {
            InitializeComponent();
            // Por qué: asegurar que el grid haga selección completa, solo lectura y binding
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;

            // Mapear columnas del diseñador a propiedades
            colIdProducto.DataPropertyName = nameof(CategoriaDto.Id);
            colCategoriaProducto.DataPropertyName = nameof(CategoriaDto.Nombre);
            cant_productos.DataPropertyName = nameof(CategoriaDto.CantidadProductos);

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = _bsCategorias;

            // Filtros disponibles (campo)
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new object[] { "Todos", "Id", "Nombre" });
            cmbCategoria.SelectedIndex = 0;

            // Eventos
            Load += async (_, __) => await CargarCategoriasAsync();
            txtBuscarProducto.TextChanged += (_, __) => _debounceBuscar.Run(AplicarFiltro);
            btnBuscarProducto.Click += (_, __) => AplicarFiltro();
            btnFiltrarProducto.Click += (_, __) => AplicarFiltro();
            btnCrearCategoria.Click += (_, __) => BtnCrearCategoria_Click();
            btnEditarCategoria.Click += (_, __) => BtnEditarCategoria_Click();
            btnEliminarCategoria.Click += async (_, __) => await BtnEliminarCategoriaAsync();
            dgvProductos.CellDoubleClick += (_, __) => BtnEditarCategoria_Click();
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                _api.SetToken(Session.Token);
                var data = await _api.GetAsync<List<CategoriaDto>>(ENDPOINT_CATEGORIAS) ?? new List<CategoriaDto>();
                _categoriasOriginal = data;
                _bsCategorias.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltro()
        {
            if (_categoriasOriginal == null) return;

            var texto = (txtBuscarProducto.Text ?? "").Trim().ToLowerInvariant();
            var campo = (cmbCategoria.SelectedItem ?? "Todos").ToString();

            IEnumerable<CategoriaDto> q = _categoriasOriginal;

            if (!string.IsNullOrWhiteSpace(texto) && campo != "Todos")
            {
                switch (campo)
                {
                    case "Id":
                        if (int.TryParse(texto, out var id))
                            q = q.Where(c => c.Id == id);
                        else
                            q = _categoriasOriginal;
                        break;
                    case "Nombre":
                        q = q.Where(c => (c.Nombre ?? "").ToLowerInvariant().Contains(texto));
                        break;
                }
            }
            else if (!string.IsNullOrWhiteSpace(texto))
            {
                q = q.Where(c =>
                    c.Id.ToString().Contains(texto) ||
                    (c.Nombre ?? "").ToLowerInvariant().Contains(texto) ||
                    c.CantidadProductos.ToString().Contains(texto)
                );
            }

            _bsCategorias.DataSource = q.ToList();
        }

        private void BtnCrearCategoria_Click()
        {
            // TODO: abre form de alta o llama POST a tu API.
            // Ejemplo:
            // var req = new { nombre = "Nueva", ... };
            // await _api.PostAsync(ENDPOINT_CATEGORIAS, req);
            MessageBox.Show("Crear Categoría - Conecta tu formulario o POST.", "Info");
        }

        private void BtnEditarCategoria_Click()
        {
            var cat = GetSeleccion<CategoriaDto>();
            if (cat == null) { MessageBox.Show("Selecciona una categoría.", "Atención"); return; }
            // TODO: abre form de edición con 'cat' o llama PUT.
            // await _api.PutAsync($"{ENDPOINT_CATEGORIAS}/{cat.Id}", updateObj);
            MessageBox.Show($"Editar Categoría #{cat.Id} - Conecta tu formulario o PUT.", "Info");
        }

        private async Task BtnEliminarCategoriaAsync()
        {
            var cat = GetSeleccion<CategoriaDto>();
            if (cat == null) { MessageBox.Show("Selecciona una categoría.", "Atención"); return; }

            var ok = MessageBox.Show($"¿Eliminar categoría #{cat.Id}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;

            try
            {
                // TODO: DELETE real
                // await _api.DeleteAsync($"{ENDPOINT_CATEGORIAS}/{cat.Id}");
                MessageBox.Show("Simulación DELETE. Implementa tu llamada real.", "Info");
                await CargarCategoriasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoría:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private T GetSeleccion<T>() where T : class
        {
            if (dgvProductos?.CurrentRow?.DataBoundItem is T item) return item;
            return null;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            var home = new Home();
            home.Show();
            Close();
        }
    }

    // DTO simple. Si ya tienes un modelo en Semestral___DSIV_GS.Clases, elimina esta clase.
    public sealed class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int CantidadProductos { get; set; }
    }

    // Debounce mínimo para la caja de búsqueda
    internal sealed class DebounceTimer
    {
        private readonly Timer _timer;
        private Action _pending;

        public DebounceTimer(int intervalMs)
        {
            _timer = new Timer { Interval = intervalMs };
            _timer.Tick += (_, __) =>
            {
                _timer.Stop();
                var a = _pending; _pending = null;
                a?.Invoke();
            };
        }

        public void Run(Action action)
        {
            _pending = action;
            _timer.Stop();
            _timer.Start();
        }
    }
}
