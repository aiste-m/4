using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestavimas4.Page
{
    public class DropdownDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

        private SelectElement _dayOfWeekDropdown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private SelectElement _dayOfWeekMultipleDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement _result => Driver.FindElement(By.ClassName("selected-value"));
        private IWebElement _multipleResult => Driver.FindElement(By.ClassName("getall-selected"));
        private IWebElement _firstResultButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _allResultsButton => Driver.FindElement(By.Id("printAll"));

        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropdownDemoPage SelectFromDropDownByText(string text)
        {
            _dayOfWeekDropdown.SelectByText(text);
            return this;
        }

        public DropdownDemoPage SelectFromDropDownByValue(string value)
        {
            _dayOfWeekDropdown.SelectByValue(value);
            return this;
        }

        public DropdownDemoPage SelectFromMultipleDropDownByText(string text)
        {
            _dayOfWeekMultipleDropdown.SelectByText(text);
            return this;
        }

        public DropdownDemoPage SelectFromMultipleDropDownByValue(string value)
        {
            _dayOfWeekMultipleDropdown.SelectByValue(value);
            return this;
        }

        public DropdownDemoPage ClickFirstSelectedButton()
        {
            _firstResultButton.Click();
            return this;
        }

        public DropdownDemoPage ClickAllSelectedButton()
        {
            _allResultsButton.Click();
            return this;
        }

        public DropdownDemoPage CheckResultText(string weekDay)
        {
            string fullText = "Day selected :- " + weekDay;
            Assert.AreEqual(fullText, _result.Text, $"Tekstai nesutampa, nerodo {weekDay}");


            Assert.IsTrue(_result.Text.Contains(weekDay), $"Tekstai nesutampa, nerodo {weekDay}");
            return this;
        }

        public DropdownDemoPage CheckStateResultText(string state)
        {
            string fullText = "First selected option is : " + state;
            Assert.AreEqual(fullText, _multipleResult.Text, $"Tekstai nesutampa, nerodo {state}");


            Assert.IsTrue(_multipleResult.Text.Contains(state), $"Tekstai nesutampa, nerodo {state}");
            return this;
        }
    }
}
