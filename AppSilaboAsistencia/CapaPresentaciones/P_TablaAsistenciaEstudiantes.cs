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

namespace CapaPresentaciones
{
    public partial class P_TablaAsistenciaEstudiantes : Form
    {
        readonly N_Catalogo ObjNegocio;
        private readonly string CodSemestre;
        public string CodAsignatura;
        public string CodDocente;
        readonly E_AsistenciaEstudiante ObjEntidadEstd;
        readonly N_AsistenciaEstudiante ObjNegocioEstd;
        readonly E_AsistenciaDocentePorAsignatura ObjEntidadDoc;
        readonly N_AsistenciaDocentePorAsignatura ObjNegocioDoc;
        public string hora;
        private DataTable PlanSesion;
        public DataTable dgvTabla;
        
        public string LmFechaInf;
        //private readonly string CodDepartamento = E_DepartamentoAcademico.CodDepartamentoA;
        public P_TablaAsistenciaEstudiantes(string pCodAsignatura, string pCodDocente, DataTable pdgv)
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LmFechaInf = Semestre.Rows[0][1].ToString();
            ObjNegocio = new N_Catalogo();
            CodAsignatura = pCodAsignatura;
            CodDocente = pCodDocente;
            dgvTabla = pdgv;
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
            dgvDatos.Columns[0].DisplayIndex = 6;
            dgvDatos.Columns[1].DisplayIndex = 6;
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
        }

        private void AccionesTablaEditar()
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
            dgvDatos.DataSource = dgvTabla;
            AccionesTabla();
        }

        public void MostrarEstudiantesRegistrados()
        {
            dgvDatos.DataSource = dgvTabla;
            AccionesTablaEditar();
        }

        public void BuscarEstudiantes()
        {
            dgvDatos.DataSource = N_Matricula.BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodAsignatura.Substring(6), CodAsignatura, txtBuscar.Text);
        }

        public void AgregarRgistroEstudiantes()
        {
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                ObjEntidadEstd.CodSemestre = CodSemestre;
                ObjEntidadEstd.CodEscuelaP = CodAsignatura.Substring(6);
                ObjEntidadEstd.CodAsignatura = CodAsignatura;
                ObjEntidadEstd.Fecha = txtFecha.Text.ToString();//actual del registro
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
                ObjEntidadEstd.CodSemestre = CodSemestre;
                ObjEntidadEstd.CodEscuelaP = CodAsignatura.Substring(6);
                ObjEntidadEstd.CodAsignatura = CodAsignatura;
                ObjEntidadEstd.Fecha = txtFecha.Text.ToString();//fecha en la que fue registrado
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
                    ObjEntidadDoc.CodDepartamentoA = "IF";
                    ObjEntidadDoc.CodAsignatura = CodAsignatura;
                    ObjEntidadDoc.Fecha = txtFecha.Text.ToString();
                    ObjEntidadDoc.Hora = hora;
                    ObjEntidadDoc.CodDocente = CodDocente;
                    ObjEntidadDoc.Asistio = "SI";
                    ObjEntidadDoc.TipoSesion = "Seleccionar";
                    ObjEntidadDoc.NombreTema = txtTema.Text.ToString();
                    ObjEntidadDoc.Observacion = "recuDelComboboX";

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


                if (A_Dialogo.DialogoPreguntaAceptarCancelar("¿Realmente desea editar el registro?") == DialogResult.Yes)
                {
                    DataTable Resultado = N_AsistenciaDocentePorAsignatura.BuscarSesionAsignatura(CodSemestre, CodDocente, CodAsignatura, txtFecha.Text.ToString(), txtFecha.Text.ToString(), "");

                    if (Resultado.Rows.Count != 0)
                    {

                        ObjEntidadDoc.CodSemestre = CodSemestre;
                        ObjEntidadDoc.CodAsignatura = CodAsignatura;
                        ObjEntidadDoc.Fecha = txtFecha.Text.ToString();
                        ObjEntidadDoc.Hora = hora;

                        string TipoSesionActualizado = "SeleccionarActualizado";
                        string NombreTemaActualizado = txtTema.Text.ToString();
                        string fechaActualizado = txtFecha.Text.ToString();
                        string ObsActulizado = "recuDelComboboX";


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
                    
                
                /*catch (Exception)
                {
                    A_Dialogo.DialogoError("Error al editar el registro");
                }*/
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
            P_TablaSesiones Sesiones = new P_TablaSesiones(CodAsignatura, CodDocente);

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
                InicializarValores();
                //Program.Evento = 0;
            }
            else
            {
                MostrarEstudiantesRegistrados();
                InicializarValoresEditar();
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
