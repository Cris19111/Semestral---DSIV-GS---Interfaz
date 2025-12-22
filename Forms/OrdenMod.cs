using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS.Forms
{
    public partial class OrdenEstadoMod : Form
    {
        private readonly ApiControl_ api = new ApiControl_();
        private readonly OrdenDto _orden;

        public OrdenEstadoMod(OrdenDto orden)
        {
            InitializeComponent();
            _orden = orden ?? throw new ArgumentNullException(nameof(orden));


            lblOrden.Text = $"Orden #{_orden.Id}";
            lblEstadoActual.Text = $"Estado actual: {_orden.Estado}";
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.DataSource = DestinosPermitidos(_orden.Estado);

            this.AcceptButton = btnGuardar;
            this.CancelButton = btnCancelar;
            btnCancelar.CausesValidation = false;
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnGuardar.Click += async (s, e) => await GuardarAsync();

            btnGuardar.Enabled = cboEstado.Items.Count > 0;
        }

        private static List<string> DestinosPermitidos(string estadoActual)
        {
            var s = (estadoActual ?? "").Trim().ToLowerInvariant();
            if (s == "procesando") return new List<string> { "revision" };
            if (s == "revision") return new List<string> { "completada", "cancelada" };
            return new List<string>();
        }

        private async Task GuardarAsync()
        {
            try
            {
                if (cboEstado.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un estado de destino.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nuevoEstado = cboEstado.SelectedItem.ToString();
                if (string.Equals(nuevoEstado, _orden.Estado, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El estado seleccionado es igual al actual.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                btnGuardar.Enabled = false;
                Cursor = Cursors.WaitCursor;
                api.SetToken(Session.Token);

                var enProceso = await api.GetAsync<List<OrdenDto>>("api/ordenes/procesando") ?? new List<OrdenDto>();
                bool existe = enProceso.Any(o => o.Id == _orden.Id);
                if (!existe)
                {
                    MessageBox.Show($"La orden #{_orden.Id} no está disponible (puede haber cambiado de estado o sido eliminada).",
                        "No encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                await api.PutAsync($"api/ordenes/{_orden.Id}", new EditarOrdenRequest { Estado = nuevoEstado });

                MessageBox.Show("Estado actualizado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al actualizar estado:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }

        private sealed class EditarOrdenRequest
        {
            public string Estado { get; set; } = "";
        }
    }
}