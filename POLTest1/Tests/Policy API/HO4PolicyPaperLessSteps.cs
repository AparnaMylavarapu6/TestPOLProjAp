using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class PostPolicyPaperLess
    {
        public int policyid { get; set; }
        public bool isPaperLess { get; set; }
        public string vendorSentDate { get; set; }
    }

    public class PutPolicyPaperLess
    {
        public int policyid { get; set; }
        public bool isPaperLess { get; set; }
        public string vendorSentDate { get; set; }
    }

    public class GetPolicyPaperLess
    {
        public int policyPaperLessPolicyid { get; set; }
        public string policyid { get; set; }
    }

    public class DeletePolicyPaperLess
    {
        public int policyPaperLessPolicyid { get; set; }
        public string policyid { get; set; }
    }

    [Binding]
    public class HO4PolicyPaperLessSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string _policyid = "";
        private int _policypaperlesspolicyid;
        private List<DeletePolicyPaperLess> deletePolicyPaperLessList = new List<DeletePolicyPaperLess>();
        private List<GetPolicyPaperLess> getPolicyPaperLessList = new List<GetPolicyPaperLess>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostPolicyPaperLess> postPolicyPaperLessList = new List<PostPolicyPaperLess>();
        private List<PutPolicyPaperLess> putPolicyPaperLessList = new List<PutPolicyPaperLess>();
        private string url = "";


        [Given(@"I have entered the policy information for the post paperless operation")]
        public void GivenIHaveEnteredThePolicyInformationForThePostPaperlessOperation(Table table)
        {
            postPolicyPaperLessList = table.CreateSet<PostPolicyPaperLess>().ToList();
        }

        [Given(@"I have entered the policy information for the put paperless operation")]
        public void GivenIHaveEnteredThePolicyInformationForThePutPaperlessOperation(Table table)
        {
            putPolicyPaperLessList = table.CreateSet<PutPolicyPaperLess>().ToList();
        }

        [Given(@"I have provided the policy id as input for fetching the policy paperless information")]
        public void GivenIHaveProvidedThePolicyIdAsInputForFetchingThePolicyPaperlessInformation(Table table)
        {
            getPolicyPaperLessList = table.CreateSet<GetPolicyPaperLess>().ToList();
        }

        [Given(@"I have provided the policy id as input for deleting the policy paperless information")]
        public void GivenIHaveProvidedThePolicyIdAsInputForDeletingThePolicyPaperlessInformation(Table table)
        {
            deletePolicyPaperLessList = table.CreateSet<DeletePolicyPaperLess>().ToList();
        }

        [When(@"I send a Post request with the given inputs to the post paperless method")]
        public void WhenISendAPostRequestWithTheGivenInputsToThePostPaperlessMethod()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "/ri-policyapi/1.0.0/PolicyPaperLess";
            for (var i = 0; i < postPolicyPaperLessList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postPolicyPaperLessList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Put request with the given inputs to the put paperless method")]
        public void WhenISendAPutRequestWithTheGivenInputsToThePutPaperlessMethod()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "/ri-policyapi/1.0.0/PolicyPaperLess";
            for (var i = 0; i < putPolicyPaperLessList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putPolicyPaperLessList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }


        [When(@"I send a Get request to fetch the policy paperless information")]
        public void WhenISendAGetRequestToFetchThePolicyPaperlessInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < getPolicyPaperLessList.Count; i++)
            {
                _policyid = getPolicyPaperLessList[i].policyid;
                _policypaperlesspolicyid = getPolicyPaperLessList[i].policyPaperLessPolicyid;
                if (_policypaperlesspolicyid != 0)
                    url = hostUrl + "PolicyPaperLess/" + _policyid + "?PolicyPaperLessPolicyId=" +
                          _policypaperlesspolicyid;
                else
                    url = hostUrl + "PolicyPaperLess/" + _policyid;

                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the policy paperless information")]
        public void WhenISendADeleteRequestToDeleteThePolicyPaperlessInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < deletePolicyPaperLessList.Count; i++)
            {
                _policyid = deletePolicyPaperLessList[i].policyid;
                _policypaperlesspolicyid = deletePolicyPaperLessList[i].policyPaperLessPolicyid;
                if (_policypaperlesspolicyid != 0)
                    url = hostUrl + "PolicyPaperLess/" + _policyid + "?PolicyPaperLessPolicyId=" +
                          _policypaperlesspolicyid;
                else
                    url = hostUrl + "PolicyPaperLess/" + _policyid;

                jsonResponse =
                    doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A successful response should be generated for the post operation")]
        public void ThenASuccessfulResponseShouldBeGeneratedForThePostOperation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A successful response should be generated for the put operation and the information should be updated or inserted successfully")]
        public void
            ThenASuccessfulResponseShouldBeGeneratedForThePutOperationAndTheInformationShouldBeUpdatedOrInsertedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the policy paperless information")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithThePolicyPaperlessInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated for the delete policy paperless method")]
        public void ThenASuccessfulResponseShouldBeGeneratedForTheDeletePolicyPaperlessMethod()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}