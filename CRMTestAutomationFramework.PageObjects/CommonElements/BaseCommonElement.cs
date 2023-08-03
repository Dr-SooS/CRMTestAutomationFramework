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

        public WebDriverWait Wait(int timeSpanInSeconds = 0) => timeSpanInSeconds != 0 ? new WebDriverWait(_driver, TimeSpan.FromSeconds(timeSpanInSeconds)) : new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


        public BaseCommonElement(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}
