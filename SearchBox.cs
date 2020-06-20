using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCYipsStory3;

namespace BCYipsStory3.Controls
{
    public class SearchBox
    {
        IWebDriver driver;

        //Search box and search button
        private By searchBox;
        private By searchButton;
        private By searchLabel;

        public SearchBox(IWebDriver driver)
        {
            this.driver = driver;
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
            //Search box and search button
            searchBox = By.XPath("//*[@id=\"Query\"]"); ;
            searchButton = By.XPath("//*[@class=\"search-yips-button\"]");
            searchLabel = By.XPath("//*[@class=\"yips-list\"]/h2");
        }

        //search method
        public void SearchYip(string text)
        {
            //finds search box and sends text into the searchbox
            driver.FindElement(searchBox).SendKeys(text);

            //clicks on search button
            driver.FindElement(searchButton).Click();
        }

        //verifies search box and search button element
        public void VerifyElement()
        {
            Assert.IsNotNull(driver.FindElement(searchBox), "searchbox is not available");
            Assert.IsNotNull(driver.FindElement(searchButton), "search button is not available");
        }

        //verifies searching label text
        public void VerifySearchLabel(string text)
        {
            var expected = "Searching for: " + text;
            var actual = driver.FindElement(searchLabel).Text;
            Assert.AreEqual(expected, actual);
        }

        //Verifies Explore title
        public void VerifyTitle()
        {
            //explore title
            var expected = "Explore - BC Yips!";
            var actual = driver.Title;
            Assert.AreEqual(expected, actual);
        }

    }
}
