using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@id='terms']")).Click();
            // driver.FindElement(By.Name("signin")).Click();

            //CSS selectors and XPath
            // driver.FindElement(By.CssSelector("input[type='submit']")).Click();
           // driver.FindElement(By.XPath("//input[@id='terms']")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            
            //Explicit wait concept
            WebDriverWait wait= new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")),"Sign In"));

            string errromsg = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errromsg); 
            
           IWebElement link= driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
           String hrefattribute= link.GetAttribute("href");
            String expectedurl = "https://rahulshettyacademy.com/documents-request";
            //validate url of the linktext
            Assert.AreEqual(expectedurl, hrefattribute);
        }
    }
}
