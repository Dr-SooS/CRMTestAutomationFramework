using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.CommonElements
{
    public class BaseCommonElement
    {
        protected IWebDriver _driver;

        public BaseCommonElement(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}
