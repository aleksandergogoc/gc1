using gc1.Test.Selenium.PageObjects.Google;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace gc1.Test.Selenium.BaseTests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private const string testUrl = "https://www.google.com/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("drivers\\");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
        }

        protected GoogleHomePage StartNavigation()
        {
            driver.Url = testUrl;
            return new GoogleHomePage(driver);
        }
    }
}