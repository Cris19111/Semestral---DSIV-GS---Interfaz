using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class FormHistorial : Form
    {
        private ApiControl_ api;
        private List<Fracturas> facturasOriginal;

        public FormHistorial()
        {
            InitializeComponent();
            api = new ApiControl_();
            cmbBoxFiltro.Items.Add("Todos");
            cmbBoxFiltro.Items.Add("UsuarioId");
            cmbBoxFiltro.Items.Add("Total");
            cmbBoxFiltro.Items.Add("Fecha");
            cmbBoxFiltro.SelectedIndex = 0;
        }

        private async void FormHistorial_Load(object sender, EventArgs e)
        {
            dgvFracturas.AutoGenerateColumns = true;
            await CargarFacturasAsync();

        }

        private async Task CargarFacturasAsync()
        {
            try
            {
                api.SetToken(Session.Token);

                List<Fracturas> facturas =
                    await api.GetAsync<List<Fracturas>>("api/facturas");

                if (facturas == null)
                {
                    MessageBox.Show("La API devolvió NULL");
                    return;
                }
                dgvFracturas.AutoGenerateColumns = true;
                dgvFracturas.DataSource = facturas;
                facturasOriginal = await api.GetAsync<List<Fracturas>>("api/facturas");
                dgvFracturas.DataSource = facturasOriginal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar facturas:\n" + ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void cmbBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }
        private void AplicarFiltro()
        {
            if (facturasOriginal == null) return;

            string filtroTexto = txtFiltro.Text.Trim().ToLower();
            string filtroCampo = cmbBoxFiltro.SelectedItem.ToString();

            List<Fracturas> filtradas;

            switch (filtroCampo)
            {
                case "UsuarioId":
                    if (int.TryParse(filtroTexto, out int userId))
                        filtradas = facturasOriginal.FindAll(f => f.UsuarioId == userId);
                    else
                        filtradas = facturasOriginal;
                    break;

                case "Total":
                    if (decimal.TryParse(filtroTexto, out decimal total))
                        filtradas = facturasOriginal.FindAll(f => f.Total == total);
                    else
                        filtradas = facturasOriginal;
                    break;

                case "Fecha":
                    if (DateTime.TryParse(filtroTexto, out DateTime fecha))
                        filtradas = facturasOriginal.FindAll(f => f.Fecha.Date == fecha.Date);
                    else
                        filtradas = facturasOriginal;
                    break;

                default: 
                    filtradas = facturasOriginal;
                    break;
            }

            dgvFracturas.DataSource = filtradas;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            Home ventan = new Home();
            ventan.Show();
            this.Close();
        }

        private void dgvFracturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }
    }
}
