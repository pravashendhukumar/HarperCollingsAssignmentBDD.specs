using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace HarperCollingsAssignment.specs.CommonUtility
{
    // This is the helper class that will provide an instance of WebDriver and perform clean up activity at the end
    [Binding]
    public class Base
    {
        private static IWebDriver driver;

        
        public static IWebDriver Driver
        {
            get
            {
                return driver ?? (driver = new ChromeDriver(@"C:\Users\prava\source\repos\HarperCollingsAssignment.specs\Drivers"));
            }
        }
        //Method for url navigation
        public static void GoToUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}
