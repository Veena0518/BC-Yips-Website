using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using BCYipsStory3.Controls;
using BCYipsStory3.ExplorePageControls;

namespace BCYipsStory3
{
    public class HomePage
    {
        IWebDriver driver;

        //title page
        private By homepageTitle;
        //footer
        private By footerBC;
        //all recent feed
        private By allYipsh2Header;
        //compose new yip class
        private ComposeNewYip composeYip;
        //Search box class
        private SearchBox searchBox;
        //Navigation control class
        private Navigationcontrol navControl;
        private YipsListControl yipListControl;


        //constructor
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            //calls init method
            this.Init();
        }

        //property for ComposeNewYip
        public ComposeNewYip ComposeYip {get{ return this.composeYip; } }

        //property for Search box 
        public SearchBox SearchBox { get { return this.searchBox; } }

        // property for Navigation control
        public Navigationcontrol Navigationcontrol { get { return this.navControl; } }

        public YipsListControl YipList { get { return this.yipListControl; } }

        public IWebElement AllYipsh2Header { get { return this.driver.FindElement(allYipsh2Header); } }

        //helper method to find elements
        private void Init()
        {
             //title page
            homepageTitle = By.XPath("/html/head/title");
            //footer
            footerBC = By.XPath("/html/body/footer");
            //all recent feed
            allYipsh2Header = By.XPath("//*[@class=\"yips-list\"]/h2");
            //compose new yip class
            composeYip = new ComposeNewYip(this.driver);
            //Search box class
            searchBox = new SearchBox(this.driver);
            //navigation control class
            navControl = new Navigationcontrol(this.driver);

            yipListControl = new YipsListControl(this.driver);
        }

        //verifies all components of home page
        public void Verify()
        {
            this.VerifyTitleAndFooter();
            this.ComposeYip.ComposeYip("Sun",3, true);
            this.ComposeYip.Verify("", 140);
            this.Navigationcontrol.GotoExplore();
            this.SearchBox.VerifyTitle();
            this.SearchBox.VerifyElement();
            this.SearchBox.SearchYip("pinkfloyd");
            this.SearchBox.VerifySearchLabel("pinkfloyd");
        }


        //verify method to verify title
        public void VerifyTitleAndFooter()
        {
            var expected = "Home Page - BC Yips!";
            var actual = driver.Title;            
            Assert.AreEqual(expected, actual);

            //verifies footer on home page
            expected = "© 2020 - Bellevue College";
            actual = driver.FindElement(footerBC).Text;
            Assert.AreEqual(expected, actual, "Footer does not match");
        }
    }
}
