using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class ProductoModAdd : Form
    {
        private readonly ApiControl_ api;
        private readonly FolderApi.Producto original;
        private readonly ErrorProvider errorProvider;

        public ProductoModAdd(FolderApi.Producto seleccionado)
        {
            InitializeComponent();

            api = new ApiControl_();
            original = seleccionado;

            // ErrorProvider para resaltar campos inválidos
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            // Cargar valores del producto seleccionado
            txtNombre.Text = original.Nombre;
            txtDescripcion.Text = original.Descripcion;
            numPrecio.Value = original.Precio;
            numStock.Value = original.Stock;
            chkItbms.Checked = original.PagaItbms;

            // Validación en vivo (opcional/recomendado)
            txtNombre.Validating += (s, e) => { if (!ValidarNombre()) e.Cancel = true; };
            txtDescripcion.Validating += (s, e) => { if (!ValidarDescripcion()) e.Cancel = true; };
            numPrecio.Validating += (s, e) => { if (!ValidarPrecio()) e.Cancel = true; };
            numStock.Validating += (s, e) => { if (!ValidarStock()) e.Cancel = true; };
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                bool ok =
                    ValidarNombre() &
                    ValidarDescripcion() &
                    ValidarPrecio() &
                    ValidarStock();

                if (!ok)
                {
                    MessageBox.Show("Revise los campos marcados antes de guardar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                api.SetToken(Session.Token);

                var actualizado = new FolderApi.Producto
                {
                    Id = original.Id,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = numPrecio.Value,
                    Stock = (int)numStock.Value,
                    PagaItbms = chkItbms.Checked
                };

                await api.PutAsync($"api/articulos/{original.Id}", actualizado);

                MessageBox.Show("Artículo actualizado correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---- VALIDACIONES ----

        private bool ValidarNombre()
        {
            string nombre = (txtNombre.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider.SetError(txtNombre, "El nombre es obligatorio.");
                return false;
            }

            if (nombre.Length < 3)
            {
                errorProvider.SetError(txtNombre, "El nombre debe tener al menos 3 caracteres.");
                return false;
            }

            if (nombre.Length > 255)
            {
                errorProvider.SetError(txtNombre, "El nombre no puede exceder 255 caracteres.");
                return false;
            }

            errorProvider.SetError(txtNombre, "");
            return true;
        }

        private bool ValidarDescripcion()
        {
            string desc = (txtDescripcion.Text ?? "").Trim();

            // Si quieres que sea opcional, elimina este bloque
            if (string.IsNullOrWhiteSpace(desc))
            {
                errorProvider.SetError(txtDescripcion, "La descripción es obligatoria.");
                return false;
            }

            if (desc.Length > 255)
            {
                errorProvider.SetError(txtDescripcion, "La descripción no puede exceder 255 caracteres.");
                return false;
            }

            errorProvider.SetError(txtDescripcion, "");
            return true;
        }

        private bool ValidarPrecio()
        {
            decimal precio = numPrecio.Value;

            if (precio <= 0)
            {
                errorProvider.SetError(numPrecio, "El precio debe ser mayor que 0.");
                return false;
            }

            errorProvider.SetError(numPrecio, "");
            return true;
        }

        private bool ValidarStock()
        {
            int stock = (int)numStock.Value;

            if (stock < 0)
            {
                errorProvider.SetError(numStock, "El stock no puede ser negativo.");
                return false;
            }

            errorProvider.SetError(numStock, "");
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
