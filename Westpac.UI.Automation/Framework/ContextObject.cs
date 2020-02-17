using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Westpac.UI.Automation.Framework
{
    public class ContextObject
    {
        public ScenarioContext scenarioContext { get; set; }
        public IWebDriver webDriver;
        public string Browser { get; set; }
        public string TestUrl { get; set; }
        public string currentScenario { get; set; }
    }
}
