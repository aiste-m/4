using AutoTestavimas4.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _page = new DropdownDemoPage(driver);
        }

        [TestCase("Friday", TestName = "Testing with Friday")]
        public static void TestSelectFromDropDownByValue(string dayOfWeek)
        {
            _page.SelectFromDropDownByValue(dayOfWeek).CheckResultText(dayOfWeek);
        }

        [TestCase("Friday", TestName = "Testing with Friday")]
        public static void TestSelectFromDropDownByText(string dayOfWeek)
        {
            _page.SelectFromDropDownByText(dayOfWeek).CheckResultText(dayOfWeek);
        }

        [TestCase("Texas", TestName = "Testing with Texas")]
        public static void TestSelectFromMultipleDropDownByText(string state)
        {
            _page.SelectFromMultipleDropDownByText(state).ClickFirstSelectedButton().CheckStateResultText(state);
        }



        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        //base class check one time tear down

    }
}
