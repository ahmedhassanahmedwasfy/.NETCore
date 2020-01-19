using CORE.Test.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects; 


namespace CORE.Test.Pages
{
    public class BasePage
    {
        public readonly IWebDriver _driver;
        [FindsBy(How = How.CssSelector, Using = ".ui-growl-message")]
        public IWebElement toaster { get; set; }

        public bool IsToasterSuccess()
        {
            toaster = _driver.FindElement(By.CssSelector("a[value='Home']"), 30);
            var text = toaster.Text.ToLower();
            var txt1 = text.Contains("succ");
            var txt2 = text.Contains("بنجاح");
            return txt1 || txt2;
        }
        public BasePage(IWebDriver driver)
        {
            this._driver = driver;

            PageFactory.InitElements(driver, this);

        }
    }
}
