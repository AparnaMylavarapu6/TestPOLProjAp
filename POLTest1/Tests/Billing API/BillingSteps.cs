using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Billing_API
{
    public class FetchBillingInformation
    {
        public int billingid { get; set; }
    }

    public class DeleteBillingInformation
    {
        public int billingid { get; set; }
        
       
    }

    public class FetchBillingResults
    {
        public int billingID { get; set; }
        public int policyID { get; set; }
        public int residentID { get; set; }
        public int paymentMethod { get; set; }
        public int paymentFrequency { get; set; }
        public string billingDate { get; set; }
        public string nextBillingDate { get; set; }
        public double annualPremium { get; set; } 
        public int statementCount { get; set; }
    }

    public class PostBillingInformation
    {
        public int billingid { get; set; }
        public int residentid { get; set; }
        public int policyid { get; set; }
        public string paymentmethod { get; set; }
        public string paymentfrequency { get; set; }
        public string billingdate { get; set; }
        public string nextbillingdate { get; set; }
        public string annualpremium { get; set; }
        public int statementcount { get; set; }
    }

    public class PostBillingResults
    {
        public int billingid { get; set; }
    }
    public class PutBillingInformation
    {
        public int billingid { get; set; }
        public int residentid { get; set; }
        public int policyid { get; set; }
        public string paymentmethod { get; set; }
        public string paymentfrequency { get; set; }
        public string billingdate { get; set; }
        public string nextbillingdate { get; set; }
        public string annualpremium { get; set; }
        public int statementcount { get; set; }
    }

    [Binding]
    public class BillingSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private int _billingid;
        private List<DeleteBillingInformation> deleteBillingInformationList = new List<DeleteBillingInformation>();
        private List<FetchBillingInformation> fetchBillingInformationList = new List<FetchBillingInformation>();
        private string jsonRequest = "";

        private string jsonResponse = "";
        private List<PostBillingInformation> postBillingInformationList = new List<PostBillingInformation>();
        private List<PutBillingInformation> putBillingInformationList = new List<PutBillingInformation>();
        private string url = "";
        private object jsonResponse1;
        private string jsonResult;

        [Given(@"I have entered the billing id to fetch the billing information")]
        public void GivenIHaveEnteredTheBillingIdToFetchTheBillingInformation(Table table)
        {
            fetchBillingInformationList = table.CreateSet<FetchBillingInformation>().ToList();
        }

        [Given(@"I have entered the billing id to delete the billing information")]
        public void GivenIHaveEnteredTheBillingIdToDeleteTheBillingInformation(Table table)
        {
            deleteBillingInformationList = table.CreateSet<DeleteBillingInformation>().ToList();
        }

        [Given(@"I have entered the billing information to be posted")]
        public void GivenIHaveEnteredTheBillingInformationToBePosted(Table table)
        {
            postBillingInformationList = table.CreateSet<PostBillingInformation>().ToList();
        }

        [Given(@"I have entered the billing information to be inserted or updated")]
        public void GivenIHaveEnteredTheBillingInformationToBeInsertedOrUpdated(Table table)
        {
            putBillingInformationList = table.CreateSet<PutBillingInformation>().ToList();
        }

        [When(@"I send a Get request to fetch the billing information")]
        public void WhenISendAGetRequestToFetchTheBillingInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < fetchBillingInformationList.Count; i++)
            {
                _billingid = fetchBillingInformationList[i].billingid;
                url = hostUrl + "Billing/" + _billingid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the billing information")]
        public void WhenISendADeleteRequestToDeleteTheBillingInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < deleteBillingInformationList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(deleteBillingInformationList[i]);
                url = hostUrl + "Billing";
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Post request to insert the billing information")]
        public void WhenISendAPostRequestToInsertTheBillingInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "Billing";
            for (var i = 0; i < postBillingInformationList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postBillingInformationList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "application/json-patch+json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Put request to insert or update the billing information")]
        public void WhenISendAPutRequestToInsertOrUpdateTheBillingInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "Billing";
            for (var i = 0; i < putBillingInformationList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putBillingInformationList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A successful response code should be generated with the billing information")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillingInformation(Table table)
        {
            var policyidList = table.CreateSet<FetchBillingResults>().ToList();
            
            for (var i = 0; i < jsonResponseList.Count(); i++)
            {
                int _policyid = policyidList[i].policyID;
                //policyidList[i].annualPremium = Math.Round(198.00, 2);
                jsonResult = JsonConvert.SerializeObject(policyidList[i]);
                //jsonResponse1 = JsonConvert.DeserializeObject(jsonResponseList[i]);
                //Assert.AreEqual(policyidList[i], jsonResponseList[i]);

                Assert.IsTrue(jsonResponseList[i].Contains("\"policyID\":"+_policyid));
                
            }
                //Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response code should be generated with the billing information deleted successfully")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillingInformationDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response code should be generated with the billing information inserted successfully")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillingInformationInsertedSuccessfully(Table table)
        {
            var postBillingResult = table.CreateSet<PostBillingResults>().ToList();
            string _billingid = "";
            
            for (var i = 0; i < jsonResponseList.Count(); i++)
            {
                _billingid = postBillingResult[i].billingid.ToString();
                Assert.AreEqual(_billingid,jsonResponseList[i].ToString());
            }
                
        }

        [Then(
            @"A successful response code should be generated with the billing information inserted or updated successfully")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillingInformationInsertedOrUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }
    }
}