using CRMTestAutomationFramework.Core.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects
{
    public abstract class BaseAppPage : BasePage
    {
        protected IWebElement _pageTitile => _driver.FindElement(By.Id("main-title"));
        protected IWebElement _statusMessage => _driver.FindElement(By.Id("ajaxStatusDiv"));
        protected IWebElement _actionsButton => _driver.FindElement(By.XPath("//button[contains(@id, 'ActionButtonHead')]"));

        public BaseAppPage(IWebDriver driver) : base(driver) { }

        public string PageTitleText => _pageTitile.Text;
        public bool PageTitleDisplayed => _pageTitile.Displayed;

        public T NavigateTo<T>(string firstLevel, string secondLevel) where T : BaseAppPage
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(By.XPath($"//a[contains(., '{firstLevel}')]"))).Perform();
            return _driver.FindElement(By.XPath($"//a[contains(., '{secondLevel}')]")).ClickAndGo<T>(_driver);
        }

        public T ClickOnShortcut<T>(string shortcut) where T : BaseAppPage
        {
            return _driver.FindElement(By.XPath($"//a[@class='sidebar-item-link-basic' and contains(., '{shortcut}')]")).ClickAndGo<T>(_driver);
        }

        public void WaitForStatusMessageIsHidden()
        {
            Wait().Until(_driver => !_statusMessage.Displayed);
        }

        public void ClickAction(string action)
        {
            _actionsButton.Click();
            _driver.FindElement(By.XPath($"//div[contains(@class, 'menu-option single') and contains(., '{action}')]")).Click();
        }
    }
}
