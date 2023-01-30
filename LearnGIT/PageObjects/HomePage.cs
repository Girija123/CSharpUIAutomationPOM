using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnGIT.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy (How=How.ClassName, Using = "login_logo")]
        public IWebElement LogoIcon;

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UsernameTxtFld;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordTxtFld;


        [FindsBy(How = How.Id, Using = "login-button")]
         public IWebElement LoginBtn;


        public void VerifyHomePageWithLogo(String expectedHomePageTitle)
        {
            Assert.IsTrue(LogoIcon.Displayed);
            Assert.That(driver.Title, Is.EqualTo(expectedHomePageTitle));
        }

        public void EnterUsername(String username)
        {
            UsernameTxtFld.SendKeys(username);
        }

        public void EnterPassword(String password)
        {
            PasswordTxtFld.SendKeys(password);
        }

        public void ClickLoginBtn()
        {
            LoginBtn.Click();
        }


    }
}
