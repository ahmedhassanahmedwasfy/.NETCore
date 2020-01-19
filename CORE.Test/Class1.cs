using CORE.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace CORE.Test
{
    [TestClass]
    public class FuelTestCases
    {
        IWebDriver _driver;

        [SetUp]
        public void setup()
        {
            //run driver   
            _driver = new ChromeDriver(@"C:\webdrivers");
            _driver.Navigate().GoToUrl("https://www.facebook.com/");
            _driver.Manage().Window.Maximize();
        }
        [Test]
        public void TestCase1()
        {
            IWebElement username = _driver.FindElement(By.Name("email"));
            IWebElement password = _driver.FindElement(By.Name("pass"));
            IWebElement login = _driver.FindElement(By.CssSelector("input[type = 'submit']"));

            username.Click();
            username.Clear();
            username.SendKeys("eng.ahmedhassan.eng@gmail.com");


            password.Click();
            password.Clear();
            password.SendKeys("P@ssw0rd");

            login.Click();


            Assert.IsTrue(IsSuccess());
        }
        public bool IsSuccess()
        {
            var _toaster = _driver.FindElement(By.CssSelector("a[href *= 'facebook.com']"), 30);

            return _toaster != null;
        }
        [TearDown]
        public void desetup()
        {
            //close driver
            _driver.Quit();
        }
    }
}
