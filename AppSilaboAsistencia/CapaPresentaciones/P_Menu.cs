using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using CapaEntidades;
using System.IO;
using System.Drawing.Drawing2D;
using Ayudas;
using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.Build.Utilities;
using System.Collections.ObjectModel;

namespace CapaPresentaciones
{
    public partial class P_Menu : Form
    {
        public string Acceso = "";
        private Image JefeActualizarPerfil = null;

        public P_Menu()
        {
            InitializeComponent();
            Control[] Controles = { pnOpciones, pnContenedor, lblSuperior, lblInferior, pbLogo, pbPerfil, lblDatos, lblAcceso, lblUsuario };
            Docker.SubscribeControlsToDragEvents(Controles);
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
                    pbPerfil.Image = Properties.Resources.Perfil as Image;
                    pbEditarPerfil.Image = Properties.Resources.Perfil as Image;
                }
                
                if (E_InicioSesion.Acceso == "Docente")
                {
                    pbPerfil.Image = Properties.Resources.Perfil_Docente as Image;
                    pbEditarPerfil.Image = Properties.Resources.Perfil_Docente as Image;
                }
            }
            else
            {
                byte[] Perfil = new byte[0];
                Perfil = E_InicioSesion.Perfil;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                pbPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
                pbEditarPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
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
                btnEditarPerfil.Visible = false;
                pbEditarPerfil.Visible = false;

                btnAsignaturasAsignadas.Visible = false;
                btnAsistencia.Visible = false;
                btnSilabos.Visible = false;
                btnSesiones.Visible = false;

                btnCatálogo.Visible = true;
                btnAsignaturas.Visible = true;
                btnDocentes.Visible = true;

                btnCatálogo.Location = new Point(0, 332);
                btnAsignaturas.Location = new Point(0, 373);
                btnDocentes.Location = new Point(0, 414);

                // Administrador 
            }
            else if (Acceso == "Jefe de Departamento")
            {
                // Docentes y catálogo
                btnAsignaturasAsignadas.Visible = true;
                btnAsistencia.Visible = true;
                btnSilabos.Visible = true;
                btnSesiones.Visible = true;

                SeparadorMenu2.Location = new Point(5, 496);
                SeparadorMenu2.Visible = true;

                //Bunifu.UI.WinForms.BunifuSeparator bs1 = new Bunifu.UI.WinForms.BunifuSeparator
                //{
                //    LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded,
                //    Location = new Point(5, 496),
                //    Size = new Size(209, 14),
                //    BackColor = Color.Transparent,
                //    LineColor = Color.FromArgb(232, 158, 31)
                //};

                //pnOpciones.Controls.Add(bs1);
                //pnOpciones.Tag = bs1;

                btnCatálogo.Location = new Point(0, 507);
                btnDocentes.Location = new Point(0, 549);

                btnCatálogo.Visible = true;
                btnAsignaturas.Visible = false;
                btnDocentes.Visible = true;
            }
            else if (Acceso == "Director de Escuela")
            {
                // Asignaturas
                btnAsignaturasAsignadas.Visible = true;
                btnAsistencia.Visible = true;
                btnSilabos.Visible = true;
                btnSesiones.Visible = true;

                SeparadorMenu2.Location = new Point(5, 496);
                SeparadorMenu2.Visible = true;

                //Bunifu.UI.WinForms.BunifuSeparator bs1 = new Bunifu.UI.WinForms.BunifuSeparator
                //{
                //    LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.DoubleEdgeFaded,
                //    Location = new Point(5, 496),
                //    Size = new Size(209, 14),
                //    BackColor = Color.Transparent,
                //    LineColor = Color.FromArgb(232, 158, 31)
                //};

                //pnOpciones.Controls.Add(bs1);
                //pnOpciones.Tag = bs1;

                btnAsignaturas.Location = new Point(0, 507);

                btnCatálogo.Visible = false;
                btnAsignaturas.Visible = true;
                btnDocentes.Visible = false;
            }
            else if (Acceso == "Docente")
            {
                btnAsignaturasAsignadas.Visible = true;
                btnAsistencia.Visible = true;
                btnSilabos.Visible = true;
                btnSesiones.Visible = true;

                btnCatálogo.Visible = false;
                btnAsignaturas.Visible = false;
                btnDocentes.Visible = false;
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
                SeparadorMenu3.Width = 209;
                pbPerfil.Visible = true;
                btnEditarPerfil.Visible = true;
                pbEditarPerfil.Visible = false;
                btnCerrarSesion.Visible = true;
                pbCerrarSesion.Visible = false;
                lblDatos.Visible = true;
                lblAcceso.Visible = true;
                lblUsuario.Visible = true;
                Transicion.ShowSync(pnOpciones);
                Transicion.ShowSync(pnContenedor);

            }
            else
            {
                pnOpciones.Width = 44;
                pbLogo.Location = new Point(49, 5);
                SeparadorMenu1.Width = 35;
                SeparadorMenu2.Width = 35;
                SeparadorMenu3.Width = 35;
                pbPerfil.Visible = false;
                btnEditarPerfil.Visible = false;
                pbEditarPerfil.Visible = true;
                btnCerrarSesion.Visible = false;
                pbCerrarSesion.Visible = true;
                lblDatos.Visible = false;
                lblAcceso.Visible = false;
                lblUsuario.Visible = false;
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
        }

        private void CerrarSesion()
        {
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Desea cerrar sesión?") == DialogResult.Yes)
            {
                Close();
                P_InicioSesion Login = new P_InicioSesion();
                Login.Show();
            }
        }

        private void EditarPerfil()
        {
            ActualizarColor();

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
            AbrirFormularios<P_TablaAsignaturasAsignadasSesiones>();
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
            /*
            // Get time in local time zone 
            DateTime thisTime = DateTime.Now;
            Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(thisTime) ?
                              TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, thisTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local));
            // Get Tokyo Standard Time zone
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
            //
            Console.WriteLine("Time in {0} zone: {1}", tst.IsDaylightSavingTime(tstTime) ?
                              tst.DaylightName : tst.StandardName, tstTime); //tstTime
            ///
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));

            Console.WriteLine(DateTime.Now);

            ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
            Console.WriteLine("The local system has the following {0} time zones", zones.Count);
            foreach (TimeZoneInfo zone in zones)
                Console.WriteLine(zone.Id);*/

            //
            DateTime a = GetNISTDate(true);
            Real = a;
            Console.WriteLine(Real.Hour.ToString());
            Console.WriteLine(Real.Minute.ToString());
            Console.WriteLine(Real.Second.ToString());
        }
        private DateTime Real;

        public static DateTime GetNISTDate(bool convertToLocalTime)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            DateTime date = DateTime.Today;
            string serverResponse = string.Empty;

            // Represents the list of NIST servers
            string[] servers = new string[] { "129.6.15.28", "132.163.97.1", "132.163.97.2", "132.163.96.1", "global address for all servers", "128.138.141.172" };

            // Try each server in random order to avoid blocked requests due to too frequent request
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    // Open a StreamReader to a random time server
                    StreamReader reader = new StreamReader(new System.Net.Sockets.TcpClient(servers[ran.Next(0, servers.Length)], 13).GetStream());
                    serverResponse = reader.ReadToEnd();
                    reader.Close();

                    // Check to see that the signiture is there
                    if (serverResponse.Length > 47 && serverResponse.Substring(38, 9).Equals("UTC(NIST)"))
                    {
                        // Parse the date
                        int jd = int.Parse(serverResponse.Substring(1, 5));
                        int yr = int.Parse(serverResponse.Substring(7, 2));
                        int mo = int.Parse(serverResponse.Substring(10, 2));
                        int dy = int.Parse(serverResponse.Substring(13, 2));
                        int hr = int.Parse(serverResponse.Substring(16, 2));
                        int mm = int.Parse(serverResponse.Substring(19, 2));
                        int sc = int.Parse(serverResponse.Substring(22, 2));

                        if (jd > 51544)
                            yr += 2000;
                        else
                            yr += 1999;

                        date = new DateTime(yr, mo, dy, hr, mm, sc);

                        // Convert it to the current timezone if desired
                        if (convertToLocalTime)
                            date = date.ToLocalTime();

                        // Exit the loop
                        break;
                    }

                }
                catch (Exception ex)
                {
                    /* Do Nothing...try the next server */
                }
            }

            return date;
        }


        private void pbEditarPerfil_Click(object sender, EventArgs e)
        {
            EditarPerfil();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void pbCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Desea salir de la aplicación?") == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMiAsistencia_Click(object sender, EventArgs e)
        {
            DateTime a = GetNISTDate(true);
            int HoraInicio = 13;
            int HoraFin = 15;
            bunifuLabel1.Text = a.ToString("hh:mm:ss");

            int Hora = a.Hour;
            MessageBox.Show(a.Hour.ToString());
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime a = GetNISTDate(true);
            int HoraInicio = 14;
            int HoraFin = 15;
            //bunifuLabel1.Text = a.ToString("hh:mm:ss");

            int Hora = a.Hour;

            if (HoraInicio <= Hora && Hora <= HoraFin)
            {
                btnMiAsistencia.Visible = true;
            }
            else
            {
                btnMiAsistencia.Visible = false;
            }
        }*/

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
            pbPerfil.Image = perfil;
            pbEditarPerfil.Image = perfil;
            JefeActualizarPerfil = perfil;
        }
    }
}
