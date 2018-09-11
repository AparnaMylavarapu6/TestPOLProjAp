using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests
{
    public class LeaseOptInInformation
    {
        public string leaseId { get; set; }
        public string isOptIn { get; set; }
        public string entityType { get; set; }
        public string entityId { get; set; }
    }

    public class LeaseOptInInformationPut
    {
        public string leaseId { get; set; }
        public string isOptIn { get; set; }
        public string entityType { get; set; }
        public string entityId { get; set; }
    }

    [Binding]
    public class LeaseSignOptInSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string entityId = "";
        private string entityType = "";
        private string isOptIn = "";
        private string jsonRequest = "";
        private string jsonResponse = "";
        private string leaseid = "";
        private List<LeaseOptInInformation> leaseOptInList = new List<LeaseOptInInformation>();
        private List<LeaseOptInInformationPut> leaseOptInPut = new List<LeaseOptInInformationPut>();


        [Given(@"I have entered the lease and property integration details")]
        public void GivenIHaveEnteredTheLeaseAndPropertyIntegrationDetails(Table table)
        {
            var leaseOptInInfo = table.CreateSet<LeaseOptInInformation>();
            leaseOptInList = leaseOptInInfo.ToList();
        }

        [When(@"I send a valid POST request")]
        public void WhenISendAValidPOSTRequest()
        {
            init();
            var url = hostUrl + "/ri-pmsintegrationapi/1.0.0/LeaseSignOptIn";
            for (var i = 0; i < leaseOptInList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(leaseOptInList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid response should be generated\.")]
        public void ThenAValidResponseShouldBeGenerated_()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Given(@"I have entered the lease and property integration details for PUT Request")]
        public void GivenIHaveEnteredTheLeaseAndPropertyIntegrationDetailsForPUTRequest(Table table)
        {
            var leaseOptInInfoPut = table.CreateSet<LeaseOptInInformationPut>();
            leaseOptInPut = leaseOptInInfoPut.ToList();
        }

        [When(@"I send a valid PUT request")]
        public void WhenISendAValidPUTRequest()
        {
            init();
            var url = hostUrl + "/ri-pmsintegrationapi/1.0.0/LeaseSignOptIn";
            for (var i = 0; i < leaseOptInPut.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(leaseOptInPut[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }
    }
}