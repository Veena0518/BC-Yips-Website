using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCYipsStory3.ExplorePageControls;

namespace BCYipsStory3
{
    public class ExplorePage
    {
        IWebDriver driver;

        //h3 header
        private By topHashtags;
        private By topYippers;
        //explore title and footer class
        private ExploreTitleAndFooter expTitleFooter;
        //Navigation control class
        private Navigationcontrol navControl;

        public ExplorePage(IWebDriver driver)
        {
            this.driver = driver;
            this.Init();
        }

        //property for explore title and footer
        public ExploreTitleAndFooter ExploreTitleAndFooter { get { return this.expTitleFooter; } }

        // property for Navigation control
        public Navigationcontrol Navigationcontrol { get { return this.navControl; } }

        public IWebElement TopHashTags { get { return this.driver.FindElement(topHashtags); } }
        public IWebElement TopYippers { get { return this.driver.FindElement(topYippers); } }

        //helper method to find elements
        private void Init()
        {
            //h3 header
            topHashtags = By.XPath("//*[@class=\"trending-hashtags\"]/header/h3");
            topYippers = By.XPath("//*[@class=\"Explore\"]//section[2]/header/h3");
            //explore title and footer class
            expTitleFooter = new ExploreTitleAndFooter(this.driver);
            //navigation control class
            navControl = new Navigationcontrol(this.driver);
        }
    }
}
