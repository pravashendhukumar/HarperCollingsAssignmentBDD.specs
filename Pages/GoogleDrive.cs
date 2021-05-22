using HarperCollingsAssignment.specs.CommonUtility;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarperCollingsAssignment.specs.Pages
{
    public class GoogleDrive : Base
    {
        public GoogleDrive(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region "Page Elements"

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'container')]//a[contains(@data-action,'go to drive')])[1]")]
        public IWebElement GoToDriveSign { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@aria-label,'Email')]")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button//span[text()='Next']")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement Password { get; set; }

        #endregion
    }
}
