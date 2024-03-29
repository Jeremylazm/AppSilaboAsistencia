﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using Ayudas;

namespace CapaPresentaciones
{
    public partial class P_TablaDocentes : Form
    {
        private readonly string Departamento;
        private readonly E_Docente ObjEntidad;
        private readonly N_Docente ObjNegocio;

        public P_TablaDocentes()
        {
            Departamento = E_InicioSesion.CodDepartamentoA;
            ObjEntidad = new E_Docente();
            ObjNegocio = new N_Docente();
            InitializeComponent();
            MostrarRegistros();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
        }

        public void AccionesTabla()
        {
            // Editar
            dgvDatos.Columns[0].DisplayIndex = 13;
            dgvDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[0].MinimumWidth = 60;
            dgvDatos.Columns[0].Width = 60;

            // Eliminar
            dgvDatos.Columns[1].DisplayIndex = 13;
            dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[1].MinimumWidth = 80;
            dgvDatos.Columns[1].Width = 80;

            // Perfil 1
            dgvDatos.Columns[2].Visible = false;

            // Perfil 2
            dgvDatos.Columns[3].HeaderText = "";
            dgvDatos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[3].MinimumWidth = 30;
            dgvDatos.Columns[3].Width = 30;

            // Codigo
            dgvDatos.Columns[4].HeaderText = "Código";
            dgvDatos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[4].MinimumWidth = 70;
            dgvDatos.Columns[4].Width = 70;

            // Apellido Paterno
            dgvDatos.Columns[5].HeaderText = "A. Paterno";
            dgvDatos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Apellido Materno
            dgvDatos.Columns[6].HeaderText = "A. Materno";
            dgvDatos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Nombre
            dgvDatos.Columns[7].HeaderText = "Nombre(s)";
            dgvDatos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Email
            dgvDatos.Columns[8].HeaderText = "Email";
            dgvDatos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Direccion
            dgvDatos.Columns[9].Visible = false;

            // Telefono
            dgvDatos.Columns[10].HeaderText = "Teléfono";
            dgvDatos.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[10].MinimumWidth = 110;
            dgvDatos.Columns[10].Width = 110;

            // Categoria
            dgvDatos.Columns[11].HeaderText = "Categoría";
            dgvDatos.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[11].MinimumWidth = 135;
            dgvDatos.Columns[11].Width = 135;

            // Subcategoria
            dgvDatos.Columns[12].HeaderText = "Subcategoría";
            dgvDatos.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[12].MinimumWidth = 125;
            dgvDatos.Columns[12].Width = 125;

            // Regimen
            dgvDatos.Columns[13].HeaderText = "Régimen";
            dgvDatos.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvDatos.Columns[13].MinimumWidth = 225;
            dgvDatos.Columns[13].Width = 225;
        }

        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_Docente.MostrarDocentesDepartamento(Departamento); // El filtro es por departamento
            AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvDatos.DataSource = N_Docente.BuscarDocentes(Departamento, txtBuscar.Text);
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

            //Form Fondo = new Form();
            using (P_DatosDocente NuevoRegistro = new P_DatosDocente())
            {
                //Fondo.StartPosition = FormStartPosition.Manual;
                //Fondo.FormBorderStyle = FormBorderStyle.None;
                //Fondo.Opacity = .70d;
                //Fondo.BackColor = Color.Black;
                //Fondo.WindowState = FormWindowState.Maximized;
                //Fondo.TopMost = true;
                //Fondo.Location = this.Location;
                //Fondo.ShowInTaskbar = false;
                //Fondo.Show();

                NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                //NuevoRegistro.Owner = Fondo;
                NuevoRegistro.ShowDialog();
            }
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
                //Form Fondo = new Form();
                using (P_DatosDocente EditarRegistro = new P_DatosDocente())
                {
                    //Fondo.StartPosition = FormStartPosition.Manual;
                    //Fondo.FormBorderStyle = FormBorderStyle.None;
                    //Fondo.Opacity = .70d;
                    //Fondo.BackColor = Color.Black;
                    //Fondo.WindowState = FormWindowState.Maximized;
                    //Fondo.TopMost = true;
                    //Fondo.Location = this.Location;
                    //Fondo.ShowInTaskbar = false;
                    //Fondo.Show();

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

                    //EditarRegistro.Owner = Fondo;

                    DialogResult dr = EditarRegistro.ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        if ((this.Parent.Parent.Parent as P_Menu).Acceso == "Jefe de Departamento")
                        {
                            (this.Parent.Parent.Parent as P_Menu).ActualizarPerfilJefe(EditarRegistro.pbPerfil.Image);
                        }
                    }
                }
            }

            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
                {
                    ObjEntidad.CodDocente = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    ObjNegocio.EliminarDocente(ObjEntidad);
                    A_Dialogo.DialogoConfirmacion("Registro eliminado exitosamente");
                    //MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }
        }
    }
}
