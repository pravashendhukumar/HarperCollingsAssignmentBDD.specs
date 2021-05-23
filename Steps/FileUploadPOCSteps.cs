using HarperCollingsAssignment.specs.CommonUtility;
using HarperCollingsAssignment.specs.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace HarperCollingsAssignment.specs.Steps
{
    [Binding]
    public class FileUploadPOCSteps : Base
    {
        #region "Object creation & instantiation"
        GoogleImage _gImagePage = new GoogleImage(Base.Driver);
        AmazonPOCSteps _amazonPOCSteps = new AmazonPOCSteps();
        #endregion

        #region "Gherkins phrases"

        //Phrases for navigation of Google Image page
        [Given(@"I naviagte to the Google Image upload page")]
        public void GivenINaviagteToTheGoogleDriveSignPage()
        {
            Driver.Manage().Window.Maximize();
            Base.GoToUrl("https://www.google.com/imghp?hl=EN");
            _amazonPOCSteps.WaitUntilPageOrElementLoad();
        }

        //Phrases for File upload
        [When(@"I upload a file ""(.*)""")]
        public void WhenIUploadAFile(String fileName)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            //Return path of Base Directory
            String FolderPath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(FolderPath);
            Console.WriteLine("file path is--->" + FolderPath + @"\" + "TestFiles\\" + fileName);
            _gImagePage.ImageUploadIcon.Click();
            _amazonPOCSteps.WaitUntilPageOrElementLoad();
            _gImagePage.ImageUploadSection.Click();
            _gImagePage.UploadButton.SendKeys(@FolderPath + @"\" + "TestFiles\\" + fileName);

        }

        [Then(@"I shoud be on GoogleImage upload page")]
        public void ThenIShoudBeOnGoogleDriveHomepage()
        {
            Assert.IsTrue(Driver.Title.Contains("Google Images"));
        }

        [Then(@"Image should be uploaded")]
        public void ThenFileShouldBeUploaded()
        {
            Assert.IsTrue(_gImagePage.UploadSuccess.Displayed);
        }
        #endregion

    }
}
