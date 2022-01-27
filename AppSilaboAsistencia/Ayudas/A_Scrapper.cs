using System;
using System.Data;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CapaEntidades;
using CapaNegocios;

namespace Ayudas
{
    public class A_Scrapper
    {
        public static List<Tuple<string, string>> Parser(string CodAsignatura)
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
                }
                else if (ex is WebDriverException)
                {
                    A_Dialogo.DialogoError("No se encuentra conectado a Internet. Revise su conexión");
                }
            }

            return null;
        }

        private static Tuple<string, string> BuscarEstudiante(List<Tuple<string, string>> ListaActualizada, string CodEstudiante)
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

        public static Tuple<int, int> ActualizarEstudiantesAsignatura(string CodAsignatura, string CodDocente, bool getInfo)
        {
            N_Catalogo ObjCatalogo = new N_Catalogo();
            E_Matricula ObjEntidadMatricula = new E_Matricula();
            N_Matricula ObjNegocioMatricula = new N_Matricula();
            DataTable Semestre = N_Semestre.SemestreActual();
            string CodSemestre = Semestre.Rows[0][0].ToString();

            int matriculados = 0, desmatriculados = 0;
            List<Tuple<string, string>> ListaActualizada = Parser(CodAsignatura);
            if (ListaActualizada != null)
            {
                DataTable Matriculados = N_Catalogo.ListaEstudiantesMatriculados(CodSemestre, CodAsignatura, CodDocente);
                string ListaConcatenada = Matriculados.Rows[0]["Matriculados"].ToString();
                string[] Lista = ListaConcatenada.Split(',');
                List<string> NuevaLista = new List<string>();

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
                    string[] NombresApellidos = estudiante.Item2.Split(new string[] { "-", "--" }, StringSplitOptions.RemoveEmptyEntries);
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
            }
            else
            {
                return null;
            }

            if (getInfo)
            {
                return Tuple.Create(matriculados, desmatriculados);
            }
            else
            {
                return Tuple.Create(0, 0);
            }
        }
    }
}
