using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTest
{
    [TestFixture]
    public class SeleniumTest
    {
        IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        { 
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", "C:\\Program Files (x86)\\Mozilla Firefox\\geckodriver.exe");
            _driver = new FirefoxDriver();
        }
        [Test]
        public void LoginFailed()
        {
            var loginText = "egfhdhjfc@com.pl";
            var passwordText = "Hasdghelo234";
            _driver.Navigate().GoToUrl("http://localhost:9751/Account/Login");
            var searchLoginBox = _driver.FindElement(By.Id("Email"));
            searchLoginBox.SendKeys(loginText);
            var searchPasswordBox = _driver.FindElement(By.Id("Password"));
            searchPasswordBox.SendKeys(passwordText + Keys.Enter);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Id("loginErrorContent"))));

            //StringAssert.StartsWith("Invalid login attemt.",
            //    _driver.FindElement(By.Id("loginErrorContent")).Text);

            StringAssert.StartsWith("Invalid login attemt.",
                _driver.FindElement(By.ClassName("validation-summary-errors text-danger")).Text);

        }
        
    }

}

