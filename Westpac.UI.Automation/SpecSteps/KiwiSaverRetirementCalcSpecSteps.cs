using System;
using TechTalk.SpecFlow;
using Westpac.UI.Automation.Framework;
using Westpac.UI.Automation.Pages;
using System.Threading;
using NUnit.Framework;
using FluentAssertions;

namespace Westpac.UI.Automation.SpecSteps
{
    [Binding]
    public class KiwiSaverRetirementCalcSpecSteps
    {
        private readonly INavigatePage _navigate;
        private readonly KiwiSaverRetirementCalcPage _KSCalcPage;
        public KiwiSaverRetirementCalcSpecSteps(INavigatePage navigate, KiwiSaverRetirementCalcPage kiwisaverPage)
        {
            _navigate = navigate;
            _KSCalcPage = kiwisaverPage;
        }

        [Given(@"I open the westpac home page")]
        public void GivenIOpenTheWestpacHomePage()
        {
            Thread.Sleep(2000);
            _navigate.OpenURL();

        }

        [Given(@"I navigate to the Retirement Calculator")]
        public void GivenINavigateToTheRetirementCalculator()
        {
            _navigate.ClickOnKiwiSaverCaluculatorButton();
            Thread.Sleep(2000);
            _navigate.ClickOnRetirementCalculatorLink();
        }

        [When(@"I click the Current Age Helper Icon")]
        public void WhenIClickTheCurrentAgeHelperIcon()
        {
            Thread.Sleep(3000);
            _KSCalcPage.SwitchtoFrame();
            _KSCalcPage.CurrentAgeInfoButtonClick();
        }

        [Then(@"I can verify the Current Age information helper message is NOT ""(.*)""")]
        public void ThenICanVerifyTheCurrentAgeInformationHelperMessage(string expectedMsg)
        {
            _KSCalcPage.currentAgeInfoMessageText().Should().NotContain(expectedMsg);

        }

        [Given(@"I my current age is ""(.*)""")]
        public void GivenIMyCurrentAgeIs(string age)
        {
            _KSCalcPage.SwitchtoFrame();
            _KSCalcPage.CurrentAgeInput(age);
        }

        [Given(@"my Emploment Status is ""(.*)""")]
        public void GivenMyEmplomentStatusIs(string empStatus)
        {
            _KSCalcPage.SelectEmploymentType(empStatus);
            
        }

        [Given(@"my Salary Contribution is ""(.*)""")]
        public void GivenMySalaryContributionIs(string salary)
        {
            _KSCalcPage.EnterSalary(salary);
        }

        [Given(@"my KiwiSaver Contribution is ""(.*)""")]
        public void GivenMyKiwiSaverContributionIs(string KSPercent)
        {
            _KSCalcPage.Click4PercentKSRadio(KSPercent);
        }

        [Given(@"I have chosen a ""(.*)"" profile")]
        public void GivenIHaveChosenAProfile(string riskProfile)
        {
            _KSCalcPage.ClickRiskProfile(riskProfile);
        }

        [When(@"I Click on the KiwiSaver Retirement Projections button")]
        public void WhenIClickOnTheKiwiSaverRetirementProjectionsButton()
        {
            _KSCalcPage.ProjectionButtonClick();
        }

       

       
        [Then(@"I can confirm my predicted Kiwisaver Balance is available")]
        public void ThenICanConfirmMyPredictedKiwisaverBalanceIsAvailable()
        {
            _KSCalcPage.IsBalanceDisplayed().Should().Be(true);
        }


        [Given(@"my Current KiwiSaver Balance is (.*)""")]
        public void GivenMyCurrentKiwiSaverBalanceIs(string currentKS)
        {
            _KSCalcPage.CurrentKiwiSaverAmount(currentKS);
        }

        [Given(@"I have a savings goal of (.*)")]
        public void GivenIHaveASavingsGoalOf(string savingGoal)
        {
            _KSCalcPage.EnterSavingGoal(savingGoal);
        }

        [Given(@"my PIR is ""(.*)""")]
        public void GivenMyPIRIs(string pir)
        {
            _KSCalcPage.SelectPIR(pir);
        }

        [Given(@"my Voluntary KiwiSaver Contribution is ""(.*)"" ""(.*)""")]
        public void GivenMyVoluntaryKiwiSaverContributionIs(string amount, string frequency)
        {
            _KSCalcPage.SelectFrequency(amount, frequency);
        }





    }
}
