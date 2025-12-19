using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class ProductoAdd : Form
    {
        private readonly ApiControl_ api;

        public ProductoAdd()
        {
            InitializeComponent();
            api = new ApiControl_();

            // Valores por defecto (opcional)
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            numPrecio.Value = 0;
            numStock.Value = 0;
            chkItbms.Checked = false;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.");
                    return;
                }

                api.SetToken(Session.Token);

                // Objeto NUEVO (sin Id)
                var nuevo = new FolderApi.Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = numPrecio.Value,
                    Stock = (int)numStock.Value,
                    PagaItbms = chkItbms.Checked
                };

                // POST (crear)
                // Si tu API devuelve texto, usa PostTextoAsync
                await api.PostTextoAsync("api/articulos", nuevo);

                MessageBox.Show("Artículo creado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
