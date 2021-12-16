using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_TablaDocentes : Form
    {
        readonly E_Docente ObjEntidad;
        readonly N_Docente ObjNegocio;

        public P_TablaDocentes()
        {
            ObjEntidad = new E_Docente();
            ObjNegocio = new N_Docente();
            InitializeComponent();
            MostrarRegistros();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Control de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Gestión de Sílabo y Control de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 13;
            dgvDatos.Columns[1].DisplayIndex = 13;
            dgvDatos.Columns[2].Visible = false;

            dgvDatos.Columns[3].HeaderText = "";
            dgvDatos.Columns[4].HeaderText = "Código";
            dgvDatos.Columns[5].HeaderText = "A. Paterno";
            dgvDatos.Columns[6].HeaderText = "A. Materno";
            dgvDatos.Columns[7].HeaderText = "Nombre";
            dgvDatos.Columns[8].HeaderText = "Email";
            dgvDatos.Columns[9].HeaderText = "Dirección";
            dgvDatos.Columns[10].HeaderText = "Teléfono";
            dgvDatos.Columns[11].HeaderText = "Categoría";
            dgvDatos.Columns[12].HeaderText = "Subcategoría";
            dgvDatos.Columns[13].HeaderText = "Régimen";
            //dgvDatos.Columns[14].HeaderText = "D. Académico";
            //dgvDatos.Columns[13].HeaderText = "Escuela P.";
        }

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_Docente.MostrarDocentesDepartamento("IF"); // El filtro es por departamento
            AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_Docente.BuscarDocentes("IF", txtBuscar.Text);
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            P_DatosDocente NuevoRegistro = new P_DatosDocente();
            NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistro.ShowDialog();
            NuevoRegistro.Dispose();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDatos.Columns[e.ColumnIndex].HeaderText == "")
            {
                byte[] bits = new byte[0];
                bits = (byte[])e.Value;
                MemoryStream ms = new MemoryStream(bits);
                Image imgSave = Image.FromStream(ms);
                e.Value = HacerImagenCircular(imgSave);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                P_DatosDocente EditarRegistro = new P_DatosDocente();
                EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

                //editar
                Program.Evento = 1;

                if (dgvDatos.Rows[e.RowIndex].Cells[2].Value.GetType() == Type.GetType("System.DBNull"))
                {
                    EditarRegistro.pbPerfil.Image = Properties.Resources.Perfil_Docente as Image;
                }
                else
                {
                    byte[] Perfil = new byte[0];
                    Perfil = (byte[])dgvDatos.Rows[e.RowIndex].Cells[2].Value;
                    MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                    EditarRegistro.pbPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
                    MemoriaPerfil = null;
                    MemoriaPerfil = null;
                }

                EditarRegistro.txtCodigo.Text = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                EditarRegistro.txtAPaterno.Text = dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString();
                EditarRegistro.txtAMaterno.Text = dgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString();
                EditarRegistro.txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells[7].Value.ToString();
                EditarRegistro.txtEmail.Text = dgvDatos.Rows[e.RowIndex].Cells[8].Value.ToString().Split('@')[0];
                EditarRegistro.txtDireccion.Text = dgvDatos.Rows[e.RowIndex].Cells[9].Value.ToString();
                EditarRegistro.txtTelefono.Text = dgvDatos.Rows[e.RowIndex].Cells[10].Value.ToString();

                EditarRegistro.cxtSubcategoria.Items.Clear();
                EditarRegistro.cxtRegimen.Items.Clear();
                EditarRegistro.cxtRegimen.Items.Add("TIEMPO COMPLETO");
                EditarRegistro.cxtRegimen.Items.Add("TIEMPO PARCIAL");

                if (dgvDatos.Rows[e.RowIndex].Cells[11].Value.Equals("NOMBRADO"))
                {
                    EditarRegistro.cxtSubcategoria.Items.Add("PRINCIPAL");
                    EditarRegistro.cxtSubcategoria.Items.Add("ASOCIADO");
                    EditarRegistro.cxtSubcategoria.Items.Add("AUXILIAR");

                    EditarRegistro.cxtRegimen.Enabled = true;
                    EditarRegistro.cxtRegimen.Items.Insert(1, "DEDICACIÓN EXCLUSIVA");
                }
                else
                {
                    EditarRegistro.cxtSubcategoria.Items.Add("A1");
                    EditarRegistro.cxtSubcategoria.Items.Add("A2");
                    EditarRegistro.cxtSubcategoria.Items.Add("A3");
                    EditarRegistro.cxtSubcategoria.Items.Add("B1");
                    EditarRegistro.cxtSubcategoria.Items.Add("B2");
                    EditarRegistro.cxtSubcategoria.Items.Add("B3");

                    EditarRegistro.cxtRegimen.Enabled = false;
                }

                EditarRegistro.cxtCategoria.SelectedItem = dgvDatos.Rows[e.RowIndex].Cells[11].Value.ToString();
                EditarRegistro.cxtSubcategoria.SelectedItem = dgvDatos.Rows[e.RowIndex].Cells[12].Value.ToString();
                EditarRegistro.cxtRegimen.SelectedItem = dgvDatos.Rows[e.RowIndex].Cells[13].Value.ToString();

                // EditarRegistro.cxtEscuela.SelectedValue = dgvTabla.CurrentRow.Cells[13].Value.ToString();

                EditarRegistro.ShowDialog();

                EditarRegistro.Dispose();
            }

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                P_DialogoPregunta Dialogo = new P_DialogoPregunta("¿Realmente desea eliminar el registro?");
                Dialogo.ShowDialog();
                DialogResult Opcion = Dialogo.DialogResult;
                //Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    ObjEntidad.CodDocente = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    ObjNegocio.EliminarDocente(ObjEntidad);
                    P_DialogoInformacion.Mostrar("Registro eliminado exitosamente");
                    //MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }
        }
    }
}
