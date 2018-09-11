using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Billing_API
{
    public class FetchLedgerMonthlyInfo
    {
        public int ledgermonthlyid { get; set; }
    }


    public class DeleteLedgerMonthlyInfo
    {
        public int ledgermonthlyid { get; set; }
    }

    public class PostLedgerMonthlyInfo
    {
        public int ledgerMonthlyID { get; set; }
        public int ledgerID { get; set; }
        public float premium { get; set; }
        public string ledgerStartDate { get; set; }
        public string ledgerEndDate { get; set; }
        public bool excludeLedger { get; set; }
        public float commission { get; set; }
        public string carrierCommunicationSent { get; set; }
        public string ledgerGeneratedDate { get; set; }
        public int excludeReason { get; set; }
        public float serviceFee { get; set; }
    }

    public class PutLedgerMonthlyInfo
    {
        public int ledgerMonthlyID { get; set; }
        public int ledgerID { get; set; }
        public float premium { get; set; }
        public string ledgerStartDate { get; set; }
        public string ledgerEndDate { get; set; }
        public bool excludeLedger { get; set; }
        public float commission { get; set; }
        public string carrierCommunicationSent { get; set; }
        public string ledgerGeneratedDate { get; set; }
        public int excludeReason { get; set; }
        public float serviceFee { get; set; }
    }

    [Binding]
    public class LedgerMonthlySteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private int _ledgermonthlyid;
        private List<DeleteLedgerMonthlyInfo> deleteLedgerMonthlyInfoList = new List<DeleteLedgerMonthlyInfo>();
        private List<FetchLedgerMonthlyInfo> fetchLedgerMonthlyInfoList = new List<FetchLedgerMonthlyInfo>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostLedgerMonthlyInfo> postLedgerMonthlyInfoList = new List<PostLedgerMonthlyInfo>();
        private List<PutLedgerMonthlyInfo> putLedgerMonthlyInfoList = new List<PutLedgerMonthlyInfo>();
        private string url = "";


        [Given(@"I have provided the ledgerMonthlyid to fetch the monthly ledger data")]
        public void GivenIHaveProvidedTheLedgerMonthlyidToFetchTheMonthlyLedgerData(Table table)
        {
            fetchLedgerMonthlyInfoList = table.CreateSet<FetchLedgerMonthlyInfo>().ToList();
        }

        [Given(@"I have provided the ledgerMonthlyid to delete the monthly ledger data")]
        public void GivenIHaveProvidedTheLedgerMonthlyidToDeleteTheMonthlyLedgerData(Table table)
        {
            deleteLedgerMonthlyInfoList = table.CreateSet<DeleteLedgerMonthlyInfo>().ToList();
        }

        [Given(@"I have provided the monthly ledger data to post the data")]
        public void GivenIHaveProvidedTheMonthlyLedgerDataToPostTheData(Table table)
        {
            postLedgerMonthlyInfoList = table.CreateSet<PostLedgerMonthlyInfo>().ToList();
        }

        [Given(@"I have provided the monthly ledger data to insert or update the data")]
        public void GivenIHaveProvidedTheMonthlyLedgerDataToInsertOrUpdateTheData(Table table)
        {
            putLedgerMonthlyInfoList = table.CreateSet<PutLedgerMonthlyInfo>().ToList();
        }

        [When(@"I send a Get request to fetch the montly ledger information")]
        public void WhenISendAGetRequestToFetchTheMontlyLedgerInformation()
        {
            init();
            for (var i = 0; i < fetchLedgerMonthlyInfoList.Count; i++)
            {
                _ledgermonthlyid = fetchLedgerMonthlyInfoList[i].ledgermonthlyid;
                url = billingAPIUrlDev + "api/LedgerMonthly/GetLedgerMonthlyInfo" + _ledgermonthlyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the montly ledger information")]
        public void WhenISendADeleteRequestToDeleteTheMontlyLedgerInformation()
        {
            init();
            for (var i = 0; i < deleteLedgerMonthlyInfoList.Count; i++)
            {
                _ledgermonthlyid = deleteLedgerMonthlyInfoList[i].ledgermonthlyid;
                jsonRequest = JsonConvert.SerializeObject(deleteLedgerMonthlyInfoList[i]);
                //url = billingAPIUrlDev + "api/LedgerMonthly/DeletLedgerMonthlyInfo" + _ledgermonthlyid;
                url = billingAPIUrlDev + "api/LedgerMonthly/DeletLedgerMonthlyInfo";
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Post request to insert the monthly ledger data")]
        public void WhenISendAPostRequestToInsertTheMonthlyLedgerData()
        {
            init();
            url = billingAPIUrlDev + "api/LedgerMonthly/InsertLedgerMonthlyInfo";
            for (var i = 0; i < postLedgerMonthlyInfoList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postLedgerMonthlyInfoList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Put request to insert or update the monthly ledger data")]
        public void WhenISendAPutRequestToInsertOrUpdateTheMonthlyLedgerData()
        {
            init();
            url = billingAPIUrlDev + "api/LedgerMonthly/UpdateLedgerMonthlyInfo";
            for (var i = 0; i < putLedgerMonthlyInfoList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putLedgerMonthlyInfoList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A success response should be generated and the monthly ledger information should be returned")]
        public void ThenASuccessResponseShouldBeGeneratedAndTheMonthlyLedgerInformationShouldBeReturned()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A success response should be generated and the monthly ledger information should be deleted successfully")]
        public void ThenASuccessResponseShouldBeGeneratedAndTheMonthlyLedgerInformationShouldBeDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A success response code should be generated and the monthly ledger data should be successfully inserted")]
        public void ThenASuccessResponseCodeShouldBeGeneratedAndTheMonthlyLedgerDataShouldBeSuccessfullyInserted()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A success response code should be generated and the monthly ledger data should be successfully inserted or updated")]
        public void
            ThenASuccessResponseCodeShouldBeGeneratedAndTheMonthlyLedgerDataShouldBeSuccessfullyInsertedOrUpdated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}