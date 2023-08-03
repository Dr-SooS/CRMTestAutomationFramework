using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts
{
    public class ContactDetailsPage : BasePage
    {
        public ContactDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement EditButton => _driver.FindElement(By.Id("DetailForm_edit"));
        public IWebElement SummaryHeader => _driver.FindElement(By.Id("_form_header"));
        public IWebElement Category => _driver.FindElement(By.XPath("//li[./p[.='Category']]"));
    }
}
