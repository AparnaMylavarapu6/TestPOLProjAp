using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Billing_API
{
    public class FetchCreditCardInformation
    {
        public int cardid { get; set; }
    }

    public class DeleteCreditCardInformation
    {
        public int cardid { get; set; }
    }

    public class PostCreditCardInformation
    {
        public int cardType { get; set; }
        public string name { get; set; }
        public string cardNumber { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public int residentID { get; set; }
        public string paymentMethod { get; set; }
        public string customerReferenceID { get; set; }
        public string accountReferenceID { get; set; }
    }

    public class PutCreditCardInformation
    {
        public int cardType { get; set; }
        public string name { get; set; }
        public string cardNumber { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public int residentID { get; set; }
        public string paymentMethod { get; set; }
        public string customerReferenceID { get; set; }
        public string accountReferenceID { get; set; }
    }

    [Binding]
    public class CreditCardSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private int _ccnumber;

        private List<DeleteCreditCardInformation> deleteCreditCardInformationList =
            new List<DeleteCreditCardInformation>();

        private List<FetchCreditCardInformation>
            fetchCreditCardInformationList = new List<FetchCreditCardInformation>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostCreditCardInformation> postCreditCardInformationList = new List<PostCreditCardInformation>();
        private List<PutCreditCardInformation> putCreditCardInformationList = new List<PutCreditCardInformation>();
        private string url = "";


        [Given(@"I have entered the card id to fetch the credit card information")]
        public void GivenIHaveEnteredTheCardIdToFetchTheCreditCardInformation(Table table)
        {
            fetchCreditCardInformationList = table.CreateSet<FetchCreditCardInformation>().ToList();
        }

        [Given(@"I have entered the card id to delete the credit card information")]
        public void GivenIHaveEnteredTheCardIdToDeleteTheCreditCardInformation(Table table)
        {
            deleteCreditCardInformationList = table.CreateSet<DeleteCreditCardInformation>().ToList();
        }

        [Given(@"I have entered the credit card information to post the data")]
        public void GivenIHaveEnteredTheCreditCardInformationToPostTheData(Table table)
        {
            postCreditCardInformationList = table.CreateSet<PostCreditCardInformation>().ToList();
        }

        [Given(@"I have entered the credit card information to insert or update the data")]
        public void GivenIHaveEnteredTheCreditCardInformationToInsertOrUpdateTheData(Table table)
        {
            putCreditCardInformationList = table.CreateSet<PutCreditCardInformation>().ToList();
        }

        [When(@"I send a Get request to fetch the credit card information")]
        public void WhenISendAGetRequestToFetchTheCreditCardInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < fetchCreditCardInformationList.Count; i++)
            {
                _ccnumber = fetchCreditCardInformationList[i].cardid;
                //url = billingAPIUrlDev + "/ri-billingapi/2.0.0/CreditCard/" + _ccnumber;
                url = hostUrl+"api/CreditCard/GetCreditCardInfo/" + _ccnumber;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Delete request to delete the credit card information")]
        public void WhenISendADeleteRequestToDeleteTheCreditCardInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            for (var i = 0; i < deleteCreditCardInformationList.Count; i++)
            {
                _ccnumber = deleteCreditCardInformationList[i].cardid;
                url = hostUrl + "api/CreditCard/GetCreditCardInfo/" + _ccnumber;
                jsonResponse =
                    doExecuteApiWithHeaders(url, "DELETE", "json", "application/json", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a post request with the credit card information")]
        public void WhenISendAPostRequestWithTheCreditCardInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/CreditCard/InsertCreditCardInfo";
            for (var i = 0; i < postCreditCardInformationList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(postCreditCardInformationList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a put request with the credit card information")]
        public void WhenISendAPutRequestWithTheCreditCardInformation()
        {
            init();
            hostUrl = GetUrl("BillingAPI");
            url = hostUrl + "api/CreditCard/UpdateCreditCardInfo";
            for (var i = 0; i < putCreditCardInformationList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(putCreditCardInformationList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "Bearer " + token,
                    jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid response code should be generated with the credit card information")]
        public void ThenAValidResponseCodeShouldBeGeneratedWithTheCreditCardInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"A valid response code should be generated with the credit card information being deleted successfully")]
        public void ThenAValidResponseCodeShouldBeGeneratedWithTheCreditCardInformationBeingDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"The CC information should be inserted successfully")]
        public void ThenTheCCInformationShouldBeInsertedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }

        [Then(@"The CC information should be inserted or updated successfully")]
        public void ThenTheCCInformationShouldBeInsertedOrUpdatedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}