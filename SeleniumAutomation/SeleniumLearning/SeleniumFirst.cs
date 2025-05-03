using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SeleniumFirst 
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        [SetUp]
        public void StartBrowser()
        {
          new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            // driver = new ChromeDriver();
           // driver = new FirefoxDriver();
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
           
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
           String title= driver.Title;
            TestContext.Progress.WriteLine(title);
            TestContext.Progress.WriteLine(driver.Url);
            driver.Close();
           // driver.Quit();

        }
    }
}
