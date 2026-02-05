using NUnit.Framework;
using CSE2522_Selenium_NUnit.Pages;
using CSE2522_Selenium_NUnit.Utilities;

namespace CSE2522_Selenium_NUnit.Tests
{
    [TestFixture]
    public class SampleAppTests
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.StartBrowser();
            DriverManager.Driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            new HomePage(DriverManager.Driver).GoToSampleApp();
        }

        [Test(Description = "TC002_2_Successful_Login")]
        public void SuccessfulLogin()
        {
            var page = new SampleAppPage(DriverManager.Driver);
            page.Login("abc", "pwd");
            Assert.That(page.GetMessage(), Does.Contain("Welcome"));
        }

        [Test(Description = "TC002_3_Unsuccessful_Login")]
        public void UnsuccessfulLogin()
        {
            var page = new SampleAppPage(DriverManager.Driver);
            page.Login("abc", "wrong");
            Assert.That(page.GetMessage(), Does.Contain("Invalid"));
        }

        [TearDown]
        public void TearDown() => DriverManager.CloseBrowser();
    }
}
