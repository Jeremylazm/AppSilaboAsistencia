using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.IO;
using SpreadsheetLight;
using ClosedXML.Excel;
using Ayudas;
using System.Globalization;
namespace CapaPresentaciones
{
    public partial class P_TablaAsistenciaEstudiantes : Form
    {
        readonly N_Catalogo ObjNegocio;
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA;
        private readonly string CodEscuelaP;
        public readonly string CodAsignatura;
        public readonly string CodDocente;
       
        readonly E_AsistenciaEstudiante ObjEntidadEstd;
        readonly N_AsistenciaEstudiante ObjNegocioEstd;
        readonly E_AsistenciaDocentePorAsignatura ObjEntidadDoc;
        readonly N_AsistenciaDocentePorAsignatura ObjNegocioDoc;
        public string hora;
        private DataTable PlanSesion;
        public DataTable dgvTabla;
        
        public string LimtFechaInf;
        //private readonly string CodDepartamento = E_DepartamentoAcademico.CodDepartamentoA;
        public P_TablaAsistenciaEstudiantes(string pCodAsignatura, string pCodDocente, DataTable pdgv)
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LimtFechaInf = DateTime.ParseExact(Semestre.Rows[0][1].ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
            CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
            CodEscuelaP = E_InicioSesion.CodEscuelaP;
            CodAsignatura = pCodAsignatura;
            CodDocente = pCodDocente;
            dgvTabla = pdgv;

            ObjNegocio = new N_Catalogo();
            ObjEntidadEstd = new E_AsistenciaEstudiante();
            ObjNegocioEstd = new N_AsistenciaEstudiante();
            ObjEntidadDoc = new E_AsistenciaDocentePorAsignatura();
            ObjNegocioDoc = new N_AsistenciaDocentePorAsignatura();

            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pbLogo, lblFecha, lblMarcarTodos, lblTema, txtFecha };
            Docker.SubscribeControlsToDragEvents(Controles);
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            lblTitulo.Text += CodAsignatura;
            lblFecha.Text += "    ";
            PlanSesion = N_Catalogo.RecuperarPlanDeSesionAsignatura(CodSemestre, CodAsignatura, CodDocente);
            //MostrarEstudiantes();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 8;
            dgvDatos.Columns[1].DisplayIndex = 8;
            dgvDatos.Columns[2].HeaderText = "Id.";
            dgvDatos.Columns[2].ReadOnly = true;
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[3].ReadOnly = true;
            dgvDatos.Columns[4].HeaderText = "Apellido Paterno";
            dgvDatos.Columns[4].ReadOnly = true;
            dgvDatos.Columns[5].HeaderText = "Apellido Materno";
            dgvDatos.Columns[5].ReadOnly = true;
            dgvDatos.Columns[6].HeaderText = "Nombre";
            dgvDatos.Columns[6].ReadOnly = true;
            dgvDatos.Columns[7].Visible = false;
            dgvDatos.Columns[8].Visible = false;
        }

        public void InicializarValores()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila.Cells["cbxObservaciones"]);
                textBoxcell.Value = "";
                fila.Cells[0].Value = ListaImagenes.Images[0];
                fila.Cells[0].Tag = false;
            }
        }

        public void InicializarValoresEditar()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila.Cells["cbxObservaciones"]);
                textBoxcell.Value = fila.Cells[8].Value;
                fila.Cells[0].Value = (fila.Cells[7].Value.Equals("SI")) ? ListaImagenes.Images[1] : ListaImagenes.Images[0];
                if(fila.Cells[7].Value.Equals("SI"))
                {
                    fila.Cells[0].Tag = true;
                }
                else
				{
                    fila.Cells[0].Tag = false;
                }
            }
        }

        private void MostrarEstudiantesNuevoRegistro()
        {
            int i = 0;
            foreach (DataRow fila in dgvTabla.Rows)
            {
                //DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila["cbxObservaciones"]);
                //textBoxcell.Value = fila[6];
                //fila.Cells[0].Value = (fila.Cells[6].Value.Equals("SI")) ? ListaImagenes.Images[1] : ListaImagenes.Images[0];
               
                

                dgvDatos.Rows.Add(ListaImagenes.Images[0],"", fila[0], fila[1], fila[2], fila[3], fila[4],"","");
                dgvDatos.Rows[i].Cells[0].Tag = false;
    
                i += 1;

            }
            //dgvDatos.DataSource = dgvTabla;
            AccionesTabla();
        }

        public void MostrarEstudiantesRegistrados()
        {
            int i = 0;
            foreach (DataRow fila in dgvTabla.Rows)
            {
                //DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila["cbxObservaciones"]);
                //textBoxcell.Value = fila[6];
                //fila.Cells[0].Value = (fila.Cells[6].Value.Equals("SI")) ? ListaImagenes.Images[1] : ListaImagenes.Images[0];
                if (fila[5].Equals("SI"))
                {

                    dgvDatos.Rows.Add(ListaImagenes.Images[1], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);
                    dgvDatos.Rows[i].Cells[0].Tag = true;
                }
                else
                {
                    dgvDatos.Rows.Add(ListaImagenes.Images[0], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);


                    dgvDatos.Rows[i].Cells[0].Tag = false;
                }

                i += 1;

            }
            //dgvDatos.DataSource = dgvTabla;
            AccionesTabla();
        }

        public void BuscarEstudiantes()
        {
            //dgvDatos.DataSource= N_Matricula.BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodEscuelaP, CodAsignatura, txtBuscar.Text);
            DataTable EstudiantesMatriculados = N_Matricula.BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodEscuelaP, CodAsignatura, txtBuscar.Text);
            this.dgvDatos.DataSource = null;


            this.dgvDatos.Rows.Clear();
            if (Program.Evento == 0)
			{
                //buscar estudiantes el dgv de agregar
                if (EstudiantesMatriculados.Rows.Count != 0)
                {

                    foreach (DataRow f in EstudiantesMatriculados.Rows)
                    {

                        if (dgvTabla.Rows.Count != 0)
                        {
                           
                            int j = 0;
                            foreach (DataRow fila in dgvTabla.Rows)
                            {
                                if (f[1].ToString() == fila[1].ToString())
                                {

                                    dgvDatos.Rows.Add(ListaImagenes.Images[0], "", fila[0], fila[1], fila[2], fila[3], fila[4], "", "");
                                    dgvDatos.Rows[j].Cells[0].Tag = false;
                                    j += 1;
                                }
                            }
                            AccionesTabla();
                        }
                    }
                }
            }
			else
			{
                //buscar estudiantes el dgv de editar
                if (EstudiantesMatriculados.Rows.Count != 0)
                {

                   
                    foreach (DataRow f in EstudiantesMatriculados.Rows)
                    {

                        if (dgvTabla.Rows.Count != 0)
                        {
                            //A_Dialogo.DialogoInformacion("si hay EN LA TABLA PRICIPAL");
                            int j = 0;
                            foreach (DataRow fila in dgvTabla.Rows)
                            {
                                if (f[1].ToString() == fila[1].ToString())
                                {

                                    if (fila[5].ToString() == "SI")
                                    {

                                        dgvDatos.Rows.Add(ListaImagenes.Images[1], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);
                                        dgvDatos.Rows[j].Cells[0].Tag = true;
                                    }
                                    else
                                    {

                                        dgvDatos.Rows.Add(ListaImagenes.Images[0], fila[6], fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6]);


                                        dgvDatos.Rows[j].Cells[0].Tag = false;
                                    }
                                    j += 1;
                                }
                            }
                            AccionesTabla();
                        }
                    }
                }
            }
            
        }

        public void AgregarRgistroEstudiantes()
        {
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                ObjEntidadEstd.CodSemestre = CodSemestre;
                ObjEntidadEstd.CodEscuelaP = N_Catalogo.VerEscuelaAsignatura(CodSemestre, CodAsignatura).ToString();
                ObjEntidadEstd.CodAsignatura = CodAsignatura;
                ObjEntidadEstd.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")); //actual del registro
                ObjEntidadEstd.Hora = hora;//actual del registro
                ObjEntidadEstd.CodEstudiante = dr.Cells[3].Value.ToString();
                ObjEntidadEstd.Asistio = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                ObjEntidadEstd.Observacion = (dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString();
                ObjNegocioEstd.RegistrarAsistenciaEstudiante(ObjEntidadEstd);
            }
            //A_Dialogo.DialogoConfirmacion("El registro de la asistencia de los estudiantes se insertó éxitosamente");
        }

        public void EditarRegistroEstudiantes()
        {
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                //cambiar es
                ObjEntidadEstd.CodSemestre = CodSemestre;
                ObjEntidadEstd.CodEscuelaP = N_Catalogo.VerEscuelaAsignatura(CodSemestre,CodAsignatura).ToString();//EscuelaProf
                ObjEntidadEstd.CodAsignatura = CodAsignatura;
                ObjEntidadEstd.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));//fecha en la que fue registrado
                ObjEntidadEstd.Hora = hora;//hora en el que fue registrado
                ObjEntidadEstd.CodEstudiante = dr.Cells[3].Value.ToString();
                
                string AsistioActualizado = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";              
                string ObsActualizada = (dr.Cells[1].Value==null)?"":dr.Cells[1].Value.ToString();

                ObjNegocioEstd.ActualizarAsistenciaEstudiante(ObjEntidadEstd, AsistioActualizado, ObsActualizada);
            }
            //A_Dialogo.DialogoConfirmacion("El registro de la asistencia de los estudiantes se Editó éxitosamente");
        }

        public void GuardarRegistroDocente()
        {
            if (Program.Evento == 0)//add
            {


                // buscar el registro de asistencia de Docente de la fecha actual
                //DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, txtFecha.Text.ToString(), txtFecha.Text.ToString(),"");

                try
                {
                    ObjEntidadDoc.CodSemestre = CodSemestre;
                    ObjEntidadDoc.CodDepartamentoA = CodDepartamentoA;
                    ObjEntidadDoc.CodAsignatura = CodAsignatura;
                    ObjEntidadDoc.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                    ObjEntidadDoc.Hora = hora;
                    ObjEntidadDoc.CodDocente = CodDocente;
                    ObjEntidadDoc.Asistio = "SI";
                    ObjEntidadDoc.TipoSesion = txtTipoSesion.Text.ToString().ToUpper();
                    ObjEntidadDoc.NombreTema = txtTema.Text.ToString();
                    ObjEntidadDoc.Observacion = "";

                    ObjNegocioDoc.RegistrarAsistenciaDocentePorAsignatura(ObjEntidadDoc);
                    //A_Dialogo.DialogoConfirmacion("El registro de Asistencia Docente se insertó éxitosamente");
                    AgregarRgistroEstudiantes();
                    A_Dialogo.DialogoConfirmacion("Se ha registrado correctamente la asistencia" + Environment.NewLine + " del Docente y los Estudiantes");
                    Program.Evento = 0;
                    Close();


                }
                catch (Exception)
                {
                    A_Dialogo.DialogoError("Error al insertar el registro");
                }
            }
            // Editar
            else
            {

                try
                {
                    if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea editar el registro?") == DialogResult.Yes)
                    {
                        DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, DateTime.Parse(txtFecha.Text.ToString(), CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), DateTime.Parse(txtFecha.Text.ToString(), CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")), "");

                        if (Resultado.Rows.Count != 0)
                        {

                            ObjEntidadDoc.CodSemestre = CodSemestre;
                            ObjEntidadDoc.CodAsignatura = CodAsignatura;
                            ObjEntidadDoc.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
                            ObjEntidadDoc.Hora = hora;

                            string TipoSesionActualizado = txtTipoSesion.Text.ToString().ToUpper();
                            string NombreTemaActualizado = txtTema.Text.ToString();

                            string ObsActulizado = "";


                            ObjNegocioDoc.ActualizarAsistenciaDocentePorAsignatura(ObjEntidadDoc, TipoSesionActualizado, NombreTemaActualizado, ObsActulizado);
                            A_Dialogo.DialogoConfirmacion("Se ha Editado  la Asistencia" + Environment.NewLine + " del Docente y los Estudiantes");
                            EditarRegistroEstudiantes();
                            Program.Evento = 0;

                            Close();
                        }
                        else
                        {
                            A_Dialogo.DialogoError("El registro de Docente no existe");
                        }
                    }

                }
                catch (Exception)
                {
                    A_Dialogo.DialogoError("Error al editar el registro");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEstudiantes();
        }

        private void btnSesiones_Click(object sender, EventArgs e)
        {
            P_TablaSesionesPendientes Sesiones = new P_TablaSesionesPendientes(CodAsignatura, CodDocente);

            Sesiones.ShowDialog();
            Sesiones.Dispose();
        }

        private void dgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
            {
                return;
            }

            var DataGrid = (sender as DataGridView);

            if (e.ColumnIndex == 0)
                DataGrid.Cursor = Cursors.Hand;
            else
                DataGrid.Cursor = Cursors.Default;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
            {
                return;
            }

            var DataGrid = (sender as DataGridView);

            if (e.ColumnIndex == 0)
            {
                var Celda = DataGrid.Rows[e.RowIndex].Cells[0];

                if ((Celda.Tag == null) || !((bool)Celda.Tag))
                {
                    // Falso
                    DataGrid.Rows[e.RowIndex].Cells[0].Value = ListaImagenes.Images[1];
                    DataGrid.Rows[e.RowIndex].Cells[0].Tag = true;
                }
                else
                {
                    DataGrid.Rows[e.RowIndex].Cells[0].Value = ListaImagenes.Images[0];
                    DataGrid.Rows[e.RowIndex].Cells[0].Tag = false;
                }
            }           
        }

        private void ckbMarcarTodos_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (ckbMarcarTodos.Checked)
            {
                foreach (DataGridViewRow Fila in dgvDatos.Rows)
                {
                    Fila.Cells[0].Value = ListaImagenes.Images[1];
                    Fila.Cells[0].Tag = true;
                }
            }
            else
            {
                foreach (DataGridViewRow Fila in dgvDatos.Rows)
                {
                    Fila.Cells[0].Value = ListaImagenes.Images[0];
                    Fila.Cells[0].Tag = false;
                }
            }
        }


        private void P_TablaAsistenciaEstudiantes_Load(object sender, EventArgs e)
        {
            if (Program.Evento == 0)
            {
                if (PlanSesion.Rows.Count > 0)
                {
                    int valor = 9;
                    // Se crea un archivo temporal, para después abrirlo con ClosedXML
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + "temp.xlsx";

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    if (File.Exists(fullFilePath))
                    {
                        File.Delete(fullFilePath);
                    }

                    byte[] archivo = PlanSesion.Rows[0]["PlanSesiones"] as byte[];

                    File.WriteAllBytes(fullFilePath, archivo);

                    SLDocument sl = new SLDocument(fullFilePath);
                    while (sl.GetCellValueAsString(valor, 8) == "Hecho")
                    {
                        valor++;
                        if (sl.GetCellValueAsString(valor, 3) == "")
                        {
                            valor++;
                        }
                    }
                    txtTema.Text = sl.GetCellValueAsString(valor, 3);
                }
                else
                {
                    btnSesiones.Enabled = false;
                    A_Dialogo.DialogoInformacion("Aun no subio un plan de sesiones");
                    txtTema.Text = "No hay tema a sugerir";
                    btnGuardar.Enabled = false;
                }
                MostrarEstudiantesNuevoRegistro();
                //InicializarValores();
                //Program.Evento = 0;
            }
            else
            {
                MostrarEstudiantesRegistrados();
                //InicializarValoresEditar();
                //Program.Evento = 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Program.Evento == 0)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "/temp/";
                string fullFilePath = folder + "temp.xlsx";

                int valor = 9;
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (File.Exists(fullFilePath))
                {
                    File.Delete(fullFilePath);
                }

                byte[] archivo = PlanSesion.Rows[0]["PlanSesiones"] as byte[];

                File.WriteAllBytes(fullFilePath, archivo);
                SLDocument sl = new SLDocument(fullFilePath);
                while (sl.GetCellValueAsString(valor, 8) == "Hecho")
                {
                    valor++;
                    if (sl.GetCellValueAsString(valor, 3) == "")
                    {
                        valor++;
                    }
                }

                XLWorkbook wb = new XLWorkbook(fullFilePath);
                wb.Worksheet(1).Cell("H" + valor.ToString()).Value = wb.Worksheet(1).Cell("H" + valor.ToString()).Value + "Hecho";
                wb.SaveAs(fullFilePath);
                byte[] arreglo = null;
                arreglo = File.ReadAllBytes(fullFilePath);

                ObjNegocio.ActualizarPlanSesionesAsignatura(CodSemestre, CodAsignatura, CodDocente, arreglo);
                //GuardarRegistroDocente();
                //Close();
            }
            else
            {
                //GuardarRegistroDocente();
                //Close();               
            }
            
            GuardarRegistroDocente();
            Close();
        }

	}
}
