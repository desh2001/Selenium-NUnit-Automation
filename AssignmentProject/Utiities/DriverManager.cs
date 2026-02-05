using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSE2522_Selenium_NUnit.Utilities
{
    public class DriverManager
    {
        public static IWebDriver Driver;

        public static void StartBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
