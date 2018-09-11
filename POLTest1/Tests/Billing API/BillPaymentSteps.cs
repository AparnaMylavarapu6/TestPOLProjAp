using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Billing_API
{
    public class FetchBillPayment
    {
        public int paymentid { get; set; }
    }

    public class DeleteBillPayment
    {
        public int paymentid { get; set; }
    }

    public class PostBillPayment
    {
        public int paymentid { get; set; }
        public string paymentMethod { get; set; }
        public string paymentFrequency { get; set; }
        public int paymentTransactionType { get; set; }
        public int residentid { get; set; }
        public int policyid { get; set; }
    }

    public class PutBillPayment
    {
        public int paymentid { get; set; }
        public string paymentMethod { get; set; }
        public string paymentFrequency { get; set; }
        public int paymentTransactionType { get; set; }
        public int residentid { get; set; }
        public int policyid { get; set; }
    }

    [Binding]
    public class BillPaymentSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private int _paymentid;
        private List<DeleteBillPayment> deleteBillPaymentList = new List<DeleteBillPayment>();
        private List<FetchBillPayment> fetchBillPaymentList = new List<FetchBillPayment>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostBillPayment> postBillPaymentList = new List<PostBillPayment>();
        private List<PutBillPayment> putBillPaymentList = new List<PutBillPayment>();
        private string url = "";

        [Given(@"I have entered the payment id to fetch the bill payment information")]
        public void GivenIHaveEnteredThePaymentIdToFetchTheBillPaymentInformation(Table table)
        {
            fetchBillPaymentList = table.CreateSet<FetchBillPayment>().ToList();
        }

        [Given(@"I have entered the payment id to delete the bill payment information")]
        public void GivenIHaveEnteredThePaymentIdToDeleteTheBillPaymentInformation(Table table)
        {
            deleteBillPaymentList = table.CreateSet<DeleteBillPayment>().ToList();
        }

        [Given(@"I have entered the bill payment information to be posted")]
        public void GivenIHaveEnteredTheBillPaymentInformationToBePosted(Table table)
        {
            postBillPaymentList = table.CreateSet<PostBillPayment>().ToList();
        }

        [Given(@"I have entered the bill payment information to be inserted or updated")]
        public void GivenIHaveEnteredTheBillPaymentInformationToBeInsertedOrUpdated(Table table)
        {
            putBillPaymentList = table.CreateSet<PutBillPayment>().ToList();
        }

        [When(@"I send a Get request to fetch the bill payment information with the payment id")]
        public void WhenISendAGetRequestToFetchTheBillPaymentInformationWithThePaymentId()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < fetchBillPaymentList.Count; i++)
            {
                _paymentid = fetchBillPaymentList[i].paymentid;
                url = hostUrl + "api/BillPayment/GetPaymentInfo/" + _paymentid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to fetch the bill payment information with the payment id")]
        public void WhenISendADeleteRequestToFetchTheBillPaymentInformationWithThePaymentId()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < deleteBillPaymentList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(deleteBillPaymentList[i]);
                _paymentid = deleteBillPaymentList[i].paymentid;
                url = hostUrl + "api/BillPayment/DeletPaymentInfo";
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Post request to insert the bill payment information")]
        public void WhenISendAPostRequestToInsertTheBillPaymentInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/BillPayment/InsertPaymentInfo";
            for (var i = 0; i < postBillPaymentList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postBillPaymentList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Put request to insert or update the bill payment information")]
        public void WhenISendAPutRequestToInsertOrUpdateTheBillPaymentInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/BillPayment/UpdatePaymentInfo";
            for (var i = 0; i < putBillPaymentList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putBillPaymentList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A successful response code should be generated with the bill payment information")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillPaymentInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A successful response code should be generated with the bill payment information deleted successfully")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillPaymentInformationDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A successful response code should be generated with the bill payment information posted successfully")]
        public void ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillPaymentInformationPostedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A successful response code should be generated with the bill payment information inserted or updated successfully")]
        public void
            ThenASuccessfulResponseCodeShouldBeGeneratedWithTheBillPaymentInformationInsertedOrUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}