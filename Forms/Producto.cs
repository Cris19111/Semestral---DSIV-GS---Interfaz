using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Producto : Form
    {
        private readonly ApiControl_ api;
        private List<FolderApi.Producto> productosOriginal;

        // Constructor: inicializa componentes, API y controles de filtrado/tabla
        public Producto()
        {
            InitializeComponent();
            api = new ApiControl_();

            cmbFiltrarProducto.Items.Clear();
            cmbFiltrarProducto.Items.Add("Todos");
            cmbFiltrarProducto.Items.Add("Id");
            cmbFiltrarProducto.Items.Add("Nombre");
            cmbFiltrarProducto.Items.Add("Descripcion");
            cmbFiltrarProducto.Items.Add("Precio");
            cmbFiltrarProducto.Items.Add("Stock");
            cmbFiltrarProducto.Items.Add("PagaItbms");
            cmbFiltrarProducto.SelectedIndex = 0;


            txtBuscarProducto.TextChanged += (s, e) => AplicarFiltro();
            cmbFiltrarProducto.SelectedIndexChanged += (s, e) => AplicarFiltro();


            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;

            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;



        }
        private FolderApi.Producto productoSeleccionado;

        // Evento Load: configura columnas automáticas y carga productos desde la API
        private async void Producto_Load(object sender, EventArgs e)
        {

            dgvProductos.AutoGenerateColumns = true;
            await CargarProductos();
        }

        // Maneja el cambio de selección en el DataGridView y habilita botones
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is FolderApi.Producto p)
            {
                productoSeleccionado = p;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                productoSeleccionado = null;

            }
        }

        // Carga la lista de productos desde la API y actualiza el DataGridView
        private async Task CargarProductos()
        {
            try
            {
                api.SetToken(Session.Token);

                var response = await api.GetAsync<ArticulosResponse>("api/articulos");

                if (response?.articulos == null)
                {
                    MessageBox.Show("La API devolvió NULL o no trajo 'articulos'.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                productosOriginal = response.articulos;
                dgvProductos.DataSource = productosOriginal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos:\n" + ex,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aplica el filtro seleccionado sobre la lista original y muestra resultados
        private void AplicarFiltro()
        {
            if (productosOriginal == null) return;

            string filtroTexto = (txtBuscarProducto.Text ?? "").Trim().ToLower();
            string filtroCampo = cmbFiltrarProducto.SelectedItem?.ToString() ?? "Todos";

            if (string.IsNullOrWhiteSpace(filtroTexto) || filtroCampo == "Todos")
            {
                dgvProductos.DataSource = productosOriginal;
                return;
            }

            List<FolderApi.Producto> filtrados;

            switch (filtroCampo)
            {
                case "Id":
                    filtrados = int.TryParse(filtroTexto, out int id)
                        ? productosOriginal.FindAll(p => p.Id == id)
                        : productosOriginal;
                    break;

                case "Nombre":
                    filtrados = productosOriginal.FindAll(p =>
                        (p.Nombre ?? "").ToLower().Contains(filtroTexto));
                    break;

                case "Descripcion":
                    filtrados = productosOriginal.FindAll(p =>
                        (p.Descripcion ?? "").ToLower().Contains(filtroTexto));
                    break;

                case "Precio":
                    filtrados = decimal.TryParse(filtroTexto, out decimal precio)
                        ? productosOriginal.FindAll(p => p.Precio == precio)
                        : productosOriginal;
                    break;

                case "Stock":
                    filtrados = int.TryParse(filtroTexto, out int stock)
                        ? productosOriginal.FindAll(p => p.Stock == stock)
                        : productosOriginal;
                    break;

                case "PagaItbms":
                    bool? paga = ParseBool(filtroTexto);
                    filtrados = paga.HasValue
                        ? productosOriginal.FindAll(p => p.PagaItbms == paga.Value)
                        : productosOriginal;
                    break;

                default:
                    filtrados = productosOriginal;
                    break;
            }

            dgvProductos.DataSource = filtrados;
        }

        // Interpreta texto como booleano (soporta 'si', 'no', '1', '0', 'true', 'false')
        private bool? ParseBool(string input)
        {
            string s = (input ?? "").Trim().ToLower();
            if (s == "true" || s == "1" || s == "si" || s == "sí") return true;
            if (s == "false" || s == "0" || s == "no") return false;
            return null;
        }

        // Devuelve el producto seleccionado actualmente en el DataGridView
        private FolderApi.Producto GetSeleccionado()
        {
            return dgvProductos.CurrentRow?.DataBoundItem as FolderApi.Producto;
        }

        // Maneja doble click en fila para abrir el formulario de edición
        private async void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var sel = GetSeleccionado();
            if (sel == null)
            {
                MessageBox.Show("Seleccione un producto.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            using (var frm = new ProductoModAdd(sel))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await CargarProductos();
                }
            }
        }

        // Botón buscar: aplica el filtro
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {

            AplicarFiltro();
        }



        // Botón volver: vuelve al formulario principal
        private void Volver_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            Close();
        }

        // Botón nuevo: abre formulario para crear un producto
        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new ProductoAdd())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        await CargarProductos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario de agregar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Botón editar: abre formulario de modificación para el producto seleccionado
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hola");
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            using (var frm = new ProductoModAdd(productoSeleccionado))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    await CargarProductos();
            }
        }


        // Botón eliminar: confirma y elimina el producto seleccionado vía API
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var sel = GetSeleccionado();
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            var ok = MessageBox.Show(
                $"¿Eliminar el artículo #{sel.Id} ({sel.Nombre})?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (ok != DialogResult.Yes) return;

            try
            {
                api.SetToken(Session.Token);
                await api.DeleteAsync($"api/articulos/{sel.Id}");

                MessageBox.Show("Artículo eliminado correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar:\n" + ex.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
