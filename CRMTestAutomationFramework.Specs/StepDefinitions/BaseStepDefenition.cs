using CRMTestAutomationFramework.PageObjects.TodayActivities.HomeDashboard;
using CRMTestAutomationFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CRMTestAutomationFramework.Specs.Configuration;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class BaseStepDefenition
    {
        protected static IWebDriver WebDriver;

        public static LoginPage LoginPage;
        public static HomeDashboardPage HomeDashboardPage;

        [BeforeTestRun]
        public static async Task BeforeTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            var user = config.GetSection("User").Get<User>();
            var siteSettings = config.GetSection("SiteSettings").Get<SiteSettings>();

            var content = new StringContent($"{{\"username\": \"{user.Username}\", \"password\": \"{user.Password}\"}}", Encoding.UTF8, "application/json");
            var responce = await new HttpClient()
                .PostAsync($"{siteSettings.BaseUrl}/json.php?action=login", content);
            var responceBody = JObject.Parse(await responce.Content.ReadAsStringAsync());

            


            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(siteSettings.BaseUrl);
            var cookie = new Cookie("PHPSESSID", responceBody.Value<string>("json_session_id"));
            WebDriver.Manage().Cookies.AddCookie(cookie);
            WebDriver.Navigate().GoToUrl($"{siteSettings.BaseUrl}/index.php");
            HomeDashboardPage = new HomeDashboardPage(WebDriver);
            HomeDashboardPage.Wait().Until(WebDriver => HomeDashboardPage.PageTitile.Displayed);
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            WebDriver.Quit();
        }
    }
}
