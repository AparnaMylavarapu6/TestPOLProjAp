using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.PMS_Integration_API
{
    public class EntityTypeRequest
    {
        public string entityType { get; set; }
        public string entityId { get; set; }
    }
    public class LeaseDetailsRequest
    {
        public EntityTypeRequest EntityTypeRequest = new EntityTypeRequest();
        public int extResidentId { get; set; }
        public int extUnitId { get; set; }
        public string leaseEffectiveDate { get; set; }
    }

    public class LeaseIDList
    {
        public string leaseId { get; set; }
    }
    [Binding]
    public class LeaseDetailsSteps:TestBase
    {
        List<EntityTypeRequest> entityTypeRequestList = new List<EntityTypeRequest>();
        List<LeaseDetailsRequest>leaseDetailsRequestList = new List<LeaseDetailsRequest>();
        List<LeaseIDList>leaseIdList = new List<LeaseIDList>(); 
        List<string>jsonResponseList = new List<string>();
        private string jsonRequest = "";
        private string jsonResponse = "";
        private string url = "";
        int _leaseId;

        [Given(@"I have entered the property type request to fetch the lease details")]
        public void GivenIHaveEnteredThePropertyTypeRequestToFetchTheLeaseDetails(Table table)
        {
            entityTypeRequestList = table.CreateSet<EntityTypeRequest>().ToList();
        }
        
        [Given(@"I have entered the Resident and Unit ID's to get the lease details")]
        public void GivenIHaveEnteredTheResidentAndUnitIDSToGetTheLeaseDetails(Table table)
        {
            leaseDetailsRequestList = table.CreateSet<LeaseDetailsRequest>().ToList();

            for (int i = 0; i < entityTypeRequestList.Count; i++)
            {
                //leaseDetailsRequestList.AddRange();
                leaseDetailsRequestList[i].EntityTypeRequest.entityType = entityTypeRequestList[i].entityType;
                leaseDetailsRequestList[i].EntityTypeRequest.entityId = entityTypeRequestList[i].entityId;
            }
        }
        
        [When(@"I send a Post request to the PMS System to fetch the lease details")]
        public void WhenISendAPostRequestToThePMSSystemToFetchTheLeaseDetails()
        {
            init();
            hostUrl = GetUrl("PMSAPI");
            url = hostUrl + "LeaseDetails";
            for (int i = 0; i < leaseDetailsRequestList.Count; i++)
            {
                jsonRequest = JsonConvert.SerializeObject(leaseDetailsRequestList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "application/json-patch+json", "application/json",
                    "Bearer " + token, jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }

        }
        
        [Then(@"A valid success response should be genrated and the lease details should be returned")]
        public void ThenAValidSuccessResponseShouldBeGenratedAndTheLeaseDetailsShouldBeReturned(Table table)
        {
            leaseIdList = table.CreateSet<LeaseIDList>().ToList();
            
            for (int i = 0; i < leaseIdList.Count; i++)
            {
                Assert.IsTrue(jsonResponseList[i].Contains("\"leaseId\":" + _leaseId));
            }
            

        }
    }
}
