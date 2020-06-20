using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3.ExplorePageControls
{
    public class ExploreTitleAndFooter
    {
        IWebDriver driver;

        //title page
        private By explorepageTitle;
        //footer
        private By footerBC;

        //constructor
        public ExploreTitleAndFooter(IWebDriver driver)
        {
            this.driver = driver;
            //calls init method
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
            //title page
            explorepageTitle = By.XPath("/html/head/title");
            
            //footer
            footerBC = By.XPath("/html/body/footer");
        }

        public IWebElement ExplorepageTitle { get { return this.driver.FindElement(explorepageTitle); } }
        public IWebElement FooterBC { get { return this.driver.FindElement(footerBC); } }        
    }
}
