using CRMTestAutomationFramework.Core.Extensions;
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

        private IWebElement _loginInput => _driver.FindElement(By.Id("login_user"));
        private IWebElement _passwordInput => _driver.FindElement(By.Id("login_pass"));
        private IWebElement _loginButton => _driver.FindElement(By.Id("login_button"));

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public HomeDashboardPage Login(string login, string password)
        {
            _loginInput.SendKeys(login);
            _passwordInput.SendKeys(password);
            return _loginButton.ClickAndGo<HomeDashboardPage>(_driver);
        }
    }
}
