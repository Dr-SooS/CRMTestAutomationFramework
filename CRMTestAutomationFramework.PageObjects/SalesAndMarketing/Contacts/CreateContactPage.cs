using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts
{
    public class CreateContactPage : BasePage
    {
        public CreateContactPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FirstNameInput => _driver.FindElement(By.Name("first_name"));
        public IWebElement LastNameInput => _driver.FindElement(By.Name("last_name"));
        public IWebElement SaveButton => _driver.FindElement(By.Id("DetailForm_save"));

        public CreateContactPage SelectCategories(List<string> categories)
        {
            foreach(var category in categories)
            {
                _driver.FindElement(By.Id("DetailFormcategories-input")).Click();
                _driver.FindElement(By.XPath($"//div[@id='DetailFormcategories-input-search-text']/input")).SendKeys(category);
                _driver.FindElement(By.XPath($"//div[contains(@class, 'menu-option single') and contains(., '{category}')]")).Click();
            }

            return this;
        }
    }
}
