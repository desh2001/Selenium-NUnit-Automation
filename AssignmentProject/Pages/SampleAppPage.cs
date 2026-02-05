using OpenQA.Selenium;

namespace CSE2522_Selenium_NUnit.Pages
{
    public class SampleAppPage
    {
        IWebDriver driver;

        public SampleAppPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            driver.FindElement(By.Name("UserName")).SendKeys(username);
            driver.FindElement(By.Name("Password")).SendKeys(password);
            driver.FindElement(By.Id("login")).Click();
        }

        public string GetMessage()
        {
            return driver.FindElement(By.Id("loginstatus")).Text;
        }
    }
}
