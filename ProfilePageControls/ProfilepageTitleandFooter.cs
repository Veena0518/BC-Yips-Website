using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3.ProfilePageControls
{
    public class ProfilepageTitleandFooter
    {
        IWebDriver driver;

        //title page
        private By ProfilepageTitle;
        //footer
        private By footerBC;
        //User's profile header
        private By userProfileHeader;
        //yippers header
        private By yippersHeader;

        //constructor
        public ProfilepageTitleandFooter(IWebDriver driver)
        {
            this.driver = driver;
            //calls init method
            this.Init();
        }

        public IWebElement FooterBC { get { return this.driver.FindElement(footerBC); } }

        //helper method to find elements
        private void Init()
        {
            //title page
            ProfilepageTitle = By.XPath("/html/head/title");
            //footer
            footerBC = By.XPath("/html/body/footer");
            //User's profile header
            userProfileHeader = By.XPath("//*[@id='content']/h2[1]");
            //yippers header
            yippersHeader = By.XPath("//*[@id='content']/h2[2]");
        }

        //verifies User profile header and yippers header
        public void VerifyUserProfileAndYippersHeader(string user)
        {
            //User profile header
            var expected = user + "'s profile";
            var actual = driver.FindElement(userProfileHeader).Text;
            Assert.AreEqual(expected, actual, "user profile header does not match");

            //yippers i'm watching header
            expected = "Yippers I am watching...";
            actual = driver.FindElement(yippersHeader).Text;
            Assert.AreEqual(expected, actual, "Yippers header does not match");
        }
    }
}
