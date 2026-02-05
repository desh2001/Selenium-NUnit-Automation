using System.Text.RegularExpressions;
using CSE2522_Selenium_NUnit.Pages;
using CSE2522_Selenium_NUnit.Utilities;
using NUnit.Framework;

namespace CSE2522_Selenium_NUnit.Tests
{
    [TestFixture]
    public class AlertsTests
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.StartBrowser();
            DriverManager.Driver!.Navigate().GoToUrl("https://uitestingplayground.com/");
            new HomePage(DriverManager.Driver!).GoToAlerts();
        }

        [TestCase(TestName = "TC004_1_Alerts_Page_Verification")]
        public void VerifyAlertsPage()
        {
            var page = new AlertsPage(DriverManager.Driver!);

            Assert.Multiple(() =>
            {
                Assert.That(page.AlertButton.Displayed, Is.True);
                Assert.That(page.ConfirmButton.Displayed, Is.True);
                Assert.That(page.PromptButton.Displayed, Is.True);
            });
        }

        [TestCase(TestName = "TC004_2_Alert_Text_Verification")]
        public void VerifyAlertText()
        {
            var page = new AlertsPage(DriverManager.Driver!);
            page.ClickAlert();

            var alert = page.WaitForAlert();
            var actualText = alert.Text ?? string.Empty;

            var normalized = Regex.Replace(actualText.Replace("\r\n", " ").Replace("\n", " "), @"\s+", " ").Trim();
            var normalizedNoPunct = Regex.Replace(normalized, @"[\p{P}]", "").ToLowerInvariant();
            var expectedNormalized = "today is a working day or less likely a holiday";

            Assert.That(normalizedNoPunct, Is.EqualTo(expectedNormalized));
            alert.Accept();
        }

        [TestCase(TestName = "TC004_3_Confirm_Accept")]
        public void ConfirmAccept()
        {
            var page = new AlertsPage(DriverManager.Driver!);
            page.ClickConfirm();

            var alert = page.WaitForAlert();
            alert.Accept();

            var result = page.WaitForAlert();
            Assert.That(result.Text, Is.EqualTo("Yes"));
            result.Accept();
        }

        [TestCase(TestName = "TC004_3_Confirm_Decline")]
        public void ConfirmDecline()
        {
            var page = new AlertsPage(DriverManager.Driver!);
            page.ClickConfirm();

            var alert = page.WaitForAlert();
            alert.Dismiss();

            var result = page.WaitForAlert();
            Assert.That(result.Text, Is.EqualTo("No"));
            result.Accept();
        }

        [TestCase(TestName = "TC004_4_Prompt_Accept")]
        public void PromptAccept()
        {
            var page = new AlertsPage(DriverManager.Driver!);
            page.ClickPrompt();

            var alert = page.WaitForAlert();
            alert.SendKeys("CSE2522");
            alert.Accept();

            var result = page.WaitForAlert();
            var actualText = result.Text ?? string.Empty;
            var normalized = Regex.Replace(actualText.Replace("\r\n", " ").Replace("\n", " "), @"\s+", " ").Trim();
            var normalizedNoPunct = Regex.Replace(normalized, @"[\p{P}]", "").ToLowerInvariant();
            var expectedNormalized = "user value cse2522";

            Assert.That(normalizedNoPunct, Is.EqualTo(expectedNormalized));
            result.Accept();
        }

        [TestCase(TestName = "TC004_4_Prompt_Decline")]
        public void PromptDecline()
        {
            var page = new AlertsPage(DriverManager.Driver!);
            page.ClickPrompt();

            var alert = page.WaitForAlert();
            alert.Dismiss();

            var result = page.WaitForAlert();
            var actualText = result.Text ?? string.Empty;
            var normalized = Regex.Replace(actualText.Replace("\r\n", " ").Replace("\n", " "), @"\s+", " ").Trim();
            var normalizedNoPunct = Regex.Replace(normalized, @"[\p{P}]", "").ToLowerInvariant();
            var expectedNormalized = "user value no answer";

            Assert.That(normalizedNoPunct, Is.EqualTo(expectedNormalized));
            result.Accept();
        }

        [TearDown]
        public void TearDown()
        {
            DriverManager.CloseBrowser();
        }
    }
}
