using HarperCollingsAssignment.specs.CommonUtility;
using HarperCollingsAssignment.specs.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace HarperCollingsAssignment.specs.Steps
{
    [Binding]
    public class AmazonPOCSteps : Base
    {
        #region "Object creation & instantiation"
        ProductDetailsPage _productDetailsPage = new ProductDetailsPage(Base.Driver);
        AmazonHomePage _homePage = new AmazonHomePage(Base.Driver);
        #endregion



        [Given(@"I am navigating to amazon hoomepage")]
        public void GivenIAmOnAmazonHomePage()
        {
            Driver.Manage().Window.Maximize();
            Base.GoToUrl("https://www.amazon.com/");
        }

        [Given(@"I should be on amazon homepage")]
        [Then(@"I should be on amazon homepage")]
        public void ThenIShouldLandingAnAmazonHomepage()
        {
            string title = "You are on amazon.com. You can also shop on Amazon India for millions of products with fast local delivery.";
            Assert.IsTrue(_homePage.AssertLandedInHomePage(title));
        }

        [When(@"I change my shoping language as per my native language")]
        public void ChangeShopingLang()
        {
            _homePage.ChangeShoopingLanguage();
        }

        [Then(@"I am able to see my shoping language as per choosen language")]
        public void AssertChoosenLang()
        {
            String GetActualChangeLangText = "Click here to shop in English";
            Assert.IsTrue(_homePage.AssertChangeLanguage(GetActualChangeLangText));

        }
        [When(@"I again rechange my shoping language to English")]
        public void RechangeLangToEnglish()
        {
            _homePage.RechangeLanguageToEnglish();
        }

        [When(@"I waits until the page or element loads")]
        public void WaitUntilPageOrElementLoad()
        {
            //Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [When(@"I enter ""(.*)"" into the search field and hit enter")]
        public void WhenIEnterTextIntoTheSearchField(string itemName)
        {
            _homePage.productSearchUsingKeyword(itemName);
        }

        [Then(@"I should see my searched item ""(.*)"" in the results list")]
        public void ThenIShouldSeeMyItemInTheResultsList(string itemName)
        {
            Console.WriteLine(_homePage.getAllTheProductsTitleinPageOne());
            Assert.IsTrue(_homePage.getAllTheProductsTitleinPageOne().ToLower().Contains(itemName.ToLower()));
        }

        [Given(@"I have nothing in my basket, it displays a total of ""(.*)""")]
        public void GivenIHaveNothingInMyBasketItDisplaysATotalOf(String cartCount)
        {

            Assert.AreEqual(cartCount, _productDetailsPage.CartCount.Text);
        }

        [When(@"I search for a ""(.*)"" in Amazon")]
        public void WhenISearchForAInAmazon(string bookName)
        {
            _homePage.SearchField.SendKeys(bookName);
            _homePage.SearchField.Submit();
            _homePage.SelectBookFromList(bookName);
        }

        [When(@"I see the details page of the ""(.*)""")]
        public void WhenISeeTheDetailsPageOfThe(string bookTitle)
        {
            Assert.IsTrue(_productDetailsPage.BookTitle.Text.ToLower().Contains(bookTitle.ToLower()));
            //Assert.AreEqual(bookTitle, _productDetailsPage.BookTitle.Text);
        }

        [When(@"I should see the book is ""(.*)""")]
        public void WhenIShouldSeeTheBookIs(String inStock)
        {
            Assert.AreEqual(inStock.ToLower(), _productDetailsPage.InStockMessage.Text.ToLower());
        }

        [When(@"I add the book to the basket")]
        public void WhenIAddTheBookToTheBasket()
        {
            _productDetailsPage.AddToBasketButton.Click();
        }

        [Then(@"my basket should dispaly a total of ""(.*)""")]
        public void ThenMyBasketShouldDispalyATotalOf(String cartCount)
        {
            Assert.AreEqual(cartCount, _productDetailsPage.CartCount.Text);
        }
    }
}
