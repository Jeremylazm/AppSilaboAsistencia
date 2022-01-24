using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using CapaEntidades;
using CapaNegocios;
using System.IO;
using System.Drawing.Drawing2D;
using Ayudas;
using System.Net.Sockets;
using System.Text;

namespace CapaPresentaciones
{
    public partial class P_Menu : Form
    {
        readonly E_AsistenciaDiariaDocente ObjEntidadDocente;
        readonly N_AsistenciaDiariaDocente ObjNegocioDocente;
        public string Acceso = "";
        private Image JefeActualizarPerfil = null;
        bool DocenteColapsado = false;
        bool JefeColapsado = true;
        bool DirectorColapsado = true;
        P_PrincipalDocente Principal;
        bool pHoraServidor = false;

        public P_Menu()
        {
            InitializeComponent();
            Control[] Controles = { pnOpciones, pnContenedor, lblSuperior, lblInferior, pbLogo, btnEditarPerfil, lblDatos, lblAcceso, lblUsuario };
            Docker.SubscribeControlsToDragEvents(Controles);

            ObjEntidadDocente = new E_AsistenciaDiariaDocente();
            ObjNegocioDocente = new N_AsistenciaDiariaDocente();
        }

        bool DrawerOpen = true;

        public Image HacerImagenCircular(Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);

            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }

            return tmp;
        }

        private void CargarDatosUsuario()
        {
            if (E_InicioSesion.Perfil == null)
            {
                if ((E_InicioSesion.Acceso == "Jefe de Departamento") || (E_InicioSesion.Acceso == "Director de Escuela") || (E_InicioSesion.Acceso == "Administrador"))
                {
                    btnEditarPerfil.Image = Properties.Resources.Perfil as Image;
                }
                
                if (E_InicioSesion.Acceso == "Docente")
                {
                    btnEditarPerfil.Image = Properties.Resources.Perfil_Docente as Image;
                }
            }
            else
            {
                byte[] Perfil = new byte[0];
                Perfil = E_InicioSesion.Perfil;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                btnEditarPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
            }
            lblDatos.Text = E_InicioSesion.Datos;
            lblAcceso.Text = E_InicioSesion.Acceso;
            lblUsuario.Text = E_InicioSesion.Usuario;
        }

        private void ActualizarPerfil(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void GestionarAcceso()
        {
            if (Acceso == "Administrador")
            {
                pnBotonesMenu.Controls.SetChildIndex(pnContenedorAdministrador, 0);
                btnPrincipal.Visible = false;
                SeparadorMenu2.Visible = false;
                btnMarcarAsistencia.Visible = false;
                pbMarcarAsistencia.Visible = false;
                pnContenedorDocente.Visible = false;
                pnContenedorDirector.Visible = false;
                pnContenedorJefe.Visible = false;
                pnContenedorAdministrador.Visible = true;
                pnContenedorAdministrador.Size = pnContenedorAdministrador.MaximumSize;

                btnEditarPerfil.Cursor = Cursors.Default;
                btnEditarPerfil.Image = Properties.Resources.Perfil;
            }
            else if (Acceso == "Jefe de Departamento")
            {
                btnPrincipal.Visible = true;
                SeparadorMenu2.Visible = true;
                btnMarcarAsistencia.Visible = true;
                pbMarcarAsistencia.Visible = true;
                pnContenedorAdministrador.Visible = false;
                pnContenedorDirector.Visible = false;
            }
            else if (Acceso == "Director de Escuela")
            {
                btnPrincipal.Visible = true;
                SeparadorMenu2.Visible = true;
                btnMarcarAsistencia.Visible = true;
                pbMarcarAsistencia.Visible = true;
                pnContenedorAdministrador.Visible = false;
                pnBotonesMenu.Controls.SetChildIndex(pnContenedorDirector, 2);
                pnContenedorJefe.Visible = false;
            }
            else if (Acceso == "Docente")
            {
                btnPrincipal.Visible = true;
                SeparadorMenu2.Visible = true;
                btnMarcarAsistencia.Visible = true;
                pbMarcarAsistencia.Visible = true;
                pnContenedorAdministrador.Visible = false;
                pnContenedorDocente.Controls.SetChildIndex(btnContenedorDocente, 5);
                btnContenedorDocente.Visible = false;
                pnContenedorJefe.Visible = false;
                pnContenedorDirector.Visible = false;
            }
        }

        private void btnContraer_Click(object sender, EventArgs e)
        {
            DrawerOpen = !DrawerOpen;
            pnOpciones.Visible = false;
            pnContenedor.Visible = false;

            if (DrawerOpen)
            {
                pnOpciones.Width = 220;
                pbLogo.Location = new Point(225, 5);
                SeparadorMenu1.Width = 209;
                SeparadorMenu2.Width = 209;
                btnEditarPerfil.Size = new Size(106, 106);
                btnEditarPerfil.Location = new Point(56, 10);
                lblDatos.Visible = true;
                lblAcceso.Visible = true;
                lblUsuario.Visible = true;
                pbMarcarAsistencia.Visible = false;
                btnMarcarAsistencia.Visible = true;
                Transicion.ShowSync(pnOpciones);
                Transicion.ShowSync(pnContenedor);

            }
            else
            {
                pnOpciones.Width = 44;
                pbLogo.Location = new Point(49, 5);
                SeparadorMenu1.Width = 35;
                SeparadorMenu2.Width = 35;
                btnEditarPerfil.Size = new Size(34, 34);
                btnEditarPerfil.Location = new Point(5, 230);
                lblDatos.Visible = false;
                lblAcceso.Visible = false;
                lblUsuario.Visible = false;
                pbMarcarAsistencia.Visible = true;
                btnMarcarAsistencia.Visible = false;
                Transicion.ShowSync(pnOpciones);
                Transicion.ShowSync(pnContenedor);
            }
        }

        private const int TamañoGrid = 10;
        private const int AreaMouse = 132;
        private const int BotonIzquierdo = 17;
        private Rectangle RectanguloGrid;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            var Region = new Region(new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            RectanguloGrid = new Rectangle(ClientRectangle.Width - TamañoGrid, ClientRectangle.Height - TamañoGrid, TamañoGrid, TamañoGrid);
            Region.Exclude(RectanguloGrid);
            pnPrincipal.Region = Region;
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case AreaMouse:
                    base.WndProc(ref m);

                    var ReferenciaPunto = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));

                    if (!RectanguloGrid.Contains(ReferenciaPunto))
                        break;

                    m.Result = new IntPtr(BotonIzquierdo);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush Solido = new SolidBrush(Color.FromArgb(232, 158, 31));
            e.Graphics.FillRectangle(Solido, RectanguloGrid);

            base.OnPaint(e);

            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, RectanguloGrid);
        }

        int Lx, Ly;
        int Sw, Sh;

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            Size = new Size(Sw, Sh);
            Location = new Point(Lx, Ly);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            Lx = Location.X;
            Ly = Location.Y;
            Sw = Size.Width;
            Sh = Size.Height;

            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ActualizarColor()
        {
            lblSuperior.Focus();
            if (pHoraServidor)
                Principal.HoraFecha.Stop();
        }

        private void CerrarSesion()
        {
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Desea cerrar sesión?") == DialogResult.Yes)
            {
                ActualizarColor();
                Close();
                P_InicioSesion Login = new P_InicioSesion();
                Login.Show();
            }
            if (E_InicioSesion.Acceso != "Administrador")
                Principal.HoraFecha.Start();
        }

        private void EditarPerfil()
        {
            ActualizarColor();

            if (E_InicioSesion.Acceso != "Administrador")
            {
                P_EditarPerfilDocente Editar = new P_EditarPerfilDocente
                {
                    UsuarioE = E_InicioSesion.Usuario,
                    perfil = JefeActualizarPerfil,
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                Editar.btnGuardar.Click += new EventHandler(ActualizarPerfil);

                pnContenedor.Controls.Add(Editar);
                pnContenedor.Tag = Editar;
                Editar.Show();
                Editar.BringToFront();
            }
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaDocentes>();
        }

        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaAsignaturas>();
        }

        private void btnSilabos_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaAsignaturasAsignadasSilabos>();
        }

        private void btnAsignaturasAsignadas_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaAsignaturasAsignadasEstudiantes>();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            EditarPerfil();
        }

        private void btnCatálogo_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaCatálogo>();
        }

        private void btnSesiones_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaAsignaturasAsignadasPlanSesiones>();
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaAsignaturasAsignadasAsistencias>();
        }

        private void P_Menu_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            GestionarAcceso();

            if (E_InicioSesion.Acceso != "Administrador")
            {
                Principal = new P_PrincipalDocente
                {
                    HoraServidor = pHoraServidor,
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                pnContenedor.Controls.Add(Principal);
                pnContenedor.Tag = Principal;
                Principal.Show();
                Principal.BringToFront();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            CerrarSesion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Desea salir de la aplicación?") == DialogResult.Yes)
            {
                ActualizarColor();
                Application.Exit();
            }
            Principal.HoraFecha.Start();
        }

        private void btnReportesDocente_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_ReporteDocente>();
        }

        private void AnimacionDocenteContenedor_Tick(object sender, EventArgs e)
        {
            if (DocenteColapsado)
            {
                JefeColapsado = false;
                AnimacionJefeContenedor.Start();
                DirectorColapsado = false;
                AnimacionDirectorContenedor.Start();

                pnContenedorDocente.Height += 10;
                if (pnContenedorDocente.Height.Equals(pnContenedorDocente.MaximumSize.Height))
                {
                    DocenteColapsado = false;
                    AnimacionDocenteContenedor.Stop();
                }
            }
            else
            {
                pnContenedorDocente.Height -= 10;
                if (pnContenedorDocente.Height.Equals(pnContenedorDocente.MinimumSize.Height))
                {
                    DocenteColapsado = true;
                    AnimacionDocenteContenedor.Stop();
                }
            }
        }

        private void AnimacionJefeContenedor_Tick(object sender, EventArgs e)
        {
            if (JefeColapsado)
            {
                DocenteColapsado = false;
                AnimacionDocenteContenedor.Start();
                DirectorColapsado = false;
                AnimacionDirectorContenedor.Start();

                pnContenedorJefe.Height += 10;
                if (pnContenedorJefe.Height.Equals(pnContenedorJefe.MaximumSize.Height))
                {
                    JefeColapsado = false;
                    AnimacionJefeContenedor.Stop();
                }
            }
            else
            {
                pnContenedorJefe.Height -= 10;
                if (pnContenedorJefe.Height.Equals(pnContenedorJefe.MinimumSize.Height))
                {
                    JefeColapsado = true;
                    AnimacionJefeContenedor.Stop();
                }
            }
        }

        private void AnimacionDirectorContenedor_Tick(object sender, EventArgs e)
        {
            if (DirectorColapsado)
            {
                DocenteColapsado = false;
                AnimacionDocenteContenedor.Start();
                JefeColapsado = false;
                AnimacionJefeContenedor.Start();

                pnContenedorDirector.Height += 10;
                if (pnContenedorDirector.Height.Equals(pnContenedorDirector.MaximumSize.Height))
                {
                    DirectorColapsado = false;
                    AnimacionDirectorContenedor.Stop();
                }
            }
            else
            {
                pnContenedorDirector.Height -= 10;
                if (pnContenedorDirector.Height.Equals(pnContenedorDirector.MinimumSize.Height))
                {
                    DirectorColapsado = true;
                    AnimacionDirectorContenedor.Stop();
                }
            }
        }

        private void btnContenedorDocente_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AnimacionDocenteContenedor.Start();
        }

        private void btnContenedorJefe_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AnimacionJefeContenedor.Start();
        }

        private void btnContenedorDirector_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AnimacionDirectorContenedor.Start();
        }

        private void btnAsistenciasDocentes_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_HistorialAsistenciasDocentes>();
        }
        private void btnReportesJefe_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_ReporteJefe>();
        }
        private void btnReportesDirector_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_ReporteDirector>();
        }

        // Abrir Formularios
        public void AbrirFormularios<FormularioAbrir>() where FormularioAbrir : Form, new()
        {
            Form Formularios = pnContenedor.Controls.OfType<FormularioAbrir>().FirstOrDefault();

            if (Formularios == null)
            {
                Formularios = new FormularioAbrir
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                pnContenedor.Controls.Add(Formularios);
                pnContenedor.Tag = Formularios;
                Formularios.Show();
                Formularios.BringToFront();
            }
            else
            {
                Formularios.BringToFront();
            }
        }

        public void ActualizarPerfilJefe(Image perfil)
        {
            btnEditarPerfil.Image = perfil;
            JefeActualizarPerfil = perfil;
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            Principal.HoraFecha.Start();
            Principal.BringToFront();
        }

        private void btnPlantillas_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaPlantillas>();
        }

        private void btnSemestres_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            AbrirFormularios<P_TablaSemestre>();
        }

        private void MarcarAsistencia()
        {
            ActualizarColor();

            // Obtener horario de la base de datos
            DataTable Semestre = N_Semestre.SemestreActual();
            string CodSemestre = Semestre.Rows[0][0].ToString();
            string Usuario = E_InicioSesion.Usuario;
            string CodDepartamentoA = E_InicioSesion.CodDepartamentoA;

            DataTable Horario = N_HorarioRegistroAsistencia.BuscarHorarioRegistroAsistencia(CodSemestre, CodDepartamentoA);
            var hora_inicio = TimeSpan.Parse(Horario.Rows[0][0].ToString());
            var hora_fin = TimeSpan.Parse(Horario.Rows[0][1].ToString());

            // Obtener horario servidor
            const string server = "time.nist.gov"; // URL del servidor
            const Int32 port = 13;                 // puerto para obtener la data del servidor 
            string date_NIST = GetNISTDateTime(server, port);

            if (date_NIST != null)
            {
                DateTime date = DateTime.Parse(date_NIST, null);
                string Fecha = date.Date.ToString("dd/MM/yyyy");
                string Hora = date.ToString("HH:mm:ss");

                // Registrar asistencia
                DataTable AsistenciaDocente = N_AsistenciaDiariaDocente.BuscarAsistenciaDocente(CodSemestre, CodDepartamentoA, Fecha, Usuario);

                if (AsistenciaDocente.Rows.Count == 0) // El docente todavia no registro su asistencia
                {
                    var hora_servidor = TimeSpan.Parse(Hora);
                    if (hora_servidor >= hora_inicio && hora_servidor <= hora_fin)
                    {
                        ObjEntidadDocente.CodSemestre = CodSemestre;
                        ObjEntidadDocente.CodDepartamentoA = CodDepartamentoA;
                        ObjEntidadDocente.Fecha = Fecha;
                        ObjEntidadDocente.Hora = Hora;
                        ObjEntidadDocente.CodDocente = Usuario;
                        ObjEntidadDocente.Asistio = "SI";
                        ObjEntidadDocente.Observacion = "";
                        ObjNegocioDocente.RegistrarAsistenciaDiariaDocente(ObjEntidadDocente);
                        A_Dialogo.DialogoConfirmacion("Se registro su asistencia.");
                    }
                    else
                    {
                        string dialogo = String.Format("La hora para registrar la asistencia es de {0} a {1}", hora_inicio, hora_fin);
                        A_Dialogo.DialogoError(dialogo);
                    }
                }
                else // El docente ya registro su asistencia
                {
                    A_Dialogo.DialogoError("Ya registró su asistencia de hoy.");
                }
            }
            Principal.HoraFecha.Start();
        }

        private void pbMarcarAsistencia_Click(object sender, EventArgs e)
        {
            MarcarAsistencia();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {

        }

        // Registrar asistencia diaria
        private void btnMarcarAsistencia_Click(object sender, EventArgs e)
        {
            MarcarAsistencia();
        }

        // Obtener hora local del servidor NIST
        public string GetNISTDateTime(string server, Int32 port)
        {
            bool bGoodConnection = false;
            TcpClient tcpClientConnection = new TcpClient();
            try
            {
                tcpClientConnection.Connect(server, port);
                bGoodConnection = true;
            }
            catch
            {
                A_Dialogo.DialogoError("No se encuentra conectado a Internet. Revise su conexión.");
            }

            if (bGoodConnection == true)
            {
                try
                {
                    NetworkStream netStream = tcpClientConnection.GetStream();

                    if (netStream.CanRead)
                    {
                        byte[] bytes = new byte[tcpClientConnection.ReceiveBufferSize];
                        netStream.Read(bytes, 0, tcpClientConnection.ReceiveBufferSize);
                        var sNISTDateTimeFull = Encoding.ASCII.GetString(bytes).Substring(0, 50);
                        var subStringNISTDateTimeShort = sNISTDateTimeFull.Substring(7, 17);
                        DateTime dtNISTDateTime = DateTime.Parse("20" + subStringNISTDateTimeShort).ToLocalTime();
                        tcpClientConnection.Close();
                        return dtNISTDateTime.ToString();
                    }
                    else 
                    {
                        A_Dialogo.DialogoError("Parece que ha ocurrido un problema. Por favor, vuelva a intentarlo.");
                        tcpClientConnection.Close();
                        tcpClientConnection.Close();
                        netStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentNullException)
                    {
                        A_Dialogo.DialogoError("El servidor se encuentra ocupado. Intentelo más tarde.");
                    }
                    else if (ex is SocketException)
                    {
                        A_Dialogo.DialogoError("Parece que ha ocurrido un problema. Por favor, vuelva a intentarlo.");
                    }
                }
            }
            return null;
        }
    }
}
