using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
    }
}
