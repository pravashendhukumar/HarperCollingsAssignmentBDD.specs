using HarperCollingsAssignment.specs.CommonUtility;
using HarperCollingsAssignment.specs.Model;
using HarperCollingsAssignment.specs.Pages;
using System;
using TechTalk.SpecFlow;

namespace HarperCollingsAssignment.specs.Steps
{
    [Binding]
    public class FileUploadPOCSteps : Base
    {
        #region "Object creation & instantiation"
        GoogleDrive _gDrivePage = new GoogleDrive(Base.Driver);
        AmazonPOCSteps _amazonPOCSteps = new AmazonPOCSteps();
        #endregion

        [Given(@"I naviagte to the GoogleDrive Sign page")]
        public void GivenINaviagteToTheGoogleDriveSignPage()
        {
            Driver.Manage().Window.Maximize();
            Base.GoToUrl("https://drive.google.com/");
            _amazonPOCSteps.WaitUntilPageOrElementLoad();
            _gDrivePage.GoToDriveSign.Click();
        }
        
        [When(@"I sign in with the below details")]
        public void WhenISignInWithTheBelowDetails(Table table)
        {
            var dictionary = TableExtension.ToDictionary(table);
            var test = dictionary["Username"];

            _gDrivePage.UserName.SendKeys(dictionary["Username"]);
            _gDrivePage.NextButton.Click();
            _amazonPOCSteps.WaitUntilPageOrElementLoad();
            _gDrivePage.Password.SendKeys(dictionary["Password"]);
            _gDrivePage.NextButton.Click();
        }
        
        [When(@"I upload a file")]
        public void WhenIUploadAFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I shoud be on GoogleDrive homepage")]
        public void ThenIShoudBeOnGoogleDriveHomepage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"File should be uploaded")]
        public void ThenFileShouldBeUploaded()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
