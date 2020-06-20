using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using BCYipsStory3.Controls;
using BCYipsStory3.ExplorePageControls;
using BCYipsStory3.ProfilePageControls;
using BCYipsStory1.HomePageControls;


namespace BCYipsStory3
{
    [TestFixture]
    public class BCYipsTests
    {
        OpenandClose setup;
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            setup = new OpenandClose();
            driver = setup.Open(null);            
        }

        [TearDown]
        public void TearDown()
        {
            setup.Close();
        }
        
        /// <summary>
        /// signing in with valid and invalid credentials
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password")]
        [TestCase("pinkfloyd", "password")]
        [TestCase("someuser", "password", "The user name or password provided is incorrect.")]
        [TestCase("user", "pass1234", "The user name or password provided is incorrect.")]
        [TestCase("=-=#4$5", "sjdkf-!23", "The user name or password provided is incorrect.")]
        [TestCase("", "", null, "The User name field is required.", "The Password field is required.")]
        [TestCase("user", "", null, null, "The Password field is required.")]
        [TestCase("", "password", null, "The User name field is required.", null)]
        [TestCase("null", "null", "The user name or password provided is incorrect.")]
        public void TestSignIn(string user, string password, string errorMessage = null, string userErrorMessage = null, string passwordErrorMessage = null)
        {
            this.InitLoginPage(user, password, errorMessage, userErrorMessage, passwordErrorMessage);            
            if (errorMessage == null && userErrorMessage == null && passwordErrorMessage == null)
            {
                Thread.Sleep(2000);
                //creates new homepage object
                HomePage homepage = new HomePage(driver);
                //verifies homepage title
                homepage.VerifyTitleAndFooter();

                Thread.Sleep(2000);
                //creates instance of NavigationControl object
                Navigationcontrol navControl = new Navigationcontrol(driver);
                //signs out from homepage
                navControl.SignOut();
                Thread.Sleep(2000);
            }
        }        

        //helper method -- to Signin
        private void InitLoginPage(string user, string password, string errorMessage, string userErrorMessage = null, string passwordErrorMessage = null)
        {
            Thread.Sleep(2000);
            //creates new singinpage object
            SignInPage login = new SignInPage(driver);
            //checks for elements
            login.Verify();
            //sends keys and clicks on element
            login.SignIn(user, password);
            if (errorMessage != null || userErrorMessage != null || passwordErrorMessage != null)
            {
                //checks for error message
                login.Verify(errorMessage, userErrorMessage, passwordErrorMessage);
            }
        }

        //helper method to verify navigation control links
        private void VerifyNavigationControl(Navigationcontrol navControl)
        {
            //verifies all these elements are available
            Assert.IsNotNull(navControl.HomeLink, "Home link is not available");
            Assert.IsNotNull(navControl.ExploreLink, "Explore link is not available");
            Assert.IsNotNull(navControl.ProfileLink, "Profile link is not available");
            Assert.IsNotNull(navControl.SignOutLink, "Signout link is not available");
        }
        
        /// <summary>
        /// composes new yip, clicks on yip button and signs out from home page
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password")] //enters valid username and password
        public void TestComposeNewYip(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            Thread.Sleep(2000);
            //creates instance of composenewyip object
            ComposeNewYip newyip = new ComposeNewYip(driver);

            //sends 'Desired text' into textarea based the 'Count' mentioned and clicks on yip button
            newyip.ComposeYip("Wow!", 20, true);
            Thread.Sleep(2000);
            //calls verify method-- it checks the yiptext and the remaining count of charlabel
            newyip.Verify("", 140);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //signs out from homepage
            navControl.SignOut();
        }

        /// <summary>
        /// Verifies Navigation control in HomePage --home, explore, profile, signout
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestNavigationControlHomePage(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //signs out from homepage
            navControl.SignOut();
        }

        /// <summary>
        /// Verifies sign in page title and footer
        /// </summary>
        [Test]
        public void TestSignInTitleAndFooter()
        {
            Thread.Sleep(2000);
            //creates new singinpage object
            SignInPage login = new SignInPage(driver);
            Thread.Sleep(2000);
            //verifies title on signin page
            var expected = "Log in - BC Yips!";
            var actual = driver.Title;
            Assert.AreEqual(expected, actual, "Title does not match");
            //verifies footer on signin page
            expected = "© 2020 - Bellevue College";
            actual = login.Footer.Text;
            Assert.AreEqual(expected, actual, "Footer does not match");
        }

        /// <summary>
        /// Verifies Navigation control in ExplorePage --home, explore, profile, signout
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestNavigationControlExplorePage(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //signs out from homepage
            navControl.SignOut();
        }

        /// <summary>
        /// Verifies Explore page title and footer
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestExplorePageTitleAndFooter(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            navControl.GotoExplore();
            Thread.Sleep(2000);
            //creates new Explore page object
            ExploreTitleAndFooter exploreTitleFooter = new ExploreTitleAndFooter(driver);
            Thread.Sleep(2000);
            //explore title
            var expected = "Explore - BC Yips!";
            var actual = driver.Title;
            Assert.AreEqual(expected, actual);
            //verifies footer on home page
            expected = "© 2020 - Bellevue College";
            actual = exploreTitleFooter.FooterBC.Text;
            Assert.AreEqual(expected, actual, "Footer does not match");
        }

        /// <summary>
        /// Verifies All Recent yips H2 header
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestAllYipsHeader(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of homepage object
            HomePage yipsH2Header = new HomePage(driver);
            Thread.Sleep(2000);
            //all yips header
            var expected = "Recent Watched Yips";
            var actual = yipsH2Header.AllYipsh2Header.Text;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies Searchbox in home page, search button and asserts searching title
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestHomePageSearchBox(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            //creates instance of SearchBox object
            SearchBox searchBox = new SearchBox(driver);
            Thread.Sleep(2000);
            //verifies search box elements
            searchBox.VerifyElement();
            Thread.Sleep(2000);
            //send text into search box
            searchBox.SearchYip("moon");
            Thread.Sleep(2000);
            //verifies explore page title
            searchBox.VerifyTitle();
            //asserts the text in search label
            searchBox.VerifySearchLabel("moon");
        }

        /// <summary>
        /// Verifies Searchbox in Explore page, search button and asserts searching title
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestExplorePageSearchBox(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on Explore link
            navControl.GotoExplore();
            //creates instance of Searchbox object
            SearchBox searchBox = new SearchBox(driver);
            Thread.Sleep(2000);
            //verifies seach box elements
            searchBox.VerifyElement();
            Thread.Sleep(2000);
            //send text into search box
            searchBox.SearchYip("Breeze");
            Thread.Sleep(2000);
            //verifies explore page title
            searchBox.VerifyTitle();
            //asserts text with the search label
            searchBox.VerifySearchLabel("Breeze");
        }

        /// <summary>
        /// Verifies Searchbox in Profile page, search button and asserts searching title
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestProfilePageSearchBox(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on Profile link
            navControl.GotoProfile();
            //creates instance of Searchbox object
            SearchBox searchBox = new SearchBox(driver);
            Thread.Sleep(2000);
            //verifies search box elements
            searchBox.VerifyElement();
            Thread.Sleep(2000);
            //send text into search box
            searchBox.SearchYip("wind chimes");
            Thread.Sleep(2000);
            //verifies explore page title
            searchBox.VerifyTitle();
            //asserts text with search label
            searchBox.VerifySearchLabel("wind chimes");
        }
        /// <summary>
        /// Verifies h3 header, top hashtags and top yippers in Explore page 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestExploreH3Header(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            navControl.GotoExplore();
            //creates instance of ExplorePage object
            ExplorePage h3Header = new ExplorePage(driver);
            Thread.Sleep(2000);
            //verifies top hashtags
            var expected = "Top Hashtags";
            var actual = h3Header.TopHashTags.Text;
            Assert.AreEqual(expected, actual);
            //verifies top yippers
            expected = "Top yippers";
            actual = h3Header.TopYippers.Text;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies Homepage controls--verifies all components of home page 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestHomepageControls(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates new homepage object
            HomePage homepage = new HomePage(driver);
            //verifies all components of home page
            homepage.Verify();
        }

        /// <summary>
        /// Verifies Profile page title, footer and navigation control
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestProfilePageTitleAndFooter(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Explore page object
            ProfilepageTitleandFooter profilepageTitle = new ProfilepageTitleandFooter(driver);
            Thread.Sleep(2000);
            //explore title
            var expected = "PinkFloyd's profile - BC Yips!";
            var actual = driver.Title;
            Assert.AreEqual(expected, actual, "title does not match");
            //verifies footer on home page
            expected = "© 2020 - Bellevue College";
            actual = profilepageTitle.FooterBC.Text;
            Assert.AreEqual(expected, actual, "Footer does not match");
        }

        /// <summary>
        /// Verifies Profile page h2 header - user profile and yippers header
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("pinkfloyd", "password")] //enters valid username and password
        public void TestUserProfileAndYippersHeader(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Explore page object
            ProfilepageTitleandFooter profilepageTitle = new ProfilepageTitleandFooter(driver);
            Thread.Sleep(2000);
            //checks user profile and yippers header
            profilepageTitle.VerifyUserProfileAndYippersHeader("PinkFloyd");
        }

        /// <summary>
        /// Verifies username in Profile container
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password")] //enters valid username and password
        public void TestUserNameInProfileContainer(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Explore page object
            ProfilePage profilePage = new ProfilePage(driver);
            //checks username in profile container
            profilePage.VerifyUserName("user");
        }

        /// <summary>
        /// Verifies first name and last name in profile page, and resets to original value after the test
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password")] //enters valid username and password
        public void TestFirstnameAndLastnameInProfilePage(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            
            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Profile page object
            ProfilePage profilePage = new ProfilePage(driver);
            //checks username in profile container
            profilePage.VerifyTextboxes();
            Thread.Sleep(2000);
            //enters firstname and last name
            profilePage.EnterFirstAndLastName("John", "Sanders");
            //clicks on home link
            navControl.GotoHome();
            Thread.Sleep(2000);
            //verifies first and last name in home page profile container
            profilePage.VerifyFullNameInHome("John ", "Sanders");
            //clicks on profile link
            navControl.GotoProfile();
            //resets to original value
            profilePage.ResetToOriginal();
        }

        /// <summary>
        /// Verifies change password in profile page, sign-out and sign back in with new password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password", "password1", "password1")] //enters valid username and password
        [TestCase("user", "password", "pass@#$", "pass@#$")] //enters valid username and password
        [TestCase("user", "password", "nullll", "nullll")] //enters valid username and password
        [TestCase("user", "password", "0000000", "0000000")] //enters valid username and password
        [TestCase("user", "password", "7890!@#", "7890!@#")] //enters valid username and password
        [TestCase("user", "password", "[]\\;'/", "[]\\;'/")] //enters valid username and password
        public void TestChangePasswordFields(string user, string password, string newPassword, string confirmNewPassword)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Profile page object
            ProfilePageChangePassword changePassword = new ProfilePageChangePassword(driver);
            changePassword.VerifyChangePassword(password, newPassword, confirmNewPassword);
            Thread.Sleep(2000);
            //clicks on sign-out link
            navControl.SignOut();
            Thread.Sleep(2000);
            //sign in again with a new password
            InitLoginPage(user, newPassword, null, null, null);
            Thread.Sleep(2000);
            //creates new homepage object
            HomePage homepage = new HomePage(driver);
            //verifies homepage title
            homepage.VerifyTitleAndFooter();
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Profile page object
            changePassword = new ProfilePageChangePassword(driver);
            //resets to original password
            changePassword.VerifyChangePassword(newPassword, password, password);
        }

        /// <summary>
        /// Verifies invalid change password in profile page
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password", "pass", "pass", "The New password must be at least 6 characters long.")] //enters valid username and password, but invalid new password
        [TestCase("user", "password", "password1", "", "The new password and confirmation password do not match.")] //enters valid username and password, but invalid new password
        [TestCase("user", "password", "", "password1", "The New password field is required.\r\nThe new password and confirmation password do not match.")] //enters valid username and password, but invalid new password
        [TestCase("user", "password", "", "", "The New password field is required.")] //enters valid username and password, but invalid new password
        [TestCase("user", "password", "", "", "The New password field is required.")] //enters valid username and password, but invalid new password
        
        public void TestInvalidChangePasswordFields(string user, string password, string newPassword, string confirmNewPassword, string errorMessage)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);

            Thread.Sleep(2000);
            //creates instance of NavigationControl object
            Navigationcontrol navControl = new Navigationcontrol(driver);
            //verifies navigation links
            VerifyNavigationControl(navControl);
            //clicks on profile link
            navControl.GotoProfile();
            Thread.Sleep(2000);
            //creates new Profile page object
            ProfilePageChangePassword changePassword = new ProfilePageChangePassword(driver);
            //sends current, new and confirm new password into textboxes
            changePassword.VerifyChangePassword(password, newPassword, confirmNewPassword);
            //verifies error message 
            changePassword.VerifyErrorLabel(errorMessage);
        }

        /// <summary>
        /// sends one new yip and asserts all the elements in the yip
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password")] //enters valid username and password
        public void TestFirstYip(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            Thread.Sleep(2000);
            //creates instance of composenewyip object
            ComposeNewYip newyip = new ComposeNewYip(driver);
            Thread.Sleep(2000);
            //sends 'Desired text' into textarea based the 'Count' mentioned and clicks on yip button
            newyip.ComposeYip("Wind!", 5, true);
            //creates a yipsinyipslist object
            YipsInYipsList yipElement = new YipsInYipsList(driver);
            Thread.Sleep(6000);
            //verifies fullname, username and yip content
            yipElement.VerifyYipElements("Tom Sanders", "user", "Wind!Wind!Wind!Wind!Wind!");
        }

        /// <summary>
        /// finds existing yip and its contents
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        [TestCase("user", "password")] //enters valid username and password
        public void TestSpecificYips(string user, string password)
        {
            //calls helper method InitLoginPage
            InitLoginPage(user, password, null, null, null);
            Thread.Sleep(2000);
            YipsListControl yipsList = new YipsListControl(driver);
            Thread.Sleep(2000);
            //verifies elements in a specific yip
            yipsList.Verify(20, 5, "Tom Sanders", "user", "Wind!Wind!Wind!Wind!Wind!");
        }
    }
}
