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

        // 1. Declara el panel y botones al inicio de la clase
        private Panel panelPrincipal = null!;
        private Button btnPrincipalAdmin = null!;
        private Button btnPrincipalTecnico = null!;
        private Button btnPrincipalCliente = null!;
        private LinkLabel LinkCuentaNueva = null!;
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
        private Button btnLateralCerrarSesion = null!;

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

        private Panel panelTecnico = null!;
        private ListView listViewTecnicoTickets = null!;
        private Button btnTecnicoAtender = null!;
        private Button btnTecnicoVerCliente = null!;
        private Button btnTecnicoVolver = null!;
        private Label lblTecnicoTitulo = null!;

        // Panel de login para técnico
        private Panel panelLoginTecnico = null!;
        private TextBox txtTecnicoUsuario = null!;
        private TextBox txtTecnicoContraseña = null!;
        private Button btnTecnicoLogin = null!;

        // Panel lateral para técnico
        private Panel panelMenuLateralTecnico = null!;
        private Button btnLateralTecnicoTickets = null!;
        private Button btnLateralTecnicoCerrarSesion = null!;

        private Button btnLateralTecnicoHistorial = null!;
        private Button btnLateralTecnicoAcerca = null!;
        private Button btnLateralTecnicoActualizar = null!;

        // Paneles para funcionalidades del técnico
        private Panel panelHistorial = null!;
        private Panel panelAcerca = null!;
        private Panel panelInicioTecnico = null!;
        private Label lblInicioTecnicoResumen = null!;
        private ListView listViewPendientes = null!;
        private ListView listViewResueltos = null!;
        private Button btnInicioTecnicoVolver = null!;

        //Seguimiento de envios
        private Button btnLateralSeguimientos = null!;
        private Panel panelSeguimientos = null!;
        private DataGridView dgvSeguimientos = null!;
        private Button btnSeguimientosVolver = null!;


        //PANEL PARA EL ADMINISTRDOR
        private Panel panelAdminLogin = null!;
        private Panel panelAdministrador = null!;
        private TextBox txtAdminUsuario = null!;
        private TextBox txtAdminContraseña = null!;


        //Panel para registrarse
        private Panel panelRegistro = null!;
        private TextBox txtRegUsuario = null!;
        private TextBox txtRegNombre = null!;
        private TextBox txtRegApellido = null!;
        private TextBox txtRegDNI = null!;
        private TextBox txtRegCalle = null!;
        private TextBox txtRegNumeroCalle = null!;
        private TextBox txtRegProvincia = null!;
        private TextBox txtRegEmail = null!;
        private TextBox txtRegTelefono = null!;
        private TextBox txtRegContraseña = null!;
        private Button btnRegistrar = null!;
        private Button btnCancelarRegistro = null!;



        public Form1()
        {
            InitializeComponent();
            InicializarPanelesAdministrador(); // <-- Agrega esta línea aquí
            InicializarPanelesAdminExtras();
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

            panelPrincipal = new Panel
            {
                Size = new Size(500, 300),
                BackColor = Color.White,
                Location = new Point((this.ClientSize.Width - 500) / 2, (this.ClientSize.Height - 300) / 2),
                Anchor = AnchorStyles.None
            };
            btnPrincipalAdmin = new Button
            {
                Text = "Administrador",
                Top = 40,
                Left = 150,
                Width = 200,
                Height = 50,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnPrincipalTecnico = new Button
            {
                Text = "Técnico",
                Top = 120,
                Left = 150,
                Width = 200,
                Height = 50,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnPrincipalCliente = new Button
            {
                Text = "Cliente",
                Top = 200,
                Left = 150,
                Width = 200,
                Height = 50,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            LinkCuentaNueva = new LinkLabel
            {
                Text = "¿No tienes cuenta? Crea una aquí",
                Top = 260,
                Left = 220,
                Width = 220,
                Font = new Font("Segoe UI", 10, FontStyle.Underline),
                LinkColor = Color.Blue,
                Cursor = Cursors.Hand
            };

            //panel de lick de la cuenta
            panelRegistro = new Panel
            {
                Size = new Size(450, 600),
                BackColor = Color.White,
                Visible = false
            };
            txtRegUsuario = new TextBox { PlaceholderText = "Usuario", Top = 30, Left = 100, Width = 250 };
            txtRegNombre = new TextBox { PlaceholderText = "Nombre", Top = 80, Left = 100, Width = 250 };
            txtRegApellido = new TextBox { PlaceholderText = "Apellido", Top = 130, Left = 100, Width = 250 };
            txtRegDNI = new TextBox { PlaceholderText = "DNI", Top = 180, Left = 100, Width = 250 };
            txtRegCalle = new TextBox { PlaceholderText = "Calle", Top = 230, Left = 100, Width = 250 };
            txtRegNumeroCalle = new TextBox { PlaceholderText = "Número", Top = 280, Left = 100, Width = 250 };
            txtRegProvincia = new TextBox { PlaceholderText = "Provincia", Top = 330, Left = 100, Width = 250 };
            txtRegEmail = new TextBox { PlaceholderText = "Email", Top = 380, Left = 100, Width = 250 };
            txtRegTelefono = new TextBox { PlaceholderText = "Teléfono", Top = 430, Left = 100, Width = 250 };
            txtRegContraseña = new TextBox { PlaceholderText = "Contraseña", Top = 480, Left = 100, Width = 250, UseSystemPasswordChar = true };

            btnRegistrar = new Button
            {
                Text = "Registrar",
                Top = 510,
                Left = 100,
                Width = 250,
                Height = 40,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White
            };
            btnRegistrar.Click += BtnRegistrar_Click;

            btnCancelarRegistro = new Button
            {
                Text = "Cancelar",
                Top = 550,
                Left = 100,
                Width = 250,
                Height = 40,
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnCancelarRegistro.Click += (s, e) =>
            {
                panelAviso.Visible = false;
                panelRegistro.Visible = false;
                panelPrincipal.Visible = true;
            };

            panelRegistro.Controls.AddRange(new Control[]
            {
    txtRegUsuario, txtRegNombre, txtRegApellido, txtRegDNI, txtRegCalle, txtRegNumeroCalle,
    txtRegProvincia, txtRegEmail, txtRegTelefono, txtRegContraseña, btnRegistrar, btnCancelarRegistro
            });
            this.Controls.Add(panelRegistro);

            // Asigna los eventos Click
            btnPrincipalAdmin.Click += (s, e) => MostrarPanelAdministrador();
            btnPrincipalTecnico.Click += (s, e) => MostrarPanelTecnico();
            btnPrincipalCliente.Click += (s, e) => MostrarPanelCliente();
            LinkCuentaNueva.Click += (s, e) => MostrarPanelRegistro();

            panelPrincipal.Controls.AddRange(new Control[] { btnPrincipalAdmin, btnPrincipalTecnico, btnPrincipalCliente });
            this.Controls.Add(panelPrincipal);

            //BOTON PARA CERRAR SESION DEL CLIENTE

            btnLateralCerrarSesion = new Button
            {
                Text = "Cerrar Sesión",
                Top = 390, // Ajusta la posición según tus otros botones
                Left = 10,
                Width = 200,
                Height = 45,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnLateralCerrarSesion.Click += (s, e) => CerrarSesionCliente();
            // Panel Técnico
            panelTecnico = new Panel
            {
                Size = new Size(700, 450),
                BackColor = Color.White,
                Visible = false
            };
            lblTecnicoTitulo = new Label
            {
                Text = "Tickets de Soporte - Técnico",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31),
                Top = 20,
                Left = 30,
                Width = 500
            };
            listViewTecnicoTickets = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 70,
                Left = 30,
                Width = 620,
                Height = 250
            };
            listViewTecnicoTickets.Columns.Add("Fecha", 140);
            listViewTecnicoTickets.Columns.Add("Cliente", 180);
            listViewTecnicoTickets.Columns.Add("Mensaje", 280);
            listViewTecnicoTickets.Columns.Add("Atendido", 80);

            btnTecnicoAtender = new Button
            {
                Text = "Marcar como Atendido",
                Top = 340,
                Left = 30,
                Width = 200,
                Height = 40,
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White
            };
            btnTecnicoAtender.Click += BtnTecnicoAtender_Click;

            btnTecnicoVerCliente = new Button
            {
                Text = "Ver Cliente",
                Top = 340,
                Left = 250,
                Width = 150,
                Height = 40,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White
            };
            btnTecnicoVerCliente.Click += BtnTecnicoVerCliente_Click;

            btnTecnicoVolver = new Button
            {
                Text = "Volver",
                Top = 340,
                Left = 420,
                Width = 120,
                Height = 40,
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnTecnicoVolver.Click += (s, e) =>
            {
                panelTecnico.Visible = false;
                panelPrincipal.Visible = true;
                panelMenuLateral.Visible = false;
            };

            panelTecnico.Controls.AddRange(new Control[] { lblTecnicoTitulo, listViewTecnicoTickets, btnTecnicoAtender, btnTecnicoVerCliente, btnTecnicoVolver });
            this.Controls.Add(panelTecnico);

            // Panel de login para técnico
            panelLoginTecnico = new Panel
            {
                Size = new Size(400, 300),
                BackColor = Color.White,
                Visible = false
            };
            txtTecnicoUsuario = new TextBox
            {
                PlaceholderText = "Usuario Técnico",
                Width = 250,
                Left = 75,
                Top = 60
            };
            txtTecnicoContraseña = new TextBox
            {
                PlaceholderText = "Contraseña",
                Width = 250,
                Left = 75,
                Top = 120,
                UseSystemPasswordChar = true
            };
            btnTecnicoLogin = new Button
            {
                Text = "Entrar",
                Width = 250,
                Height = 40,
                Left = 75,
                Top = 180,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White
            };
            btnTecnicoLogin.Click += BtnTecnicoLogin_Click;
            panelLoginTecnico.Controls.AddRange(new Control[] { txtTecnicoUsuario, txtTecnicoContraseña, btnTecnicoLogin });
            this.Controls.Add(panelLoginTecnico);

            // Panel lateral para técnico
            panelMenuLateralTecnico = new Panel
            {
                Size = new Size(220, this.ClientSize.Height - panelHeader.Height),
                BackColor = Color.FromArgb(245, 245, 245),
                Left = 0,
                Top = panelHeader.Height,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
                Visible = false
            };

            btnLateralTecnicoTickets = new Button
            {
                Text = "Ver Tickets",
                Top = 50,
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
            btnLateralTecnicoTickets.Click += (s, e) => MostrarPanelTecnicoTickets();



            panelSeguimientos = new Panel
            {
                Size = new Size(670, 420),
                BackColor = Color.White,
                Visible = false
            };

            dgvSeguimientos = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 300,
                Width = 780,
                Left = 10,
                Top = 10,
                AllowUserToAddRows = false,
                ReadOnly = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvSeguimientos.Columns.Add("NumeroSeguimiento", "Seguimiento");
            dgvSeguimientos.Columns.Add("Cliente", "Cliente");
            dgvSeguimientos.Columns.Add("Estado", "Estado");
            dgvSeguimientos.CellValueChanged += DgvSeguimientos_CellValueChanged;
            dgvSeguimientos.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvSeguimientos.IsCurrentCellDirty)
                    dgvSeguimientos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            var estadoCol = new DataGridViewComboBoxColumn
            {
                Name = "EstadoCombo",
                HeaderText = "Cambiar Estado",
                DataSource = Enum.GetNames(typeof(EstadoPedido))
            };
            dgvSeguimientos.Columns.Add(estadoCol);

            btnSeguimientosVolver = new Button
            {
                Text = "Volver",
                Width = 120,
                Height = 40,
                Top = 320,
                Left = 340,
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnSeguimientosVolver.Click += (s, e) =>
            {
                panelSeguimientos.Visible = false;
                CentrarPanel(panelTecnico);
                panelTecnico.BringToFront();
            };

            panelSeguimientos.Controls.Add(dgvSeguimientos);
            panelSeguimientos.Controls.Add(btnSeguimientosVolver);
            this.Controls.Add(panelSeguimientos);
            // Panel Historial
            panelHistorial = new Panel
            {
                Size = new Size(900, 600),
                BackColor = Color.FromArgb(250, 250, 250), // Color más claro para diferenciarlo
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            var lblHistorial = new Label
            {
                Text = "Historial de Tickets de Clientes",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31),
                Top = 30,
                Left = 30,
                Width = 800
            };
            var listViewHistorial = new ListView
            {
                Name = "listViewHistorial",
                View = View.Details,
                FullRowSelect = true,
                Top = 80,
                Left = 30,
                Width = 820,
                Height = 400
            };
            listViewHistorial.Columns.Add("Fecha", 120);
            listViewHistorial.Columns.Add("Cliente", 180);
            listViewHistorial.Columns.Add("Email", 200);
            listViewHistorial.Columns.Add("Mensaje", 300);
            var btnHistorialVolver = new Button
            {
                Text = "Volver",
                Top = 500,
                Left = 380,
                Width = 140,
                Height = 50,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            // Panel Inicio Técnico
            panelInicioTecnico = new Panel
            {
                Size = new Size(900, 600),
                BackColor = Color.FromArgb(245, 245, 245),
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            lblInicioTecnicoResumen = new Label
            {
                Text = "Resumen de Tickets",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31),
                Top = 30,
                Left = 30,
                Width = 800
            };
            var lblPendientes = new Label
            {
                Text = "Tickets Pendientes",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Top = 90,
                Left = 30,
                Width = 300
            };
            listViewPendientes = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 120,
                Left = 30,
                Width = 400,
                Height = 350,
                Name = "listViewPendientes"
            };
            listViewPendientes.Columns.Add("Fecha", 120);
            listViewPendientes.Columns.Add("Cliente", 120);
            listViewPendientes.Columns.Add("Mensaje", 150);

            var lblResueltos = new Label
            {
                Text = "Tickets Resueltos",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Top = 90,
                Left = 470,
                Width = 300
            };
            listViewResueltos = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 120,
                Left = 470,
                Width = 400,
                Height = 350,
                Name = "listViewResueltos"
            };
            listViewResueltos.Columns.Add("Fecha", 120);
            listViewResueltos.Columns.Add("Cliente", 120);
            listViewResueltos.Columns.Add("Mensaje", 150);

            btnInicioTecnicoVolver = new Button
            {
                Text = "Volver",
                Top = 500,
                Left = 380,
                Width = 140,
                Height = 50,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnInicioTecnicoVolver.Click += (s, e) =>
            {
                panelInicioTecnico.Visible = false;
                panelTecnico.Visible = true;
                CentrarPanel(panelTecnico);
            };
            var btnLateralTecnicoInicio = new Button
            {
                Text = "Inicio",
                Top = 10,
                Left = 10,
                Width = 200,
                Height = 35,
                BackColor = Color.FromArgb(220, 36, 31), 
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnLateralTecnicoInicio.Click += (s, e) => MostrarPanelInicioTecnico();
            panelMenuLateralTecnico.Controls.Add(btnLateralTecnicoInicio);

            panelInicioTecnico.Controls.AddRange(new Control[] {
    lblInicioTecnicoResumen, lblPendientes, listViewPendientes, lblResueltos, listViewResueltos, btnInicioTecnicoVolver
});
            this.Controls.Add(panelInicioTecnico);
            btnHistorialVolver.Click += (s, e) => panelHistorial.Visible = false;
            panelHistorial.Controls.AddRange(new Control[] { lblHistorial, listViewHistorial, btnHistorialVolver });
            this.Controls.Add(panelHistorial);
            // Panel Acerca de
            panelAcerca = new Panel
            {
                Size = new Size(400, 250),
                BackColor = Color.White,
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            var lblAcerca = new Label
            {
                Text = "Sistema de gestión de paquetería\nVersión 1.0\nDesarrollado por el equipo.",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(158, 158, 158),
                Top = 30,
                Left = 30,
                Width = 340,
                Height = 100
            };
            var btnAcercaVolver = new Button
            {
                Text = "Volver",
                Top = 150,
                Left = 140,
                Width = 120,
                Height = 40,
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnAcercaVolver.Click += (s, e) => panelAcerca.Visible = false;
            panelAcerca.Controls.AddRange(new Control[] { lblAcerca, btnAcercaVolver });
            this.Controls.Add(panelAcerca);

            btnLateralTecnicoHistorial = new Button
            {
                Text = "Historial de Tickets",
                Top = 105,
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
            btnLateralTecnicoHistorial.Click += (s, e) => MostrarPanelHistorial();
            btnLateralTecnicoAcerca = new Button
            {
                Text = "Acerca de",
                Top = 155,
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
            btnLateralTecnicoAcerca.Click += (s, e) => MostrarAviso("Acerca de", "Sistema de gestión de paquetería.\nVersión 1.0\nDesarrollado por el equipo.");

            btnLateralTecnicoActualizar = new Button
            {
                Text = "Seguimientos",
                Top = 205,
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
            btnLateralTecnicoActualizar.Click += (s, e) => MostrarPanelSeguimientos();

            btnLateralTecnicoCerrarSesion = new Button
            {
                Text = "Cerrar Sesión",
                Top = 255,
                Left = 10,
                Width = 200,
                Height = 45,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnLateralTecnicoCerrarSesion.Click += (s, e) => CerrarSesionTecnico();

            panelMenuLateralTecnico.Controls.AddRange(new Control[] {
                btnLateralTecnicoTickets,
                btnLateralTecnicoHistorial,
                btnLateralTecnicoAcerca,
                btnLateralTecnicoActualizar,
                btnLateralTecnicoCerrarSesion
            });
            this.Controls.Add(panelMenuLateralTecnico);

            panelMenuLateralTecnico.Controls.AddRange(new Control[] { btnLateralTecnicoTickets, btnLateralTecnicoCerrarSesion });



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
            btnLateralPreguntas, btnLateralSucursales, btnLateralAyuda,
            btnLateralCerrarSesion, btnLateralSeguimientos // <-- Agregado aquí
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
            panelLogin.Controls.Add(LinkCuentaNueva);
            LinkCuentaNueva.Top = btnLoginEntrar.Bottom + 20;
            LinkCuentaNueva.Left = btnLoginEntrar.Left;

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

            panelPrincipal.Visible = true;
            panelMenuLateral.Visible = false; 
            panelLogin.Visible = false;
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
        }

        private void MostrarPanelCliente()
        {
            panelPrincipal.Visible = false;
            panelMenuLateral.Visible = false; 
            panelLogin.Visible = true;
            CentrarPanel(panelLogin);
        }

        private void MostrarPanelTecnico()
        {
            panelPrincipal.Visible = false;
            panelMenuLateral.Visible = false;
            panelMenuLateralTecnico.Visible = false;
            panelTecnico.Visible = false;
            OcultarPanelesTecnico();
            panelLoginTecnico.Visible = true;
            CentrarPanel(panelLoginTecnico);
            panelLoginTecnico.BringToFront();
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
                case "SEGUIMIENTOS":
                    MostrarPanelSeguimientos();
                    break;

                default:
                    break;
            }
        }

        private void CentrarPanel(Panel panel)
        {
            if (!this.Controls.Contains(panel))
            {
                this.Controls.Add(panel);
            }
            // Logic to center the panel
            panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2);
            this.Resize += (s, e) =>
            {
                panel.Location = new Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2);
            };
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

        //Login del Usuario 
        private void BtnLoginEntrar_Click(object? sender, EventArgs e)
        {
            if (txtLoginNombre.Text != "" && txtLoginContraseña.Text != "")
            {
                bool loginCorrecto = pInicio.Validar(txtLoginNombre.Text, txtLoginContraseña.Text);
                if (loginCorrecto)
                {

                    lblUsuario.Text = $"Bienvenido, {txtLoginNombre.Text}";
                    panelMenuLateral.Visible = true;
                    panelLogin.Visible = false;
                    panelMenu.Visible = true;
                    CentrarPanel(panelMenu);
                    clienteActual = new Cliente
                    {
                        Usuario = txtLoginNombre.Text,
                        Contraseña = txtLoginContraseña.Text
                    };
                }
            }
            else
            {
                MostrarAviso("Datos requeridos", "Debe completar todos los campos para ingresar.");
                return;
            }
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

            // Cambia aquí: usa ConsultaSoporteExtendido
            var consulta = new ConsultaSoporteExtendido
            {
                NombreCliente = $"{clienteActual?.Nombre} {clienteActual?.Apellido}",
                Email = clienteActual?.Email ?? "",
                Mensaje = txtSoporteMensaje.Text,
                Fecha = DateTime.Now,
                Atendido = false // Nuevo ticket, no atendido
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

        private void CargarTicketsTecnico()
        {
            listViewTecnicoTickets.Items.Clear();
            foreach (var ticket in consultasSoporte)
            {
                // Puedes agregar una propiedad "Atendido" a ConsultaSoporte si lo deseas
                string atendido = ticket is ConsultaSoporteExtendido ext && ext.Atendido ? "Sí" : "No";
                var item = new ListViewItem(new[]
                {
            ticket.Fecha.ToString("dd/MM/yyyy HH:mm"),
            ticket.NombreCliente,
            ticket.Mensaje,
            atendido
        });
                item.Tag = ticket;
                listViewTecnicoTickets.Items.Add(item);
            }
        }

        private void BtnTecnicoAtender_Click(object? sender, EventArgs e)
        {
            if (listViewTecnicoTickets.SelectedItems.Count == 0)
            {
                MostrarAviso("Atención", "Seleccione un ticket para marcar como atendido.");
                return;
            }
            var item = listViewTecnicoTickets.SelectedItems[0];
            if (item.Tag is ConsultaSoporteExtendido ticket)
            {
                ticket.Atendido = true;
                CargarTicketsTecnico();
                MostrarAviso("Ticket atendido", "El ticket fue marcado como atendido.");
            }
            else
            {
                MostrarAviso("Error", "No se pudo marcar el ticket.");
            }
        }

        private void BtnTecnicoVerCliente_Click(object? sender, EventArgs e)
        {
            if (listViewTecnicoTickets.SelectedItems.Count == 0)
            {
                MostrarAviso("Atención", "Seleccione un ticket para ver el cliente.");
                return;
            }
            var item = listViewTecnicoTickets.SelectedItems[0];
            if (item.Tag is ConsultaSoporte ticket)
            {
                // 1. Buscar en la base de datos
                var cliente = TP4_LEANDRO.Controladores.pInicio.BuscarClientePorEmailONombre(ticket.Email, ticket.NombreCliente);

                // 2. Si no encuentra, buscar en la lista de pedidos en memoria
                if (cliente == null)
                {
                    cliente = pedidos.Select(p => p.Cliente)
                        .FirstOrDefault(c =>
                            (!string.IsNullOrEmpty(ticket.Email) && c.Email == ticket.Email) ||
                            (!string.IsNullOrEmpty(ticket.NombreCliente) && $"{c.Nombre} {c.Apellido}" == ticket.NombreCliente)
                        );
                }

                if (cliente != null)
                {
                    string detalles = $"Nombre: {cliente.Nombre}\n" +
                                      $"Apellido: {cliente.Apellido}\n" +
                                      $"DNI: {cliente.DNI}\n" +
                                      $"Email: {cliente.Email}\n" +
                                      $"Teléfono: {cliente.Telefono}\n" +
                                      $"Dirección: {cliente.Calle} {cliente.NumeroCalle}, {cliente.Provincia}";
                    MostrarAviso("Datos del Cliente", detalles);
                }
                else
                {
                    MostrarAviso("No encontrado", "No se encontró el cliente.");
                }
            }
        }
        public class ConsultaSoporteExtendido : ConsultaSoporte
        {
            public bool Atendido { get; set; }
        }

        //Login Tecnico 

        private void BtnTecnicoLogin_Click(object? sender, EventArgs e)
        {
            if (txtTecnicoUsuario.Text != "" && txtTecnicoContraseña.Text != "")
            {
                bool loginCorrecto = pInicio.Validar(txtTecnicoUsuario.Text, txtTecnicoContraseña.Text);
                if (loginCorrecto)
                {
                    panelLoginTecnico.Visible = false;
                    panelMenuLateralTecnico.Visible = true;
                    panelTecnico.Visible = true;
                    CentrarPanel(panelTecnico);
                    CargarTicketsTecnico(); 
                }
            }
            else
            {
                // Ajustar tamaño y posición del panelAviso antes de crear el botón
                panelAviso.Size = panelLoginTecnico.Size;
                panelAviso.Location = panelLoginTecnico.Location;
                panelAviso.BringToFront();

                lblAvisoTitulo.Text = "Error de inicio de sesión";
                lblAvisoMensaje.Text = "Usuario o Contraseña Incorrectos.";
                btnAvisoCerrar.Visible = false;

                // Buscar o crear el botón "Volver"
                Button? btnVolver = null;
                foreach (Control ctrl in panelAviso.Controls)
                {
                    if (ctrl is Button btn && btn.Name == "btnVolverAviso")
                    {
                        btnVolver = btn;
                        break;
                    }
                }

                if (btnVolver == null)
                {
                    btnVolver = new Button
                    {
                        Name = "btnVolverAviso",
                        Text = "Volver",
                        Width = 160,
                        Height = 50,
                        BackColor = Color.Gray,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold)
                    };
                    btnVolver.Click += (s, ev) =>
                    {
                        panelAviso.Visible = false;
                        btnAvisoCerrar.Visible = true;
                    };
                    panelAviso.Controls.Add(btnVolver);
                }

                // Siempre ajustar la posición antes de mostrar
                btnVolver.Top = panelAviso.Height - btnVolver.Height - 20;
                btnVolver.Left = (panelAviso.Width - btnVolver.Width) / 2;
                btnVolver.Visible = true;

                // Traer el botón al frente
                panelAviso.Controls.SetChildIndex(btnVolver, panelAviso.Controls.Count - 1);

                // Forzar repintado
                btnVolver.BringToFront();
                panelAviso.Refresh();

                panelAviso.Visible = true;
            }
        }

        private void MostrarPanelTecnicoTickets()
        {
            OcultarPanelesTecnico();
            panelTecnico.Visible = true;
            CentrarPanel(panelTecnico);
            panelTecnico.BringToFront();
            CargarTicketsTecnico();
        }
        

        private void CerrarSesionTecnico()
        {
            panelMenuLateralTecnico.Visible = false;
            OcultarTodosLosPaneles();
            panelPrincipal.Visible = true;
        }
        private void MostrarPanelHistorial()
        {
            OcultarPanelesTecnico();
            var listView = panelHistorial.Controls["listViewHistorial"] as ListView;
            if (listView == null) return;

            listView.Items.Clear();
            foreach (var ticket in consultasSoporte)
            {
                var item = new ListViewItem(new[]
                {
            ticket.Fecha.ToString("dd/MM/yyyy HH:mm"),
            ticket.NombreCliente,
            ticket.Email,
            ticket.Mensaje
        });
                listView.Items.Add(item);
            }
            panelHistorial.Visible = true;
            panelHistorial.BringToFront();
            CentrarPanel(panelHistorial);
        }
        private void MostrarPanelAcerca()
        {
            OcultarPanelesTecnico();
            panelAcerca.Visible = true;
            CentrarPanel(panelAcerca);
            panelAcerca.BringToFront();
        }

        private void MostrarPanelInicioTecnico()
        {
            OcultarPanelesTecnico();
            // Resumen
            int pendientes = consultasSoporte.OfType<ConsultaSoporteExtendido>().Count(t => !t.Atendido);
            int resueltos = consultasSoporte.OfType<ConsultaSoporteExtendido>().Count(t => t.Atendido);
            lblInicioTecnicoResumen.Text = $"Resumen de Tickets - Pendientes: {pendientes} | Resueltos: {resueltos}";

            // Llenar pendientes
            listViewPendientes.Items.Clear();
            foreach (var ticket in consultasSoporte.OfType<ConsultaSoporteExtendido>().Where(t => !t.Atendido))
            {
                var item = new ListViewItem(new[]
                {
            ticket.Fecha.ToString("dd/MM/yyyy HH:mm"),
            ticket.NombreCliente,
            ticket.Mensaje
        });
                listViewPendientes.Items.Add(item);
            }

            // Llenar resueltos
            listViewResueltos.Items.Clear();
            foreach (var ticket in consultasSoporte.OfType<ConsultaSoporteExtendido>().Where(t => t.Atendido))
            {
                var item = new ListViewItem(new[]
                {
            ticket.Fecha.ToString("dd/MM/yyyy HH:mm"),
            ticket.NombreCliente,
            ticket.Mensaje
        });
                listViewResueltos.Items.Add(item);
            }
            panelInicioTecnico.Visible = true;
            CentrarPanel(panelInicioTecnico);
            panelInicioTecnico.BringToFront();
        }
        private void CerrarSesionCliente()
        {
            panelMenuLateral.Visible = false;
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;
            panelLogin.Visible = false; // <-- Esto oculta el login del cliente
            panelPrincipal.Visible = true;
            clienteActual = null;
            lblUsuario.Text = "Bienvenido";
        }
        private void MostrarPanelSeguimientos()
        {
            dgvSeguimientos.Rows.Clear();
            foreach (var pedido in pedidos)
            {
                int rowIndex = dgvSeguimientos.Rows.Add(
                    pedido.NumeroSeguimiento,
                    $"{pedido.Cliente.Nombre} {pedido.Cliente.Usuario}",
                    pedido.Estado.ToString(),
                    pedido.Estado.ToString()
                );
                dgvSeguimientos.Rows[rowIndex].Tag = pedido;
            }
            OcultarPanelesTecnico(); // Oculta todos los paneles técnicos
            panelSeguimientos.Visible = true;
            CentrarPanel(panelSeguimientos);
            panelSeguimientos.BringToFront();
        }

        private void DgvSeguimientos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSeguimientos.Columns[e.ColumnIndex].Name == "EstadoCombo")
            {
                var row = dgvSeguimientos.Rows[e.RowIndex];
                var pedido = row.Tag as Pedido;
                if (pedido != null)
                {
                    var nuevoEstadoStr = row.Cells["EstadoCombo"].Value?.ToString();
                    if (Enum.TryParse<EstadoPedido>(nuevoEstadoStr, out var nuevoEstado))
                    {
                        pedido.Estado = nuevoEstado;
                        row.Cells["Estado"].Value = nuevoEstado.ToString();
                    }
                }
            }
        }
        private void OcultarPanelesTecnico()
        {
            panelTecnico.Visible = false;
            panelInicioTecnico.Visible = false;
            panelHistorial.Visible = false;
            panelAcerca.Visible = false;
        }

        private void MostrarPanelAdministrador()
        {
            // Oculta todos los paneles principales y laterales
            panelPrincipal.Visible = false;
            panelMenuLateral.Visible = false;
            panelMenuLateralTecnico.Visible = false;
            panelMenuLateralAdmin.Visible = false;
            panelAdministrador.Visible = false;

            // Muestra solo el login de admin
            panelAdminLogin.Visible = true;
            CentrarPanel(panelAdminLogin);
            panelAdminLogin.BringToFront();
        }

        // Este método ya lo tienes, pero para mostrar el panel principal del administrador después del login exitoso:
        private void MostrarPanelAdminPrincipal()
        {
            OcultarPanelesAdmin();
            panelAdminLogin.Visible = false;
            panelAdministrador.Visible = true;
            panelMenuLateralAdmin.Visible = true;
            CentrarPanel(panelAdministrador);
            panelAdministrador.BringToFront();
            CargarDatosAdmin();
        }

        private void MostrarPanelRegistro()
        {
            panelLogin.Visible = false;
            panelRegistro.Visible = true;
            CentrarPanel(panelRegistro);
        }

        //Login Admin
        private void BtnAdminEntrar_Click(object? sender, EventArgs e)
        {
            if (txtAdminUsuario.Text != "" && txtAdminContraseña.Text != "")
            {
                bool loginCorrecto = pInicio.ValidarAdmin_Tecn(txtAdminUsuario.Text, txtAdminContraseña.Text);
                if (loginCorrecto)
                {
                    MostrarPanelAdminPrincipal();
                }
            }
            else
            {
                MostrarAviso("Error", "Usuario o contraseña incorrectos.");
            }
        }
        private ListView listViewAdmin = null!;
        private Button btnVerClientes = null!;
        private Button btnVerTecnicos = null!;
        private Button btnAgregar = null!;
        private Button btnEditar = null!;
        private Button btnEliminar = null!;
        private Label lblAdminTitulo = null!;
        private bool mostrandoClientes = true;
        private Panel panelMenuLateralAdmin = null!;
        private Button btnAdminClientes = null!;
        private Button btnAdminTecnicos = null!;
        private Button btnAdminCerrarSesion = null!;

        private Panel panelAdminPedidos = null!;
        private Panel panelAdminAuditoria = null!;
        private Panel panelAdminDashboard = null!;
        private ListView listViewAdminPedidos = null!;
        private ListView listViewAdminAuditoria = null!;
        private Label lblDashboardPedidos = null!;
        private Label lblDashboardFinalizados = null!;
        private Label lblDashboardTicketsPendientes = null!;
        private Label lblDashboardTicketsAtendidos = null!;
        private Label lblDashboardTecnicos = null!;
        private ComboBox comboAsignarTecnico = null!;
        private Button btnAsignarTecnico = null!;
        private Button btnCambiarEstado = null!;

        // Para logs de auditoría
        private List<string> logsAuditoria = new();

        private List<Cliente> tecnicos = new();
        private void InicializarPanelesAdministrador()
        {

            // Panel de login de administrador (igual que antes)
            panelAdminLogin = new Panel
            {
                Size = new Size(400, 300),
                BackColor = Color.White,
                Visible = false
            };
            txtAdminUsuario = new TextBox
            {
                PlaceholderText = "Usuario Administrador",
                Width = 250,
                Left = 75,
                Top = 60
            };
            txtAdminContraseña = new TextBox
            {
                PlaceholderText = "Contraseña",
                Width = 250,
                Left = 75,
                Top = 120,
                UseSystemPasswordChar = true
            };

            var btnAdminEntrar = new Button
            {
                Text = "Entrar",
                Width = 250,
                Height = 40,
                Left = 75,
                Top = 180,
                BackColor = Color.FromArgb(220, 36, 31),
                ForeColor = Color.White
            };
            btnAdminEntrar.Click += BtnAdminEntrar_Click;
            panelAdminLogin.Controls.AddRange(new Control[] { txtAdminUsuario, txtAdminContraseña, btnAdminEntrar });
            this.Controls.Add(panelAdminLogin);

            // Panel lateral administrador
            panelMenuLateralAdmin = new Panel
            {
                Size = new Size(220, 500),
                BackColor = Color.FromArgb(245, 245, 245),
                Left = 0,
                Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
                Visible = false
            };

            btnAdminClientes = new Button
            {
                Text = "Clientes",
                Top = 50,
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
            btnAdminClientes.Click += (s, e) =>
            {
                mostrandoClientes = true;
                lblAdminTitulo.Text = "Administración de Clientes";
                CargarDatosAdmin();
            };

            btnAdminTecnicos = new Button
            {
                Text = "Técnicos",
                Top = 110,
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
            btnAdminTecnicos.Click += (s, e) =>
            {
                mostrandoClientes = false;
                lblAdminTitulo.Text = "Administración de Técnicos";
                CargarDatosAdmin();
            };

            btnAdminCerrarSesion = new Button
            {
                Text = "Cerrar Sesión",
                Top = 400,
                Left = 10,
                Width = 200,
                Height = 45,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnAdminCerrarSesion.Click += (s, e) =>
            {
                OcultarPanelesAdmin();
                panelMenuLateralAdmin.Visible = false;
                panelPrincipal.Visible = true;
            };

            panelMenuLateralAdmin.Controls.AddRange(new Control[] { btnAdminClientes, btnAdminTecnicos, btnAdminCerrarSesion });
            this.Controls.Add(panelMenuLateralAdmin);

            // Panel principal del administrador
            panelAdministrador = new Panel
            {
                Size = new Size(700, 500),
                BackColor = Color.White,
                Visible = false,
                Left = panelMenuLateralAdmin.Width,
                Top = 0
            };

            lblAdminTitulo = new Label
            {
                Text = "Administración de Clientes",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 36, 31),
                Top = 20,
                Left = 30,
                Width = 500
            };

            listViewAdmin = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 80,
                Left = 30,
                Width = 620,
                Height = 350
            };
            listViewAdmin.Columns.Add("ID", 50);
            listViewAdmin.Columns.Add("Usuario", 120);
            listViewAdmin.Columns.Add("Nombre", 120);
            listViewAdmin.Columns.Add("Apellido", 120);
            listViewAdmin.Columns.Add("Email", 180);

            panelAdministrador.Controls.AddRange(new Control[]
            {
        lblAdminTitulo, listViewAdmin
            });
            this.Controls.Add(panelAdministrador);

            // Botón Pedidos
            var btnAdminPedidos = new Button
            {
                Text = "Pedidos",
                Top = 170,
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
            btnAdminPedidos.Click += (s, e) => MostrarPanelAdminPedidos();
            panelMenuLateralAdmin.Controls.Add(btnAdminPedidos);

            // Botón Auditoría
            var btnAdminAuditoria = new Button
            {
                Text = "Auditoría",
                Top = 230,
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
            btnAdminAuditoria.Click += (s, e) => MostrarPanelAdminAuditoria();
            panelMenuLateralAdmin.Controls.Add(btnAdminAuditoria);

            // Botón Dashboard
            var btnAdminDashboard = new Button
            {
                Text = "Dashboard",
                Top = 290,
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
            btnAdminDashboard.Click += (s, e) => MostrarPanelAdminDashboard();
            panelMenuLateralAdmin.Controls.Add(btnAdminDashboard);
        }

        //Boton para registrarse 
        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtRegNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRegApellido.Text) ||
                string.IsNullOrWhiteSpace(txtRegDNI.Text) ||
                string.IsNullOrWhiteSpace(txtRegCalle.Text) ||
                string.IsNullOrWhiteSpace(txtRegNumeroCalle.Text) ||
                string.IsNullOrWhiteSpace(txtRegProvincia.Text) ||
                string.IsNullOrWhiteSpace(txtRegEmail.Text) ||
                string.IsNullOrWhiteSpace(txtRegTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtRegContraseña.Text))
            {
                MostrarAviso("Campos requeridos", "Debe completar todos los campos para registrarse.");
                panelAviso.BringToFront();
                return;
            }

            var nuevoCliente = new Cliente
            {
                Usuario = txtRegUsuario.Text,
                Nombre = txtRegNombre.Text,
                Apellido = txtRegApellido.Text,
                DNI = txtRegDNI.Text,
                Calle = txtRegCalle.Text,
                NumeroCalle = txtRegNumeroCalle.Text,
                Provincia = txtRegProvincia.Text,
                Email = txtRegEmail.Text,
                Telefono = txtRegTelefono.Text,
                Contraseña = txtRegContraseña.Text,
                Es_Admin = false
            };

            // Guarda el cliente en la base de datos
            pInicio.InsertarCliente(nuevoCliente);

            MostrarAviso("Registro exitoso", "¡Cuenta creada correctamente! Ahora puede iniciar sesión.");
            panelRegistro.Visible = false;
            panelPrincipal.Visible = true;
        }
        private void CargarDatosAdmin()
        {
            listViewAdmin.Items.Clear();
            if (mostrandoClientes)
            {
                foreach (var c in pedidos.Select(p => p.Cliente).Where(c => !c.Es_Admin).DistinctBy(c => c.ID))
                {
                    var item = new ListViewItem(new[]
                    {
                c.ID.ToString(),
                c.Usuario,
                c.Nombre,
                c.Apellido,
                c.Email
            });
                    item.Tag = c;
                    listViewAdmin.Items.Add(item);
                }
            }
            else
            {
                foreach (var t in tecnicos)
                {
                    var item = new ListViewItem(new[]
                    {
                t.ID.ToString(),
                t.Usuario,
                t.Nombre,
                t.Apellido,
                t.Email
            });
                    item.Tag = t;
                    listViewAdmin.Items.Add(item);
                }
            }
        }
        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            var form = new Form
            {
                Text = mostrandoClientes ? "Agregar Cliente" : "Agregar Técnico",
                Size = new Size(350, 400),
                StartPosition = FormStartPosition.CenterParent
            };
            var txtUsuario = new TextBox { PlaceholderText = "Usuario", Top = 20, Left = 30, Width = 250 };
            var txtNombre = new TextBox { PlaceholderText = "Nombre", Top = 60, Left = 30, Width = 250 };
            var txtApellido = new TextBox { PlaceholderText = "Apellido", Top = 100, Left = 30, Width = 250 };
            var txtEmail = new TextBox { PlaceholderText = "Email", Top = 140, Left = 30, Width = 250 };
            var txtContraseña = new TextBox { PlaceholderText = "Contraseña", Top = 180, Left = 30, Width = 250, UseSystemPasswordChar = true };
            var btnAceptar = new Button { Text = "Aceptar", Top = 240, Left = 30, Width = 100, Height = 35, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White };
            var btnCancelar = new Button { Text = "Cancelar", Top = 240, Left = 180, Width = 100, Height = 35, BackColor = Color.Gray, ForeColor = Color.White };
            btnCancelar.Click += (s, ev) => form.Close();
            btnAceptar.Click += (s, ev) =>
            {
                var nuevo = new Cliente
                {
                    ID = new Random().Next(1000, 9999),
                    Usuario = txtUsuario.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Contraseña = txtContraseña.Text,
                    Es_Admin = false
                };
                if (mostrandoClientes)
                {
                    // Aquí deberías agregar a la base de datos o lista real de clientes
                    // Ejemplo: clientes.Add(nuevo);
                }
                else
                {
                    tecnicos.Add(nuevo);
                }
                form.Close();
                CargarDatosAdmin();
            };
            form.Controls.AddRange(new Control[] { txtUsuario, txtNombre, txtApellido, txtEmail, txtContraseña, btnAceptar, btnCancelar });
            form.ShowDialog();
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (listViewAdmin.SelectedItems.Count == 0) return;
            var seleccionado = listViewAdmin.SelectedItems[0].Tag as Cliente;
            if (seleccionado == null) return;

            var form = new Form
            {
                Text = mostrandoClientes ? "Editar Cliente" : "Editar Técnico",
                Size = new Size(350, 400),
                StartPosition = FormStartPosition.CenterParent
            };
            var txtUsuario = new TextBox { Text = seleccionado.Usuario, Top = 20, Left = 30, Width = 250 };
            var txtNombre = new TextBox { Text = seleccionado.Nombre, Top = 60, Left = 30, Width = 250 };
            var txtApellido = new TextBox { Text = seleccionado.Apellido, Top = 100, Left = 30, Width = 250 };
            var txtEmail = new TextBox { Text = seleccionado.Email, Top = 140, Left = 30, Width = 250 };
            var txtContraseña = new TextBox { Text = seleccionado.Contraseña, Top = 180, Left = 30, Width = 250, UseSystemPasswordChar = true };
            var btnAceptar = new Button { Text = "Aceptar", Top = 240, Left = 30, Width = 100, Height = 35, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White };
            var btnCancelar = new Button { Text = "Cancelar", Top = 240, Left = 180, Width = 100, Height = 35, BackColor = Color.Gray, ForeColor = Color.White };
            btnCancelar.Click += (s, ev) => form.Close();
            btnAceptar.Click += (s, ev) =>
            {
                seleccionado.Usuario = txtUsuario.Text;
                seleccionado.Nombre = txtNombre.Text;
                seleccionado.Apellido = txtApellido.Text;
                seleccionado.Email = txtEmail.Text;
                seleccionado.Contraseña = txtContraseña.Text;
                form.Close();
                CargarDatosAdmin();
            };
            form.Controls.AddRange(new Control[] { txtUsuario, txtNombre, txtApellido, txtEmail, txtContraseña, btnAceptar, btnCancelar });
            form.ShowDialog();
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (listViewAdmin.SelectedItems.Count == 0) return;
            var seleccionado = listViewAdmin.SelectedItems[0].Tag as Cliente;
            if (seleccionado == null) return;
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (mostrandoClientes)
                {
                    // Eliminar de la lista real de clientes
                    // clientes.Remove(seleccionado);
                }
                else
                {
                    tecnicos.Remove(seleccionado);
                }
                CargarDatosAdmin();
            }
        }
        private void InicializarPanelesAdminExtras()
        {
            // Panel Pedidos
            panelAdminPedidos = new Panel
            {
                Size = new Size(700, 500),
                BackColor = Color.White,
                Visible = false,
                Left = panelMenuLateralAdmin.Width,
                Top = 0
            };
            listViewAdminPedidos = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 20,
                Left = 20,
                Width = 640,
                Height = 350
            };
            listViewAdminPedidos.Columns.Add("Seguimiento", 120);
            listViewAdminPedidos.Columns.Add("Fecha", 120);
            listViewAdminPedidos.Columns.Add("Estado", 100);
            listViewAdminPedidos.Columns.Add("Cliente", 150);
            listViewAdminPedidos.Columns.Add("Técnico", 120);

            comboAsignarTecnico = new ComboBox { Left = 20, Top = 380, Width = 200 };
            btnAsignarTecnico = new Button { Text = "Asignar Técnico", Left = 240, Top = 380, Width = 140 };
            btnCambiarEstado = new Button { Text = "Cambiar Estado", Left = 400, Top = 380, Width = 140 };

            // Eventos para asignar técnico y cambiar estado
            btnAsignarTecnico.Click += BtnAsignarTecnico_Click;
            btnCambiarEstado.Click += BtnCambiarEstado_Click;

            panelAdminPedidos.Controls.AddRange(new Control[] { listViewAdminPedidos, comboAsignarTecnico, btnAsignarTecnico, btnCambiarEstado });
            this.Controls.Add(panelAdminPedidos);

            // Panel Auditoría
            panelAdminAuditoria = new Panel
            {
                Size = new Size(700, 500),
                BackColor = Color.White,
                Visible = false,
                Left = panelMenuLateralAdmin.Width,
                Top = 0
            };
            listViewAdminAuditoria = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Top = 20,
                Left = 20,
                Width = 640,
                Height = 400
            };
            listViewAdminAuditoria.Columns.Add("Fecha", 150);
            listViewAdminAuditoria.Columns.Add("Usuario", 150);
            listViewAdminAuditoria.Columns.Add("Acción", 320);
            panelAdminAuditoria.Controls.Add(listViewAdminAuditoria);
            this.Controls.Add(panelAdminAuditoria);

            // Panel Dashboard
            panelAdminDashboard = new Panel
            {
                Size = new Size(700, 500),
                BackColor = Color.White,
                Visible = false,
                Left = panelMenuLateralAdmin.Width,
                Top = 0
            };
            lblDashboardPedidos = new Label { Left = 50, Top = 50, Width = 600, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(220, 36, 31) };
            lblDashboardFinalizados = new Label { Left = 50, Top = 100, Width = 600, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(220, 36, 31) };
            lblDashboardTicketsPendientes = new Label { Left = 50, Top = 150, Width = 600, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(220, 36, 31) };
            lblDashboardTicketsAtendidos = new Label { Left = 50, Top = 200, Width = 600, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(220, 36, 31) };
            lblDashboardTecnicos = new Label { Left = 50, Top = 250, Width = 600, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(220, 36, 31) };
            panelAdminDashboard.Controls.AddRange(new Control[] { lblDashboardPedidos, lblDashboardFinalizados, lblDashboardTicketsPendientes, lblDashboardTicketsAtendidos, lblDashboardTecnicos });
            this.Controls.Add(panelAdminDashboard);
        }
        private void MostrarPanelAdminPedidos()
        {
            OcultarPanelesAdmin();
            panelAdminPedidos.Visible = true;
            CentrarPanel(panelAdminPedidos);
            panelAdminPedidos.BringToFront();
            panelAdministrador.Visible = false;
            panelAdminAuditoria.Visible = false;
            panelAdminDashboard.Visible = false;

            // Cargar pedidos
            listViewAdminPedidos.Items.Clear();
            foreach (var pedido in pedidos)
            {
                var item = new ListViewItem(new[]
                {
            pedido.NumeroSeguimiento,
            pedido.Fecha.ToString("dd/MM/yyyy HH:mm"),
            pedido.Estado.ToString(),
            $"{pedido.Cliente.Nombre} {pedido.Cliente.Apellido}",
            ""
        });
                item.Tag = pedido;
                listViewAdminPedidos.Items.Add(item);
            }
            comboAsignarTecnico.Items.Clear();
            foreach (var t in tecnicos)
                comboAsignarTecnico.Items.Add($"{t.Nombre} {t.Apellido}");
        }

        private void MostrarPanelAdminAuditoria()
        {
            OcultarPanelesAdmin();
            CentrarPanel(panelAdminAuditoria);
            panelAdminAuditoria.Visible = true;
            panelAdminAuditoria.BringToFront();
            panelAdministrador.Visible = false;
            panelAdminPedidos.Visible = false;
            panelAdminDashboard.Visible = false;

            // Cargar logs
            listViewAdminAuditoria.Items.Clear();
            foreach (var log in logsAuditoria)
            {
                var partes = log.Split('|');
                if (partes.Length == 3)
                    listViewAdminAuditoria.Items.Add(new ListViewItem(partes));
            }
        }

        private void MostrarPanelAdminDashboard()
        {
            OcultarPanelesAdmin();
            CentrarPanel(panelAdminDashboard);
            panelAdministrador.Visible = false;
            panelAdminPedidos.Visible = false;
            panelAdminAuditoria.Visible = false;
            panelAdminDashboard.Visible = true;
            panelAdminDashboard.BringToFront();

            lblDashboardPedidos.Text = $"Pedidos totales: {pedidos.Count}";
            lblDashboardFinalizados.Text = $"Pedidos finalizados: {pedidos.Count(p => p.Estado == EstadoPedido.Finalizado)}";
            lblDashboardTicketsPendientes.Text = $"Tickets pendientes: {consultasSoporte.OfType<ConsultaSoporteExtendido>().Count(t => !t.Atendido)}";
            lblDashboardTicketsAtendidos.Text = $"Tickets atendidos: {consultasSoporte.OfType<ConsultaSoporteExtendido>().Count(t => t.Atendido)}";
            lblDashboardTecnicos.Text = $"Técnicos: {tecnicos.Count}";
        }

        private void BtnAsignarTecnico_Click(object? sender, EventArgs e)
        {
            // Aquí va la lógica para asignar técnico a un pedido
            // Por ejemplo, puedes mostrar un mensaje temporal:
            MessageBox.Show("Funcionalidad de asignar técnico aún no implementada.");
        }

        private void BtnCambiarEstado_Click(object? sender, EventArgs e)
        {
            // Aquí va la lógica para cambiar el estado de un pedido
            // Por ejemplo, puedes mostrar un mensaje temporal:
            MessageBox.Show("Funcionalidad de cambiar estado aún no implementada.");
        }

        // Agrega este método en tu clase Form1:
        private void OcultarPanelesAdmin()
        {
            panelAdministrador.Visible = false;
            panelAdminPedidos.Visible = false;
            panelAdminAuditoria.Visible = false;
            panelAdminDashboard.Visible = false;
        }

        // Agrega este método en tu clase Form1:
        private void OcultarTodosLosPaneles()
        {
            // Paneles cliente
            panelMenuLateral.Visible = false;
            panelLogin.Visible = false;
            panelMenu.Visible = false;
            panelPedido.Visible = false;
            panelEstado.Visible = false;
            panelListaPedidos.Visible = false;
            panelSoporte.Visible = false;
            panelAviso.Visible = false;
            panelTickets.Visible = false;
            panelEditarPedido.Visible = false;

            // Paneles técnico
            panelMenuLateralTecnico.Visible = false;
            panelTecnico.Visible = false;
            panelLoginTecnico.Visible = false;
            panelHistorial.Visible = false;
            panelAcerca.Visible = false;
            panelInicioTecnico.Visible = false;
            panelSeguimientos.Visible = false;

            // Paneles admin
            panelMenuLateralAdmin.Visible = false;
            panelAdminLogin.Visible = false;
            panelAdministrador.Visible = false;
            panelAdminPedidos.Visible = false;
            panelAdminAuditoria.Visible = false;
            panelAdminDashboard.Visible = false;
        }

    }
}