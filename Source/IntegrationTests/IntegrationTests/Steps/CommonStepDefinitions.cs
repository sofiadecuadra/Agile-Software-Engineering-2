using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using IntegrationTests.Models;
using TechTalk.SpecFlow.Assist;

namespace IntegrationTests.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            try
            {
                _scenarioContext.Get<SeleniumTestHelper>();
            }
            catch (Exception)
            {
                _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
            }
        }

        [Given(@"a logged in admin")]
        public void GivenALoggedInAdmin(Table admin)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Login(admin.Rows[0]["Email"], admin.Rows[0]["Password"]);
            _scenarioContext.Set<bool>(true, "loginStatus");
        }

        [Given(@"an existing region")]
        public void GivenAnExistingRegion(Table regionTable)
        {
            string regionId = $"region-{regionTable.Rows[0]["Id"]}";
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/regions");
            helper.WaitForElement(By.Id(regionId));


            Region region = regionTable.CreateInstance<Region>();
            _scenarioContext.Set<Region>(region);
        }

        [Then(@"the error (.*) should be raised")]
        public void ThenTheErrorShouldBeRaised(string error)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            IList<IWebElement> errorMessages = helper.WaitForElements(By.Name("error"));
            bool found = false;
            foreach (IWebElement errorMessage in errorMessages)
            {
                if (errorMessage.Text == error)
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
            //helper.Quit();
        }

        [Then(@"Cleanup")]
        public void ThenCleanup()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            bool loginStatus = false;
            try
            {
                loginStatus = _scenarioContext.Get<bool>("loginStatus");
            }
            catch (Exception)
            {
            }
            helper.DeleteAllChargingSpots(loginStatus);
        }

    }
}