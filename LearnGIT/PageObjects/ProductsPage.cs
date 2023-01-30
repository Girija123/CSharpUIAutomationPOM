using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.DevTools;


namespace LearnGIT.PageObjects
{
    public  class ProductsPage
    {

        private IWebDriver driver;


        public ProductsPage(IWebDriver driver) {

            PageFactory.InitElements(driver, this);
            this.driver = driver;
        
        }



        [FindsBy(How= How.Id, Using = "react-burger-menu-btn")]
        public IWebElement MenuIcon;

        [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
        public IWebElement BagIcon;

        [FindsBy(How = How.ClassName, Using = "title")]
        public IWebElement ProductsPageHeading;

        [FindsBy(How = How.ClassName, Using = "product_sort_container")]
        public IWebElement SortDropdown;

        [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
        public IWebElement AllItemsMenuOption;

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        public IWebElement AboutMenuOption;

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        public IWebElement LogOutMenuOption;

        [FindsBy(How = How.Id, Using = "reset_sort_container")]
        public IWebElement ResetMenuOption;

        public void ClickAddToCartBtn(String ProductName)
        {
            driver.FindElement(By.XPath("")).Click();
        }

        public void clickMenuIcon()
        {
            MenuIcon.Click();
            Assert.True(AllItemsMenuOption.Displayed);
            Assert.True(AboutMenuOption.Displayed);
            Assert.True(LogOutMenuOption.Displayed);
            Assert.True(ResetMenuOption.Displayed);

        }
        
        public void VerifyProductsPageLanding(String expectedProductsPageHeadingText)
        {
            Assert.That(ProductsPageHeading.Text, Is.EqualTo(expectedProductsPageHeadingText));
        }

        public void ClickBagIcon()
        {
            BagIcon.Click();
        }

        public void ChooseSortOption(String sortOption)
        {
            new SelectElement(SortDropdown).SelectByText(sortOption);
        }

    }
}
