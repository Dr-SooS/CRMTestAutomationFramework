using CRMTestAutomationFramework.Core.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.CommonElements
{
    public class BaseTableFilterBar : BaseCommonElement
    {
        private string _containerXpath = "//div[@class='filter-basic-inner form-inline']";
        private string _optionXpath = "//div[contains(@class, 'option-cell') and contains(., '{0}')]";

        public BaseTableFilterBar(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _searchField => _driver.FindElement(By.XPath($"{_containerXpath}//div[contains(@class, 'input-search')]/input"));

        public T SearchBySearchField<T>(string searchString) where T : BaseAppPage { 
            _searchField.SendKeys(searchString);
            return _driver.FindElement(By.XPath(String.Format(_optionXpath, searchString))).ClickAndGo<T>(_driver);
        }
    }
}
