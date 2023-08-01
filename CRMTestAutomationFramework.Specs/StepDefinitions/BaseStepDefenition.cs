using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class BaseStepDefenition
    {
        protected static IWebDriver WebDriver;

        [BeforeTestRun]
        public static void BeforeTest()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Window.Maximize();
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            WebDriver.Quit();
        }
    }
}
