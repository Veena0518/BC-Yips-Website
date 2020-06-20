using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3
{
    public class ProfilePage
    {
        IWebDriver driver;

        //username in profile container
        private By usernameProfileContainer;
        //first name textbox
        private By firstNameTextbox;
        //last name textbox
        private By lastNameTextbox;
        //save changes button
        private By saveChangesButton;
        //full name
        private By fullName;

        private string originalFirstName;
        private string originalLastName;

        //constructor
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            //calls init method
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
            //username in profile container
            usernameProfileContainer = By.XPath("//*[@id=\"side\"]//*[@class=\"username\"]");
            //first name textbox
             firstNameTextbox = By.XPath("//*[@id='FirstName']");
            //last name textbox
             lastNameTextbox = By.XPath("//*[@id='LastName']");
            //save changes button
            saveChangesButton = By.XPath("//*[@class='save-profile-button']");
            //full name
            fullName = By.XPath("//*[@id='side']//*[@class='fullname']");
        }

        //verify username in profile container
        public void VerifyUserName(string username)
        {
            //explore title
            var expected = "@"+ username;
            var actual = driver.FindElement(usernameProfileContainer).Text;
            Assert.AreEqual(expected, actual, "username does not match");
        }
        
        //verifies textboxes
        public void VerifyTextboxes()
        {
            Assert.IsNotNull(driver.FindElement(firstNameTextbox), "Firstname textbox is not available");
            Assert.IsNotNull(driver.FindElement(lastNameTextbox), "Lastname textbox is not available");
            Assert.IsNotNull(driver.FindElement(saveChangesButton), "Save changes button is not available");
        }

        //verify first name and last name textbox
        public void EnterFirstAndLastName(string firstname, string lastname)
        {
            //gets original value from first name textbox
            this.originalFirstName = driver.FindElement(firstNameTextbox).GetAttribute("value");
            //gets original value from last name textbox
            this.originalLastName = driver.FindElement(lastNameTextbox).GetAttribute("value");
            //sets first name and last name
            this.SetFirstAndLastName(firstname, lastname);   
        }

        //verify fullname in profile container of home page
        public void VerifyFullNameInHome(string firstname, string lastname)
        {
            //verifies fullname 
            var expected = firstname + lastname;
            var actual = driver.FindElement(fullName).Text;
            Assert.AreEqual(expected, actual, "Fullname does not match");
        }

        //resets original value back in the textboxes
        public void ResetToOriginal()
        {
            this.SetFirstAndLastName(this.originalFirstName, this.originalLastName);
        }

        private void SetFirstAndLastName(string firstname, string lastname)
        {
            //clears text box
            driver.FindElement(firstNameTextbox).Clear();
            //finds text box and sends text into the boxes
            driver.FindElement(firstNameTextbox).SendKeys(firstname);
            //clears text box
            driver.FindElement(lastNameTextbox).Clear();
            //sends value
            driver.FindElement(lastNameTextbox).SendKeys(lastname);
            //clicks on save changes button
            driver.FindElement(saveChangesButton).Click();
        }        
    }
}
