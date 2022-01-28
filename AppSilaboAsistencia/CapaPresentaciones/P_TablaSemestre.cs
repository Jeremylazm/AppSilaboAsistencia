using System;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using MathNet.Numerics.Statistics;
using Ayudas;
using ControlesPerzonalizados;
using System.Globalization;
using Bunifu.UI.WinForms;


namespace CapaPresentaciones
{
    public partial class P_TablaSemestre : Form
    {
        readonly E_Semestre ObjEntidad;
        readonly N_Semestre ObjNegocio;
        
        public P_TablaSemestre()
        {
            ObjEntidad = new E_Semestre();
            ObjNegocio = new N_Semestre();
            InitializeComponent();
            MostrarRegistros();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            
        }
        public void AccionesTabla()
        {
            //dgvDatos.Columns[0].DisplayIndex = 3;
            //dgvDatos.Columns[1].DisplayIndex = 3;
            //dgvDatos.Columns[2].Visible = false;

            dgvDatos.Columns[0].HeaderText = "Semestre";
            dgvDatos.Columns[1].HeaderText = "Fecha de inicio";
            
        }
        public void MostrarRegistros()
        {
            dgvDatos.DataSource = N_Semestre.SemestreActual(); // El filtro es por departamento
            
            AccionesTabla();
        }
        
        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        private void ActualizarColor()
        {
            lblTitulo.Focus();
        }
        private string SiguienteSemestre(string Semestre)
        {
           
            string nuevoSemestre;
            string PrimerOSegundo=Semestre.Substring(5);
            int AñoSemestre = Int32.Parse(Semestre.Substring(0, 4));
            if (PrimerOSegundo == "I")
            {
                nuevoSemestre = AñoSemestre.ToString() + "-II";
            }
            else
            {
                AñoSemestre = Int32.Parse(Semestre.Substring(0, 4)) + 1;
                nuevoSemestre = AñoSemestre.ToString() + "-I";
            }
            

            return (nuevoSemestre);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (P_DatosSemestre EditarRegistro = new P_DatosSemestre())
            {
               

                DataTable Semestre = N_Semestre.SemestreActual();
                string semestreActual = Semestre.Rows[0]["Denominacion"].ToString();
                EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                Program.Evento = 1;
                EditarRegistro.txtSemestre.Text = semestreActual.ToString();
                

                //EditarRegistro.Owner = Fondo;
                EditarRegistro.ShowDialog();
                EditarRegistro.Dispose();
                //Fondo.Dispose();
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActualizarColor();
            Form Fondo = new Form();
            using (P_DatosSemestre NuevoRegistro = new P_DatosSemestre())
            {


                
                NuevoRegistro.Owner = Fondo;
                DataTable Semestre = N_Semestre.SemestreActual();
                string semestreActual = Semestre.Rows[0]["Denominacion"].ToString();
                NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
                NuevoRegistro.txtSemestre.Text = SiguienteSemestre(semestreActual);
                
                NuevoRegistro.ShowDialog();
                NuevoRegistro.Dispose();

                Fondo.Dispose();
            }


        }

        private void P_TablaSemestre_Load(object sender, EventArgs e)
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            txtSemestreActivo.Text = Semestre.Rows[0]["Denominacion"].ToString();
        }

        //private void btnAgregar_Click(object sender, EventArgs e)
        //{
        //    ActualizarColor();

        //    Form Fondo = new Form();
        //    using (P_DatosSemestre NuevoRegistro = new P_DatosSemestre())
        //    {
        //        //Fondo.StartPosition = FormStartPosition.Manual;
        //        //Fondo.FormBorderStyle = FormBorderStyle.None;
        //        //Fondo.Opacity = .70d;
        //        //Fondo.BackColor = Color.Black;
        //        //Fondo.WindowState = FormWindowState.Maximized;
        //        //Fondo.TopMost = true;
        //        //Fondo.Location = this.Location;
        //        //Fondo.ShowInTaskbar = false;
        //        //Fondo.Show();

        //        NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
        //        NuevoRegistro.Owner = Fondo;
        //        NuevoRegistro.ShowDialog();
        //        NuevoRegistro.Dispose();

        //        Fondo.Dispose();
        //    }
        //}

        //private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
        //    //{
        //    //    Form Fondo = new Form();

        //    //    using (P_DatosSemestre EditarRegistro = new P_DatosSemestre())
        //    //    {
        //    //        //Fondo.StartPosition = FormStartPosition.Manual;
        //    //        //Fondo.FormBorderStyle = FormBorderStyle.None;
        //    //        //Fondo.Opacity = .70d;
        //    //        //Fondo.BackColor = Color.Black;
        //    //        //Fondo.WindowState = FormWindowState.Maximized;
        //    //        //Fondo.TopMost = true;
        //    //        //Fondo.Location = this.Location;
        //    //        //Fondo.ShowInTaskbar = false;
        //    //        //Fondo.Show();

        //    //        EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

        //    //        Program.Evento = 1;

        //    //        EditarRegistro.txtDenominacionSemestre.Text = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();

        //    //        //EditarRegistro.Owner = Fondo;
        //    //        EditarRegistro.ShowDialog();
        //    //        EditarRegistro.Dispose();

        //    //        //Fondo.Dispose();
        //    //    }
        //    //}

        //    //if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
        //    //{
        //    //    if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
        //    //    {
        //    //        ObjEntidad.Denominacion = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
        //    //        ObjNegocio.EliminarSemestre(ObjEntidad);
        //    //        A_Dialogo.DialogoConfirmacion("Registro eliminado exitosamente");
        //    //        MostrarRegistros();
        //    //    }
        //    //}
        //}
    }
}
