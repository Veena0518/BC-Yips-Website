using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCYipsStory3.ProfilePageControls
{
    public class ProfilePageChangePassword
    {
        IWebDriver driver;

        //current password textbox
        private By currentPasswordTextbox;
        //New password textbox
        private By newPasswordTextbox;
        //confirm new password textbox
        private By confirmNewPasswordTextbox;
        //change password button
        private By changePasswordButton;
        //current password error field
        private By currentPasswordErrorLabel;
       
        //constructor
        public ProfilePageChangePassword(IWebDriver driver)
        {
            this.driver = driver;
            //calls init method
            this.Init();
        }

        //helper method to find elements
        private void Init()
        {
           //current password textbox
             currentPasswordTextbox = By.XPath("//*[@id='OldPassword']");
            //New password textbox
            newPasswordTextbox = By.XPath("//*[@id='NewPassword']");
            //confirm new password textbox
            confirmNewPasswordTextbox = By.XPath("//*[@id='ConfirmPassword']");
            //change password button
            changePasswordButton = By.XPath("//*[@id='side']//*[@class='profile-container']//input[@value='Change password']");
            //current password error field
            currentPasswordErrorLabel = By.XPath("//*[@id='side']//*[@class='validation-summary-errors']/ul[li]");
    }

        //verifies textboxes
        private void VerifyTextboxes()
        {
            Assert.IsNotNull(driver.FindElement(currentPasswordTextbox), "Current password textbox is not available");
            Assert.IsNotNull(driver.FindElement(newPasswordTextbox), "New password textbox is not available");
            Assert.IsNotNull(driver.FindElement(confirmNewPasswordTextbox), "Confirm new password textbox is not available");
            Assert.IsNotNull(driver.FindElement(changePasswordButton), "Change password button is not available");
        }

        //sets password into textboxes
        private void SetPassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            //finds text box and sends text into the boxes
            driver.FindElement(currentPasswordTextbox).SendKeys(currentPassword);
            //sends value
            driver.FindElement(newPasswordTextbox).SendKeys(newPassword);
            //sends value
            driver.FindElement(confirmNewPasswordTextbox).SendKeys(confirmNewPassword);
            //clicks on change password button
            driver.FindElement(changePasswordButton).Click();
        }

        //verify error message
        public void VerifyErrorLabel(string currentMessage = null)
        {
            if (currentMessage != null)
            {
                Assert.AreEqual(driver.FindElement(currentPasswordErrorLabel).Text, currentMessage, "current password field is required");
            }
        }

        public void VerifyChangePassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            VerifyTextboxes();
            SetPassword(currentPassword, newPassword, confirmNewPassword);
        }
    }
}
