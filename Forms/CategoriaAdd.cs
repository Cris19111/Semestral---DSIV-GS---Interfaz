using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class CategoriaAdd : Form
    {
        private readonly ApiControl_ api;
        private readonly ErrorProvider errorProvider;

        private const string ENDPOINT_CATEGORIAS = "api/categorias";

        public CategoriaAdd()
        {
            InitializeComponent();

            api = new ApiControl_();

            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            // Validación al salir del campo
            txtNombre.Validating += (s, e) =>
            {
                if (!ValidarNombre()) e.Cancel = true;
            };

            // UX
            this.AcceptButton = btnGuardar;
            this.CancelButton = btnCancelar;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (!ValidarNombre())
                {
                    MessageBox.Show("Revise el campo marcado antes de continuar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                api.SetToken(Session.Token);

                int padreId = ObtenerCategoriaPadreId(); // 0 si no hay control o si está vacío

                // Regla de tu API: si no tiene padre => 0
                if (padreId < 0) padreId = 0;

                var req = new InsertarCategoriaRequestDto
                {
                    Nombre = txtNombre.Text.Trim(),
                    CategoriaPadreId = padreId
                };

                // POST -> tu API devuelve texto (Ok("..."))
                await api.PostTextoAsync(ENDPOINT_CATEGORIAS, req);

                MessageBox.Show("Categoría creada correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (HttpRequestException)
            {
                // Ojo: con tu PostTextoAsync actual no verás el mensaje 409 (Conflict).
                MessageBox.Show("No se pudo crear la categoría.\n" +
                                "Verifique si ya existe o si el padreId es válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // ---------------- VALIDACIONES ----------------

        private bool ValidarNombre()
        {
            string v = (txtNombre.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(v))
            {
                errorProvider.SetError(txtNombre, "El nombre es obligatorio.");
                return false;
            }

            if (v.Length < 2)
            {
                errorProvider.SetError(txtNombre, "Debe tener al menos 2 caracteres.");
                return false;
            }

            if (v.Length > 50)
            {
                errorProvider.SetError(txtNombre, "No puede exceder 50 caracteres.");
                return false;
            }

            // Permite letras/números/espacios/guiones/acentos
            var re = new Regex(@"^[\p{L}\p{N}\s\-_áéíóúÁÉÍÓÚñÑ]+$");
            if (!re.IsMatch(v))
            {
                errorProvider.SetError(txtNombre, "Nombre inválido.");
                return false;
            }

            errorProvider.SetError(txtNombre, "");
            return true;
        }

        // ---------------- HELPERS ----------------

        // Si existe un NumericUpDown llamado numCategoriaPadreId -> lo usa.
        // Si no existe -> retorna 0.
        private int ObtenerCategoriaPadreId()
        {
            try
            {
                var encontrados = this.Controls.Find("numCategoriaPadreId", true);
                if (encontrados != null && encontrados.Length > 0 && encontrados[0] is NumericUpDown nud)
                {
                    return (int)nud.Value;
                }
            }
            catch { /* ignora */ }

            return 0;
        }
    }

    // DTO para que el JSON matchee con tu API (case-insensitive igual funciona, pero así queda seguro)
    internal sealed class InsertarCategoriaRequestDto
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("categoriaPadreId")]
        public int CategoriaPadreId { get; set; }
    }
}
