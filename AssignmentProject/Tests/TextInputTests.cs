using NUnit.Framework;
using CSE2522_Selenium_NUnit.Pages;
using CSE2522_Selenium_NUnit.Utilities;

namespace CSE2522_Selenium_NUnit.Tests
{
    [TestFixture]
    public class TextInputTests
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.StartBrowser();
            DriverManager.Driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            new HomePage(DriverManager.Driver).GoToTextInput();
        }

        [Test(Description = "TC001_1_Text_Input_Verification")]
        public void VerifyTextInput()
        {
            var page = new TextInputPage(DriverManager.Driver);
            page.EnterText("Hello CSE2522");
            page.ClickButton();

            Assert.That(page.GetButtonText(), Is.EqualTo("Hello CSE2522"));
        }

        [TearDown]
        public void TearDown() => DriverManager.CloseBrowser();
    }
}
