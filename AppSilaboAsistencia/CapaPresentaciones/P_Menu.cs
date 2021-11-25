using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_Menu : Form
    {
        public P_Menu()
        {
            InitializeComponent();
            Control[] Controles = { pnOpciones, pnContenedor, lblSuperior, lblInferior, pbLogo, pbPerfil, lblDatos, lblAcceso, lblUsuario };
            Docker.SubscribeControlsToDragEvents(Controles);
        }

        bool DrawerOpen = true;

        private void btnContraer_Click(object sender, EventArgs e)
        {
            DrawerOpen = !DrawerOpen;
            pnOpciones.Visible = false;
            pnContenedor.Visible = false;

            if (DrawerOpen)
            {
                pnOpciones.Width = 173;
                pbLogo.Location = new Point(178, 6);
                SeparadorMenu.Width = 161;
                pbPerfil.Visible = true;
                btnEditarPerfil.Visible = true;
                pbEditarPerfil.Visible = false;
                lblDatos.Visible = true;
                lblAcceso.Visible = true;
                lblUsuario.Visible = true;
                //btnContraer.Image = Properties.Resources.Cerrar as Image;
                Transicion.ShowSync(pnOpciones);
                Transicion.ShowSync(pnContenedor);

            }
            else
            {
                pnOpciones.Width = 44;
                pbLogo.Location = new Point(49, 6);
                SeparadorMenu.Width = 35;
                pbPerfil.Visible = false;
                btnEditarPerfil.Visible = false;
                pbEditarPerfil.Visible = true;
                lblDatos.Visible = false;
                lblAcceso.Visible = false;
                lblUsuario.Visible = false;
                //btnContraer.Image = Properties.Resources.Ingresar as Image;
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

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            ActualizarColor();
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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Sistema de Gestión de Sílabo y Control de Asistencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Abrir Formularios
        private void AbrirFormularios<FormularioAbrir>() where FormularioAbrir : Form, new()
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

    }
}
