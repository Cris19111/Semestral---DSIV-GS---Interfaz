    using Semestral___DSIV_GS.FolderApi;
    using System;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    namespace Semestral___DSIV_GS
    {
        public partial class Registro : Form
        {
            private readonly ApiControl_ api;
            private readonly ErrorProvider errorProvider;

            public Registro()
            {
                InitializeComponent();

                api = new ApiControl_();

                errorProvider = new ErrorProvider
                {
                    BlinkStyle = ErrorBlinkStyle.NeverBlink
                };


                txtNombre.Validating += (s, e) => { if (!ValidarNombre()) e.Cancel = true; };
                txtApellido.Validating += (s, e) => { if (!ValidarApellido()) e.Cancel = true; };
                txtTelefono.Validating += (s, e) => { if (!ValidarTelefono()) e.Cancel = true; };
                txtCorreo.Validating += (s, e) => { if (!ValidarCorreo()) e.Cancel = true; };
                txtDireccion.Validating += (s, e) => { if (!ValidarDireccion()) e.Cancel = true; };
                txtUsuario.Validating += (s, e) => { if (!ValidarUsuario()) e.Cancel = true; };
                txtContraseña.Validating += (s, e) => { if (!ValidarContrasena()) e.Cancel = true; };


            }

            private async void btnlogin_Click(object sender, EventArgs e)
            {
                try
                {
                    errorProvider.Clear();

                    bool ok =
                        ValidarNombre() &
                        ValidarApellido() &
                        ValidarTelefono() &
                        ValidarCorreo() &
                        ValidarDireccion() &
                        ValidarUsuario() &
                        ValidarContrasena();

                    if (!ok)
                    {
                        MessageBox.Show("Revise los campos marcados antes de continuar.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

         
                    Cursor = Cursors.WaitCursor;

                    var obj = new RegistroUsuario
                    {
                        nombre = txtNombre.Text.Trim(),
                        apellido = txtApellido.Text.Trim(),
                        telefono = NormalizarTelefono(txtTelefono.Text),
                        correo = txtCorreo.Text.Trim(),
                        direccion = txtDireccion.Text.Trim(),
                        user = txtUsuario.Text.Trim(),
                        Contrasena = txtContraseña.Text
                    };

                    await api.PostTextoAsync("api/auth/register/cliente", obj);

                    MessageBox.Show("Cliente registrado correctamente",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new Form1().Show();
                    Close();
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("El usuario o el correo ya se encuentran en uso.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
            
                }
            }

            private void btncancelar_Click(object sender, EventArgs e)
            {
                new Form1().Show();
                Close();
            }



            private bool ValidarNombre()
            {
                string v = (txtNombre.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(v))
                {
                    errorProvider.SetError(txtNombre, "El nombre es obligatorio.");
                    return false;
                }
                if (v.Length < 2)
                {
                    errorProvider.SetError(txtNombre, "El nombre debe tener al menos 2 caracteres.");
                    return false;
                }
                if (v.Length > 50)
                {
                    errorProvider.SetError(txtNombre, "El nombre no puede exceder 50 caracteres.");
                    return false;
                }
                errorProvider.SetError(txtNombre, "");
                return true;
            }

            private bool ValidarApellido()
            {
                string v = (txtApellido.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(v))
                {
                    errorProvider.SetError(txtApellido, "El apellido es obligatorio.");
                    return false;
                }
                if (v.Length < 2)
                {
                    errorProvider.SetError(txtApellido, "El apellido debe tener al menos 2 caracteres.");
                    return false;
                }
                if (v.Length > 50)
                {
                    errorProvider.SetError(txtApellido, "El apellido no puede exceder 50 caracteres.");
                    return false;
                }
                errorProvider.SetError(txtApellido, "");
                return true;
            }

            private bool ValidarTelefono()
            {
                string raw = (txtTelefono.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(raw))
                {
                    errorProvider.SetError(txtTelefono, "El teléfono es obligatorio.");
                    return false;
                }

                string digits = SoloDigitos(raw);


                if (digits.Length < 8 || digits.Length > 15)
                {
                    errorProvider.SetError(txtTelefono, "Teléfono inválido (8 a 15 dígitos).");
                    return false;
                }

                errorProvider.SetError(txtTelefono, "");
                return true;
            }

            private bool ValidarCorreo()
            {
                string email = (txtCorreo.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    errorProvider.SetError(txtCorreo, "El correo es obligatorio.");
                    return false;
                }


                var re = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!re.IsMatch(email))
                {
                    errorProvider.SetError(txtCorreo, "Correo inválido. Ej: usuario@dominio.com");
                    return false;
                }

                if (email.Length > 100)
                {
                    errorProvider.SetError(txtCorreo, "El correo no puede exceder 100 caracteres.");
                    return false;
                }

                errorProvider.SetError(txtCorreo, "");
                return true;
            }

            private bool ValidarDireccion()
            {
                string v = (txtDireccion.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(v))
                {
                    errorProvider.SetError(txtDireccion, "La dirección es obligatoria.");
                    return false;
                }
                if (v.Length < 5)
                {
                    errorProvider.SetError(txtDireccion, "La dirección debe tener al menos 5 caracteres.");
                    return false;
                }
                if (v.Length > 150)
                {
                    errorProvider.SetError(txtDireccion, "La dirección no puede exceder 150 caracteres.");
                    return false;
                }
                errorProvider.SetError(txtDireccion, "");
                return true;
            }

            private bool ValidarUsuario()
            {
                string v = (txtUsuario.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(v))
                {
                    errorProvider.SetError(txtUsuario, "El usuario es obligatorio.");
                    return false;
                }
                if (v.Length < 3)
                {
                    errorProvider.SetError(txtUsuario, "El usuario debe tener al menos 3 caracteres.");
                    return false;
                }
                if (v.Length > 50)
                {
                    errorProvider.SetError(txtUsuario, "El usuario no puede exceder 50 caracteres.");
                    return false;
                }


                if (v.Contains(" "))
                {
                    errorProvider.SetError(txtUsuario, "El usuario no debe contener espacios.");
                    return false;
                }

                errorProvider.SetError(txtUsuario, "");
                return true;
            }

            private bool ValidarContrasena()
            {
                string v = txtContraseña.Text ?? "";
                if (string.IsNullOrWhiteSpace(v))
                {
                    errorProvider.SetError(txtContraseña, "La contraseña es obligatoria.");
                    return false;
                }
                if (v.Length < 6)
                {
                    errorProvider.SetError(txtContraseña, "La contraseña debe tener al menos 6 caracteres.");
                    return false;
                }
                if (v.Length > 100)
                {
                    errorProvider.SetError(txtContraseña, "La contraseña no puede exceder 100 caracteres.");
                    return false;
                }
                errorProvider.SetError(txtContraseña, "");
                return true;
            }



            private string SoloDigitos(string s)
            {
                if (string.IsNullOrEmpty(s)) return "";
                var chars = s.ToCharArray();
                var result = new System.Text.StringBuilder(chars.Length);
                foreach (var c in chars)
                    if (char.IsDigit(c)) result.Append(c);
                return result.ToString();
            }

            private string NormalizarTelefono(string s)
            {

                return SoloDigitos(s);
            }
        }
    }
