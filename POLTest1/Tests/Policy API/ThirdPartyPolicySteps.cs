using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class PostThirdPartyPolicyInformation
    {
        public int policyid { get; set; }
        public int policystatus { get; set; }
        public string policynumber { get; set; }
        public int policysource { get; set; }
        public string effectivedate { get; set; }
        public string expirydate { get; set; }
        public int createdbyid { get; set; }
        public int modifiedby { get; set; }
        public double liabilitylimit { get; set; }
        public int carrierid { get; set; }
        public bool isCorporate { get; set; }
    }

    public class PutThirdPartyPolicyInformation
    {
        public int policyid { get; set; }
        public int policystatus { get; set; }
        public string policynumber { get; set; }
        public int policysource { get; set; }
        public string effectivedate { get; set; }
        public string expirydate { get; set; }
        public int createdbyid { get; set; }
        public int modifiedby { get; set; }
        public double liabilitylimit { get; set; }
        public int carrierid { get; set; }
        public bool isCorporate { get; set; }
    }

    public class GetThirdPartyPolicyInformation
    {
        public string policyid { get; set; }
    }

    public class DeleteThirdPartyPolicyInformation
    {
        public string policyid { get; set; }
        public int thirdpartypolicyid { get; set; }
    }

    [Binding]
    public class ThirdPartyPolicySteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string _policyid = "";
        private int _thirdpartypolicyid;

        private List<DeleteThirdPartyPolicyInformation> deleteThirdPartyPolicyList =
            new List<DeleteThirdPartyPolicyInformation>();

        private List<GetThirdPartyPolicyInformation> getThirdPartyPolicyList =
            new List<GetThirdPartyPolicyInformation>();

        private string jsonRequest = "";
        private string jsonResponse = "";

        private List<PostThirdPartyPolicyInformation> postThirdPartyPolicyList =
            new List<PostThirdPartyPolicyInformation>();

        private List<PutThirdPartyPolicyInformation> putThirdPartyPolicyList =
            new List<PutThirdPartyPolicyInformation>();
        
        private string url = "";

        [Given(@"I have entered the ThirdParty policy information")]
        public void GivenIHaveEnteredTheThirdPartyPolicyInformation(Table table)
        {
            postThirdPartyPolicyList = table.CreateSet<PostThirdPartyPolicyInformation>().ToList();
        }

        [Given(@"I have entered the new or updated ThirdParty policy information")]
        public void GivenIHaveEnteredTheNewOrUpdatedThirdPartyPolicyInformation(Table table)
        {
            putThirdPartyPolicyList = table.CreateSet<PutThirdPartyPolicyInformation>().ToList();
        }

        [Given(@"I have provided the policy id as an input to fetch the policy information")]
        public void GivenIHaveProvidedThePolicyIdAsAnInputToFetchThePolicyInformation(Table table)
        {
            getThirdPartyPolicyList = table.CreateSet<GetThirdPartyPolicyInformation>().ToList();
        }

        [Given(@"I have provided the policy id as an input to delete the policy information")]
        public void GivenIHaveProvidedThePolicyIdAsAnInputToDeleteThePolicyInformation(Table table)
        {
            deleteThirdPartyPolicyList = table.CreateSet<DeleteThirdPartyPolicyInformation>().ToList();
        }

        [When(@"I send a Post request with the policy information")]
        public void WhenISendAPostRequestWithThePolicyInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "/ri-policyapi/1.0.0/ThirdParty";
            for (var i = 0; i < postThirdPartyPolicyList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postThirdPartyPolicyList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", token, jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Put request with the policy information")]
        public void WhenISendAPutRequestWithThePolicyInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "/ri-policyapi/1.0.0/ThirdParty";
            for (var i = 0; i < putThirdPartyPolicyList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putThirdPartyPolicyList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", token, jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request with the policy id as input")]
        public void WhenISendAGetRequestWithThePolicyIdAsInput()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < getThirdPartyPolicyList.Count; i++)
            {
                _policyid = getThirdPartyPolicyList[i].policyid;
                url = hostUrl + "ThirdParty/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request with the policy id as input")]
        public void WhenISendADeleteRequestWithThePolicyIdAsInput()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < deleteThirdPartyPolicyList.Count; i++)
            {
                _policyid = deleteThirdPartyPolicyList[i].policyid;
                _thirdpartypolicyid = deleteThirdPartyPolicyList[i].thirdpartypolicyid;
                if (_thirdpartypolicyid != 0)
                    url = hostUrl + "/ri-policyapi/1.0.0/ThirdParty/" + _policyid + "?thirdPartyPolicyId=" +
                          _thirdpartypolicyid;
                else
                    url = hostUrl + "/ri-policyapi/1.0.0/ThirdParty/" + _policyid;

                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid successful response should be generated with the policy information")]
        public void ThenAValidSuccessfulResponseShouldBeGeneratedWithThePolicyInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A valid successful response should be generated with the new or updated policy information")]
        public void ThenAValidSuccessfulResponseShouldBeGeneratedWithTheNewOrUpdatedPolicyInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the third party policy information")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithTheThirdPartyPolicyInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the delete operation being successfully done")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithTheDeleteOperationBeingSuccessfullyDone()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }
    }
}