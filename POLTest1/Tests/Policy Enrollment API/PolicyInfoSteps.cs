using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_Enrollment_API
{
    public class PolicyDetails
    {
        public string externalResidentID { get; set; }
        public string unitType { get; set; }
        public string unitID { get; set; }
    }

    [Binding]
    public class PolicyInfoSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string jsonRequest = "";
        private string jsonResponse = "";

        private List<PolicyDetails> policydetailslist = new List<PolicyDetails>();

        [Given(@"I have entered the unit information to fetch the policy details")]
        public void GivenIHaveEnteredTheUnitInformationToFetchThePolicyDetails(Table table)
        {
            var policydetailsinfo = table.CreateSet<PolicyDetails>();
            policydetailslist = policydetailsinfo.ToList();
        }

        [When(@"I send a Post request to fetch the policy details")]
        public void WhenISendAPostRequestToFetchThePolicyDetails()
        {
            init();
            var url = hostUrl + "/ri-policyenrollmentapi/1.0.0/GetPolicyDetails";
            for (var i = 0; i < policydetailslist.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(policydetailslist[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The Policy details should be displayed")]
        public void ThenThePolicyDetailsShouldBeDisplayed()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}