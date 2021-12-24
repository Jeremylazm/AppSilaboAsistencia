using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CapaNegocios;
using System.Data;
using CapaEntidades;
using Ayudas;
using System.Drawing;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadasEstudiantes : Form
    {
        readonly N_Catalogo ObjCatalogo;
        readonly E_Matricula ObjEntidadMatricula;
        readonly N_Matricula ObjNegocioMatricula;
        private readonly string CodSemestre;
        private readonly string CodDocente = E_InicioSesion.Usuario;
        private readonly string CodEscuelaP = "IF";

        public P_TablaAsignaturasAsignadasEstudiantes()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            ObjCatalogo = new N_Catalogo();
            ObjEntidadMatricula = new E_Matricula();
            ObjNegocioMatricula = new N_Matricula();
            InitializeComponent();
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvDatos, sbDatos);
            MostrarAsignaturas();
        }

        private void AccionesTabla()
        {
            dgvDatos.Columns[0].DisplayIndex = 5;
            dgvDatos.Columns[1].DisplayIndex = 5;
            dgvDatos.Columns[5].Visible = false;
            dgvDatos.Columns[2].HeaderText = "Código";
            dgvDatos.Columns[3].HeaderText = "Nombre";
            dgvDatos.Columns[4].HeaderText = "Escuela Profesional";
            dgvDatos.Columns[5].HeaderText = "Grupo";
        }

        private void MostrarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasDocente(CodSemestre, CodEscuelaP, CodDocente);
            AccionesTabla();
        }   

        public void BuscarAsignaturas()
        {
            dgvDatos.DataSource = N_Catalogo.BuscarAsignaturasAsignadasDocente(CodDocente, CodEscuelaP, CodDocente, txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public List<Tuple<string, string>> Parse(string CodAsignatura)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(service, chromeOptions);
            try
            {
                driver.Navigate().GoToUrl("http://ccomputo.unsaac.edu.pe/index.php?op=alcurso");
                
                IWebElement inputsearch = driver.FindElement(By.Name("curso"));
                inputsearch.SendKeys(CodAsignatura);
                inputsearch.Submit();

                IWebElement tableElement = driver.FindElement(By.XPath("//div[@id='main_container']/div[3]/div/div[2]/table"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                IList<IWebElement> rowTD;
                List<string> Codigos = new List<string>();
                List<string> Nombres = new List<string>();
                foreach (IWebElement row in tableRow)
                {
                    rowTD = row.FindElements(By.TagName("td"));
                    if (rowTD[1].Text != "ALUMNO")
                    {
                        Codigos.Add(rowTD[1].Text); // Agregar códigos
                        Nombres.Add(rowTD[2].Text); // Agregar nombres
                    }
                }
                driver.Close();
                driver.Quit();

                List<Tuple<string, string>> ListaActualizada = new List<Tuple<string, string>>();
                for (int i = 0; i < Codigos.Count; i++)
                {
                    ListaActualizada.Add(Tuple.Create(Codigos[i], Nombres[i]));
                }
                return ListaActualizada;
            }
            catch (Exception ex)
            {
                driver.Close();
                driver.Quit();
                if (ex is NoSuchElementException)
                {
                    A_Dialogo.DialogoError("El servidor se encuentra temporalmente fuera de servicio");
                    //MessageBox.Show("El servidor se encuentra temporalmente fuera de servicio.");
                }
                else if (ex is WebDriverException)
                {
                    A_Dialogo.DialogoError("No se encuentra conectado a Internet. Revise su conexión");
                    //MessageBox.Show("No se encuentra conectado a Internet. Revise su conexión.");
                }
            }

            return null;
        }

        public Tuple<string, string> BuscarEstudiante(List<Tuple<string, string>> ListaActualizada, string CodEstudiante)
        {
            foreach (var estudiante in ListaActualizada)
            {
                if (estudiante.Item1 == CodEstudiante)
                {
                    return estudiante;
                }
            }
            return null;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Estudiantes
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 0))
            {
                string CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();

                Form Fondo = new Form();
                using (P_TablaEstudiantesAsignatura Estudiantes = new P_TablaEstudiantesAsignatura(CodAsignatura))
                {
                    Fondo.StartPosition = FormStartPosition.Manual;
                    Fondo.FormBorderStyle = FormBorderStyle.None;
                    Fondo.Opacity = .70d;
                    Fondo.BackColor = Color.Black;
                    Fondo.WindowState = FormWindowState.Maximized;
                    Fondo.TopMost = true;
                    Fondo.Location = this.Location;
                    Fondo.ShowInTaskbar = false;
                    Fondo.Show();

                    Estudiantes.Owner = Fondo;
                    Estudiantes.ShowDialog();
                    Estudiantes.Dispose();

                    Fondo.Dispose();
                }
            }

            // Actualizar
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 1))
            {
                string CodAsignatura = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();

                List<Tuple<string, string>> ListaActualizada = Parse(CodAsignatura);
                if (ListaActualizada != null)
                {
                    DataTable Matriculados = N_Catalogo.ListaEstudiantesMatriculados(CodSemestre, CodAsignatura, CodDocente);
                    string ListaConcatenada = Matriculados.Rows[0]["Matriculados"].ToString();
                    String[] Lista = ListaConcatenada.Split(',');
                    List<string> NuevaLista = new List<string>();

                    int matriculados = 0, desmatriculados = 0;
                    // Buscar cod estudiante de la lista de matriculados en la lista actualizada:
                    foreach (var codigo in Lista)
                    {
                        Tuple<string, string> estudiante = BuscarEstudiante(ListaActualizada, codigo);
                        if (estudiante != null) // cod estudiante se encuentra en la lista actualizada
                        {
                            ListaActualizada.Remove(estudiante);
                            NuevaLista.Add(codigo);
                        }
                        else
                        {
                            if (codigo != "")
                            {
                                // Eliminar de la tabla matricula 
                                ObjEntidadMatricula.CodSemestre = CodSemestre;
                                ObjEntidadMatricula.CodEscuelaP = CodAsignatura.Substring(6);
                                ObjEntidadMatricula.CodAsignatura = CodAsignatura;
                                ObjEntidadMatricula.CodEstudiante = codigo;
                                ObjNegocioMatricula.EliminarMatricula(ObjEntidadMatricula);
                                desmatriculados += 1;
                            }
                        }
                    }
                    // Agregar los estudiantes que quedan en la lista actualizada
                    foreach (var estudiante in ListaActualizada)
                    {
                        NuevaLista.Add(estudiante.Item1);
                        // Agregar a la tabla matricula
                        string[] NombresApellidos = estudiante.Item2.Split('-');
                        ObjEntidadMatricula.CodSemestre = CodSemestre;
                        ObjEntidadMatricula.CodEscuelaP = CodAsignatura.Substring(6);
                        ObjEntidadMatricula.CodAsignatura = CodAsignatura;
                        ObjEntidadMatricula.CodEstudiante = estudiante.Item1;
                        ObjEntidadMatricula.APaterno = NombresApellidos[0];
                        ObjEntidadMatricula.AMaterno = NombresApellidos[1];
                        ObjEntidadMatricula.Nombre = NombresApellidos[2];
                        ObjNegocioMatricula.InsertarMatricula(ObjEntidadMatricula);
                        matriculados += 1;
                    }

                    // Actualizar lista matriculados
                    string[] MatriculadosActual = NuevaLista.ToArray();
                    ObjCatalogo.ActualizarMatriculadosAsignatura(CodSemestre, CodAsignatura, CodDocente, string.Join(",", MatriculadosActual));
                    A_Dialogo.DialogoInformacion("La actualización ha terminado..." + Environment.NewLine +
                                                 "Nuevos estudiantes matriculados: " + matriculados.ToString() + Environment.NewLine +
                                                 "Estudiantes desmatriculados: " + desmatriculados.ToString() + Environment.NewLine);
                    //MessageBox.Show("La actualización ha terminado...\n" +
                    //                "Nuevos estudiantes matriculados: " + matriculados.ToString() + "\n" +
                    //                "Estudiantes desmatriculados: " + desmatriculados.ToString() + "\n");
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarAsignaturas();
        }
    }
}
