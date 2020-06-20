using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3
{
    public class YipsListControl
    {
        IWebDriver driver;

        private List<YipsFeedControl> YipList;

        public YipsListControl(IWebDriver driver)
        {
            this.driver = driver;
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
            this.YipList = new List<YipsFeedControl>();
            var yipElements = this.driver.FindElements(By.XPath("//div[@class='yips-list']//*[@class='yip']"));
            int ind = 1;
            foreach (var yipElement in yipElements)
            {
                this.YipList.Add(new YipsFeedControl(this.driver, yipElement, ind));
                ind++;
            }
        }

        public void Verify(int totalCount, int yipInd, string fullname, string username, string yipcontent)
        {
            Assert.LessOrEqual(YipList.Count, totalCount);
            if (yipInd < totalCount)
            {
                YipList[yipInd].VerifyYipElements(fullname, username, yipcontent);
            }
        }
    }
}
