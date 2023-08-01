using CRMTestAutomationFramework.Core.Constants;
using CRMTestAutomationFramework.PageObjects;
using CRMTestAutomationFramework.PageObjects.TodayActivities.HomeDashboard;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class LoginStepDefenitions
    {
        protected static IWebDriver WebDriver;
        private LoginPage _loginPage;
        private HomeDashboardPage _homeDashboardPage;

        public LoginStepDefenitions()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Window.Maximize();
            _loginPage = new LoginPage(WebDriver);
        }

        [Given("I'm on the LoginPage")]
        public void GivenIamOnTheLoginPage()
        {
            _loginPage.Navigate();
        }

        [When("I try to login with (.*) username and (.*) password")]
        public void WhenITryToLogin(string username, string password)
        {
            _homeDashboardPage = _loginPage.Login(username, password);
        }

        [Then("I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully() {
            _homeDashboardPage.Wait().Until(WebDriver => _homeDashboardPage.PageTitile.Displayed);
            _homeDashboardPage.PageTitile.Text.Should().Contain(PageTitles.HomeDashboard);
            WebDriver.Quit();
        }
    }
}
