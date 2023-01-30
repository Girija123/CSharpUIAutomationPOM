using LearnGIT.PageObjects;
using LearnGIT.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LearnGIT.Tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

        }

        public void VerifySort()
        {
            HomePage homePage = new HomePage(driver);
            ProductsPage productsPage = new ProductsPage(driver);

            homePage.VerifyHomePageWithLogo("Swag Labs");
            homePage.EnterUsername("standard_user");
            homePage.EnterPassword("secret_sauce");
            homePage.ClickLoginBtn();
            productsPage.VerifyProductsPageLanding("Products");
            productsPage.ChooseSortOption("Price (low to high)");
        }

        [Test]
        public void VerifyValidLogin()
        {
            HomePage homePage= new HomePage(driver);
            ProductsPage productsPage= new ProductsPage(driver);
            CommonFunctions commonFunctions =  new CommonFunctions(driver);

            homePage.VerifyHomePageWithLogo("Swag Labs");
            homePage.EnterUsername("standard_user");
            homePage.EnterPassword("secret_sauce");
            homePage.ClickLoginBtn();
            commonFunctions.WaitForSpecificAmountOfTime(3);
            productsPage.VerifyProductsPageLanding("Products");

        }

        public void VerifyInValidLogin()
        {
            HomePage homePage = new HomePage(driver);
            ProductsPage productsPage = new ProductsPage(driver);
            CommonFunctions commonFunctions = new CommonFunctions(driver);

            homePage.VerifyHomePageWithLogo("Swag Labs");
            homePage.EnterUsername("standard_user_inv");
            homePage.EnterPassword("secret_sauce_inv");
            homePage.ClickLoginBtn();
            commonFunctions.WaitForSpecificAmountOfTime(2);
            productsPage.VerifyProductsPageLanding("Products");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}