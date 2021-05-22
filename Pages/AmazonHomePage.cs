using System;
using System.Collections.Generic;
using HarperCollingsAssignment.specs.CommonUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;


// This is a Pageobject pattern file for Amazon home Page

namespace HarperCollingsAssignment.specs.Pages
{
    public class AmazonHomePage : Base
    {

        public AmazonHomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region "Page Elements"


        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'card-lite')]//span[contains(text(),'You are on amazon.com')]")]
        public IWebElement HomePageTitleForAssert { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@aria-label='Choose a language for shopping.']")]
        public IWebElement HeaderSectionLanguageSelector { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a//span[text()='Português - PT'])[1]")]
        public IWebElement portugeseLangSelectionForShoping { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Click here to shop in English']")]
        public IWebElement changeBackToEnglishLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'radio')]//input//following::span[contains(text(),'English')]")]
        public IWebElement ReselectionToEnglish { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='a-button-inner']//span[text()='Save Changes']")]
        public IWebElement LanguageSelectionSaveChangeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#twotabsearchtextbox")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2//a[@class='a-link-normal a-text-normal']")]
        public IList<IWebElement> ResultsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#nav-cart-count")]
        public IWebElement CartCount { get; set; }
        #endregion

        #region "Page methods"
        // Methods for change shopping language
        public void ChangeShoopingLanguage()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(HeaderSectionLanguageSelector).Perform();
            Console.Write("Done Mouse hover on Choose Language Icon");
            //Mouse hover to portuguese Language selection
            actions.MoveToElement(portugeseLangSelectionForShoping).Click().Build().Perform();
        }
        //Method for rechange the language to English
        public void RechangeLanguageToEnglish()
        {

            changeBackToEnglishLink.Click();
            Actions actions = new Actions(Driver);
            actions.MoveToElement(ReselectionToEnglish).Click().Build().Perform();
            actions.MoveToElement(LanguageSelectionSaveChangeButton).Click().Build().Perform();
        }
        public Boolean AssertLandedInHomePage(String homePageTitle)
        {
            if (HomePageTitleForAssert.Text.Equals(homePageTitle))
            {
                return true;
            }

            return false;
        }

        public Boolean AssertChangeLanguage(String ChangeLangText)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            if (changeBackToEnglishLink.Text.Equals(ChangeLangText))
            {
                return true;
            }

            return false;
        }

        public void productSearchUsingKeyword(String itemName)
        {
            SearchField.SendKeys(itemName + Keys.Enter);
	    }

        public String getAllTheProductsTitleinPageOne()
        {
            String visibleProdTitle = null;
            foreach (IWebElement getProdTitle in ResultsList)
            {
                {
                    visibleProdTitle = getProdTitle.Text;
                    break;
                }

            }
            return visibleProdTitle;
        }

        public void SelectBookFromList(String ItemName)
        {
            foreach (IWebElement book in ResultsList)
            {
                if (book.Text.Contains(ItemName))
                {
                    book.Click();
                    return;
                }
            }
        }


        #endregion
    }
}

