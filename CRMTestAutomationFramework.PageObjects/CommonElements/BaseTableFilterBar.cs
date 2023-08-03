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
        protected string _containerXpath = "//div[@class='filter-basic-inner form-inline']";

        public BaseTableFilterBar(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SearchField => _driver.FindElement(By.XPath($"{_containerXpath}//div[contains(@class, 'input-search')]/input"));

        public T SearchBySearchField<T>(string searchString) where T : BasePage { 
            SearchField.SendKeys(searchString);
            return _driver.FindElement(By.XPath($"//div[contains(@class, 'option-cell') and contains(., '{searchString}')]")).ClickAndGo<T>(_driver);
        }
    }
}
