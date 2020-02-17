using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Westpac.UI.Automation.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Westpac.UI.Automation.Pages
{
    public class KiwiSaverRetirementCalcPage : SetupPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _element;
        private WebDriverWait _wait;

        public KiwiSaverRetirementCalcPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;

        }

        //Kiwisaver Retirement Calculator
        #region Locators

        //Info Helpers
        private readonly By currentAgeInfoByXPath = By.XPath("(//button[@class='icon-target icon-target-help-toggle icon-btn icon-btn-info ir ng-scope'])[1]");
        private readonly By currentAgeInfoMessageByXPath = By.XPath("//div[@class='field-message message-info ng-binding']/p");
        private readonly By RetirementCalcIframeByXPath = By.XPath("//iframe[@src='/calculator-widgets/kiwisaver-calculator/?gclid=&referrer=https%3A%2F%2Fwww.westpac.co.nz%2F&parent=3956&host=calculator-embed']");

        //DropDown Sections
        private readonly By EmploymentSectionByXPath = By.XPath("//div[@selected-content='ctrl.data.EmploymentStatusHTML']");
        private readonly By PIRSectionByXPath = By.XPath("//div[@selected-content='ctrl.data.PIRRateHTML']");
        private readonly By FrequencySectionByXPath = By.XPath("//div[@selected-content='$parent.periodHtml']");



        //Calculator Locators
        private readonly By CurrentAgeInputBoxByXPath = By.XPath("(//input[@class='ng-pristine ng-valid'])[1]");
        private readonly By EmploymentStatusDropDownByXPath = By.XPath("(//div[@class='control select-control  no-selection'])[1]");
        private readonly By EmployedOptionByXPath = By.XPath("//li[@value='employed']");
        private readonly By SelfEmployedOptionByXPath = By.XPath("//li[@value='self-employed']");
        private readonly By NotEmployedOptionByXPath = By.XPath("//li[@value='not-employed']");
        private readonly By EmploymentStatusTextByXPath = By.XPath("//span[@class='ng-scope']");
        private readonly By SalaryPerYrByXPath = By.XPath("(//input[@ng-model='displayModel'])[2]");
        private readonly By CurrentKiwiSaverByXPath = By.XPath("(//input[@ng-model='displayModel'])[2]");
        private readonly By VoluntaryContributionAmountByXPath = By.XPath("(//input[@ng-model='displayModel'])[3]");
        private readonly By VoluntaryFrequencyDropdownByXPath = By.XPath("(//div[@class='well-value ng-binding'])[5]");
        private readonly By VoluntaryFortnightByXPath = By.XPath("//li[@value='fortnight']");
        private readonly By VoluntaryAnnualByXPath = By.XPath("//li[@value='year']");
        private readonly By KiwiSaver4ContributionByXPath = By.XPath("//input[@id='radio-option-06E']");
        private readonly By PIRByXPath = By.XPath("(//div[@class='well-value ng-binding'])[2]");
        private readonly By PIRTenPointFiveByXPath = By.XPath("//li[@value='10.5']");
        private readonly By PIRSeventeenPointFiveByXPath = By.XPath("//li[@value='17.5']");
        private readonly By BalanceValueByXPath = By.XPath("//span[@class='result-value result-currency ng-binding']");



        private readonly By LowRiskProfileRadioByXPath = By.XPath("//input[@id='radio-option-01V']");
        private readonly By MediumRiskProfileRadioByXPath = By.XPath("//input[@id='radio-option-01Y']");
        private readonly By HighRiskProfileRadioByXPath = By.XPath("//input[@id='radio-option-021']");
        private readonly By SavingGoalByXPath = By.XPath("(//input[@ng-model='displayModel'])[4]");
        private readonly By ProjectionsButtonByXPath = By.XPath("//button[@class='btn btn-regular btn-results-reveal btn-has-chevron']");
        private readonly By KiwiSaverEstimateByXPath = By.XPath("//span[@class='result-value result-currency ng-binding']");


        #endregion

        #region WebElements

        IWebElement currentAgeInfoButton => _webDriver.FindElement(currentAgeInfoByXPath);
        IWebElement currentAgeInfoMessage => _webDriver.FindElement(currentAgeInfoMessageByXPath);
        IWebElement RetirementCalcIframe => _webDriver.FindElement(RetirementCalcIframeByXPath);
        IWebElement BalanceValue => _webDriver.FindElement(BalanceValueByXPath);
        IWebElement CurrentAgeInputBox => _webDriver.FindElement(CurrentAgeInputBoxByXPath);
        IWebElement EmploymentStatusSection => _webDriver.FindElement(EmploymentSectionByXPath);
        IWebElement PIRSection => _webDriver.FindElement(PIRSectionByXPath);
        IWebElement FrequencySection => _webDriver.FindElement(FrequencySectionByXPath);

        IWebElement EmploymentStatusDropDown => _webDriver.FindElement(EmploymentSectionByXPath).FindElement(EmploymentStatusDropDownByXPath);

        IWebElement EmploymentStatusText => _webDriver.FindElement(EmploymentStatusTextByXPath);

        IWebElement EmployedOption => _webDriver.FindElement(EmployedOptionByXPath);

        IWebElement SelfEmployedOption => _webDriver.FindElement(SelfEmployedOptionByXPath);

        IWebElement NotEmployedOption => _webDriver.FindElement(NotEmployedOptionByXPath);

        IWebElement PIRDropDown => _webDriver.FindElement(PIRSectionByXPath).FindElement(PIRByXPath);
        IWebElement PIRTenPointFive => _webDriver.FindElement(PIRTenPointFiveByXPath);

        IWebElement PIRSeventeenPointFive => _webDriver.FindElement(PIRSeventeenPointFiveByXPath);

        IWebElement SalaryPerYr => _webDriver.FindElement(SalaryPerYrByXPath);
        IWebElement CurrentKiwiSaver => _webDriver.FindElement(CurrentKiwiSaverByXPath);
        IWebElement VoluntaryContributionAmount => _webDriver.FindElement(VoluntaryContributionAmountByXPath);
        IWebElement VoluntaryFrequencyDropdown => _webDriver.FindElement(VoluntaryFrequencyDropdownByXPath).FindElement(VoluntaryFrequencyDropdownByXPath);

        IWebElement VoluntaryFortnight => _webDriver.FindElement(VoluntaryFortnightByXPath);

        IWebElement VoluntaryAnnual => _webDriver.FindElement(VoluntaryAnnualByXPath);

        IWebElement KiwiSaver4Contribution => _webDriver.FindElement(KiwiSaver4ContributionByXPath);
        IWebElement PIR => _webDriver.FindElement(PIRSectionByXPath).FindElement(PIRByXPath);
        IWebElement LowRiskProfileRadio => _webDriver.FindElement(LowRiskProfileRadioByXPath);
        IWebElement MediumRiskProfileRadio => _webDriver.FindElement(MediumRiskProfileRadioByXPath);
        IWebElement HighRiskProfileRadio => _webDriver.FindElement(HighRiskProfileRadioByXPath);
        IWebElement SavingGoal => _webDriver.FindElement(SavingGoalByXPath);
        IWebElement ProjectionsButton => _webDriver.FindElement(ProjectionsButtonByXPath);
        IWebElement KiwiSaverEstimate => _webDriver.FindElement(KiwiSaverEstimateByXPath);


        #endregion

        #region Methods

        public void CurrentAgeInput(string age)
        {
           CurrentAgeInputBox.SendKeys(age);

        }

        public void SelectEmploymentType(string empStatus)
        {
            WaitForElement(EmploymentStatusDropDownByXPath);
            EmploymentStatusDropDown.Click();
            
             switch(empStatus)
            {
                case "Employed":
                    EmployedOption.Click();
                    break;                   
            
                case "not-employed":
                    NotEmployedOption.Click();
                    break;

                case "self-employed":
                    SelfEmployedOption.Click();
                   break;
                default:
                    Assert.Fail($"\"{empStatus}\" value not recognised");
                    break;
            }
        }

        public void SelectPIR(string pir)
        {
            WaitForElement(PIRByXPath);
            PIR.Click();
            
            switch (pir)
            {
                case "10.5%":
                    PIRTenPointFive.Click();
                    break;


                case "17.5":
                    PIRSeventeenPointFive.Click();
                    break;

                default:
                    Assert.Fail($"\"{pir}\" value not recognised");
                    break;
            }
        }

       

        public void SelectFrequency(string amount, string frequency)
        {
            VoluntaryContributionAmount.SendKeys(amount);
            WaitForElement(VoluntaryFrequencyDropdownByXPath);
            VoluntaryFrequencyDropdown.Click();
            
            switch (frequency)
            {
                case "fortnightly":
                    VoluntaryFortnight.Click();
                    break;


                case "annually":
                    VoluntaryAnnual.Click();
                    break;

                default:
                    Assert.Fail($"\"{frequency}\" value not recognised");
                    break;
            }
        }


        public void SwitchtoFrame()
        {
            _webDriver.SwitchTo().Frame(RetirementCalcIframe);
        }

        public void CurrentAgeInfoButtonClick()
        {
            WaitForElement(currentAgeInfoByXPath);
            currentAgeInfoButton.Click();
        }

        public string currentAgeInfoMessageText()
        {
           return currentAgeInfoMessage.Text; 
        }

        public void EnterSalary(string salary)
        {
            SalaryPerYr.SendKeys(salary);
        }

        public void Click4PercentKSRadio(string fourPercent)
        {
            switch (fourPercent)
            {
                case "4%":
                    KiwiSaver4Contribution.Click();
                    break;
            }
        }

        public void ClickRiskProfile(string riskProfile)
        {
            switch (riskProfile)
            {
                case "High Risk":
                    HighRiskProfileRadio.Click();
                    break;
                case "Medium Risk":
                    MediumRiskProfileRadio.Click();
                    break;
            }
        }

        public void ProjectionButtonClick()
        {
            ProjectionsButton.Click();
        }


        public bool IsBalanceDisplayed()
        {
            return BalanceValue.Displayed;
        }

        public void CurrentKiwiSaverAmount(string currentKS)
        {
            CurrentKiwiSaver.SendKeys(currentKS);
        }

        public void EnterSavingGoal(string savingGoal)
        {
            SavingGoal.SendKeys(savingGoal);
        }

        #endregion
    }
}
