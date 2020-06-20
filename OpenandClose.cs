using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BCYipsStory3
{
    public class OpenandClose
    {
        private IWebDriver driver;
      
        //Bc yips url
        private const string BCYipsUrl = @"http://localhost:50783/";

        //open method
        public IWebDriver Open(string type)
        {
            if (string.IsNullOrEmpty(type) || type == "chrome")
            {
                driver = new ChromeDriver();
            }

            driver.Navigate().GoToUrl(BCYipsUrl);
            return driver;
        }

        //close method
        public void Close()
        {
            driver.Quit();
        }
    }
}
