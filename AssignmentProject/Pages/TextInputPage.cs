using OpenQA.Selenium;

namespace CSE2522_Selenium_NUnit.Pages
{
    public class TextInputPage
    {
        IWebDriver driver;

        public TextInputPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TextBox => driver.FindElement(By.Id("newButtonName"));
        public IWebElement Button => driver.FindElement(By.Id("updatingButton"));

        public void EnterText(string text)
        {
            TextBox.Clear();
            TextBox.SendKeys(text);
        }

        public void ClickButton() => Button.Click();
        public string GetButtonText() => Button.Text;
    }
}
