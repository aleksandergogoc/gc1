using gc1.Test.Selenium.BaseTests;
using gc1.Test.Selenium.PageObjects.GainCapital;
using NUnit.Framework;

namespace gc1.Test.Selenium.Tests
{
    class SeleniumTest : BaseTest
    {
        [Test]
        public void SeleniumTest1()
        {
            string searchKeyword = "New Accounts Associate";

            MainPage gcMainPage = StartNavigation();
            CareersPage careersPage = gcMainPage.ClickCareers();
            CurrentVacanciesPage currentVacancies = careersPage
                .ClickJobOportunitiesButton()
                .ClickViewAllPositionsLink();
            currentVacancies.DoSearch(searchKeyword);
            Assert.AreEqual(5, currentVacancies.GetCurrentPageResultsCount(), "Wrong vacancies search results count!");
        }
    }
}
