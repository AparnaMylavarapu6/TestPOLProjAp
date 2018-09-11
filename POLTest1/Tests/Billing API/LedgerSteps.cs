using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Billing_API
{
    public class FetchLedgerInfo
    {
        public int ledgerid { get; set; }
    }

    public class DeleteLedgerInfo
    {
        public int ledgerid { get; set; }
    }

    public class PostLedgerInfo
    {
        public int ledgerID { get; set; }
        public int groupPolicyID { get; set; }
        public string groupPolicyNumber { get; set; }
        public string certificateNumber { get; set; }
        public int locationID { get; set; }
        public float AnnualPremium { get; set; }
        public string ledgerEffectiveDate { get; set; }
        public string ledgerEndDate { get; set; }
        public int policyStatusID { get; set; }
        public int productRateID { get; set; }
        public int quoteID { get; set; }
    }

    public class PutLedgerInfo
    {
        public int ledgerID { get; set; }
        public int groupPolicyID { get; set; }
        public string groupPolicyNumber { get; set; }
        public string certificateNumber { get; set; }
        public int locationID { get; set; }
        public float AnnualPremium { get; set; }
        public string ledgerEffectiveDate { get; set; }
        public string ledgerEndDate { get; set; }
        public int policyStatusID { get; set; }
        public int productRateID { get; set; }
        public int quoteID { get; set; }
    }

    [Binding]
    public class LedgerSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private int _ledgerid;
        private List<DeleteLedgerInfo> deleteLedgerInfoList = new List<DeleteLedgerInfo>();
        private List<FetchLedgerInfo> fetchLedgerInfoList = new List<FetchLedgerInfo>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostLedgerInfo> postLedgerInfoList = new List<PostLedgerInfo>();
        private List<PutLedgerInfo> putLedgerInfoList = new List<PutLedgerInfo>();
        private string url = "";

        [Given(@"I have provided the ledgerid to fetch the ledger information")]
        public void GivenIHaveProvidedTheLedgeridToFetchTheLedgerInformation(Table table)
        {
            fetchLedgerInfoList = table.CreateSet<FetchLedgerInfo>().ToList();
        }

        [Given(@"I have provided the ledgerid to delete the ledger information")]
        public void GivenIHaveProvidedTheLedgeridToDeleteTheLedgerInformation(Table table)
        {
            deleteLedgerInfoList = table.CreateSet<DeleteLedgerInfo>().ToList();
        }

        [Given(@"I have provided the ledger information to post the data")]
        public void GivenIHaveProvidedTheLedgerInformationToPostTheData(Table table)
        {
            postLedgerInfoList = table.CreateSet<PostLedgerInfo>().ToList();
        }

        [Given(@"I have provided the ledger information to insert or update the data")]
        public void GivenIHaveProvidedTheLedgerInformationToInsertOrUpdateTheData(Table table)
        {
            putLedgerInfoList = table.CreateSet<PutLedgerInfo>().ToList();
        }

        [When(@"I send a Get request to fetch the ledger information for the provided ledgerid")]
        public void WhenISendAGetRequestToFetchTheLedgerInformationForTheProvidedLedgerid()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < fetchLedgerInfoList.Count; i++)
            {
                _ledgerid = fetchLedgerInfoList[i].ledgerid;
                url = hostUrl + "api/Ledger/GetLedgerInfo/" + _ledgerid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the ledger information for the provided ledgerid")]
        public void WhenISendADeleteRequestToDeleteTheLedgerInformationForTheProvidedLedgerid()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < deleteLedgerInfoList.Count; i++)
            {
                _ledgerid = deleteLedgerInfoList[i].ledgerid;
                jsonRequest = JsonConvert.SerializeObject(deleteLedgerInfoList[i]);
                url = hostUrl + "api/Ledger/DeletLedgerInfo" + _ledgerid;
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Post request to insert the ledger information")]
        public void WhenISendAPostRequestToInsertTheLedgerInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/Ledger/InsertLedgerInfo";
            for (var i = 0; i < postLedgerInfoList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postLedgerInfoList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Put request to insert or update the ledger information")]
        public void WhenISendAPutRequestToInsertOrUpdateTheLedgerInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/Ledger/UpdateLedgerInfo";
            for (var i = 0; i < putLedgerInfoList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putLedgerInfoList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A success response code should be generated and the ledger information should be returned")]
        public void ThenASuccessResponseCodeShouldBeGeneratedAndTheLedgerInformationShouldBeReturned()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A success response code should be generated and the ledger information should be deleted successfully")]
        public void ThenASuccessResponseCodeShouldBeGeneratedAndTheLedgerInformationShouldBeDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A success response should be generated and the ledger information should be inserted successfully")]
        public void ThenASuccessResponseShouldBeGeneratedAndTheLedgerInformationShouldBeInsertedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A success response should be generated and the ledger information should be inserted or updated successfully")]
        public void ThenASuccessResponseShouldBeGeneratedAndTheLedgerInformationShouldBeInsertedOrUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}