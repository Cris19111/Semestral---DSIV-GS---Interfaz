using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using Semestral___DSIV_GS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Ordenes : Form
    {
        private readonly ApiControl_ api = new ApiControl_();
        private List<OrdenDto> ordenesOriginal = new List<OrdenDto>();

        public Ordenes()
        {
            InitializeComponent();
        }

        private async void Ordenes_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoGenerateColumns = true;        
            await CargarOrdenesProcesandoAsync();          
        }

        private async Task CargarOrdenesProcesandoAsync()
        {
            try
            {
                api.SetToken(Session.Token);

                var lista = await api.GetAsync<List<OrdenDto>>("api/ordenes/procesando");

                ordenesOriginal = lista ?? new List<OrdenDto>();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = ordenesOriginal;

      
                FormatearGrid();

                if (ordenesOriginal.Count == 0)
                    MessageBox.Show("No hay órdenes en proceso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar órdenes en proceso:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormatearGrid()
        {
   
            if (dgvProductos.Columns["Fecha"] != null)
                dgvProductos.Columns["Fecha"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

            foreach (var col in new[] { "Subtotal", "Total", "Descuento", "Itbms" })
            {
                if (dgvProductos.Columns[col] != null)
                    dgvProductos.Columns[col].DefaultCellStyle.Format = "N2";
            }
        }


        private void btnFiltro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = ordenesOriginal;
                FormatearGrid();
                return;
            }

            if (!int.TryParse(txtFiltro.Text, out int usuarioId))
            {
                MessageBox.Show("El ID debe ser un número válido");
                return;
            }

            var filtradas = ordenesOriginal.Where(o => o.Usuario_Id == usuarioId).ToList();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtradas;
            FormatearGrid();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            var h = new Home();
            h.Show();
            Close();
        }

        private async void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            var sel = dgvProductos.CurrentRow?.DataBoundItem as OrdenDto;
            if (sel == null)
            {
                MessageBox.Show("Seleccione una orden.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var frm = new OrdenEstadoMod(sel))
                {
                    var dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                        await CargarOrdenesProcesandoAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la ventana:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
