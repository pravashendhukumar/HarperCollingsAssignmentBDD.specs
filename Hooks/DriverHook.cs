using HarperCollingsAssignment.specs.CommonUtility;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace HarperCollingsAssignment.specs.Hooks
{
    [Binding]
    public class DriverHook : Base
    {
        [AfterTestRun]
        // This method run after every test run 
        public static void AfterTestRun()
        {
            Driver.Close();
            Driver.Quit();
            
        }
    }
}
