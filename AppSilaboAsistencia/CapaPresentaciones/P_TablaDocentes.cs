using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_TablaDocentes : Form
    {
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();

        public P_TablaDocentes()
        {
            InitializeComponent();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void P_TablaDocentes_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        public void AccionesTabla()
        {
            dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[4].Visible = false;
            dgvTabla.Columns[5].Visible = false;
            dgvTabla.Columns[13].Visible = false;

            dgvTabla.Columns[1].HeaderText = "";
            dgvTabla.Columns[2].HeaderText = "Cod. Docente";
            dgvTabla.Columns[6].HeaderText = "Docente";
            dgvTabla.Columns[7].HeaderText = "Email";
            dgvTabla.Columns[8].HeaderText = "Dirección";
            dgvTabla.Columns[9].HeaderText = "Teléfono";
            dgvTabla.Columns[10].HeaderText = "Categoría";
            dgvTabla.Columns[11].HeaderText = "Subcategoría";
            dgvTabla.Columns[12].HeaderText = "Régimen";
            dgvTabla.Columns[14].HeaderText = "Escuela Profesional";
        }

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Docente.MostrarDocentes("IN");
            AccionesTabla();
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
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
            P_DatosDocente NuevoRegistro = new P_DatosDocente();
            NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistro.ShowDialog();
            NuevoRegistro.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            P_DatosDocente EditarRegistro = new P_DatosDocente();
            EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

            if (dgvTabla.SelectedRows.Count > 0)
            {
                Program.Evento = 1;

                if (dgvTabla.CurrentRow.Cells[0].Value.GetType() == Type.GetType("System.DBNull"))
                {
                    EditarRegistro.imgPerfil.Image = Properties.Resources.Perfil_Docente as Image;
                }
                else
                {
                    byte[] Perfil = new byte[0];
                    Perfil = (byte[])dgvTabla.CurrentRow.Cells[0].Value;
                    MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                    EditarRegistro.imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
                    MemoriaPerfil = null;
                    MemoriaPerfil = null;
                }

                EditarRegistro.txtCodigo.Text = dgvTabla.CurrentRow.Cells[2].Value.ToString();
                EditarRegistro.txtAPaterno.Text = dgvTabla.CurrentRow.Cells[3].Value.ToString();
                EditarRegistro.txtAMaterno.Text = dgvTabla.CurrentRow.Cells[4].Value.ToString();
                EditarRegistro.txtNombre.Text = dgvTabla.CurrentRow.Cells[5].Value.ToString();
                EditarRegistro.txtEmail.Text = dgvTabla.CurrentRow.Cells[7].Value.ToString().Substring(0, dgvTabla.CurrentRow.Cells[7].Value.ToString().Length - 14);
                EditarRegistro.txtDireccion.Text = dgvTabla.CurrentRow.Cells[8].Value.ToString();
                EditarRegistro.txtTelefono.Text = dgvTabla.CurrentRow.Cells[9].Value.ToString();

                EditarRegistro.cxtSubcategoria.Items.Clear();
                EditarRegistro.cxtRegimen.Items.Clear();
                EditarRegistro.cxtRegimen.Items.Add("TIEMPO COMPLETO");
                EditarRegistro.cxtRegimen.Items.Add("TIEMPO PARCIAL");

                if (dgvTabla.CurrentRow.Cells[10].Value.ToString() == "NOMBRADO")
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

                EditarRegistro.cxtCategoria.SelectedItem = dgvTabla.CurrentRow.Cells[10].Value.ToString();
                EditarRegistro.cxtSubcategoria.SelectedItem = dgvTabla.CurrentRow.Cells[11].Value.ToString();
                EditarRegistro.cxtRegimen.SelectedItem = dgvTabla.CurrentRow.Cells[12].Value.ToString();

                EditarRegistro.cxtEscuela.SelectedValue = dgvTabla.CurrentRow.Cells[13].Value.ToString();

                EditarRegistro.ShowDialog();
            }
            else
            {
                MensajeError("Debe seleccionar una fila");
            }
            EditarRegistro.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTabla.SelectedRows.Count > 0)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    ObjEntidad.CodDocente = dgvTabla.CurrentRow.Cells[0].Value.ToString();
                    ObjNegocio.EliminarDocente(ObjEntidad);
                    MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }
            else
            {
                MensajeError("Debe seleccionar una fila");
            }
        }
    }
}
