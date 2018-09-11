using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class FetchProductOptions
    {
        public string policyid { get; set; }
    }

    public class DeleteProductOptions
    {
        public string policyid { get; set; }
    }

    public class ProductOptionsList
    {
        public int pOAID { get; set; }
        public string effDate { get; set; }
        public string expDate { get; set; }
        public int noOfIncrements { get; set; }
    }


    public class PolicyProductOptions
    {
        public int policyId { get; set; }
        public List<ProductOptionsList> productOptionsList { get; set; }
    }

    [Binding]
    public class HO4PolicyProductOptionsSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string _policyid = "";
        private List<DeleteProductOptions> deleteProductOptionsList = new List<DeleteProductOptions>();
        private List<FetchProductOptions> fetchProductOptionsList = new List<FetchProductOptions>();
        private string jsonRequest = "";
        private string jsonResponse = "";
        private string url = "";

        [Given(@"I have provided the policy id to fetch Policy Product Options")]
        public void GivenIHaveProvidedThePolicyIdToFetchPolicyProductOptions(Table table)
        {
            fetchProductOptionsList = table.CreateSet<FetchProductOptions>().ToList();
        }

        [Given(@"I have provided the policy id to delete Policy Product Options")]
        public void GivenIHaveProvidedThePolicyIdToDeletePolicyProductOptions(Table table)
        {
            deleteProductOptionsList = table.CreateSet<DeleteProductOptions>().ToList();
        }

        [Given(@"I have provided the Product Options List to post the product options")]
        public void GivenIHaveProvidedTheProductOptionsListToPostTheProductOptions(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have provided the Product Options List to insert or update the product options")]
        public void GivenIHaveProvidedTheProductOptionsListToInsertOrUpdateTheProductOptions(Table table)
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I send a Get request to fetch the product options")]
        public void WhenISendAGetRequestToFetchTheProductOptions()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < fetchProductOptionsList.Count; i++)
            {
                _policyid = fetchProductOptionsList[i].policyid;
                url = hostUrl + "PolicyProductOptions/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the product options")]
        public void WhenISendADeleteRequestToDeleteTheProductOptions()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < deleteProductOptionsList.Count; i++)
            {
                _policyid = deleteProductOptionsList[i].policyid;
                url = hostUrl + "PolicyProductOptions/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Post request with the product options list and the policy id")]
        public void WhenISendAPostRequestWithTheProductOptionsListAndThePolicyId()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I send a Put request with the product options list and the policy id")]
        public void WhenISendAPutRequestWithTheProductOptionsListAndThePolicyId()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"A successful response code should be generated with the product option information")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheProductOptionInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A successful response code should be generated with the delete option being successful")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheDeleteOptionBeingSuccessful()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A successful response code should be generated with the product option information successfully posted")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheProductOptionInformationSuccessfullyPosted()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A successful response code should be generated with the product option information successfully inserted or updated")]
        public void
            ThenASuccessfulResponseCodeShouldBeGeneratedWithTheProductOptionInformationSuccessfullyInsertedOrUpdated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}