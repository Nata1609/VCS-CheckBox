using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotestai.Page
{
    public class CheckboxDemoPage
    {
        private static IWebDriver _driver;

        private IWebElement firstCheckbox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement text => _driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> multipleCheckboxList => _driver.FindElements(By.CssSelector(".cb1-element"));
        private string checkButton => _driver.FindElement(By.Id("check1")).GetAttribute("value");
        private string checkButton2 => _driver.FindElement(By.Id("check1")).GetAttribute("value");


        public CheckboxDemoPage(IWebDriver webdriver) => _driver = webdriver;

        public void ClickOnThisCheckbox()
        {
            firstCheckbox.Click();
        }

        public void CheckResultIfSuccess()
        {
           Assert.IsTrue(text.Text.Equals("Success - Check box is checked"));
        }

        public void CheckIfClickOnThisCheckboxNotSelected()
        {
            if (firstCheckbox.Selected)
             ClickOnThisCheckbox(); 
        }

        public void ClickOnAllMultipleCheckboxes()
        {
            foreach (IWebElement element in multipleCheckboxList)
            {
                element.Click();

            }
        }

        public void CheckResultIfUncheckAllButtonsAppear(string text)
        {
            Assert.That(checkButton, Is.EqualTo(text));
        }

        public void UnclickOnAllMultipleCheckboxes() 
        {
            ClickOnAllMultipleCheckboxes();
            ClickOnAllMultipleCheckboxes();
        }

        public void CheckResultIfCheckAllButtonAppear(string text)
        {
            Assert.That(checkButton2, Is.EqualTo(text));
        }




    }

}
