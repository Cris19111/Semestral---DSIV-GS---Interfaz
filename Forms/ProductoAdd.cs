using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class ProductoAdd : Form
    {
        private readonly ApiControl_ api;
        private readonly ErrorProvider errorProvider;

        // Constructor: inicializa componentes, API y validaciones de campos
        public ProductoAdd()
        {
            InitializeComponent();
            api = new ApiControl_();

            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            txtNombre.Validating += (s, e) => { if (!ValidarNombre()) e.Cancel = true; };
            txtDescripcion.Validating += (s, e) => { if (!ValidarDescripcion()) e.Cancel = true; };
            numPrecio.Validating += (s, e) => { if (!ValidarPrecio()) e.Cancel = true; };
            numStock.Validating += (s, e) => { if (!ValidarStock()) e.Cancel = true; };
        }

        // Guardar: valida campos y crea el producto vía API
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

                var nuevo = new FolderApi.Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = numPrecio.Value,
                    Stock = (int)numStock.Value,
                    PagaItbms = chkItbms.Checked
                };

                await api.PostTextoAsync("api/articulos", nuevo);

                MessageBox.Show("Artículo creado correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Valida el nombre del producto
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

        // Valida la descripción del producto
        private bool ValidarDescripcion()
        {
            string desc = (txtDescripcion.Text ?? "").Trim();


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

        // Valida que el precio sea mayor que cero
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

        // Valida que el stock no sea negativo
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

        // Cancelar: cierra el formulario sin guardar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
