using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Carrier_API
{
    public class PostHO4Rates
    {
        public string propertyID { get; set; }
        public string propertyName { get; set; }
        public string propertyAddress { get; set; }
        public string state { get; set; }
        public string quoteSource { get; set; }
        public string zipcode { get; set; }
        public string quoteEffdDate { get; set; }
    }

    public class PostPOLRates
    {
        public string propertyID { get; set; }
        public string propertyName { get; set; }
        public string propertyAddress { get; set; }
        public string state { get; set; }
        public string quoteSource { get; set; }
        public string zipcode { get; set; }
        public string quoteEffdDate { get; set; }
    }

    [Binding]
    public class CarrierSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<PostHO4Rates> PostHO4RatesList = new List<PostHO4Rates>();
        private List<PostPOLRates> PostPOLRatesList = new List<PostPOLRates>();

        [Given(@"I have entered the property details to post the rates")]
        public void GivenIHaveEnteredThePropertyDetailsToPostTheRates(Table table)
        {
            var postHo4info = table.CreateSet<PostHO4Rates>();
            PostHO4RatesList = postHo4info.ToList();
        }

        [Given(@"I have entered the property details to post POL Rates")]
        public void GivenIHaveEnteredThePropertyDetailsToPostPOLRates(Table table)
        {
            var postpolinfo = table.CreateSet<PostPOLRates>();
            PostPOLRatesList = postpolinfo.ToList();
        }


        [When(@"I send a valid POST Request with the input")]
        public void WhenISendAValidPOSTRequestWithTheInput()
        {
            init();
            hostUrl = GetUrl("CarrierAPI");
            var url = hostUrl + "/HO4Rates";
            for (var i = 0; i < PostHO4RatesList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(PostHO4RatesList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a valid POST Request with the POL input data")]
        public void WhenISendAValidPOSTRequestWithThePOLInputData()
        {
            init();
            hostUrl = GetUrl("CarrierAPI");
            var url = hostUrl + "/POLRates";
            for (var i = 0; i < PostHO4RatesList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(PostPOLRatesList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid product package information should be generated")]
        public void ThenAValidProductPackageInformationShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }
    }
}