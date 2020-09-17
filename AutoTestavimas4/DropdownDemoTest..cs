using AutoTestavimas4.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestavimas4
{
    class DropdownDemoTest
    {

        private static DropdownDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            _page = new DropdownDemoPage(driver);
        }       

        //1) Pažymime 3 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.

        [TestCase("Texas", "Florida", "Ohio", "Texas", TestName = "Testing with 3 states")]
       
        public static void TestSelectThreeStatesFromMultipleDropDownByText(string state1, string state2, string state3, string state)
        {           
            _page.SelectThreeStatesFromMultipleDropDownByText(state1, state2, state3).ClickFirstSelectedButton().CheckStateResultText(state);
        }

        //2) Pažymime 4 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.

        [TestCase("Texas", "Florida", "Ohio", "New York", "Options selected are : Texas,Florida,Ohio,New York", TestName = "Testing with 4 states")]
        public static void TestSelectFourStatesFromMultipleDropDownByText(string state1, string state2, string state3, string state4, string state)
        {
            _page.SelectFourStatesFromMultipleDropDownByText(state1, state2, state3, state4);                  
            _page.ClickAllSelectedButton();
            _page.CheckStateResultText(state);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }     

    }
}
