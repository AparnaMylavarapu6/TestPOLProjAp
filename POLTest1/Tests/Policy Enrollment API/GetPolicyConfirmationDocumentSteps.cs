using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_Enrollment_API
{
    public class ResidentIDList
    {
        public string residentid { get; set; }
    }

    [Binding]
    public class GetPolicyConfirmationDocumentSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<ResidentIDList> residentIdList = new List<ResidentIDList>();

        [Given(@"I have provided the residentid to get policy confirmation document")]
        public void GivenIHaveProvidedTheResidentidToGetPolicyConfirmationDocument(Table table)
        {
            var residentIdInfo = table.CreateSet<ResidentIDList>();
            residentIdList = residentIdInfo.ToList();
        }

        [When(@"I send a Post  request to fetch the confirmation document")]
        public void WhenISendAPostRequestToFetchTheConfirmationDocument()
        {
            init();
            var url = "";
            var _residentid = "";
            for (var i = 0; i < residentIdList.Count(); i++)
            {
                _residentid = residentIdList[i].residentid;
                url = hostUrl + "/ri-policyenrollmentapi/1.0.0/GetPolicyConfirmationDocument/" + _residentid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid policy confirmation document response should be generated")]
        public void ThenAValidPolicyConfirmationDocumentResponseShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}