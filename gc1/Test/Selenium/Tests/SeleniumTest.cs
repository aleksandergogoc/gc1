using gc1.Test.Selenium.BaseTests;
using gc1.Test.Selenium.PageObjects.Google;
using NUnit.Framework;

namespace gc1.Test.Selenium.Tests
{
    class SeleniumTest : BaseTest
    {
        [Test, Parallelizable]
        public void SearchForAppleKeywordTest()
        {
            const string searchKeyword = "apple";

            GoogleHomePage googleMainPage = StartNavigation();
            SearchResultsPage searchResultsPage = googleMainPage.SearchFor(searchKeyword);
            SearchResultTargetWebPage searchResultTargetWebPage = searchResultsPage.ClickFirstSearchResult();
            Assert.True(searchResultTargetWebPage.IsPageLoaded());           

        }
    }
}
