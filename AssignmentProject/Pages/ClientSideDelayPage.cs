using OpenQA.Selenium;

namespace CSE2522_Selenium_NUnit.Pages
{
    public class ClientSideDelayPage
    {
        IWebDriver driver;

        public ClientSideDelayPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TriggerButton => driver.FindElement(By.Id("ajaxButton"));
        public IWebElement ResultText => driver.FindElement(By.Id("content"));

        public void ClickButton() => TriggerButton.Click();
        public string GetResult() => ResultText.Text;
    }
}
