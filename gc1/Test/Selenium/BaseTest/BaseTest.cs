using gc1.Test.Selenium.PageObjects.GainCapital;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace gc1.Test.Selenium.BaseTests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private const string gcUrl = "https://www.gaincapital.com/";

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

        protected MainPage StartNavigation()
        {
            driver.Url = gcUrl;
            return new MainPage(driver);
        }
    }
}