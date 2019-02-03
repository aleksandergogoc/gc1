using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;

namespace gc1.Test.Selenium.PageObjects.GainCapital
{
    public class CareersPage : BaseObjectClass
    {
        private readonly string WEB_ADDRESS = "/careers";

        #region locators
        private readonly By careersPageBody = By.XPath("//body[@class='clients-page']");
        private readonly By jobOportunitiesButton = By.XPath("//a[@href='#jobListing']");
        private readonly By viewAllPositionsLink = By.XPath("//a[@href='http://gaincapital.force.com/recruit/fRecruit__ApplyJobList']");
        #endregion

        public CareersPage(IWebDriver driver) : base(driver)
        {
            string url = driver.Url;
            if (!url.Contains(WEB_ADDRESS))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(WEB_ADDRESS));
                    if (!url.Contains(WEB_ADDRESS)) throw new WebException("This is not the Gain Capital Careers page!");
                }
                catch (Exception e) { }
            }
            else
            {
                WaitForElementVisibility(careersPageBody);
            }
        }

        public CareersPage ClickJobOportunitiesButton()
        {
            WaitForElementClickable(jobOportunitiesButton);
            ClickElement(jobOportunitiesButton);
            return this;
        }          

        public CurrentVacanciesPage ClickViewAllPositionsLink()
        {
            WaitForElementClickable(viewAllPositionsLink);
            ClickElement(viewAllPositionsLink);
            WaitForNumerOfTabsOpened(2);
            return new CurrentVacanciesPage(driver);
        }
    }
}
