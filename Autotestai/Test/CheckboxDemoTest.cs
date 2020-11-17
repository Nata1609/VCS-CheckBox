using Autotestai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotestai.Test
{
    public class CheckboxDemoTest
    {

        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();

        }

        [Test]
        public void CheckboxTestFirstBlock()
        {
            CheckboxDemoPage page = new CheckboxDemoPage(_driver);

            page.ClickOnThisCheckbox();
            page.CheckResultIfSuccess();

        }

        [TestCase("Uncheck All")]
        [TestCase("Check All")]

        public void MultipleCheckboxTest(string msg)
        {
            CheckboxDemoPage page = new CheckboxDemoPage(webdriver: _driver);

            page.CheckIfClickOnThisCheckboxNotSelected();
            page.ClickOnAllMultipleCheckboxes();
            page.CheckResultIfUncheckAllButtonsAppear(msg);
            page.UnclickOnAllMultipleCheckboxes();
            page.CheckResultIfCheckAllButtonAppear(msg);


        }



    }
}
