using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Westpac.UI.Automation.Framework;

namespace Westpac.UI.Automation.Pages
{
    public class NavigatePage : SetupPage, INavigatePage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _element;
        private WebDriverWait _wait;
        public NavigatePage(IWebDriver webDriver, WebDriverWait wait) : base(webDriver)
        {

            _webDriver = webDriver;
            _wait = wait;
        }

        #region Locators

        private readonly By KiwiSaverLinkByXPath = By.XPath("//a[@id='ubermenu-section-link-kiwisaver-ps']");
        private readonly By KiwiSaverCalculatorButtonByXPath = By.XPath("//a[@id='ubermenu-item-cta-kiwisaver-calculators-ps']");
        private readonly By KiwiSaverRetirementCalcByXPath = By.XPath("//span[@class='sw-sidenav-item-link-text last' and contains(text(), 'KiwiSaver Retirement Calculator')]");

        #endregion

        #region PageElements

        private IWebElement KiwisaverLink => _webDriver.FindElement(KiwiSaverLinkByXPath);
        private IWebElement KiwiSaverCalculatorButton => _webDriver.FindElement(KiwiSaverCalculatorButtonByXPath);
        private IWebElement KiwiSaverRetirementCalc => _webDriver.FindElement(KiwiSaverRetirementCalcByXPath);

        #endregion

        #region Methods

        public void OpenURL()
        {
            _webDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["TestUrl"]);
        }

        public void ClickOnKiwiSaverCaluculatorButton()
        {
            //KiwiSaverCalculatorButtonClick();
            Actions action = new Actions(_webDriver);
            action.MoveToElement(_webDriver.FindElement(KiwiSaverLinkByXPath)).Build().Perform();
            _webDriver.FindElement(KiwiSaverCalculatorButtonByXPath).Click();
        }

        public void ClickOnRetirementCalculatorLink()
        {
            //KiwiSaverRetirementCalcClick();
            _webDriver.FindElement(KiwiSaverRetirementCalcByXPath).Click();
        }

        #endregion
    }
}
