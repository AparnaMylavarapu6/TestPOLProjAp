using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_Enrollment_API
{
    public class ThirdPartyPolicyInfo
    {
        public string policyNumber { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
        public string carrierName { get; set; }
        public string liabilityAmount { get; set; }
        public string docData { get; set; }
    }

    [Binding]
    public class ThirdPartyPolicySteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<ThirdPartyPolicyInfo> thirdpartyList = new List<ThirdPartyPolicyInfo>();
        private string url = "";


        [Given(@"I have entered the policy information")]
        public void GivenIHaveEnteredThePolicyInformation(Table table)
        {
            var thirdpartyinfo = table.CreateSet<ThirdPartyPolicyInfo>();
            thirdpartyList = thirdpartyinfo.ToList();
        }

        [When(@"I send a Post Request to post the policy doc data")]
        public void WhenISendAPostRequestToPostThePolicyDocData()
        {
            init();
            url = hostUrl + "/ri-policyenrollmentapi/1.0.0/PolicyUpload";
            for (var i = 0; i < thirdpartyList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(thirdpartyList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid policy upload response should be generated")]
        public void ThenAValidPolicyUploadResponseShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}