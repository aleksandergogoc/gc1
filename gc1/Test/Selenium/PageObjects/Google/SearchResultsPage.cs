using OpenQA.Selenium;
using System;
using System.Net;

namespace gc1.Test.Selenium.PageObjects.Google
{
    public class SearchResultsPage : BaseObjectClass
    {
        private readonly string WEB_ADDRESS = "/search";

        #region locators
        private readonly By searchResultLink = By.XPath("//a//h3");
        #endregion

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            string url = driver.Url;
            if (!url.Contains(WEB_ADDRESS))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(WEB_ADDRESS));
                    if (!url.Contains(WEB_ADDRESS)) throw new WebException("This is not the Google search results page!");
                }
                catch (Exception e) { }
            }
        }

        public SearchResultTargetWebPage ClickFirstSearchResult()
        {
            WaitForElementClickable(searchResultLink);
            ClickElement(searchResultLink);
            return new SearchResultTargetWebPage(driver);
        }          
                
    }
}
