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
        private string _cellXpath = "//table/tbody/tr[{0}]/td[{1}]";

        public BaseTable(IWebDriver driver) : base(driver)
        {
        }

        private List<IWebElement> _rows => _driver.FindElements(By.XPath("//table/tbody/tr")).ToList();

        public int RowsCount => _rows.Count;

        public void SelectRow(int rowIndex)
        {
            _rows[rowIndex].FindElement(By.TagName("input")).Click();
        }

        public string GetCellValue(int rowIndex, int cellIndex)
        {
            return _driver.FindElement(By.XPath(String.Format(_cellXpath, rowIndex, cellIndex))).Text;
        }

        public bool IsRowContainingFollowingTextExists(string text)
        {
            return _rows.Any(row => row.Text.Contains(text));
        }
    }
}
