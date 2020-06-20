using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3.Controls
{
    public class ComposeNewYip
    {
        IWebDriver driver;

        //compose new yip
        private By composeNewYipTextArea;
        private By newyipButton;
        private By charLabel;

        //constructor
        public ComposeNewYip(IWebDriver driver)
        {
            this.driver = driver;
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
             //compose new yip
            composeNewYipTextArea = By.XPath("//*[@id=\"Content\"]");
            newyipButton = By.XPath("//*[@class=\"create-yip-button\"]");
            charLabel = By.XPath("//*[@id=\"post-yip\"]//*[@class=\"char-count\"]");
        }

        //composes new yip
        public void ComposeYip(string text, int count, bool click)
        {
            //finds text area
            var element = driver.FindElement(composeNewYipTextArea);
            //sends desired text with desired count to text area
            for(int i=0; i<count; i++)
            {
                //sends text
                element.SendKeys(text);
            }
            //clicks on Yip button--if it is set to true in the test
            if(click)    
               driver.FindElement(newyipButton).Click();
        }

        //verify method to compose new yip
        public void Verify(string yiptext, int remainingcount)
        {
            //verifies textarea and yip button- whether it is available or not
            Assert.IsNotNull(driver.FindElement(composeNewYipTextArea), "textarea is not available");
            Assert.IsNotNull(driver.FindElement(newyipButton), "Yip button is not available");
           
            //verifies desired text with the text available in the text area
            Assert.AreEqual(yiptext, driver.FindElement(composeNewYipTextArea).GetAttribute("value"), "text entered is different");
            //verifies remaining count with the count available in the charlabel
            //Assert.AreEqual(remainingcount.ToString(), driver.FindElement(charLabel).GetAttribute("value"), "text count is not same");
            Assert.AreEqual(remainingcount.ToString(), driver.FindElement(charLabel).Text, "text count is not same");
        }
    }

}
