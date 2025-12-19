using Semestral___DSIV_GS.Clases;
using Semestral___DSIV_GS.FolderApi;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Form1 : Form
    {
        private readonly ApiControl_ api;
        private readonly ErrorProvider errorProvider;

        public Form1()
        {
            InitializeComponent();

            txtpass.UseSystemPasswordChar = true;
            api = new ApiControl_();


            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };


            txtuser.Validating += (s, e) => { if (!ValidarUsuario()) e.Cancel = true; };
            txtpass.Validating += (s, e) => { if (!ValidarPassword()) e.Cancel = true; };


            this.AcceptButton = btnlogin;
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
                errorProvider.Clear();

                bool ok = ValidarUsuario() & ValidarPassword();
                if (!ok)
                {
                    MessageBox.Show("Revise los campos marcados antes de continuar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnlogin.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var request = new LoginRequest
                {
                    User = txtuser.Text.Trim(),
                    Contrasena = txtpass.Text
                };

                string token = await api.PostTextoAsync("api/auth/login", request);

                if (string.IsNullOrWhiteSpace(token))
                {
                    MessageBox.Show("El servidor no devolvió un token.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                api.SetToken(token);
                Session.Token = token;

                MessageBox.Show("Login exitoso",
                    "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Home ventana = new Home();
                ventana.Show();
                this.Hide();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error de conexión con el servidor",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnlogin.Enabled = true;
            }
        }



        private bool ValidarUsuario()
        {
            string user = (txtuser.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(user))
            {
                errorProvider.SetError(txtuser, "El usuario es obligatorio.");
                return false;
            }


            if (user.Length < 3)
            {
                errorProvider.SetError(txtuser, "El usuario debe tener al menos 3 caracteres.");
                return false;
            }

            if (user.Length > 50)
            {
                errorProvider.SetError(txtuser, "El usuario no puede exceder 50 caracteres.");
                return false;
            }

            errorProvider.SetError(txtuser, "");
            return true;
        }

        private bool ValidarPassword()
        {
            string pass = txtpass.Text ?? "";

            if (string.IsNullOrWhiteSpace(pass))
            {
                errorProvider.SetError(txtpass, "La contraseña es obligatoria.");
                return false;
            }


            if (pass.Length < 6)
            {
                errorProvider.SetError(txtpass, "La contraseña debe tener al menos 6 caracteres.");
                return false;
            }

            if (pass.Length > 100)
            {
                errorProvider.SetError(txtpass, "La contraseña no puede exceder 100 caracteres.");
                return false;
            }

            errorProvider.SetError(txtpass, "");
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
