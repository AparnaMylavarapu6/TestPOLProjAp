using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_Enrollment_API
{
    public class PropertyInfoPOL
    {
        public string propertyIdType { get; set; }
        public string propertyID { get; set; }
    }

    public class PostPolicyOptIn
    {
        public PropertyInfoPOL PropertyInfoPol { get; set; }
        public int quoteId { get; set; }
        public int productRateID { get; set; }
    }

    [Binding]
    public class POLSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private readonly List<string> productRateIDlist = new List<string>();
        private readonly List<string> quoteList = new List<string>();
        private string jsonRequest = "";
        private string jsonResponse = "";

        //List<QuoteInformationPOL> quoteInformationPolList = new List<QuoteInformationPOL>();
        private List<PostPolicyOptIn> postPolicyOptInList = new List<PostPolicyOptIn>();
        private List<PropertyInfoPOL> propertyInfoPolList = new List<PropertyInfoPOL>();
        private string url = "";

        [Given(@"I have provided the property information to post the  pol product opt-in")]
        public void GivenIHaveProvidedThePropertyInformationToPostThePolProductOpt_In(Table table)
        {
            propertyInfoPolList = table.CreateSet<PropertyInfoPOL>().ToList();
        }

        [Given(@"I have provided the quoteid and the productrateid")]
        public void GivenIHaveProvidedTheQuoteidAndTheProductrateid(Table table)
        {
            //quoteInformationPolList = table.CreateSet<QuoteInformationPOL>().ToList();
            postPolicyOptInList = table.CreateSet<PostPolicyOptIn>().ToList();
            for (var i = 0; i < postPolicyOptInList.Count; i++)
            {
                quoteList.Add(postPolicyOptInList[i].quoteId.ToString());
                productRateIDlist.Add(postPolicyOptInList[i].productRateID.ToString());
            }
        }

        //[Given(@"I have provided the authentication information for POL policy activation")]
        //public void GivenIHaveProvidedTheAuthenticationInformationForPOLPolicyActivation(Table table)
        //{

        //}

        //[Given(@"I have provided the property information for POL policy activation")]
        //public void GivenIHaveProvidedThePropertyInformationForPOLPolicyActivation(Table table)
        //{

        //}

        //[Given(@"I have provided the quote information for POL policy activation")]
        //public void GivenIHaveProvidedTheQuoteInformationForPOLPolicyActivation(Table table)
        //{

        //}

        [When(@"I send a Post request to fetch the certificate number")]
        public void WhenISendAPostRequestToFetchTheCertificateNumber()
        {
            var postPolicyOptInObj = new PostPolicyOptIn();
            url = hostUrl + "/ri-policyenrollmentapi/1.0.0/PolicyOptIn";
            for (var i = 0; i < postPolicyOptInList.Count; i++)
            {
                postPolicyOptInObj.PropertyInfoPol = propertyInfoPolList[i];
                postPolicyOptInObj.quoteId = Convert.ToInt32(quoteList[i]);
                postPolicyOptInObj.productRateID = Convert.ToInt32(productRateIDlist[i]);
                jsonRequest = JsonConvert.SerializeObject(postPolicyOptInObj);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        //[When(@"I send a Post request for POL Policy Activation")]
        //public void WhenISendAPostRequestForPOLPolicyActivation()
        //{
        //    ScenarioContext.Current.Pending();
        //}

        [Then(@"A valid certificate number should be generated")]
        public void ThenAValidCertificateNumberShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
        }

        //[Then(@"A valid success response should be generated")]
        //public void ThenAValidSuccessResponseShouldBeGenerated()
        //{
        //    for (var i = 0; i < jsonResponseList.Count(); i++)
        //    {
        //        Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        //        //sw.Write(jsonResponseList[i]);
        //    }
        //}
    }
}