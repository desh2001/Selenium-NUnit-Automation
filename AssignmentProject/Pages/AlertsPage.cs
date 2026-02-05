using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CSE2522_Selenium_NUnit.Pages
{
    public class AlertsPage
    {
        private readonly IWebDriver driver;

        public AlertsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AlertButton => driver.FindElement(By.Id("alertButton"));
        public IWebElement ConfirmButton => driver.FindElement(By.Id("confirmButton"));
        public IWebElement PromptButton => driver.FindElement(By.Id("promptButton"));

        public void ClickAlert() => AlertButton.Click();
        public void ClickConfirm() => ConfirmButton.Click();
        public void ClickPrompt() => PromptButton.Click();

        /// <summary>
        /// Waits until an alert is present and then switches to it
        /// </summary>
        public IAlert WaitForAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.AlertIsPresent());
            return driver.SwitchTo().Alert();
        }
    }
}
