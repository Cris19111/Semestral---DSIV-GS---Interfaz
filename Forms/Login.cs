using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Semestral___DSIV_GS
{
    public partial class Form1 : Form
    {
        private ApiControl_ api;

        public Form1()
        {
            InitializeComponent();
            txtpass.UseSystemPasswordChar = true;
            api = new ApiControl_();
        }

        private void btnFiltrarProducto_Click(object sender, EventArgs e)
        {

        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            Registro ventana = new Registro();
            ventana.Show();
            this.Hide();


        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtuser.Text) ||
                    string.IsNullOrWhiteSpace(txtpass.Text))
                {
                    MessageBox.Show("Ingrese usuario y contraseña",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                LoginRequest request = new LoginRequest
                {
                    User = txtuser.Text,
                    Contrasena = txtpass.Text
                };
                string token = await api.PostTextoAsync(
                    "api/auth/login",
                    request
                );


                api.SetToken(token);
                Session.Token = token;

                MessageBox.Show("Login exitoso",
                                "Correcto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                Home ventana = new Home();
                ventana.Show();
                this.Hide();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error de conexión con el servidor",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
