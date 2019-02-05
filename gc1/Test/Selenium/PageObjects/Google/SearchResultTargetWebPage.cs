using OpenQA.Selenium;

namespace gc1.Test.Selenium.PageObjects.Google
{
    public class SearchResultTargetWebPage : BaseObjectClass
    {
        #region locators
        private readonly By targetWebPageBody = By.XPath("//body");
        #endregion

        public SearchResultTargetWebPage(IWebDriver driver) : base(driver)
        {
            
        }

        public bool IsPageLoaded()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(targetWebPageBody));
            return true;
        }

    }
}
