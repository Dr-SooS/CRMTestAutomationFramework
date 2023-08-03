using CRMTestAutomationFramework.PageObjects.TodayActivities.HomeDashboard;
using CRMTestAutomationFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class BaseStepDefenition
    {
        protected static IWebDriver WebDriver;

        public static LoginPage LoginPage;
        public static HomeDashboardPage HomeDashboardPage;

        [BeforeTestRun]
        public static void BeforeTest()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://demo.1crmcloud.com/login.php");
            LoginPage = new LoginPage(WebDriver);
            HomeDashboardPage = LoginPage.Login("admin", "admin");
            HomeDashboardPage.Wait().Until(WebDriver => HomeDashboardPage.PageTitile.Displayed);
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            WebDriver.Quit();
        }
    }
}
