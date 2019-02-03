using OpenQA.Selenium;
using System;
using System.Net;

namespace gc1.Test.Selenium.PageObjects.GainCapital
{
    public class MainPage : BaseObjectClass
    {
        private readonly string WEB_ADDRESS = "https://www.gaincapital.com/";
        private readonly By homePageBody = By.XPath("//body[@class='home-page']");
        private readonly By careersMenuOption = By.XPath("(//a[@href='careers.shtml'])[1]");

        public MainPage(IWebDriver driver) : base(driver)            
        {
            string url = driver.Url;
            if(!url.Equals(WEB_ADDRESS))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(WEB_ADDRESS));
                    if (!url.Equals(WEB_ADDRESS)) throw new WebException("This is not the Gain Capital home page!");
                }
                catch (Exception e) { }
            } else
            {
                WaitForElementVisibility(homePageBody);
            }
        }

        public CareersPage ClickCareers()
        {
            ClickElement(careersMenuOption);
            return new CareersPage(driver);
        }
    }
}
