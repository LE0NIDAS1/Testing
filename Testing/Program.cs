using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Casos_de_uso;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string algo = Environment.CurrentDirectory;

            IWebDriver driver = new ChromeDriver(algo.Substring(0, algo.IndexOf("bin")));

            CasosDeUsos casos = new CasosDeUsos();
            casos.initialize();
            //Iniciar sesion
            casos.login();
            casos.cleanUp();

        }
    }
}
