using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Westpac.UI.Automation.Framework;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using BoDi;
using Westpac.UI.Automation.Pages;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace Westpac.UI.Automation.SpecSteps
{
    [Binding]
    public class StepBinding : BaseStep
    {
        private readonly ContextObject _contextObject;
        private new readonly IObjectContainer _container;
        public StepBinding(ContextObject context, IObjectContainer container) : base(context)
        {
            _contextObject = context;
            _scenarioContext = container.Resolve<ScenarioContext>();
            _container = container;

        }


        [BeforeScenario]
        public void StartDriver()
        {
            _contextObject.TestUrl = ConfigurationManager.AppSettings["TestUrl"];
            _contextObject.currentScenario = TestContext.CurrentContext.Test.Name;
            InitDriver();
            TestContext.Out.WriteLine($"Executing Scenario={_contextObject.currentScenario}");
            TestContext.Out.WriteLine($"Navigating to url={_contextObject.TestUrl}");
        }

        private void InitDriver()
        {
            _contextObject.webDriver = InitBrowser();
        }

        private IWebDriver InitBrowser()
        {
            IWebDriver driver = null;
            switch (ConfigurationManager.AppSettings["Browser"].ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "ie":
                    var ieOptions = new InternetExplorerOptions();
                    driver = new InternetExplorerDriver(ieOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
            }

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var navPage = new NavigatePage(driver, wait);
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _container.RegisterInstanceAs<INavigatePage>(navPage);
            return driver;

        }


        [AfterScenario(Order = 10)]
        public void CloseDriver()
        {
            _contextObject.webDriver.Close();
            _contextObject.webDriver.Quit();
        }

        [AfterScenario(Order = 999)]
        private void KillProcesses()
        {

            switch (ConfigurationManager.AppSettings["Browser"].ToLower())
            {
                case "chrome":
                    Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver.exe");
                    foreach (var chromeDriverProcess in chromeDriverProcesses)
                    {
                        chromeDriverProcess.Kill();
                    }
                    break;
                case "ie":
                    Process[] ieDriverProcesses = Process.GetProcessesByName("iexplore.exe");
                    foreach (var ieDriverProcess in ieDriverProcesses)
                    {
                        ieDriverProcess.Kill();
                    }
                    break;
                case "firefox":
                    Process[] ffDriverProcesses = Process.GetProcessesByName("firefox.exe");
                    foreach (var ffDriverProcess in ffDriverProcesses)
                    {
                        ffDriverProcess.Kill();
                    }
                    break;





            }
        }

    }
}
