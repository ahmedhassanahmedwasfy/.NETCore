using CORE.Test.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CORE.Test.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            //PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement txt_email { get; set; }
        [FindsBy(How = How.Name, Using = "pass")]
        public IWebElement txt_password { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        public IWebElement btn_login { get; set; }

        public bool Login(string username, string password)
        {
            txt_email.Click();
            txt_email.Clear();
            txt_email.SendKeys(username);
            txt_password.Click();
            txt_password.Clear();
            txt_password.SendKeys(password);
            btn_login.Click();



            //check for success

            return IsSuccess();
        }
        public bool IsSuccess()
        {
            var _toaster = _driver.FindElement(By.CssSelector("a[href *= 'facebook.com']"), 30);

            return _toaster != null;
        }
    }
}
