using BCYipsStory1;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3.ExplorePageControls
{
    public class Navigationcontrol
    {
        IWebDriver driver;

        //title bar
        private By homeLink;
        private By exploreLink;
        private By profileLink;
        private By signOutForm;

        public IWebElement HomeLink {  get { return this.driver.FindElement(homeLink); } }
        public IWebElement ExploreLink { get { return this.driver.FindElement(exploreLink); } }
        public IWebElement ProfileLink { get { return this.driver.FindElement(profileLink); } }
        public IWebElement SignOutLink { get { return this.driver.FindElement(signOutForm); } }

        public Navigationcontrol(IWebDriver driver)
        {
            this.driver = driver;
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
            //title bar
            homeLink = By.XPath("//*[@id=\"site-menu\"]//*[@href=\"/\"]");
            exploreLink = By.XPath("//*[@id=\"site-menu\"]//*[@href=\"/Explore\"]");
            profileLink = By.XPath("//*[@id=\"site-menu\"]//*[contains(@href,\"/Profile\")]");
            //sign out
            signOutForm = By.XPath("//*[@id=\"site-menu\"]//*[@id=\"logoutForm\"]");
        }

        //sign out method
        public void SignOut()
        {
            this.driver.FindElement(signOutForm).Click();
        }

        //finds Home element and clicks on it
        public void GotoHome()
        {
            this.driver.FindElement(homeLink).Click();
        }

        //finds explore element and clicks on it
        public void GotoExplore()
        {
            this.driver.FindElement(exploreLink).Click();
        }

        //finds profile element and clicks on it
        public void GotoProfile()
        {
            this.driver.FindElement(profileLink).Click();
        }
    }
}
