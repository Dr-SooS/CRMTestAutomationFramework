using CRMTestAutomationFramework.PageObjects.TodayActivities.HomeDashboard;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects
{
    public class LoginPage: BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement LoginInput => _driver.FindElement(By.Id("login_user"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("login_pass"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login_button"));

        public void Navigate()
        {
            _driver.Navigate().GoToUrl("https://demo.1crmcloud.com/login.php");
        }

        public HomeDashboardPage Login(string login, string password)
        {
            LoginInput.SendKeys(login);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            return new HomeDashboardPage(_driver);
        }
    }
}
