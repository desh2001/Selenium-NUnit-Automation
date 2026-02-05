using OpenQA.Selenium;

namespace CSE2522_Selenium_NUnit.Pages
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToTextInput() => driver.FindElement(By.LinkText("Text Input")).Click();
        public void GoToSampleApp() => driver.FindElement(By.LinkText("Sample App")).Click();
        public void GoToClientSideDelay() => driver.FindElement(By.LinkText("Client Side Delay")).Click();
        public void GoToAlerts() => driver.FindElement(By.LinkText("Alerts")).Click();
    }
}
