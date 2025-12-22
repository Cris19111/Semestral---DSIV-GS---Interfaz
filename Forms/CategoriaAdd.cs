using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };


            txtNombre.Validating += (s, e) => { if (!ValidarNombre()) e.Cancel = true; };


            btnCancelar.CausesValidation = false;


            if (cboPadre != null) cboPadre.DropDownStyle = ComboBoxStyle.DropDownList;


            this.Shown += async (s, e) => await CargarPadresAsync();
        }

        // Carga las categorías desde la API y llena el ComboBox de padres
        private async Task CargarPadresAsync()
        {
            try
            {
     
                api.SetToken(Session.Token);

                var categorias = await api.GetAsync<List<CategoriaDto>>(ENDPOINT_CATEGORIAS)
                                 ?? new List<CategoriaDto>();

              
                var opciones = new List<PadreOption>
                {
                    new PadreOption { Id = 0, Nombre = "Sin padre (raíz)" }
                };

                foreach (var c in categorias)
                {
                    if (c == null) continue;
                    opciones.Add(new PadreOption
                    {
                        Id = c.Id,
                        Nombre = $"{c.Id} - {c.Nombre}"
                    });
                }


                if (cboPadre == null)
                {
                    MessageBox.Show("No se encontró el ComboBox 'cboPadre' en el formulario.",
                        "Error de diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cboPadre.DisplayMember = nameof(PadreOption.Nombre);
                cboPadre.ValueMember = nameof(PadreOption.Id);
                cboPadre.DataSource = opciones;
                cboPadre.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías padre:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Maneja el guardado: valida, envía la petición a la API y cierra el formulario
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarNombre())
                {
                    MessageBox.Show("Revise el campo marcado antes de continuar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int padreId = 0;
                if (cboPadre?.SelectedValue is int sel) padreId = sel;
                if (padreId < 0) padreId = 0;

                btnGuardar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                api.SetToken(Session.Token);

                var req = new InsertarCategoriaRequestDto
                {
                    Nombre = (txtNombre.Text ?? "").Trim(),
                    CategoriaPadreId = padreId
                };

                await api.PostTextoAsync(ENDPOINT_CATEGORIAS, req);

                MessageBox.Show("Categoría creada correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (HttpRequestException)
            {
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

        // Maneja la cancelación y cierra el formulario sin guardar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

  
        // Valida el campo Nombre y muestra errores en el ErrorProvider
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
            var re = new Regex(@"^[\p{L}\p{N}\s\-_áéíóúÁÉÍÓÚñÑ]+$");
            if (!re.IsMatch(v))
            {
                errorProvider.SetError(txtNombre, "Nombre inválido.");
                return false;
            }
            errorProvider.SetError(txtNombre, "");
            return true;
        }
    }
}