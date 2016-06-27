using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Helper;

namespace Testing.Casos_de_uso
{
    
    class CasosDeUsos
    {
        private IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")));
        [SetUp]
        public void initialize()
        {
      
            driver.Navigate().GoToUrl("https://localhost:44300/");
        }

        [Test]
        public void login()
        {
           
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"))+@"Helper\Pruebas.xlsx");
            
            IWebElement element = driver.FindElement(By.Id("loginLink"));
            element.Click();
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys(ExcelLibrary.ReadData(1, "email"));
            IWebElement pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys(ExcelLibrary.ReadData(1, "pass"));
            IWebElement btn = driver.FindElement(By.Id("save"));
            btn.Submit();
        }

        [Test]
        public void caso2()
        {
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\Pruebas.xlsx");
            //login
            IWebElement element = driver.FindElement(By.Id("loginLink"));
            element.Click();
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys(ExcelLibrary.ReadData(1, "email"));
            IWebElement pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys(ExcelLibrary.ReadData(1, "pass"));
            IWebElement btn = driver.FindElement(By.Id("save"));
            btn.Submit();

            //crear un juego
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosGame.xlsx");

            btn = driver.FindElement(By.LinkText("Inicio »"));
            btn.Click();
            btn = driver.FindElement(By.LinkText("Create New"));
            btn.Click();
            IWebElement name = driver.FindElement(By.Name("name"));
            name.SendKeys(ExcelLibrary.ReadData(1, "name"));
            name = driver.FindElement(By.Name("domain"));
            name.SendKeys(ExcelLibrary.ReadData(1, "domain"));
            if(ExcelLibrary.ReadData(1, "state").Equals("Activo")){
                IWebElement box = driver.FindElement(By.Id("stateGame"));
                box.Click();
            }
            name = driver.FindElement(By.Name("FacebookAppID"));
            name.SendKeys(ExcelLibrary.ReadData(1, "FacebookAppID"));
            name = driver.FindElement(By.Name("facebookAuth"));
            name.SendKeys(ExcelLibrary.ReadData(1, "facebookAuth"));
            name = driver.FindElement(By.Name("FacebookAppSecret"));
            name.SendKeys(ExcelLibrary.ReadData(1, "FacebookAppSecret"));
            name = driver.FindElement(By.Name("GoogleClientID"));
            name.SendKeys(ExcelLibrary.ReadData(1, "GoogleClientID"));
            name = driver.FindElement(By.Name("GoogleClientSecret"));
            name.SendKeys(ExcelLibrary.ReadData(1, "GoogleClientSecret"));
            btn = driver.FindElement(By.Id("submitGame"));
            btn.Submit();
            
            //agregar categoria
            
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosCategory.xlsx");
            btn = driver.FindElements(By.Id("IdCategory")).First();
            btn.Click();
            btn = driver.FindElement(By.LinkText("Create New"));
            btn.Click();
            element = driver.FindElement(By.Name("Name"));
            element.SendKeys(ExcelLibrary.ReadData(1, "Name"));
            element = driver.FindElement(By.Name("Tooltip"));
            element.SendKeys(ExcelLibrary.ReadData(1, "tooltip"));
            btn = driver.FindElement(By.Id("submitCategory"));
            btn.Submit();
            

            //Agregar Recurso
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosResource.xlsx");
            btn = driver.FindElements(By.Id("IdResource")).First();
            btn.Click();
            btn = driver.FindElement(By.LinkText("Create New"));
            btn.Click();
            element = driver.FindElement(By.Name("Name"));
            element.SendKeys(ExcelLibrary.ReadData(1, "NameResource"));
            btn = driver.FindElement(By.Id("submitResource"));
            btn.Submit();
            
            //Agregar GameObject
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosGameObject.xlsx");
            btn = driver.FindElements(By.Id("IdGameObject")).First();
            btn.Click();
            btn = driver.FindElement(By.LinkText("Create New"));
            btn.Click();
            element = driver.FindElement(By.Name("Name"));
            element.SendKeys(ExcelLibrary.ReadData(1, "NameObject"));
            element = driver.FindElement(By.Name("Description"));
            element.SendKeys(ExcelLibrary.ReadData(1, "Description"));
            new SelectElement(driver.FindElement(By.Name("IdCategory"))).SelectByText(ExcelLibrary.ReadData(1, "IdCategoryObject"));
            btn = driver.FindElement(By.Id("submitGameObject"));
            btn.Submit();


            //Agregar Attribute
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosAttribute.xlsx");
            btn = driver.FindElements(By.Id("IdGameObject")).First();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            btn = driver.FindElements(By.Id("IdAttribute")).First();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Create New")).Last();
            btn.Click();
            element = driver.FindElement(By.Name("Name"));
            element.SendKeys(ExcelLibrary.ReadData(1, "NameAttribute"));
            element = driver.FindElement(By.Name("valor"));
            element.SendKeys(ExcelLibrary.ReadData(1, "valor"));
            new SelectElement(driver.FindElement(By.Name("Type"))).SelectByText(ExcelLibrary.ReadData(1, "Type"));
            btn = driver.FindElement(By.Id("submitResource"));
            btn.Submit();
            driver.Navigate().GoToUrl("https://localhost:44300/Game");


            //Agregar Costos
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosCostes.xlsx");
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            btn = driver.FindElements(By.Id("IdGameObject")).First();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            btn = driver.FindElements(By.Id("IdCostes")).First();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Create New")).Last();
            btn.Click();

            new SelectElement(driver.FindElement(By.Name("id_Resource"))).SelectByText(ExcelLibrary.ReadData(1, "id_Resource"));
            element = driver.FindElement(By.Name("cant"));
            element.SendKeys(ExcelLibrary.ReadData(1, "cant"));
            btn = driver.FindElement(By.Id("submitCostes"));
            btn.Submit();
            

            //agregar objetos iniciales
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosInitialObject.xlsx");
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            btn = driver.FindElements(By.Id("IdInitial")).First();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Agregar Objetos al Iniciar")).Last();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Create New")).Last();
            btn.Click();
            element = driver.FindElement(By.Name("Quantity"));
            element.SendKeys(ExcelLibrary.ReadData(1, "Quantity"));
            new SelectElement(driver.FindElement(By.Name("IdGameObject"))).SelectByText(ExcelLibrary.ReadData(1, "IdGameObjectInitial"));
            btn = driver.FindElement(By.Id("submitInitial"));
            btn.Submit();


            //Agregar accion de creacion
            driver.Navigate().GoToUrl("https://localhost:44300/Game");
            ExcelLibrary.PopulateInCollection(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Helper\DatosAction.xlsx");
            btn = driver.FindElements(By.LinkText("Edit")).Last();
            btn.Click();
            btn = driver.FindElements(By.Id("IdAction")).First();
            btn.Click();
            btn = driver.FindElements(By.LinkText("Create New")).Last();
            btn.Click();
            new SelectElement(driver.FindElement(By.Name("TypeAction"))).SelectByText(ExcelLibrary.ReadData(1, "TypeAction"));
            new SelectElement(driver.FindElement(By.Name("idGameObject"))).SelectByText(ExcelLibrary.ReadData(1, "idGameObjectAction"));
            btn = driver.FindElement(By.Id("submitAction"));
            btn.Submit();



            


        }

        [TearDown]
        public void cleanUp()
        {
            driver.Close();
        }
    }
}
