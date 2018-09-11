using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class GetPolicy
    {
        public string policyid { get; set; }
    }

    public class DeletePolicy
    {
        public int policyid { get; set; }
    }

    public class PostPolicy
    {
        public int policyId { get; set; }
        public int quoteId { get; set; }
        public string policyNumber { get; set; }
        public int policySource { get; set; }
        public int policyStatus { get; set; }
        public string effectiveDate { get; set; }

        public string expiryDate { get; set; }
        public int createdById { get; set; }

        public int modifiedBy { get; set; }
        public string carrier { get; set; }
        public int productID { get; set; }
    }

    public class UpdatePolicy
    {
        public int policyId { get; set; }
        public int quoteId { get; set; }
        public string policyNumber { get; set; }
        public int policySource { get; set; }
        public int policyStatus { get; set; }
        public string effectiveDate { get; set; }

        public string expiryDate { get; set; }
        public int createdById { get; set; }

        public int modifiedBy { get; set; }
        public string carrier { get; set; }
        public int productID { get; set; }
    }

    [Binding]
    public class HO4PolicySteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private List<DeletePolicy> deletePolicyList = new List<DeletePolicy>();
        private List<GetPolicy> getPolicyList = new List<GetPolicy>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostPolicy> postPolicyList = new List<PostPolicy>();
        private List<UpdatePolicy> updatePolicyList = new List<UpdatePolicy>();
        private string url = "";

        /* Get Policy Information */

        [Given(@"I have provided a policyid to fetch the policy details")]
        public void GivenIHaveProvidedAPolicyidToFetchThePolicyDetails(Table table)
        {
            getPolicyList = table.CreateSet<GetPolicy>().ToList();
        }

        [When(@"I send a Get request to the web API")]
        public void WhenISendAGetRequestToTheWebAPI()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            var _policyid = "";
            for (var i = 0; i < getPolicyList.Count(); i++)
            {
                _policyid = getPolicyList[i].policyid;
                url = hostUrl + "/ri-policyapi/1.0.0/HO4/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }


        [Then(@"The policy information should be fetched successfully")]
        public void ThenThePolicyInformationShouldBeFetchedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }


        /* Delete Policy Information*/

        [Given(@"I have provided a valid policyid to delete the policy details")]
        public void GivenIHaveProvidedAValidPolicyidToDeleteThePolicyDetails(Table table)
        {
            deletePolicyList = table.CreateSet<DeletePolicy>().ToList();
        }


        [When(@"I send a valid Delete request with the policyid to the web API")]
        public void WhenISendAValidDeleteRequestWithThePolicyidToTheWebAPI()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            var _policyid = 0;
            for (var i = 0; i < deletePolicyList.Count(); i++)
            {
                _policyid = deletePolicyList[i].policyid;
                url = hostUrl + "/ri-policyapi/1.0.0/HO4/{PolicyId}?" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The policy information should be removed successfully")]
        public void ThenThePolicyInformationShouldBeRemovedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        /* Post Policy Information */

        [Given(@"I have provided the policy details to post the information")]
        public void GivenIHaveProvidedThePolicyDetailsToPostTheInformation(Table table)
        {
            postPolicyList = table.CreateSet<PostPolicy>().ToList();
        }

        [When(@"I send a valid Post Request to the Web API")]
        public void WhenISendAValidPostRequestToTheWebAPI()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "/ri-policyapi/1.0.0/HO4";
            for (var i = 0; i < postPolicyList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postPolicyList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }


        [Then(@"The policy information should be posted successfully")]
        public void ThenThePolicyInformationShouldBePostedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }


        /* Put Policy Information */

        [Given(@"I have provided the policy details to update the policy information")]
        public void GivenIHaveProvidedThePolicyDetailsToUpdateThePolicyInformation(Table table)
        {
            updatePolicyList = table.CreateSet<UpdatePolicy>().ToList();
        }

        [When(@"I send a valid Put Request to the Web API")]
        public void WhenISendAValidPutRequestToTheWebAPI()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            url = hostUrl + "/ri-policyapi/1.0.0/HO4";
            for (var i = 0; i < updatePolicyList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(updatePolicyList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }


        [Then(@"The policy information should be updated successfully")]
        public void ThenThePolicyInformationShouldBeUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}