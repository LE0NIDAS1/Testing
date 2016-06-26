using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IWebElement element = driver.FindElement(By.Id("loginLink"));
            element.Click();
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("Admin@atlas.com");
            IWebElement pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("Atlas@123");
            IWebElement btn = driver.FindElement(By.Id("save"));
            btn.Submit();
        }

        [TearDown]
        public void cleanUp()
        {
            driver.Close();
        }
    }
}
