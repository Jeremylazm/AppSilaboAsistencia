using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using CapaEntidades;
using System.IO;
using System.Drawing.Drawing2D;
using Ayudas;

namespace CapaPresentaciones
{
    public partial class P_Menu : Form
    {

        public string Acceso = "";
        private Image JefeActualizarPerfil = null;
        bool DocenteColapsado = false;
        bool JefeColapsado = true;
        bool DirectorColapsado = true;

        public P_Menu()
        {
            InitializeComponent();
            Control[] Controles = { pnOpciones, pnContenedor, lblSuperior, lblInferior, pbLogo, btnEditarPerfil, lblDatos, lblAcceso, lblUsuario };
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
                
            }
            else if (Acceso == "Jefe de Departamento")
            {
                pnContenedorDirector.Visible = false;
            }
            else if (Acceso == "Director de Escuela")
            {
                pnBotonesMenu.Controls.SetChildIndex(pnContenedorDirector, 2);
                pnContenedorJefe.Visible = false;
            }
            else if (Acceso == "Docente")
            {
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
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
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
    }
}
