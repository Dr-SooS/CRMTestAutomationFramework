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
using log4net.Config;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class BaseStepDefenition
    {
        protected static User _user;
        protected static SiteSettings _siteSettings;
        protected static IWebDriver WebDriver;

        public static LoginPage LoginPage;
        public static HomeDashboardPage HomeDashboardPage;

        [BeforeTestRun]
        public static async Task BeforeTest()
        {
            BuildConfig();
            InitWebDriwer();
            Login(await GetAuthorizedSessionId(_user));
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            WebDriver.Quit();
        }

        public static void BuildConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            _user = config.GetSection("User").Get<User>();
            _siteSettings = config.GetSection("SiteSettings").Get<SiteSettings>();
        }

        public static async Task<string> GetAuthorizedSessionId(User user)
        {
            var content = new StringContent($"{{\"username\": \"{user.Username}\", \"password\": \"{user.Password}\"}}", Encoding.UTF8, "application/json");
            var responce = await new HttpClient()
                .PostAsync($"{_siteSettings.BaseUrl}/json.php?action=login", content);
            var responceBody = JObject.Parse(await responce.Content.ReadAsStringAsync());
            return responceBody.Value<string>("json_session_id");
        }

        public static void InitWebDriwer()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            WebDriver.Manage().Window.Maximize();
        }

        public static void Login(string sessionId)
        {
            WebDriver.Navigate().GoToUrl(_siteSettings.BaseUrl);
            var cookie = new Cookie("PHPSESSID", sessionId);
            WebDriver.Manage().Cookies.AddCookie(cookie);
            WebDriver.Navigate().GoToUrl($"{_siteSettings.BaseUrl}/index.php");
            HomeDashboardPage = new HomeDashboardPage(WebDriver);
            HomeDashboardPage.Wait().Until(WebDriver => HomeDashboardPage.PageTitleDisplayed);
        }
    }
}
