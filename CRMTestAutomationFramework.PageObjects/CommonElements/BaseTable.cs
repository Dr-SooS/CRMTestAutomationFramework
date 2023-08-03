using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.CommonElements
{
    public class BaseTable : BaseCommonElement
    {
        public BaseTable(IWebDriver driver) : base(driver)
        {
        }

        public List<IWebElement> Rows => _driver.FindElements(By.XPath("//table/tbody/tr")).ToList();

        public void SelectRow(int rowIndex)
        {
            Rows[rowIndex].FindElement(By.TagName("input")).Click();
        }

        public string GetCellValue(int rowIndex, int cellIndex)
        {
            return _driver.FindElement(By.XPath($"//table/tbody/tr[{rowIndex}]/td[{cellIndex}]")).Text;
        }

        public bool IsRowContainingFollowingTextExists(string text)
        {
            return Rows.Any(row => row.Text.Contains(text));
        }
    }
}
