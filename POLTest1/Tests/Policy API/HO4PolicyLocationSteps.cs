using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class FetchByPolicyId
    {
        public string policyid { get; set; }
    }

    public class DeleteByPolicyId
    {
        public int policyid { get; set; }
    }

    public class FetchByLocationId
    {
        public string locationid { get; set; }
    }

    public class DeleteByLocationId
    {
        public int locationid { get; set; }
    }

    public class PostPolicyInformation
    {
        public int policyid { get; set; }
        public int locationid { get; set; }
        public string TransferEffectiveDate { get; set; }

        public bool makeVaccant { get; set; }
        public bool active { get; set; }
    }

    public class PutPolicyInformation
    {
        public int policyid { get; set; }
        public int locationid { get; set; }
        public string TransferEffectiveDate { get; set; }

        public bool makeVaccant { get; set; }
        public bool active { get; set; }
    }

    [Binding]
    public class HO4PolicyLocationSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private List<DeleteByLocationId> deleteByLocationIdList = new List<DeleteByLocationId>();
        private List<DeleteByPolicyId> deleteByPolicyIdList = new List<DeleteByPolicyId>();
        private List<FetchByLocationId> fetchByLocationIdList = new List<FetchByLocationId>();
        private List<FetchByPolicyId> fetchByPolicyIdList = new List<FetchByPolicyId>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostPolicyInformation> postPolicyInformationList = new List<PostPolicyInformation>();
        private List<PutPolicyInformation> putPolicyInformationList = new List<PutPolicyInformation>();
        private string url = "";

        /*Fetch Policy Location by policyid */
        [Given(@"I have entered the policyid to fetch the policy locations")]
        public void GivenIHaveEnteredThePolicyidToFetchThePolicyLocations(Table table)
        {
            fetchByPolicyIdList = table.CreateSet<FetchByPolicyId>().ToList();
        }


        [When(@"I send a Get request to getpolicylocation method")]
        public void WhenISendAGetRequestToGetpolicylocationMethod()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            var _policyid = "";
            for (var i = 1; i < fetchByPolicyIdList.Count(); i++)
            {
                _policyid = fetchByPolicyIdList[i].policyid;
                url = hostUrl + "PolicyLocation/Policy/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The policy location should be fetched successfully")]
        public void ThenThePolicyLocationShouldBeFetchedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }


        /* Delete policy location by policyid */
        [Given(@"I have entered the policyid to delete the policy locations")]
        public void GivenIHaveEnteredThePolicyidToDeleteThePolicyLocations(Table table)
        {
            deleteByPolicyIdList = table.CreateSet<DeleteByPolicyId>().ToList();
        }


        [When(@"I send a Delete request to deletepolicylocation method")]
        public void WhenISendADeleteRequestToDeletepolicylocationMethod()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            var _policyid = 0;
            for (var i = 0; i < deleteByPolicyIdList.Count(); i++)
            {
                _policyid = deleteByPolicyIdList[i].policyid;
                url = hostUrl + "PolicyLocation/Policy/" + _policyid;
                jsonResponse =
                    doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }


        [Then(@"The policy location should be deleted successfully")]
        public void ThenThePolicyLocationShouldBeDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        /* Fetch Policy by locationid */

        [Given(@"I have entered the locationid to fetch the policy locations")]
        public void GivenIHaveEnteredTheLocationidToFetchThePolicyLocations(Table table)
        {
            fetchByLocationIdList = table.CreateSet<FetchByLocationId>().ToList();
        }

        [When(@"I send a Get request with the locationid to fetch policies")]
        public void WhenISendAGetRequestWithTheLocationidToFetchPolicies()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            var _locationid = "";
            for (var i = 0; i < fetchByLocationIdList.Count(); i++)
            {
                _locationid = fetchByLocationIdList[i].locationid;
                url = hostUrl + "PolicyLocation/Location/" + _locationid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The policies should be fetched successfully")]
        public void ThenThePoliciesShouldBeFetchedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }
        /* Delete Policy by locationid */

        [Given(@"I have entered the locationid to delete the policy locations")]
        public void GivenIHaveEnteredTheLocationidToDeleteThePolicyLocations(Table table)
        {
            deleteByLocationIdList = table.CreateSet<DeleteByLocationId>().ToList();
        }

        [When(@"I send a Delete request with the locationid to delete policies")]
        public void WhenISendADeleteRequestWithTheLocationidToDeletePolicies()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            var _locationid = 0;

            for (var i = 0; i < deleteByLocationIdList.Count(); i++)
            {
                _locationid = deleteByLocationIdList[i].locationid;
                url = hostUrl + "PolicyLocation/Location/" + _locationid;
                jsonResponse =
                    doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The policies should be deleted successfully")]
        public void ThenThePoliciesShouldBeDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        /* Post Policy Information */
        [Given(@"I have entered the Policy Location information")]
        public void GivenIHaveEnteredThePolicyLocationInformation(Table table)
        {
            postPolicyInformationList = table.CreateSet<PostPolicyInformation>().ToList();
        }

        [When(@"I send a Post request to insert the policy location information")]
        public void WhenISendAPostRequestToInsertThePolicyLocationInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "PolicyLocation";
            for (var i = 0; i < postPolicyInformationList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postPolicyInformationList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The policy location information should be inserted successfully")]
        public void ThenThePolicyLocationInformationShouldBeInsertedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        /* Put Policy Information */
        [Given(@"I have provided the Policy Location information")]
        public void GivenIHaveProvidedThePolicyLocationInformation(Table table)
        {
            putPolicyInformationList = table.CreateSet<PutPolicyInformation>().ToList();
        }

        [When(@"I send a Put request to insert or update the policy location information")]
        public void WhenISendAPutRequestToInsertOrUpdateThePolicyLocationInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "PolicyLocation";
            for (var i = 0; i < putPolicyInformationList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putPolicyInformationList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The policy location information should be updated successfully")]
        public void ThenThePolicyLocationInformationShouldBeUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}