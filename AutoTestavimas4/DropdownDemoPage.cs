using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTestavimas4.Page
{
    public class DropdownDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";  
        private SelectElement _stateMultipleDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _multipleResult => Driver.FindElement(By.ClassName("getall-selected"));
        private IWebElement _firstResultButton => Driver.FindElement(By.Id("printMe"));         
        private IWebElement _allResultsButton => Driver.FindElement(By.Id("printAll"));
       
        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
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

        public DropdownDemoPage CheckStateResultText(string state)
        {          
            string fullText = "First selected option is : " + state;
            Assert.AreEqual(fullText, _multipleResult.Text, $"Tekstai nesutampa, nerodo {state}");          
            return this;
        }   
       
        //1) Pažymime 3 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.

        public DropdownDemoPage SelectThreeStatesFromMultipleDropDownByText(string state1, string state2, string state3)
        {
            Actions actionBuider = new Actions(Driver);
            IAction selectThreeItems = actionBuider.KeyDown(Keys.Control).Click();
            _stateMultipleDropdown.SelectByText(state1);
            _stateMultipleDropdown.SelectByText(state2);
            _stateMultipleDropdown.SelectByText(state3);           
            actionBuider.KeyUp(Keys.Control).Build();
            selectThreeItems.Perform();
            return this;
        }

        //2) Pažymime 4 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
        public DropdownDemoPage SelectFourStatesFromMultipleDropDownByText(string state1, string state2, string state3, string state4)
        {
            Actions actionBuider = new Actions(Driver);
            IAction selectFourItems = actionBuider.KeyDown(Keys.Control).Click();
            _stateMultipleDropdown.SelectByText(state1);
            _stateMultipleDropdown.SelectByText(state2);
            _stateMultipleDropdown.SelectByText(state3);
            _stateMultipleDropdown.SelectByText(state4);            
            actionBuider.KeyUp(Keys.Control).Build();
            selectFourItems.Perform();            
            return this;
        }
    }
}
