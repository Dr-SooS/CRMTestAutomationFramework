using CRMTestAutomationFramework.PageObjects.CommonElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts
{
    public class ContactCategoriesInput : BaseCommonElement
    {
        public ContactCategoriesInput(IWebDriver driver) : base(driver)
        {
        }

        private string _optionXpath = "//div[contains(@class, 'menu-option single') and contains(., '{0}')]";

        private IWebElement _categorySelectorInput => _driver.FindElement(By.Id("DetailFormcategories-input"));
        private IWebElement _categorySelectorSearchField => _driver.FindElement(By.XPath($"//div[@id='DetailFormcategories-input-search-text']/input"));

        public void SelectCategories(List<string> categories)
        {
            foreach (var category in categories)
            {
                _categorySelectorInput.Click();
                _categorySelectorSearchField.SendKeys(category);
                _driver.FindElement(By.XPath(String.Format(_optionXpath, category))).Click();
            }
        }
    }
}
