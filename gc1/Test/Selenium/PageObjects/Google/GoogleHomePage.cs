using OpenQA.Selenium;
using System;
using System.Net;

namespace gc1.Test.Selenium.PageObjects.Google
{
    public class GoogleHomePage : BaseObjectClass
    {
        private readonly string WEB_ADDRESS = "https://www.google.com/";
        private readonly By searchBox = By.Name("q");

        public GoogleHomePage(IWebDriver driver) : base(driver)            
        {
            string url = driver.Url;
            if(!url.Equals(WEB_ADDRESS))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(WEB_ADDRESS));
                    if (!url.Equals(WEB_ADDRESS)) throw new WebException("This is not the Google.com home page!");
                }
                catch (Exception e) { }
            }
        }

        public SearchResultsPage SearchFor(string keyword)
        {
            WaitForElementVisibility(searchBox);
            ClickElement(searchBox);
            driver.FindElement(searchBox).SendKeys(keyword);
            driver.FindElement(searchBox).SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
