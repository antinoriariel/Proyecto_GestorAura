using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormMensajes : Form
    {
        private readonly MensajeNegocio _mensajeNegocio = new MensajeNegocio();
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        private int _idUsuarioActual;
        private int _idOtroUsuarioSeleccionado;
        private string _rolUsuarioActual = "";
        private System.Windows.Forms.Timer _timerRefresco;

        public FormMensajes() : this(0, "") { }

        public FormMensajes(int idUsuarioActual, string rolUsuario)
        {
            _idUsuarioActual = idUsuarioActual;
            _rolUsuarioActual = rolUsuario;

            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            Text = "Mensajes";
            Font = new Font("Consolas", 10F);
            BackColor = Color.WhiteSmoke;
            Size = new Size(1000, 600);
            StartPosition = FormStartPosition.CenterScreen;

            CrearInterfaz();

            Load += OnLoad;
            FormClosing += (s, e) => DetenerRefresco();
        }

        private void CrearInterfaz()
        {
            // ===== Panel lateral =====
            Panel panelLateral = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                Padding = new Padding(8),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            Label lblNuevo = new Label
            {
                Text = "📝 Nuevo mensaje:",
                Dock = DockStyle.Top,
                Height = 25,
                ForeColor = Color.FromArgb(40, 56, 74),
                Font = new Font("Consolas", 10F, FontStyle.Bold)
            };

            cmbUsuarios = new ComboBox
            {
                Dock = DockStyle.Top,
                Height = 28,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Consolas", 10F)
            };
            cmbUsuarios.SelectedIndexChanged += CmbUsuarios_SelectedIndexChanged;

            Label lblConversaciones = new Label
            {
                Text = "💬 Conversaciones:",
                Dock = DockStyle.Top,
                Height = 25,
                ForeColor = Color.FromArgb(40, 56, 74),
                Font = new Font("Consolas", 10F, FontStyle.Bold),
                Padding = new Padding(0, 10, 0, 0)
            };

            lstConversaciones = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10F),
                IntegralHeight = false,
                BackColor = Color.White
            };
            lstConversaciones.SelectedIndexChanged += LstConversaciones_SelectedIndexChanged;

            panelLateral.Controls.Add(lstConversaciones);
            panelLateral.Controls.Add(lblConversaciones);
            panelLateral.Controls.Add(cmbUsuarios);
            panelLateral.Controls.Add(lblNuevo);

            // ===== Panel chat =====
            Panel panelPrincipal = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(8),
                BackColor = Color.White
            };

            rtbHistorial = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Consolas", 10F)
            };

            Panel panelEnviar = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(0, 8, 0, 0)
            };

            txtMensaje = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Escribe un mensaje...",
                Font = new Font("Consolas", 10F),
                Multiline = true
            };
            txtMensaje.KeyDown += TxtMensaje_KeyDown;

            btnEnviar = new Button
            {
                Dock = DockStyle.Right,
                Width = 100,
                Text = "Enviar",
                BackColor = Color.FromArgb(0, 136, 204),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White
            };
            btnEnviar.FlatAppearance.BorderSize = 0;
            btnEnviar.Click += BtnEnviar_Click;

            panelEnviar.Controls.Add(txtMensaje);
            panelEnviar.Controls.Add(btnEnviar);

            panelPrincipal.Controls.Add(rtbHistorial);
            panelPrincipal.Controls.Add(panelEnviar);

            // ===== Ensamblar =====
            Controls.Clear();
            Controls.Add(panelPrincipal);
            Controls.Add(panelLateral);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (_idUsuarioActual == 0)
            {
                MessageBox.Show("No se ha asignado el usuario actual.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            CargarUsuariosDisponibles();
            CargarConversaciones();
            IniciarRefresco();
        }

        // ====== Refresco automático ======
        private void IniciarRefresco()
        {
            DetenerRefresco();
            _timerRefresco = new System.Windows.Forms.Timer { Interval = 3000 };
            _timerRefresco.Tick += (s, e) =>
            {
                if (_idOtroUsuarioSeleccionado > 0)
                    CargarHistorialSeleccion();
            };
            _timerRefresco.Start();
        }

        private void DetenerRefresco()
        {
            _timerRefresco?.Stop();
            _timerRefresco?.Dispose();
            _timerRefresco = null;
        }

        // ====== Eventos UI ======
        private void BtnEnviar_Click(object sender, EventArgs e) => Enviar();
        private void TxtMensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                Enviar();
            }
        }
        private void CmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem is ComboItem item && (int)item.Value != 0)
            {
                _idOtroUsuarioSeleccionado = (int)item.Value;
                CargarHistorialSeleccion();
            }
        }
        private void LstConversaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConversaciones.SelectedItem is ComboItem item)
            {
                _idOtroUsuarioSeleccionado = (int)item.Value;
                CargarHistorialSeleccion();
            }
        }

        // ====== Lógica de carga ======
        private void CargarUsuariosDisponibles()
        {
            try
            {
                var tabla = _usuarioNegocio.ObtenerUsuariosChatPorRol(_rolUsuarioActual);
                cmbUsuarios.Items.Clear();
                cmbUsuarios.Items.Add(new ComboItem { Text = "Seleccionar usuario...", Value = 0 });

                foreach (DataRow row in tabla.Rows)
                {
                    int id = Convert.ToInt32(row["id_usuario"]);
                    string nombre = $"{row["nombre"]} {row["apellido"]} ({row["rol"]})";
                    cmbUsuarios.Items.Add(new ComboItem { Text = nombre, Value = id });
                }

                cmbUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error");
            }
        }

        private void CargarConversaciones()
        {
            try
            {
                var tabla = _mensajeNegocio.ObtenerConversaciones(_idUsuarioActual);
                lstConversaciones.Items.Clear();

                if (tabla.Rows.Count == 0)
                {
                    lstConversaciones.Items.Add("(Sin conversaciones)");
                    lstConversaciones.Enabled = false;
                    return;
                }

                lstConversaciones.Enabled = true;
                foreach (DataRow row in tabla.Rows)
                {
                    int idOtro = Convert.ToInt32(row["id_otro"]);
                    string nombreOtro = row.Table.Columns.Contains("nombre_otro")
                        ? row["nombre_otro"]?.ToString() ?? $"Usuario #{idOtro}"
                        : $"Usuario #{idOtro}";

                    lstConversaciones.Items.Add(new ComboItem { Text = nombreOtro, Value = idOtro });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar conversaciones: {ex.Message}", "Error");
            }
        }

        private void CargarHistorialSeleccion()
        {
            try
            {
                var tabla = _mensajeNegocio.ObtenerConversacion(_idUsuarioActual, _idOtroUsuarioSeleccionado);
                rtbHistorial.Clear();

                if (tabla.Rows.Count == 0)
                {
                    rtbHistorial.SelectionColor = Color.Gray;
                    rtbHistorial.AppendText("No hay mensajes previos.\n");
                    return;
                }

                foreach (DataRow row in tabla.Rows)
                {
                    string cuerpo = row["cuerpo"]?.ToString() ?? "";
                    DateTime fecha = Convert.ToDateTime(row["fecha_creacion"]);
                    int remitente = Convert.ToInt32(row["id_remitente"]);

                    bool esMio = remitente == _idUsuarioActual;
                    string quien = esMio ? "Tú" : $"Usuario {remitente}";
                    Color color = esMio ? Color.FromArgb(0, 136, 204) : Color.FromArgb(220, 53, 69);

                    rtbHistorial.SelectionColor = color;
                    rtbHistorial.AppendText($"{quien} [{fecha:HH:mm}]\n");
                    rtbHistorial.SelectionColor = Color.Black;
                    rtbHistorial.AppendText($"{cuerpo}\n\n");
                }

                rtbHistorial.SelectionStart = rtbHistorial.Text.Length;
                rtbHistorial.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar mensajes: {ex.Message}", "Error");
            }
        }

        private void Enviar()
        {
            string msg = txtMensaje.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("Escribe un mensaje.", "Advertencia");
                return;
            }
            if (_idOtroUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un destinatario.", "Advertencia");
                return;
            }

            try
            {
                _mensajeNegocio.EnviarMensaje(_idUsuarioActual, _idOtroUsuarioSeleccionado, msg);
                txtMensaje.Clear();
                CargarHistorialSeleccion();
                CargarConversaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar: {ex.Message}", "Error");
            }
        }

        private class ComboItem
        {
            public string Text { get; set; } = "";
            public object Value { get; set; } = 0;
            public override string ToString() => Text;
        }
    }
}
