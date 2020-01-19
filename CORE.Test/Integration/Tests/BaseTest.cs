
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace CORE.Test.Tests
{ 
    [Parallelizable(ParallelScope.All)] 
    public class BaseTest <TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IWebDriver _driver;
        public string URL = "https://www.facebook.com/";
        [SetUp]
        public void setup()
        {
            //string path= System.Environment.GetEnvironmentVariable("DRIVERSPATH");
            string path = @"C:\webdrivers";
            this._driver= (TWebDriver)Activator.CreateInstance(typeof(TWebDriver), path);
            //this._driver = new TWebDriver();
           

            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void Desetup()
        {
            _driver.Quit();
        }
    }
}
