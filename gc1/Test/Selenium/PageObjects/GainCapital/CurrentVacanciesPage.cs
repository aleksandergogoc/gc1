using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace gc1.Test.Selenium.PageObjects.GainCapital
{
    public class CurrentVacanciesPage : BaseObjectClass
    {
        private readonly string WEB_ADDRESS = "http://gaincapital.force.com/recruit/fRecruit__ApplyJobList";
        #region locators
        private readonly By searchInput = By.XPath("//form[@action = '/recruit/fRecruit__ApplyJobList']//./input[@type='text']");
        private readonly By searchButton = By.XPath("//input[@value='Search']");
        private readonly By vacancy = By.XPath("//table[contains(@class, 'jobListPanel')]/tbody/tr");
        #endregion

        public CurrentVacanciesPage(IWebDriver driver) : base(driver)
        {
            IList<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            string url = driver.Url;
            if (!url.Equals(WEB_ADDRESS))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(WEB_ADDRESS));
                    if (!url.Equals(WEB_ADDRESS)) throw new WebException("This is not the Current Vacancies page!");
                }
                catch (Exception e) { }
            }
        }

        public CurrentVacanciesPage DoSearch(string keyword)
        {
            driver.FindElement(searchInput).Clear();
            ClickElement(searchInput);
            driver.FindElement(searchInput).SendKeys(keyword);
            ClickElement(searchButton);
            return this;
        }

        public int GetCurrentPageResultsCount()
        {
            ReadOnlyCollection<IWebElement> vacancies = driver.FindElements(vacancy);
            return vacancies.Count;
        }
    }
}
