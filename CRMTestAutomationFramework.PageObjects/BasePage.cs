﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public WebDriverWait Wait(int timeSpanInSeconds = 0) => timeSpanInSeconds != 0 ? new WebDriverWait(_driver, TimeSpan.FromSeconds(timeSpanInSeconds)) : new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        public IWebElement PageTitile => _driver.FindElement(By.Id("main-title-module"));

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
        }
    }
}