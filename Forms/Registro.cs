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

namespace Semestral___DSIV_GS
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async void btnlogin_Click(object sender, EventArgs e) {
            try
            {
                ApiControl_ api = new ApiControl_();

            

                RegistroUsuario obj = new RegistroUsuario
                {
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    telefono = txtTelefono.Text,
                    correo = txtCorreo.Text,
                    direccion = txtDireccion.Text,
                    user = txtUsuario.Text,
                    Contrasena = txtContraseña.Text
                };

                string respuesta = await api.PostTextoAsync(
                      "api/auth/register/cliente",
                      obj
                  );

                MessageBox.Show("Cliente registrado correctamente");
                Form1 venta = new Form1();
                venta.Show();
                this.Close();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    "El usuario o el corre ya se encuentran en uso:",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Form1 venta = new Form1();
            venta.Show();
            this.Close();
        }
    }
}
