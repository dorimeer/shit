using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab3
{
    public class Tests
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            
        }

        [Test]
        public void TestCase1_Id()
        {
            _webDriver.Navigate().GoToUrl(@"https://gitlab.com/users/sign_up");
            _webDriver.Manage()
                .Window.Maximize();
            var form = _webDriver.FindElement(By.Id("new_new_user"));
            form.FindElement(By.Id("new_user_first_name")).SendKeys("lol");
            form.FindElement(By.Id("new_user_last_name")).SendKeys("chel");
            form.FindElement(By.Id("new_user_username")).SendKeys("lolchel");
            form.FindElement(By.Id("new_user_email")).SendKeys("lolchel@lolchel.com");
            form.FindElement(By.Id("new_user_password")).SendKeys("Lolche123654");
            // form.FindElement(By.ClassName("recaptcha-checkbox-border")).Click();
            form.FindElement(By.Name("commit")).Click();
            Thread.Sleep(500);
        }
        [Test]
        public void TestCase2_Name()
        {
            _webDriver.Navigate().GoToUrl(@"https://lichess.org/login?referrer=/");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.Name("username")).SendKeys("lolchel");
            _webDriver.FindElement(By.Name("password")).SendKeys("lolchel123654");
            _webDriver.FindElement(By.CssSelector("#main-wrap > main > form > div.one-factor > button")).Click();
            Thread.Sleep(500);
        }
        [Test]
        public void TestCase3_Link()
        {
            Assert.True(true);
        }
        [Test]
        public void TestCase4_XPath()
        {
            _webDriver.Navigate().GoToUrl(@"https://lichess.org/");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.XPath("//*[@id=\"main-wrap\"]/main/div[1]/div[2]/a[1]")).Click();
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                By.XPath("//*[@id=\"modal-wrap\"]/div/form/div[3]/button[2]")));
            _webDriver.FindElement(By.XPath("//*[@id=\"modal-wrap\"]/div/form/div[3]/button[2]")).Click();
        }
        [Test]
        public void TestCase5_Css()
        {
            _webDriver.Navigate().GoToUrl(@"https://lichess.org/");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.CssSelector("#topnav > section:nth-child(2) > a")).Click();
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                By.CssSelector("#main-wrap > main > div.puzzle__tools > div.puzzle__feedback.play > div.view_solution.show > a")));
            _webDriver.FindElement(By.CssSelector("#main-wrap > main > div.puzzle__tools > div.puzzle__feedback.play > div.view_solution.show > a")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            //_webDriver.Dispose();
        }
    }
}