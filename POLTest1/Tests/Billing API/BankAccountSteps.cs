using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Billing_API
{
    public class FetchBankDetails
    {
        public int accountid { get; set; }
    }

    public class DeleteBankDetails
    {
        public int accountid { get; set; }
    }

    public class PostBankDetails
    {
        public string routingNumber { get; set; }
        public string accountNumber { get; set; }
        public string checkNumber { get; set; }
        public string customerReferenceID { get; set; }
        public string accountReferenceID { get; set; }
        public bool isPrimary { get; set; }
    }

    public class PutBankDetails
    {
        public string routingNumber { get; set; }
        public string accountNumber { get; set; }
        public string checkNumber { get; set; }
        public string customerReferenceID { get; set; }
        public string accountReferenceID { get; set; }
        public bool isPrimary { get; set; }
    }

    [Binding]
    public class BankAccountSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private int _accountid;
        private List<DeleteBankDetails> deleteBankDetailsList = new List<DeleteBankDetails>();
        private List<FetchBankDetails> fetchBankDetailsList = new List<FetchBankDetails>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostBankDetails> postBankDetailsList = new List<PostBankDetails>();
        private List<PutBankDetails> putBankDetailsList = new List<PutBankDetails>();
        private string url = "";


        [Given(@"I have provided the account id to fetch the bank account details")]
        public void GivenIHaveProvidedTheAccountIdToFetchTheBankAccountDetails(Table table)
        {
            System.Console.WriteLine("Testpass1");
            fetchBankDetailsList = table.CreateSet<FetchBankDetails>().ToList();
        }

        [Given(@"I have provided the account id to delete the bank account details")]
        public void GivenIHaveProvidedTheAccountIdToDeleteTheBankAccountDetails(Table table)
        {
            deleteBankDetailsList = table.CreateSet<DeleteBankDetails>().ToList();
        }

        [Given(@"I have provided the bank account details to post the information")]
        public void GivenIHaveProvidedTheBankAccountDetailsToPostTheInformation(Table table)
        {
            postBankDetailsList = table.CreateSet<PostBankDetails>().ToList();
        }

        [Given(@"I have provided the bank account details to insert or update the information")]
        public void GivenIHaveProvidedTheBankAccountDetailsToInsertOrUpdateTheInformation(Table table)
        {
            putBankDetailsList = table.CreateSet<PutBankDetails>().ToList();
        }

        [When(@"I send a Get request to fetch the bank account details for the provided account id")]
        public void WhenISendAGetRequestToFetchTheBankAccountDetailsForTheProvidedAccountId()
        {
            init();

            for (var i = 0; i < fetchBankDetailsList.Count; i++)
            {
                _accountid = fetchBankDetailsList[i].accountid;
                hostUrl = GetUrl("BillingAPI");
                url = hostUrl + "api/BankAccount/GetBankAccountInfo/" + _accountid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to fetch the bank account details for the provided account id")]
        public void WhenISendADeleteRequestToFetchTheBankAccountDetailsForTheProvidedAccountId()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/BankAccount/DeletBankAccountInfo";
            for (var i = 0; i < deleteBankDetailsList.Count; i++)
            {
                //_accountid = deleteBankDetailsList[i].accountid;
                //url = hostUrl + "/ri-billingapi/2.0.0/BankAccount/" + _accountid;
                jsonRequest = JsonConvert.SerializeObject(deleteBankDetailsList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a post request to insert the bank account details")]
        public void WhenISendAPostRequestToInsertTheBankAccountDetails()
        {
            init();
            //DataRow[] urldDataRow = GetUrl("BillingApi", "dev");

            //url = billingAPIUrlDev + "api/BankAccount/InsertBankAccountInfo";
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/BankAccount/InsertBankAccountInfo";
            for (var i = 0; i < postBankDetailsList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postBankDetailsList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a put request to insert or update the bank account details")]
        public void WhenISendAPutRequestToInsertOrUpdateTheBankAccountDetails()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/BankAccount/UpdateBankAccountInfo";
            for (var i = 0; i < putBankDetailsList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putBankDetailsList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid success response should be generated with the bank account information")]
        public void ThenAValidSuccessResponseShouldBeGeneratedWithTheBankAccountInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(
            @"A valid success response should be generated and the bank account details should be succdessfully deleted")]
        public void ThenAValidSuccessResponseShouldBeGeneratedAndTheBankAccountDetailsShouldBeSuccdessfullyDeleted()
        {
            //var sw = new StreamWriter("D:\\BillingAPI.txt", true, Encoding.ASCII);
            //var CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);

            //sw.Close();
        }

        [Then(@"A valid success response should be generated and the details should be inserted successfully")]
        public void ThenAValidSuccessResponseShouldBeGeneratedAndTheDetailsShouldBeInsertedSuccessfully()
        {
            //List<HttpStatusCode> httpStatusCodes = new List<HttpStatusCode>();  
            for (var i = 0; i < jsonResponseList.Count(); i++)

            {
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
                //jsonResponseList[i].Select("residentId");
            }
            

            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);

            //sw.Close();
        }

        [Then(
            @"A valid success response should be generated and the details should be inserted or updated successfully")]
        public void ThenAValidSuccessResponseShouldBeGeneratedAndTheDetailsShouldBeInsertedOrUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}