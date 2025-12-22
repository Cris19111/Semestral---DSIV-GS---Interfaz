
using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS.Forms
{
    public partial class CategoriaMod : Form
    {
        private readonly ApiControl_ api = new ApiControl_();
        private readonly ErrorProvider ep = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        private readonly FolderApi.Categoria seleccionado;
        private const string ENDPOINT = "api/categorias";

        // Nombre actual (no editable, pero lo necesitamos para PUT)
        private string _nombreActual = "";

        // Controles esperados:
        // txtId (TextBox, ReadOnly), txtNombre (TextBox, ReadOnly), cboPadre (ComboBox DL), btnGuardar, btnCancelar

        public CategoriaMod(FolderApi.Categoria seleccionadoRow)
        {
            InitializeComponent();
            seleccionado = seleccionadoRow ?? throw new ArgumentNullException(nameof(seleccionadoRow));

            // Guards de diseñador
            if (txtId == null) throw new InvalidOperationException("Falta TextBox 'txtId'.");
            if (txtNombre == null) throw new InvalidOperationException("Falta TextBox 'txtNombre'.");
            if (cboPadre == null) throw new InvalidOperationException("Falta ComboBox 'cboPadre'.");
            if (btnGuardar == null) throw new InvalidOperationException("Falta Button 'btnGuardar'.");
            if (btnCancelar == null) throw new InvalidOperationException("Falta Button 'btnCancelar'.");

            // Id y Nombre no editables
            txtId.ReadOnly = true;
            txtNombre.ReadOnly = true;

            txtId.Text = seleccionado.Id.ToString();
            txtNombre.Text = seleccionado.Nombre ?? "";
            _nombreActual = txtNombre.Text;

            cboPadre.DropDownStyle = ComboBoxStyle.DropDownList;

            this.AcceptButton = btnGuardar;
            this.CancelButton = btnCancelar;

            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnGuardar.Click += async (s, e) => await GuardarAsync();
            this.Shown += async (s, e) => await CargarAsync();
        }

        private async Task CargarAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                api.SetToken(Session.Token);

                // Detalle: aseguramos nombre actual (por si la grilla no venía al día) y padre actual
                var detalle = await api.GetAsync<CategoriaDetalleDto>($"{ENDPOINT}/{seleccionado.Id}");
                if (detalle != null)
                {
                    _nombreActual = detalle.Nombre ?? _nombreActual;
                    txtNombre.Text = _nombreActual;
                }
                int padreActual = detalle != null && detalle.CategoriaPadreId.HasValue ? detalle.CategoriaPadreId.Value : 0;

                // Árbol: para excluir descendientes (no permitir ciclos)
                var arbol = await api.GetAsync<CategoriaArbolDto>($"{ENDPOINT}/{seleccionado.Id}/arbol");
                var descendientes = new HashSet<int>(Flatten(arbol).Where(id => id != seleccionado.Id));

                // Todas: poblar combo (0 = Sin padre)
                var todas = await api.GetAsync<List<CategoriaListaDto>>(ENDPOINT);
                if (todas == null) todas = new List<CategoriaListaDto>();

                var opciones = new List<PadreOption>();
                opciones.Add(new PadreOption { Id = 0, Nombre = "Sin padre (raíz)" });
                foreach (var c in todas)
                {
                    if (c == null) continue;
                    if (c.Id == seleccionado.Id) continue;
                    if (descendientes.Contains(c.Id)) continue;
                    opciones.Add(new PadreOption { Id = c.Id, Nombre = c.Id + " - " + (c.Nombre ?? "") });
                }

                cboPadre.DisplayMember = nameof(PadreOption.Nombre);
                cboPadre.ValueMember = nameof(PadreOption.Id);
                cboPadre.DataSource = opciones;

                // Seleccionar padre actual
                var idx = opciones.FindIndex(x => x.Id == (padreActual == 0 ? 0 : padreActual));
                if (idx >= 0) cboPadre.SelectedIndex = idx;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static IEnumerable<int> Flatten(CategoriaArbolDto raiz)
        {
            if (raiz == null) yield break;
            yield return raiz.Id;
            if (raiz.Hijos == null) yield break;
            foreach (var h in raiz.Hijos)
                foreach (var id in Flatten(h))
                    yield return id;
        }

        private async Task GuardarAsync()
        {
            try
            {
                ep.Clear();

                if (cboPadre == null)
                {
                    MessageBox.Show("No existe 'cboPadre' en el formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int sel = cboPadre.SelectedValue is int v ? v : 0;
                if (sel == seleccionado.Id)
                {
                    ep.SetError(cboPadre, "La categoría no puede ser su propio padre.");
                    MessageBox.Show("La categoría no puede ser su propio padre.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mapea UI→SQL: 0 (sin padre) => -1 (quitar padre), >0 set padre
                int padreToSend = sel == 0 ? -1 : sel;

                btnGuardar.Enabled = false;
                Cursor = Cursors.WaitCursor;
                api.SetToken(Session.Token);

                var req = new CategoriaPutDto
                {
                    Id = seleccionado.Id,
                    Nombre = _nombreActual,        // nombre se mantiene igual
                    CategoriaPadreId = padreToSend
                };

                await api.PutAsync(ENDPOINT, req);

                MessageBox.Show("Padre actualizado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (HttpRequestException ex)
            {
                string msg = "No se pudo actualizar la categoría.";
                if (ex.Data["StatusCode"] is HttpStatusCode sc)
                {
                    if (sc == HttpStatusCode.NotFound) msg = "La categoría no existe (404).";
                    else if (sc == HttpStatusCode.Conflict) msg = "Conflicto (409).";
                    else if (sc == HttpStatusCode.BadRequest) msg = "Datos inválidos (400).";
                }
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }

        // --- DTOs locales para este form ---
        private sealed class PadreOption
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = "";
        }

        internal sealed class CategoriaDetalleDto
        {
            [JsonPropertyName("id")] public int Id { get; set; }
            [JsonPropertyName("nombre")] public string Nombre { get; set; } = "";
            [JsonPropertyName("categoriaPadreId")] public int? CategoriaPadreId { get; set; }
        }

        internal sealed class CategoriaListaDto
        {
            [JsonPropertyName("id")] public int Id { get; set; }
            [JsonPropertyName("nombre")] public string Nombre { get; set; } = "";
        }

        internal sealed class CategoriaArbolDto
        {
            [JsonPropertyName("id")] public int Id { get; set; }
            [JsonPropertyName("nombre")] public string Nombre { get; set; } = "";
            [JsonPropertyName("hijos")] public List<CategoriaArbolDto> Hijos { get; set; } = new List<CategoriaArbolDto>();
        }

        internal sealed class CategoriaPutDto
        {
            [JsonPropertyName("id")] public int Id { get; set; }
            [JsonPropertyName("nombre")] public string Nombre { get; set; } = "";
            [JsonPropertyName("categoriaPadreId")] public int CategoriaPadreId { get; set; } // -1 o >0
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
