using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace gc1.Test.Selenium.PageObjects
{
    public abstract class BaseObjectClass
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BaseObjectClass(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected void WaitForElementVisibility(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        protected void WaitForElementClickable(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        protected void ClickElement(By locator)
        {
            try
            {
                driver.FindElement(locator).Click();
            }
            catch (Exception e)
            {
                IWebElement element = driver.FindElement(locator);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);
            }
        }

        protected string GetElementText(By locator)
        {
            return driver.FindElement(locator).Text;
        }

        protected void WaitForNumerOfTabsOpened(int expectedTabsCount)
        {
            try
            {
                wait.Until((driver) =>
                {
                    IList<string> tabs = new List<string>(driver.WindowHandles);
                    if (tabs.Count.Equals(expectedTabsCount))
                    {
                        Console.WriteLine("Current number of opened tabs is: {0}", tabs.Count);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            } catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException("Timed out when waiting for expected number of tabs opened!");
            }
        }
    }
}
