using TP4_LEANDRO.Controladores;
using TP4_LEANDRO.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP4_LEANDRO
{
    public partial class Form1 : Form
    {
        // Paneles principales
        private Panel panelHeader = null!;
        private Panel panelMenuLateral = null!; 
        private Panel panelLogin = null!;
        private Panel panelMenu = null!;
        private Panel panelPedido = null!;
        private Panel panelEstado = null!;
        private Panel panelListaPedidos = null!;
        private Panel panelSoporte = null!;
        private Panel panelAviso = null!;
        private Label lblAvisoTitulo = null!;
        private Label lblAvisoMensaje = null!;
        private Button btnAvisoCerrar = null!;

        private Panel panelEditarPedido = null!;
        private TextBox txtEditNombre = null!;
        private TextBox txtEditApellido = null!;
        private TextBox txtEditDNI = null!;
        private TextBox txtEditCalle = null!;
        private TextBox txtEditNumeroCalle = null!;
        private TextBox txtEditProvincia = null!;
        private TextBox txtEditEmail = null!;
        private TextBox txtEditTelefono = null!;
        private Button btnEditAceptar = null!;
        private Button btnEditCancelar = null!;
        private Pedido? pedidoEnEdicion = null;

        // Panel tickets soporte
        private Panel panelTickets = null!;
        private Label lblTicketsTitulo = null!;
        private ListView listViewTickets = null!;
        private Button btnTicketsCerrar = null!;

        // Botones menú lateral
        private Button btnLateralInicio = null!;
        private Button btnLateralHacerEnvio = null!;
        private Button btnLateralVerEnvios = null!;
        private Button btnLateralPreguntas = null!;
        private Button btnLateralSucursales = null!;
        private Button btnLateralAyuda = null!;

        // Controles para login
        private TextBox txtLoginNombre = null!;
        private TextBox txtLoginContraseña = null!;
        private Button btnLoginEntrar = null!;

        // Controles para el menú principal
        private Button btnMenuAgregarPedido = null!;
        private Button btnMenuHistorial = null!;
        private Button btnMenuSalir = null!;
        private Button btnMenuAyuda = null!;

        // Controles para pedido
        private TextBox txtCalle = null!;
        private TextBox txtProvincia = null!;
        private TextBox txtNumeroCalle = null!;
        private TextBox txtEmail = null!;
        private TextBox txtTelefono = null!;
        private Button btnSiguientePedido = null!;
        private Button btnVerPedidos = null!;
        private Label lblEstado = null!;
        private Label lblSeguimiento = null!;
        private Label lblFecha = null!;
        private Label lblDatosPedido = null!;
        private Label lblUsuario = null!;

        // Panel de lista de pedidos
        private ListView listViewPedidos = null!;
        private Button btnModificar = null!;
        private Button btnCancelar = null!;
        private Button btnVolver = null!;
        private Button btnVerDetalles = null!;
        private Label lblComentario = null!;

        // Controles para soporte técnico
        private TextBox txtSoporteMensaje = null!;
        private Button btnEnviarSoporte = null!;
        private Button btnVolverSoporte = null!;
        private Label lblSoporteInfo = null!;

        // Modelos y datos
        private Cliente? clienteActual;
        private Pedido? pedidoActual;
        private List<Pedido> pedidos = new();
        private List<ConsultaSoporte> consultasSoporte = new();
        private Dictionary<string, string> comentarios = new();

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InicializarPaneles();
            this.Resize += (s, e) => CentrarTodosLosPaneles();
        }

        private void InicializarPaneles()
        {
            // Header con usuario
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(220, 36, 31)
            };
            lblUsuario = new Label
            {
                Text = $"Bienvenido", // Texto por defecto, se actualizará al iniciar sesión
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleRight,
                Top = 15,
                Left = this.ClientSize.Width - 220
            };
            panelHeader.Controls.Add(lblUsuario);
            this.Controls.Add(panelHeader);
            panelHeader.Resize += (s, e) =>
            {
                lblUsuario.Left = panelHeader.Width - lblUsuario.Width - 30;
            };

            // Panel lateral izquierdo para el menú principal
            panelMenuLateral = new Panel
            {
                Size = new Size(220, this.ClientSize.Height - panelHeader.Height),
                BackColor = Color.FromArgb(245, 245, 245),
                Left = 0,
                Top = panelHeader.Height,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };

            // Asignación de eventos centralizada con switch
            btnLateralInicio = CrearBotonLateral("INICIO", 30, BotonMenu_Click);
            btnLateralHacerEnvio = CrearBotonLateral("HACER UN ENVÍO", 90, BotonMenu_Click);
            btnLateralVerEnvios = CrearBotonLateral("VER MIS ENVÍOS", 150, BotonMenu_Click);
            btnLateralPreguntas = CrearBotonLateral("PREGUNTAS FRECUENTES", 210, BotonMenu_Click);
            btnLateralSucursales = CrearBotonLateral("SUCURSALES", 270, BotonMenu_Click);
            btnLateralAyuda = CrearBotonLateral("AYUDA", 330, BotonMenu_Click);

            panelMenuLateral.Controls.AddRange(new Control[] {
                btnLateralInicio, btnLateralHacerEnvio, btnLateralVerEnvios,
                btnLateralPreguntas, btnLateralSucursales, btnLateralAyuda
            });
            this.Controls.Add(panelMenuLateral);

            this.Resize += (s, e) =>
            {
                panelMenuLateral.Height = this.ClientSize.Height - panelHeader.Height;
                CentrarTodosLosPaneles();
            };

            // Panel de aviso reutilizable (agrandado)
            panelAviso = new Panel
            {
                Size = new Size(680, 440),
                BackColor = Color.White,
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            lblAvisoTitulo = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31),
                Top = 20,
                Left = 30,
                Width = 600,
                Height = 40
            };
            lblAvisoMensaje = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 13, FontStyle.Regular),
                ForeColor = Color.Black,
                Top = 80,
                Left = 30,
                Width = 600,
                Height = 250,
                AutoSize = false
            };
            btnAvisoCerrar = new Button
            {
                Text = "Aceptar",
                Top = 350,
                Left = 260,
                Width = 160,
                Height = 50,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnAvisoCerrar.Click += (s, e) =>
            {
                panelAviso.Visible = false;
                if (panelAviso.Controls.Count > 3)
                    panelAviso.Controls[3].Visible = false; // Oculta el botón "Ver mis Tickets" si está
            };
            panelAviso.Controls.AddRange(new Control[] { lblAvisoTitulo, lblAvisoMensaje, btnAvisoCerrar });
            this.Controls.Add(panelAviso);

            // Panel Tickets Soporte
            panelTickets = new Panel
            {
                Size = new Size(600, 400),
                BackColor = Color.White,
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            lblTicketsTitulo = new Label
            {
                Text = "Mis Tickets de Soporte",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31),
                Top = 20,
                Left = 30,
                Width = 540,
                Height = 30
            };
            listViewTickets = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 70,
                Left = 30,
                Width = 540,
                Height = 250
            };
            listViewTickets.Columns.Add("Fecha", 140);
            listViewTickets.Columns.Add("Mensaje", 380);
            btnTicketsCerrar = new Button
            {
                Text = "Cerrar",
                Top = 340,
                Left = 240,
                Width = 120,
                Height = 40,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White
            };
            btnTicketsCerrar.Click += (s, e) => panelTickets.Visible = false;
            panelTickets.Controls.AddRange(new Control[] { lblTicketsTitulo, listViewTickets, btnTicketsCerrar });
            this.Controls.Add(panelTickets);

            // Panel Login (centrado)
            panelLogin = new Panel
            {
                Size = new Size(450, 400),
                BackColor = Color.White,
                Location = new Point((this.ClientSize.Width - 450) / 2, (this.ClientSize.Height - 400) / 2),
                Anchor = AnchorStyles.None
            };

            txtLoginNombre = new TextBox
            {
                PlaceholderText = "Usuario",
                Width = panelLogin.Width - 100,
                Left = (panelLogin.Width - (panelLogin.Width - 100)) / 2,
                Top = 80,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            txtLoginContraseña = new TextBox
            {
                PlaceholderText = "Contraseña",
                Width = panelLogin.Width - 100,
                Left = (panelLogin.Width - (panelLogin.Width - 100)) / 2,
                Top = 140,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            btnLoginEntrar = new Button
            {
                Text = "Entrar",
                Width = panelLogin.Width - 100,
                Height = 40,
                Left = (panelLogin.Width - (panelLogin.Width - 100)) / 2,
                Top = 260,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            btnLoginEntrar.Click += BtnLoginEntrar_Click;
            panelLogin.Controls.AddRange(new Control[] { txtLoginNombre, txtLoginContraseña, btnLoginEntrar });
            this.Controls.Add(panelLogin);

            // Panel Menú Principal (centrado)
            panelMenu = new Panel
            {
                Size = new Size(450, 450),
                BackColor = Color.White
            };
            btnMenuAgregarPedido = new Button { Text = "Agregar Pedido", Top = 100, Left = 100, Width = 250, Height = 50, BackColor = Color.FromArgb(220, 36, 31), ForeColor = Color.White };
            btnMenuHistorial = new Button { Text = "Ver Historial de Pedidos", Top = 180, Left = 100, Width = 250, Height = 50, BackColor = Color.FromArgb(220, 36, 31), ForeColor = Color.White };
            btnMenuSalir = new Button { Text = "Salir", Top = 340, Left = 100, Width = 250, Height = 50, BackColor = Color.Gray, ForeColor = Color.White };
            btnMenuAyuda = new Button { Text = "Ayuda", Top = 260, Left = 100, Width = 250, Height = 50, BackColor = Color.FromArgb(220, 36, 31), ForeColor = Color.White };
            btnMenuAgregarPedido.Click += BotonMenu_Click;
            btnMenuHistorial.Click += BotonMenu_Click;
            btnMenuSalir.Click += BotonMenu_Click;
            btnMenuAyuda.Click += BotonMenu_Click;
            panelMenu.Controls.AddRange(new Control[] { btnMenuAgregarPedido, btnMenuHistorial, btnMenuSalir, btnMenuAyuda });
            this.Controls.Add(panelMenu);

            // Panel Pedido (centrado)
            panelPedido = new Panel { Size = new Size(400, 350), BackColor = Color.White, Visible = false };
            txtCalle = new TextBox { PlaceholderText = "Calle", Top = 20, Left = 50, Width = 300 };
            txtNumeroCalle = new TextBox { PlaceholderText = "Número", Top = 60, Left = 50, Width = 300 };
            txtProvincia = new TextBox { PlaceholderText = "Provincia", Top = 100, Left = 50, Width = 300 };
            txtEmail = new TextBox { PlaceholderText = "Email", Top = 140, Left = 50, Width = 300 };
            txtTelefono = new TextBox { PlaceholderText = "Teléfono", Top = 180, Left = 50, Width = 300 };
            btnSiguientePedido = new Button { Text = "Generar Pedido", Top = 240, Left = 50, Width = 300, Height = 40, BackColor = Color.FromArgb(220, 36, 31), ForeColor = Color.White };
            btnSiguientePedido.Click += BtnSiguientePedido_Click;
            panelPedido.Controls.AddRange(new Control[] { txtCalle, txtNumeroCalle, txtProvincia, txtEmail, txtTelefono, btnSiguientePedido });
            this.Controls.Add(panelPedido);

            // Panel Estado (centrado)
            panelEstado = new Panel { Size = new Size(700, 400), BackColor = Color.White, Visible = false };
            lblSeguimiento = new Label { Top = 20, Left = 50, Width = 600, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(220, 36, 31) };
            lblEstado = new Label { Top = 70, Left = 50, Width = 600, Font = new Font("Segoe UI", 12, FontStyle.Regular) };
            lblFecha = new Label { Top = 110, Left = 50, Width = 600, Font = new Font("Segoe UI", 10, FontStyle.Italic) };
            lblDatosPedido = new Label { Top = 150, Left = 50, Width = 600, Height = 120, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            btnVerPedidos = new Button { Text = "Ver mis pedidos", Top = 300, Left = 50, Width = 200, Height = 40, BackColor = Color.FromArgb(220, 36, 31), ForeColor = Color.White };
            btnVerPedidos.Click += (s, e) => MostrarPanelListaPedidos();
            panelEstado.Controls.AddRange(new Control[] { lblSeguimiento, lblEstado, lblFecha, lblDatosPedido, btnVerPedidos });
            this.Controls.Add(panelEstado);

            // Panel Lista de Pedidos (centrado)
            panelListaPedidos = new Panel { Size = new Size(800, 520), BackColor = Color.White, Visible = false };
            listViewPedidos = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 60,
                Left = 30,
                Width = 700,
                Height = 300
            };
            listViewPedidos.Columns.Add("Seguimiento", 120);
            listViewPedidos.Columns.Add("Fecha", 150);
            listViewPedidos.Columns.Add("Estado", 100);
            listViewPedidos.Columns.Add("Dirección", 200);
            listViewPedidos.Columns.Add("Comentario", 200);

            btnModificar = new Button { Text = "Modificar", Top = 380, Left = 30, Width = 120, Height = 40, BackColor = Color.FromArgb(255, 193, 7), ForeColor = Color.Black };
            btnModificar.Click += BtnModificar_Click;
            btnCancelar = new Button { Text = "Cancelar", Top = 380, Left = 170, Width = 120, Height = 40, BackColor = Color.FromArgb(220, 36, 31), ForeColor = Color.White };
            btnCancelar.Click += BtnCancelar_Click;
            btnVerDetalles = new Button { Text = "Ver Detalles", Top = 380, Left = 310, Width = 120, Height = 40, BackColor = Color.LightBlue, ForeColor = Color.Black };
            btnVerDetalles.Click += BtnVerDetalles_Click;
            btnVolver = new Button { Text = "Volver", Top = 380, Left = 450, Width = 120, Height = 40, BackColor = Color.Gray, ForeColor = Color.White };
            btnVolver.Click += (s, e) => MostrarPanelMenu();
            lblComentario = new Label { Top = 440, Left = 30, Width = 700, Height = 60, Font = new Font("Segoe UI", 10, FontStyle.Italic), ForeColor = Color.FromArgb(33, 37, 41) };

            panelListaPedidos.Controls.AddRange(new Control[] { listViewPedidos, btnModificar, btnCancelar, btnVerDetalles, btnVolver, lblComentario });
            this.Controls.Add(panelListaPedidos);

            // Panel de edición de pedido
            panelEditarPedido = new Panel
            {
                Size = new Size(400, 420),
                BackColor = Color.White,
                Visible = false
            };
            txtEditNombre = new TextBox { PlaceholderText = "Nombre", Top = 20, Left = 50, Width = 300 };
            txtEditApellido = new TextBox { PlaceholderText = "Apellido", Top = 60, Left = 50, Width = 300 };
            txtEditDNI = new TextBox { PlaceholderText = "DNI", Top = 100, Left = 50, Width = 300 };
            txtEditCalle = new TextBox { PlaceholderText = "Calle", Top = 140, Left = 50, Width = 300 };
            txtEditNumeroCalle = new TextBox { PlaceholderText = "Número", Top = 180, Left = 50, Width = 300 };
            txtEditProvincia = new TextBox { PlaceholderText = "Provincia", Top = 220, Left = 50, Width = 300 };
            txtEditEmail = new TextBox { PlaceholderText = "Email", Top = 260, Left = 50, Width = 300 };
            txtEditTelefono = new TextBox { PlaceholderText = "Teléfono", Top = 300, Left = 50, Width = 300 };
            btnEditAceptar = new Button { Text = "Aceptar", Top = 350, Left = 50, Width = 120, Height = 40, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White };
            btnEditCancelar = new Button { Text = "Cancelar", Top = 350, Left = 230, Width = 120, Height = 40, BackColor = Color.Gray, ForeColor = Color.White };
            btnEditAceptar.Click += BtnEditAceptar_Click;
            btnEditCancelar.Click += (s, e) => { panelEditarPedido.Visible = false; pedidoEnEdicion = null; };
            panelEditarPedido.Controls.AddRange(new Control[] {
                txtEditNombre, txtEditApellido, txtEditDNI, txtEditCalle, txtEditNumeroCalle,
                txtEditProvincia, txtEditEmail, txtEditTelefono, btnEditAceptar, btnEditCancelar
            });
            this.Controls.Add(panelEditarPedido);

            // Panel Soporte Técnico (centrado)
            panelSoporte = new Panel { Size = new Size(600, 350), BackColor = Color.White, Visible = false };
            lblSoporteInfo = new Label
            {
                Text = "Consulta a Soporte Técnico",
                Top = 30,
                Left = 50,
                Width = 400,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31)
            };
            txtSoporteMensaje = new TextBox
            {
                Multiline = true,
                Top = 90,
                Left = 50,
                Width = 500,
                Height = 120,
                Font = new Font("Segoe UI", 11)
            };
            btnEnviarSoporte = new Button
            {
                Text = "Enviar Consulta",
                Top = 230,
                Left = 50,
                Width = 200,
                Height = 40,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White
            };
            btnEnviarSoporte.Click += BtnEnviarSoporte_Click;
            btnVolverSoporte = new Button
            {
                Text = "Volver",
                Top = 230,
                Left = 270,
                Width = 120,
                Height = 40,
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnVolverSoporte.Click += (s, e) => MostrarPanelMenu();
            panelSoporte.Controls.AddRange(new Control[] { lblSoporteInfo, txtSoporteMensaje, btnEnviarSoporte, btnVolverSoporte });
            this.Controls.Add(panelSoporte);

            // Centrar todos los paneles
            CentrarTodosLosPaneles();

            // Mostrar solo el login al inicio
            panelLogin.Visible = true;
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
        }

        private void BotonMenu_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;

            // Validación de datos de cliente solo para botones laterales
            if (btn.Parent == panelMenuLateral && !ClienteDatosCompletos())
            {
                MostrarAviso("Datos requeridos", "Debe ingresar su Usuario y Contraseña correctamente.");
                return;
            }

            switch (btn.Text)
            {
                case "INICIO":
                    MostrarPanelMenu();
                    break;
                case "HACER UN ENVÍO":
                case "Agregar Pedido":
                    MostrarPanelPedido();
                    break;
                case "VER MIS ENVÍOS":
                case "Ver Historial de Pedidos":
                    MostrarPanelListaPedidos();
                    break;
                case "PREGUNTAS FRECUENTES":
                    MostrarAviso("Preguntas Frecuentes",
                        "1. ¿Cuánto tarda un envío?\nR: Entre 24 y 72hs hábiles.\n\n" +
                        "2. ¿Puedo cancelar un envío?\nR: Sí, desde la sección 'Ver mis envíos'.\n\n" +
                        "3. ¿Cómo hago seguimiento de mi pedido?\nR: Desde 'Ver mis envíos' o con el número de seguimiento.\n\n"
                    );
                    break;
                case "SUCURSALES":
                    MostrarAviso("Sucursales",
                        "Sucursal Centro: Av. Principal 123\nSucursal Norte: Calle 456\nSucursal Sur: Ruta 789\nSucursal Oeste: Av. Libertad 321\nSucursal Este: Calle 789"
                    );
                    break;
                case "AYUDA":
                case "Ayuda":
                    MostrarPanelSoporte();
                    break;
                case "Salir":
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void CentrarPanel(Panel panel)
        {
            int leftPanelWidth = panelMenuLateral?.Width ?? 0;
            panel.Left = leftPanelWidth + (this.ClientSize.Width - leftPanelWidth - panel.Width) / 2;
            panel.Top = ((this.ClientSize.Height - panel.Height) / 2) + 25;
        }

        private void CentrarTodosLosPaneles()
        {
            CentrarPanel(panelLogin);
            CentrarPanel(panelMenu);
            CentrarPanel(panelPedido);
            CentrarPanel(panelEstado);
            CentrarPanel(panelListaPedidos);
            CentrarPanel(panelSoporte);
            CentrarPanel(panelAviso);
            CentrarPanel(panelTickets);
            CentrarPanel(panelEditarPedido);
        }

        private void BtnLoginEntrar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoginNombre.Text) ||
                string.IsNullOrWhiteSpace(txtLoginContraseña.Text))
            {
                MostrarAviso("Datos requeridos", "Debe completar todos los campos para ingresar.");
                return;
            }

            lblUsuario.Text = $"Bienvenido, {txtLoginNombre.Text}";
            panelLogin.Visible = false;
            panelMenu.Visible = true;
            CentrarPanel(panelMenu);
            clienteActual = new Cliente
            {
                Usuario = txtLoginNombre.Text,
                Contraseña = txtLoginContraseña.Text
            };
        }



        private void MostrarPanelMenu()
        {
            panelMenu.Visible = true;
            CentrarPanel(panelMenu);
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;
        }

        private void MostrarPanelPedido()
        {
            txtCalle.Text = "";
            txtNumeroCalle.Text = "";
            txtProvincia.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            panelMenu.Visible = false;
            panelPedido.Visible = true;
            CentrarPanel(panelPedido);
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;
        }

        private void MostrarPanelEstado()
        {
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = true;
            CentrarPanel(panelEstado);
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;
        }

        private void MostrarPanelListaPedidos()
        {
            ActualizarListaPedidos();
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = true;
            CentrarPanel(panelListaPedidos);
            panelSoporte.Visible = false;
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;
        }

        private void MostrarPanelSoporte()
        {
            txtSoporteMensaje.Text = "";
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = true;
            CentrarPanel(panelSoporte);
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;
        }

        private void MostrarAviso(string titulo, string mensaje)
        {
            lblAvisoTitulo.Text = titulo;
            lblAvisoMensaje.Text = mensaje;
            btnAvisoCerrar.Text = "Aceptar";
            if (panelAviso.Controls.Count > 3)
                panelAviso.Controls[3].Visible = false;
            panelAviso.Visible = true;
            CentrarPanel(panelAviso);
        }

        // Nuevo: Mostrar aviso con botón "Ver mis Tickets"
        private void MostrarAvisoConBotonTickets(string titulo, string mensaje)
        {
            lblAvisoTitulo.Text = titulo;
            lblAvisoMensaje.Text = mensaje;
            btnAvisoCerrar.Text = "Aceptar";
            Button btnVerTickets;
            if (panelAviso.Controls.Count < 4)
            {
                btnVerTickets = new Button
                {
                    Text = "Ver mis Tickets",
                    Top = 350,
                    Left = 440,
                    Width = 180,
                    Height = 50,
                    BackColor = Color.FromArgb(33, 150, 243),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                btnVerTickets.Click += (s, e) =>
                {
                    panelAviso.Visible = false;
                    MostrarPanelTickets();
                };
                panelAviso.Controls.Add(btnVerTickets);
            }
            else
            {
                btnVerTickets = (Button)panelAviso.Controls[3];
                btnVerTickets.Visible = true;
            }
            panelAviso.Visible = true;
            CentrarPanel(panelAviso);
        }

        // Nuevo: Panel para mostrar tickets enviados
        private void MostrarPanelTickets()
        {
            listViewTickets.Items.Clear();
            foreach (var ticket in consultasSoporte)
            {
                if (ticket.NombreCliente == clienteActual?.Nombre + " " + clienteActual?.Apellido)
                {
                    var item = new ListViewItem(new[]
                    {
                        ticket.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        ticket.Mensaje
                    });
                    listViewTickets.Items.Add(item);
                }
            }
            panelTickets.Visible = true;
            CentrarPanel(panelTickets);
        }

        private void BtnEnviarSoporte_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoporteMensaje.Text))
            {
                MostrarAviso("Consulta vacía", "Por favor, escriba su consulta antes de enviar.");
                return;
            }

            var consulta = new ConsultaSoporte
            {
                NombreCliente = clienteActual?.Nombre + " " + clienteActual?.Apellido,
                Email = clienteActual?.Email ?? "",
                Mensaje = txtSoporteMensaje.Text,
                Fecha = DateTime.Now
            };
            consultasSoporte.Add(consulta);

            MostrarAvisoConBotonTickets("Consulta enviada",
                "¡Su consulta fue enviada a soporte técnico!\nNos contactaremos a la brevedad.\n\n¿Desea ver sus tickets enviados?");
            MostrarPanelMenu();
        }

        private void BtnSiguientePedido_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroCalle.Text) ||
                string.IsNullOrWhiteSpace(txtProvincia.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarAviso("Campos obligatorios", "Debe completar todos los campos del pedido.");
                return;
            }

            if (clienteActual == null)
            {
                MostrarAviso("Error", "Debe ingresar los datos del cliente primero.");
                return;
            }

            clienteActual.Calle = txtCalle.Text;
            clienteActual.NumeroCalle = txtNumeroCalle.Text;
            clienteActual.Provincia = txtProvincia.Text;
            clienteActual.Email = txtEmail.Text;
            clienteActual.Telefono = txtTelefono.Text;

            pedidoActual = new Pedido
            {
                Cliente = clienteActual,
                NumeroSeguimiento = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                Estado = EstadoPedido.Ingresado,
                Fecha = DateTime.Now
            };

            pedidos.Add(pedidoActual);

            lblSeguimiento.Text = $"N° Seguimiento: {pedidoActual.NumeroSeguimiento}";
            lblEstado.Text = $"Estado: {pedidoActual.Estado}";
            lblFecha.Text = $"Fecha de alta: {pedidoActual.Fecha:dd/MM/yyyy HH:mm}";
            lblDatosPedido.Text =
                $"Cliente: {clienteActual.Nombre} {clienteActual.Apellido}\n" +
                $"DNI: {clienteActual.DNI}\n" +
                $"Dirección: {clienteActual.Calle} {clienteActual.NumeroCalle}, {clienteActual.Provincia}\n" +
                $"Email: {clienteActual.Email}\n" +
                $"Teléfono: {clienteActual.Telefono}";

            MostrarPanelEstado();
        }

        private void ActualizarListaPedidos()
        {
            listViewPedidos.Items.Clear();
            foreach (var pedido in pedidos)
            {
                string comentario = comentarios.ContainsKey(pedido.NumeroSeguimiento) ? comentarios[pedido.NumeroSeguimiento] : "";
                var item = new ListViewItem(new[]
                {
                    pedido.NumeroSeguimiento,
                    pedido.Fecha.ToString("dd/MM/yyyy HH:mm"),
                    pedido.Estado.ToString(),
                    $"{pedido.Cliente.Calle} {pedido.Cliente.NumeroCalle}, {pedido.Cliente.Provincia}",
                    comentario
                });
                listViewPedidos.Items.Add(item);
            }
            lblComentario.Text = "";
        }

        private void BtnModificar_Click(object? sender, EventArgs e)
        {
            if (listViewPedidos.SelectedItems.Count == 0)
            {
                MostrarAviso("Atención", "Seleccione un pedido para modificar.");
                return;
            }
            var seleccionado = listViewPedidos.SelectedItems[0];
            var numSeguimiento = seleccionado.SubItems[0].Text;
            var pedido = pedidos.Find(p => p.NumeroSeguimiento == numSeguimiento);

            if (pedido == null)
            {
                MostrarAviso("Atención", "No se encontró el pedido seleccionado.");
                return;
            }

            if (pedido.Estado == EstadoPedido.Finalizado)
            {
                MostrarAviso("Atención", "No se puede modificar un pedido finalizado.");
                return;
            }

            // Llenar los campos con los datos actuales del cliente
            txtEditNombre.Text = pedido.Cliente.Nombre;
            txtEditApellido.Text = pedido.Cliente.Apellido;
            txtEditDNI.Text = pedido.Cliente.DNI;
            txtEditCalle.Text = pedido.Cliente.Calle;
            txtEditNumeroCalle.Text = pedido.Cliente.NumeroCalle;
            txtEditProvincia.Text = pedido.Cliente.Provincia;
            txtEditEmail.Text = pedido.Cliente.Email;
            txtEditTelefono.Text = pedido.Cliente.Telefono;
            pedidoEnEdicion = pedido;

            panelEditarPedido.Visible = true;
            panelEditarPedido.BringToFront();
            CentrarPanel(panelEditarPedido);
        }

        private void BtnEditAceptar_Click(object? sender, EventArgs e)
        {
            if (pedidoEnEdicion == null) return;
            if (string.IsNullOrWhiteSpace(txtEditNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEditApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEditDNI.Text))
            {
                MostrarAviso("Campos requeridos", "Nombre, Apellido y DNI son obligatorios.");
                return;
            }
            pedidoEnEdicion.Cliente.Nombre = txtEditNombre.Text;
            pedidoEnEdicion.Cliente.Apellido = txtEditApellido.Text;
            pedidoEnEdicion.Cliente.DNI = txtEditDNI.Text;
            pedidoEnEdicion.Cliente.Calle = txtEditCalle.Text;
            pedidoEnEdicion.Cliente.NumeroCalle = txtEditNumeroCalle.Text;
            pedidoEnEdicion.Cliente.Provincia = txtEditProvincia.Text;
            pedidoEnEdicion.Cliente.Email = txtEditEmail.Text;
            pedidoEnEdicion.Cliente.Telefono = txtEditTelefono.Text;
            string comentario = $"Pedido modificado el {DateTime.Now:dd/MM/yyyy HH:mm}";
            comentarios[pedidoEnEdicion.NumeroSeguimiento] = comentario;
            lblComentario.Text = comentario;
            ActualizarListaPedidos();
            panelEditarPedido.Visible = false;
            pedidoEnEdicion = null;
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            if (listViewPedidos.SelectedItems.Count == 0)
            {
                MostrarAviso("Atención", "Seleccione un pedido para cancelar.");
                return;
            }
            var seleccionado = listViewPedidos.SelectedItems[0];
            var numSeguimiento = seleccionado.SubItems[0].Text;
            var pedido = pedidos.Find(p => p.NumeroSeguimiento == numSeguimiento);

            if (pedido == null)
            {
                MostrarAviso("Atención", "No se encontró el pedido seleccionado.");
                return;
            }

            if (pedido.Estado == EstadoPedido.Finalizado)
            {
                MostrarAviso("Atención", "No se puede cancelar un pedido finalizado.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea cancelar este pedido?", "Cancelar pedido", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                pedido.Estado = EstadoPedido.Finalizado;
                string comentario = $"Pedido cancelado el {DateTime.Now:dd/MM/yyyy HH:mm}";
                comentarios[pedido.NumeroSeguimiento] = comentario;
                lblComentario.Text = comentario;
                ActualizarListaPedidos();
            }
        }

        private void BtnVerDetalles_Click(object? sender, EventArgs e)
        {
            if (listViewPedidos.SelectedItems.Count == 0)
            {
                MostrarAviso("Atención", "Seleccione un pedido para ver los detalles.");
                return;
            }
            var seleccionado = listViewPedidos.SelectedItems[0];
            var numSeguimiento = seleccionado.SubItems[0].Text;
            var pedido = pedidos.Find(p => p.NumeroSeguimiento == numSeguimiento);

            if (pedido != null)
            {
                var c = pedido.Cliente;
                string detalles = $"Nombre: {c.Nombre}\n" +
                                  $"Apellido: {c.Apellido}\n" +
                                  $"DNI: {c.DNI}\n" +
                                  $"Calle: {c.Calle}\n" +
                                  $"Número: {c.NumeroCalle}\n" +
                                  $"Provincia: {c.Provincia}\n" +
                                  $"Email: {c.Email}\n" +
                                  $"Teléfono: {c.Telefono}";
                MostrarAviso("Detalles del Cliente", detalles);
            }
        }

        private Button CrearBotonLateral(string texto, int top, EventHandler click)
        {
            var btn = new Button
            {
                Text = texto,
                Top = top,
                Left = 10, 
                Width = 200,
                Height = 45,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btn.Click += click;
            return btn;
        }
         
        //Parametro para que no se pueda usar nada a menos que haya un usuario iniciado en la aplicacion
        private bool ClienteDatosCompletos()
        {
            return clienteActual != null &&
                   !string.IsNullOrWhiteSpace(clienteActual.Usuario) &&
                   !string.IsNullOrWhiteSpace(clienteActual.Contraseña);
        }
    }
}