using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace Westpac.UI.Automation.Framework
{
    public class SetupPage
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;

        public SetupPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }

        public IWebDriver webDriver
        {
            get {; return _webDriver; }
            set
            {
                _webDriver = value;
                _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 30));
                _wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            }
        }

        public void WaitForElement(By locator)
        {
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60));
            _wait.Until(element => element.FindElement(locator));
        }

    }
}
