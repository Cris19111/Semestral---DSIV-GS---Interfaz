
using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net; 
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using CatDto = Semestral___DSIV_GS.FolderApi.CategoriaDto;

namespace Semestral___DSIV_GS.Forms
{
    public partial class CategoriaMod : Form
    {
        private readonly ApiControl_ api = new ApiControl_();
        private readonly ErrorProvider ep = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        private readonly CatDto _sel;
        private const string ENDPOINT = "api/categorias";
        private int _padreActualId = 0;

        private sealed class PadreOption { public int Id { get; set; } public string Nombre { get; set; } = ""; }

        public CategoriaMod(CatDto seleccionado)
        {
            InitializeComponent();
            _sel = seleccionado ?? throw new ArgumentNullException(nameof(seleccionado));

            if ( txtNombre == null || cboPadre == null || btnGuardar == null || btnCancelar == null)
                throw new InvalidOperationException("Faltan controles requeridos en el formulario.");

 

            txtNombre.ReadOnly = false;
            txtNombre.Text = _sel.Nombre ?? "";
            txtNombre.Validating += (s, e) => { if (!ValidarNombre()) e.Cancel = true; };

            cboPadre.DropDownStyle = ComboBoxStyle.DropDownList;

            this.AcceptButton = btnGuardar;
            this.CancelButton = btnCancelar;
            btnCancelar.CausesValidation = false;
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

  
                var detalle = await TryGetOrNullAsync<CatDto>($"{ENDPOINT}/{_sel.Id}");
                if (detalle == null)
                {
                    MessageBox.Show("La categoría seleccionada ya no existe.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                txtNombre.Text = detalle.Nombre ?? txtNombre.Text;
                _padreActualId = detalle.CategoriaPadreId ?? 0; 

                var arbol = await TryGetOrNullAsync<CategoriaArbolDto>($"{ENDPOINT}/{_sel.Id}/arbol");
                var descendientes = (arbol == null)
                    ? new HashSet<int>()
                    : new HashSet<int>(Flatten(arbol).Where(id => id != _sel.Id));


                var todas = await api.GetAsync<List<CatDto>>(ENDPOINT) ?? new List<CatDto>();

                var opciones = new List<PadreOption> { new PadreOption { Id = 0, Nombre = "Sin padre (raíz)" } };
                foreach (var c in todas)
                {
                    if (c == null) continue;
                    if (c.Id == _sel.Id) continue;              
                    if (descendientes.Contains(c.Id)) continue; 
                    opciones.Add(new PadreOption { Id = c.Id, Nombre = $"{c.Id} - {c.Nombre}" });
                }

                cboPadre.DisplayMember = nameof(PadreOption.Nombre);
                cboPadre.ValueMember = nameof(PadreOption.Id);
                cboPadre.DataSource = opciones;

                var idx = opciones.FindIndex(x => x.Id == (_padreActualId == 0 ? 0 : _padreActualId));
                if (idx >= 0) cboPadre.SelectedIndex = idx;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categoría:\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
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


        private bool ValidarNombre()
        {
            string v = (txtNombre.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(v)) { ep.SetError(txtNombre, "El nombre es obligatorio."); return false; }
            if (v.Length < 2) { ep.SetError(txtNombre, "Debe tener al menos 2 caracteres."); return false; }
            if (v.Length > 50) { ep.SetError(txtNombre, "No puede exceder 50 caracteres."); return false; }
            var re = new Regex(@"^[\p{L}\p{N}\s\-_áéíóúÁÉÍÓÚñÑ]+$");
            if (!re.IsMatch(v)) { ep.SetError(txtNombre, "Nombre inválido."); return false; }
            ep.SetError(txtNombre, ""); return true;
        }













        private async Task<T> TryGetOrNullAsync<T>(string endpoint) where T : class
        {
            try
            {
                return await api.GetAsync<T>(endpoint);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                if (Is404(ex)) return null;
                throw;
            }
        }

        private static bool Is404(System.Net.Http.HttpRequestException ex)
        {
            try
            {
                var prop = ex.GetType().GetProperty("StatusCode");
                if (prop != null)
                {
                    var val = prop.GetValue(ex);
                    if (val != null && val.ToString().Contains("404")) return true;
                }
            }
            catch { /* ignore */ }

            var msg = ex.Message ?? "";
            return msg.Contains("404") || msg.IndexOf("Not Found", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private async Task GuardarAsync()
        {
            try
            {
                ep.Clear();
                if (!ValidarNombre()) return;

                int sel = (cboPadre?.SelectedValue is int v) ? v : 0;
                if (sel == _sel.Id)
                {
                    ep.SetError(cboPadre, "La categoría no puede ser su propio padre.");
                    MessageBox.Show("La categoría no puede ser su propio padre.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tri-estado: -1 (quitar), 0 (no tocar), >0 (asignar)
                int padreToSend =
                    (sel == 0 && _padreActualId != 0) ? -1 :
                    (sel == _padreActualId) ? 0 :
                                                         sel;

                btnGuardar.Enabled = false;
                Cursor = Cursors.WaitCursor;
                api.SetToken(Session.Token);

                var req = new CategoriaPutDto
                {
                    Id = _sel.Id,
                    Nombre = (txtNombre.Text ?? "").Trim(),
                    CategoriaPadreId = padreToSend
                };

                await api.PutAsync(ENDPOINT, req);

                MessageBox.Show("Categoría actualizada correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }

    }
}
