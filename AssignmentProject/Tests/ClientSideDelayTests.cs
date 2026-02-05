using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using CSE2522_Selenium_NUnit.Pages;
using CSE2522_Selenium_NUnit.Utilities;

namespace CSE2522_Selenium_NUnit.Tests
{
    [TestFixture]
    public class ClientSideDelayTests
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.StartBrowser();
            DriverManager.Driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            new HomePage(DriverManager.Driver).GoToClientSideDelay();
        }

        [Test(Description = "TC003_1_Client_Side_Delay_Verification")]
        public void VerifyClientSideDelay()
        {
            var page = new ClientSideDelayPage(DriverManager.Driver);
            page.ClickButton();

            WebDriverWait wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(15));
            wait.Until(driver =>
            {
                var element = driver.FindElement(OpenQA.Selenium.By.Id("content"));
                return element.Text.Contains("Data calculated on the client side.");
            });

            Assert.That(page.GetResult(), Is.EqualTo("Data calculated on the client side."));
        }

        [TearDown]
        public void TearDown() => DriverManager.CloseBrowser();
    }
}
