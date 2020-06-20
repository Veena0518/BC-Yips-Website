using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory1.HomePageControls
{
    public class YipsInYipsList
    {
        IWebDriver driver;

        //Yip elements
        private By fullName;
        private By userName;
        private By yipContent;
        private By reLink;
        //private By reyipLink;

        public YipsInYipsList(IWebDriver driver)
        {
            this.driver = driver;
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
            //Yip elements
             fullName = By.XPath("//*[@id='content']//*[@class='heading']/span[@class='fullname']");
             userName = By.XPath("//*[@id='content']//*[@class='heading']/span[@class='username']");
            yipContent = By.XPath("//*[@id='content']//*[@class='details']//*[@class='content']");
            reLink = By.XPath("//*[@id='content']//*[@class='details']//*[@class='re-links']");
            //reyipLink = By.XPath("");
        }

        //verify method 
        public void VerifyYipElements(string fullname, string username, string yipcontent)
        {
            //fullname
            var expected1 = fullname;
            var actual1 = driver.FindElement(fullName).Text;
            Assert.AreEqual(expected1, actual1);

            //username
            var expected2 = "@"+ username;
            var actual2 = driver.FindElement(userName).Text;
            Assert.AreEqual(expected2, actual2);

            //yip content
            var expected3 = yipcontent;
            var actual3 = driver.FindElement(yipContent).Text;
            Assert.AreEqual(expected3, actual3);

            //relink
            var expected4 = "( reply re-yip )";
            var actual4 = driver.FindElement(reLink).Text;
            Assert.AreEqual(expected4, actual4);
        }
    }
}

