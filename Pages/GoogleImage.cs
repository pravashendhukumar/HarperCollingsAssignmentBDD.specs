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
    public class GoogleImage : Base
    {
        public GoogleImage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region "Page Elements"

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Search by image']")]
        public IWebElement ImageUploadIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Upload an image')]")]
        public IWebElement ImageUploadSection { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='file']")]
        public IWebElement UploadButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='result-stats' and contains(text(), 'About')]")]
        public IWebElement UploadSuccess { get; set; }

        #endregion
    }
}