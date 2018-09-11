using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class FetchPolicyResidentByPolicy
    {
        public string policyid { get; set; }
    }

    public class DeletePolicyResidentByPolicy
    {
        public int policyid { get; set; }
    }

    public class FetchPolicyResidentByResident
    {
        public string residentid { get; set; }
    }

    public class DeletePolicyResidentByResident
    {
        public int residentid { get; set; }
    }


    [Binding]
    public class HO4PolicyResidentSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();

        private List<DeletePolicyResidentByPolicy> deletePolicyResidentByPolicyList =
            new List<DeletePolicyResidentByPolicy>();

        private List<DeletePolicyResidentByResident> deletePolicyResidentByResidentList =
            new List<DeletePolicyResidentByResident>();

        private List<FetchPolicyResidentByPolicy> fetchPolicyResidentByPolicyList =
            new List<FetchPolicyResidentByPolicy>();

        private List<FetchPolicyResidentByResident> fetchPolicyResidentByResidentList =
            new List<FetchPolicyResidentByResident>();

        private string jsonRequest = "";

        private string jsonResponse = "";
        private string url = "";

        [Given(@"I have entered the policy id to fetch the policy and resident information")]
        public void GivenIHaveEnteredThePolicyIdToFetchThePolicyAndResidentInformation(Table table)
        {
            fetchPolicyResidentByPolicyList = table.CreateSet<FetchPolicyResidentByPolicy>().ToList();
        }

        [Given(@"I have entered the policy id to delete the policy and resident information")]
        public void GivenIHaveEnteredThePolicyIdToDeleteThePolicyAndResidentInformation(Table table)
        {
            deletePolicyResidentByPolicyList = table.CreateSet<DeletePolicyResidentByPolicy>().ToList();
        }

        [Given(@"I have entered the resident id to fetch the policy and resident information")]
        public void GivenIHaveEnteredTheResidentIdToFetchThePolicyAndResidentInformation(Table table)
        {
            fetchPolicyResidentByResidentList = table.CreateSet<FetchPolicyResidentByResident>().ToList();
        }

        [Given(@"I have entered the residentid id to delete the policy and resident information")]
        public void GivenIHaveEnteredTheResidentidIdToDeleteThePolicyAndResidentInformation(Table table)
        {
            deletePolicyResidentByResidentList = table.CreateSet<DeletePolicyResidentByResident>().ToList();
        }

        [When(@"I send a Get request to fetch the policy and resident information")]
        public void WhenISendAGetRequestToFetchThePolicyAndResidentInformation()
        {
            var _policyid = "";
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < fetchPolicyResidentByPolicyList.Count; i++)
            {
                _policyid = fetchPolicyResidentByPolicyList[i].policyid;
                url = hostUrl + "PolicyResident/Policy/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the policy and resident information")]
        public void WhenISendADeleteRequestToDeleteThePolicyAndResidentInformation()
        {
            var _policyid = 0;
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < deletePolicyResidentByPolicyList.Count; i++)
            {
                _policyid = deletePolicyResidentByPolicyList[i].policyid;
                url = hostUrl + "PolicyResident/Policy/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request to fetch the policy and resident information by residentid")]
        public void WhenISendAGetRequestToFetchThePolicyAndResidentInformationByResidentid()
        {
            var _residentid = "";
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < fetchPolicyResidentByResidentList.Count; i++)
            {
                _residentid = fetchPolicyResidentByResidentList[i].residentid;
                url = hostUrl + "PolicyResident/Resident/" + _residentid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the policy and resident information by residentid")]
        public void WhenISendADeleteRequestToDeleteThePolicyAndResidentInformationByResidentid()
        {
            var _residentid = 0;
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < deletePolicyResidentByResidentList.Count; i++)
            {
                _residentid = deletePolicyResidentByResidentList[i].residentid;
                url = hostUrl + "PolicyResident/Resident/" + _residentid;
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A successful response code should be generated with the policy and resident information")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithThePolicyAndResidentInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A successful response code should be generated with the delete operation being successful")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheDeleteOperationBeingSuccessful()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}