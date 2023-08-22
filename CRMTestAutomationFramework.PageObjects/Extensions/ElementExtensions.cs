using CRMTestAutomationFramework.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.Core.Extensions
{
    public static class ElementExtensions
    {
        public static T ClickAndGo<T>(this IWebElement element, IWebDriver webDriver) where T : BaseAppPage
        {
            element.Click();
            return Activator.CreateInstance(typeof(T), new object[] { webDriver }) as T;
        }
    }
}
