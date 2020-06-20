using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3
{
    public class YipsFeedControl
    {
        IWebDriver driver;

        //user details
        private IWebElement fullName;
        private IWebElement userName;
        //yip content
        private IWebElement yipContent;
        private IWebElement reLink;

        public YipsFeedControl(IWebDriver driver, IWebElement element, int yipInd)
        {
            this.driver = driver;
            this.Init(element, yipInd);
        }

        //helper method to find elements
        private void Init(IWebElement element, int yipdInd)
        {
            //Yip elements
            fullName = GetElement(element, "//*[@id='content']//*[@class='heading']/span[@class='fullname']", yipdInd);
            userName = GetElement(element, "//*[@id='content']//*[@class='heading']/span[@class='username']", yipdInd);
            yipContent = GetElement(element, "//*[@id='content']//*[@class='details']//*[@class='content']", yipdInd);
            reLink = GetElement(element, "//*[@id='content']//*[@class='details']//*[@class='re-links']", yipdInd);
        }

        private IWebElement GetElement(IWebElement element, string xPath, int yipInd)
        {
            var elements = element.FindElements(By.XPath(xPath));
            if (elements.Count > yipInd)
            {
                return elements[yipInd];
            }

            return null;
        }

        //verify method 
        public void VerifyYipElements(string fullname, string username, string yipcontent)
        {
            //fullname
            Assert.AreEqual(fullname, fullName.Text);
            //username
            Assert.AreEqual("@" + username, userName.Text);
            //yip content
            Assert.AreEqual(yipcontent, yipContent.Text);
            //relink
            Assert.AreEqual("( reply re-yip )", reLink.Text);
        }
    }
}
