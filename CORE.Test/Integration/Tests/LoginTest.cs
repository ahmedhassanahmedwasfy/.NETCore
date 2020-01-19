using System;
using CORE.Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
namespace CORE.Test.Tests
{
    //[TestFixture(typeof(FirefoxDriver))] 

    //[TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class LoginTest<TWebDriver> : BaseTest<TWebDriver> where TWebDriver : IWebDriver, new ()
    { 
        [Test]
        public void Login_Normal()
        {
            string email = "eng.ahmedhassan.eng@gmail.com";
            string password = "P@ssw0rd";
            LoginPage loginPage = new LoginPage(base._driver);
            Assert.IsTrue(loginPage.Login(email, password));
        }
    }
}
