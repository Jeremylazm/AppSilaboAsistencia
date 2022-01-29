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
            CodDocente = pCodDocente;
            dgvTabla = pdgv;
            CodAsignatura = pCodAsignatura;
            CodDepartamentoA = E_InicioSesion.CodDepartamentoA;
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            DataTable EsculeaProf = N_Catalogo.VerEscuelaAsignatura(CodSemestre,CodAsignatura);

            
            LimtFechaInf = DateTime.ParseExact(Semestre.Rows[0][1].ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("es-ES")).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));
            CodEscuelaP = EsculeaProf.Rows[0][0].ToString();
            
            ObjEntidadEstd = new E_AsistenciaEstudiante();
            ObjNegocioEstd = new N_AsistenciaEstudiante();
            ObjEntidadDoc = new E_AsistenciaDocentePorAsignatura();
            ObjNegocioDoc = new N_AsistenciaDocentePorAsignatura();
            ObjNegocio = new N_Catalogo();

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
            dgvDatos.Columns[2].HeaderText = "Nro.";
            dgvDatos.Columns[2].ReadOnly = true;
            dgvDatos.Columns[3].HeaderText = "Código";
            dgvDatos.Columns[3].ReadOnly = true;
            dgvDatos.Columns[4].HeaderText = "Apellido Paterno";
            dgvDatos.Columns[4].ReadOnly = true;
            dgvDatos.Columns[5].HeaderText = "Apellido Materno";
            dgvDatos.Columns[5].ReadOnly = true;
            dgvDatos.Columns[6].HeaderText = "Nombres";
            dgvDatos.Columns[6].ReadOnly = true;
            dgvDatos.Columns[7].Visible = false;
            dgvDatos.Columns[8].Visible = false;
        }
        
        private void MostrarEstudiantesNuevoRegistro()
        {
            //agregar fila al datagridview
            int i = 0;
            foreach (DataRow fila in dgvTabla.Rows)
            {
                //DataGridViewComboBoxCell textBoxcell = (DataGridViewComboBoxCell)(fila["cbxObservaciones"]);
                //textBoxcell.Value = fila[6];
                //fila.Cells[0].Value = (fila.Cells[6].Value.Equals("SI")) ? ListaImagenes.Images[1] : ListaImagenes.Images[0];



                dgvDatos.Rows.Add(ListaImagenes.Images[0], "", fila[0], fila[1], fila[2], fila[3], fila[4], "", "");
                dgvDatos.Rows[i].Cells[0].Tag = false;

                i += 1;

            }
            //atributos de las columnas
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.AutoSizeMode= DataGridViewAutoSizeColumnMode.None;

            }
            
            dgvDatos.Columns[0].MinimumWidth = 100;
            dgvDatos.Columns[0].Width = 100;
            dgvDatos.Columns[1].MinimumWidth = 200;
            dgvDatos.Columns[1].Width = 200;
            dgvDatos.Columns[2].MinimumWidth = 40;
            dgvDatos.Columns[2].Width = 40;
            dgvDatos.Columns[3].MinimumWidth = 80;
            dgvDatos.Columns[3].Width = 80;
            dgvDatos.Columns[4].MinimumWidth = 250;
            dgvDatos.Columns[4].Width = 250;
            dgvDatos.Columns[5].MinimumWidth = 250;
            dgvDatos.Columns[5].Width = 250;
            dgvDatos.Columns[6].MinimumWidth = 200;
            dgvDatos.Columns[6].Width = 200;
           
            AccionesTabla();
        }

        public void MostrarEstudiantesRegistrados()
        {
            //agregar fila al datagridview
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
            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
            {
                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            }

            dgvDatos.Columns[0].MinimumWidth = 100;
            dgvDatos.Columns[0].Width = 100;
            dgvDatos.Columns[1].MinimumWidth = 200;
            dgvDatos.Columns[1].Width = 200;
            dgvDatos.Columns[2].MinimumWidth = 40;
            dgvDatos.Columns[2].Width = 40;
            dgvDatos.Columns[3].MinimumWidth = 80;
            dgvDatos.Columns[3].Width = 80;
            dgvDatos.Columns[4].MinimumWidth = 250;
            dgvDatos.Columns[4].Width = 250;
            dgvDatos.Columns[5].MinimumWidth = 250;
            dgvDatos.Columns[5].Width = 250;
            dgvDatos.Columns[6].MinimumWidth = 200;
            dgvDatos.Columns[6].Width = 200;
            AccionesTabla();
        }

        public void BuscarEstudiantes()
        {
            //A_Dialogo.DialogoInformacion("esi: "+ N_Catalogo.VerEscuelaAsignatura(CodSemestre,CodAsignatura).ToString());
            //dgvDatos.DataSource= N_Matricula.BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodEscuelaP, CodAsignatura, txtBuscar.Text);
            DataTable EstudiantesMatriculados = N_Matricula.BuscarEstudiantesMatriculadosAsignatura(CodSemestre, CodEscuelaP, CodAsignatura, txtBuscar.Text);
            dgvDatos.DataSource = null;
            dgvDatos.Rows.Clear();

            if (Program.Evento == 0)
			{
                //buscar estudiantes el dgv de agregar
                if (EstudiantesMatriculados.Rows.Count != 0)
                {

                    foreach (DataRow f in EstudiantesMatriculados.Rows)
                    {

                        if (dgvTabla.Rows.Count != 0)
                        {
                            //agregar fila al datagridview
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
                            //atributos de las columnas
                            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
                            {
                                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                Columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                            }

                            dgvDatos.Columns[0].MinimumWidth = 100;
                            dgvDatos.Columns[0].Width = 100;
                            dgvDatos.Columns[1].MinimumWidth = 200;
                            dgvDatos.Columns[1].Width = 200;
                            dgvDatos.Columns[2].MinimumWidth = 40;
                            dgvDatos.Columns[2].Width = 40;
                            dgvDatos.Columns[3].MinimumWidth = 80;
                            dgvDatos.Columns[3].Width = 80;
                            dgvDatos.Columns[4].MinimumWidth = 250;
                            dgvDatos.Columns[4].Width = 250;
                            dgvDatos.Columns[5].MinimumWidth = 250;
                            dgvDatos.Columns[5].Width = 250;
                            dgvDatos.Columns[6].MinimumWidth = 200;
                            dgvDatos.Columns[6].Width = 200;
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
                            //agregar fila al datagridview
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
                            //atributos de las columnas
                            dgvDatos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            foreach (DataGridViewColumn Columna in dgvDatos.Columns)
                            {
                                Columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                Columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                            }

                            dgvDatos.Columns[0].MinimumWidth = 100;
                            dgvDatos.Columns[0].Width = 100;
                            dgvDatos.Columns[1].MinimumWidth = 200;
                            dgvDatos.Columns[1].Width = 200;
                            dgvDatos.Columns[2].MinimumWidth = 40;
                            dgvDatos.Columns[2].Width = 40;
                            dgvDatos.Columns[3].MinimumWidth = 80;
                            dgvDatos.Columns[3].Width = 80;
                            dgvDatos.Columns[4].MinimumWidth = 250;
                            dgvDatos.Columns[4].Width = 250;
                            dgvDatos.Columns[5].MinimumWidth = 250;
                            dgvDatos.Columns[5].Width = 250;
                            dgvDatos.Columns[6].MinimumWidth = 200;
                            dgvDatos.Columns[6].Width = 200;
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
                ObjEntidadEstd.CodEscuelaP = CodEscuelaP;
                ObjEntidadEstd.CodAsignatura = CodAsignatura;
                ObjEntidadEstd.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES")); //actual del registro
                ObjEntidadEstd.Hora = hora;//actual del registro
                ObjEntidadEstd.CodEstudiante = dr.Cells[3].Value.ToString();
                ObjEntidadEstd.Asistio = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                ObjEntidadEstd.Observacion = (dr.Cells[0].Tag.Equals(true))? ((dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString()): ((dr.Cells[1].Value == null|| dr.Cells[1].Value.ToString()=="") ? "FALTO SIN JUSTIFICAR" : dr.Cells[1].Value.ToString());
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
                ObjEntidadEstd.CodEscuelaP = CodEscuelaP;
                ObjEntidadEstd.CodAsignatura = CodAsignatura;
                ObjEntidadEstd.Fecha = DateTime.Parse(txtFecha.Text.ToString()).ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("es-ES"));//fecha en la que fue registrado
                ObjEntidadEstd.Hora = hora;//hora en el que fue registrado
                ObjEntidadEstd.CodEstudiante = dr.Cells[3].Value.ToString();

                string AsistioActualizado = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                string ObsActualizada = (dr.Cells[0].Tag.Equals(true)) ? ((dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString()) : ((dr.Cells[1].Value == null || dr.Cells[1].Value.ToString() == "") ? "FALTO SIN JUSTIFICAR" : dr.Cells[1].Value.ToString());

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
                            EditarRegistroEstudiantes();
                            A_Dialogo.DialogoConfirmacion("Se ha Editado  la Asistencia" + Environment.NewLine + " del Docente y los Estudiantes");
                            
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

        private void AjustarTabla()
        {
            // Verificar el numero de filas de los resultados
            if (dgvDatos.Rows.Count <= 20)
            {
                sbDatos.Visible = false;
                dgvDatos.Width = 1124;
                this.Height = dgvDatos.Rows.Count * 26 + 253;
            }
            else
            {
                sbDatos.Visible = true;
                sbDatos.Maximum = dgvDatos.Rows.Count - 20;
                this.Height = 773;
            }
        }
        public void ActualizarCheckBox()
        {
            bool R = true;
            foreach (DataGridViewRow Fila in dgvDatos.Rows)
            {
                if (Fila.Cells[0].Tag.Equals(false) && Fila.Cells[0]!=null)
                {
                    R = false;
                    //ckbMarcarTodos.Checked = false;
                    break;
                }

            }
            if (R.Equals(true))
            {
                Console.WriteLine("llegue aqui");
                ckbMarcarTodos.Checked=true;
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
            //ActualizarCheckBox();
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
                ActualizarCheckBox();
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
                    btnMostrarPlanSesiones.Enabled = false;
                    A_Dialogo.DialogoInformacion("Aun no subio un plan de sesiones");
                    txtTema.Text = "No hay tema a sugerir";
                    btnGuardar.Enabled = false;
                }
                MostrarEstudiantesNuevoRegistro();

            }
            else
            {
                MostrarEstudiantesRegistrados();

            }
            //ActualizarCheckBox();
            AjustarTabla();
            
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

            }

            GuardarRegistroDocente();
            Close();
        }

        private void btnMostrarPlanSesiones_Click(object sender, EventArgs e)
        {
            P_TablaSesionesPendientes Sesiones = new P_TablaSesionesPendientes(CodAsignatura, CodDocente);

            Sesiones.ShowDialog();
            Sesiones.Dispose();
        }


        private void sbDatos_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            //MessageBox.Show(sbDatos.Value.ToString());
        }

		private void ckbMarcarTodos_Click(object sender, EventArgs e)
		{
            //probar
		}
	}
}
