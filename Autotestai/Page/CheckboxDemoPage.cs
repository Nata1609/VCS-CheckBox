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
                
        private string ButtonUncheckAllValue => _driver.FindElement(By.Id("check1")).GetAttribute("value" );
        private string ButtonCheckAllValue => _driver.FindElement(By.Id("check1")).GetAttribute("value");


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
        public void CheckResultIfButtonsAppear(bool buttonSelected, string buttonValue)
        {
            if (!buttonSelected)
            {
                ClickOnAllMultipleCheckboxes();
                Assert.That(ButtonCheckAllValue, Is.EqualTo(buttonValue));
            }
            else {

                Assert.That(ButtonUncheckAllValue, Is.EqualTo(buttonValue));

            }                       
            
        }


    }

}
