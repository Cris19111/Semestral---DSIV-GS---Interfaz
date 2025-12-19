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

        public ProductoModAdd(FolderApi.Producto seleccionado)
        {
            InitializeComponent();

            api = new ApiControl_();
            original = seleccionado;


            txtNombre.Text = original.Nombre;
            txtDescripcion.Text = original.Descripcion;
            numPrecio.Value = original.Precio;
            numStock.Value = original.Stock;
            chkItbms.Checked = original.PagaItbms;
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

                MessageBox.Show("Artículo actualizado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar:\n" + ex.Message,
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
