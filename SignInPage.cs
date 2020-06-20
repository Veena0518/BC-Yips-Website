using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;

namespace BCYipsStory3
{
    public class SignInPage
    {
        IWebDriver driver;

        private By userNameTextbox;
        private By passwordTextbox;
        private By rememberMeCheckbox;
        private By SigninButton;
        //Error label fields
        private By errorLabel;
        private By usernameerrorLabel;
        private By passwordErrorField;
        //sign in page title
        private By signinPageTitle;
        private By logoMascot;
        private By logoYips;
        private By logoBC;
        private By footer;

        //constructor
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            //calls init method
            this.Init();
        }

        public IWebElement Footer { get { return this.driver.FindElement(footer); } }

        //helper method to find elements
        private void Init()
        {
            userNameTextbox = By.Id("UserName");
            passwordTextbox = By.Id("Password");
            rememberMeCheckbox = By.XPath("//*[@id=\"loginForm\"]//*[@class=\"checkbox\"]");
            SigninButton = By.XPath("//*[@id=\"loginForm\"]//*[@type=\"submit\"]");

            //Error label fields
            errorLabel = By.XPath("//*[@id=\"loginForm\"]//*[@class=\"validation-summary-errors\"]");
            usernameerrorLabel = By.XPath("//*[@id=\"loginForm\"]//*[@for=\"UserName\"]");
            passwordErrorField = By.XPath("//*[@id=\"loginForm\"]//*[@for=\"Password\"]");
            //sign in page title
            signinPageTitle = By.XPath("/html/head/title");
            logoMascot = By.XPath("//*[@class=\"logo-mascot\"]");
            logoYips = By.XPath("//*[@class=\"logo-yips\"]");
            logoBC = By.XPath("//*[@class=\"logo-bc\"]");
            footer = By.XPath("/html/body/footer");
        }

        //sign in method
        public void SignIn(string user, string password)
        {
            //finds text box and sends text into the boxes
            driver.FindElement(userNameTextbox).SendKeys(user);
            driver.FindElement(passwordTextbox).SendKeys(password);
            //clicks on rememberme box
            driver.FindElement(rememberMeCheckbox).Click();
            //clicks on sign in button
            driver.FindElement(SigninButton).Click();
        }

        //verify method
        public void Verify(string failedMessage = null, string userMessage = null, string passwordMessage = null)
        {
            Assert.IsNotNull(driver.FindElement(userNameTextbox), "username textbox is not available");
            Assert.IsNotNull(driver.FindElement(passwordTextbox), "password textbox is not available");
            Assert.IsNotNull(driver.FindElement(rememberMeCheckbox), "remember me box is not available");
            Assert.IsNotNull(driver.FindElement(SigninButton), "sign in button is not available");

            //verifies error label above the usertextbox with the provided message
            if (failedMessage != null)
            {
                Assert.AreEqual(driver.FindElement(errorLabel).Text, failedMessage, "username or password did not match");
            }
            //verifies username error label with the provided message
            if (userMessage != null)
            {
                Assert.AreEqual(driver.FindElement(usernameerrorLabel).Text, userMessage, "username did not match");
            }
            //verifies password error label with the provided message
            if (passwordMessage != null)
            {
                Assert.AreEqual(driver.FindElement(passwordErrorField).Text, passwordMessage, "password did not match");
            }
        }
    }
}
