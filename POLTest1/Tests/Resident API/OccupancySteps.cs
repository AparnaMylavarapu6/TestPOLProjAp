using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Resident_API
{

    public class OccupancyID 
    {
        public int occupancyID { get; set; }
    }
    public class DeleteOccupancyData
    {
        public int occupancyID { get; set; }
    }

    public class Resident
    {
        public int residentId { get; set; }
        public bool isPrimary { get; set; }
        public int occupancyID { get; set; }
    }

    public class OccupancyInfo
    {
        public int occupancyGroupId { get; set; }
        public int locationID { get; set; }
        public DateTime leaseStartDate { get; set; }
        public DateTime leaseEndDate { get; set; }
        public DateTime createdDate { get; set; }
        public List<Resident> residents { get; set; }
    }

    public class OccupancyInfoObject
    {

        public List<OccupancyInfo> OccupancyInfo = new List<OccupancyInfo>();
    }
    [Binding]
    public  class OccupancySteps : TestBase
    {
       
        private readonly List<string> jsonResponseListGet = new List<string>();
        private readonly List<string> jsonResponseListPost = new List<string>();
        private readonly List<string> jsonResponseListPut = new List<string>();
        private readonly List<string> jsonResponseListDel = new List<string>();
        private List<OccupancyID> occupancyIDList = new List<OccupancyID>();
        private List<DeleteOccupancyData> DeleteOccupancyIDList = new List<DeleteOccupancyData>();
        private List<Resident> ResidentInfoList = new List<Resident>();
        private List<OccupancyInfo> OccupancyInfoList = new List<OccupancyInfo>();
        private OccupancyInfoObject OccupancyInfoObject = new OccupancyInfoObject();

        private string jsonResponse = null;
        private string jsonRequest = "";
        private int GetOccupancyID;
        private int DelOccupancyID;

        //GET Request
        [Given(@"I have OccupancyID details")]
        public void GivenIHaveOccupancyIDDetails(Table table)
        {
            var OccupancyIDList = table.CreateSet<OccupancyID>();
            var occupancyIDListInfo = OccupancyIDList.ToList();
            var count = occupancyIDListInfo.Count();
            for (var i = 0; i < count; i++) occupancyIDList.Add(occupancyIDListInfo[i]);
        }

        //GET Request
        [When(@"I pass the OccupancyID for a get request")]
        public void WhenIPassTheOccupancyIDForAGetRequest()
        {
            var count = occupancyIDList.Count();
            init();
            var host = GetUrl("ResidentAPi");
            // var token = GetTokenInfo();
            for (var i = 0; i < count; i++)
            {
                GetOccupancyID = occupancyIDList[i].occupancyID;
                var jsonRequest = host + "Occupancy/" + GetOccupancyID;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "application/json", "application/json", "Bearer " + token, "");
                jsonResponseListGet.Add(jsonResponse);

            }
        }

        //GET Request
        [Then(@"the Occupant details should be displayed")]
        public void ThenTheOccupantDetailsShouldBeDisplayed()
        {
            for (var i = 0; i < jsonResponseListGet.Count(); i++)
            {
         //       Assert.IsTrue(jsonResponseListGet[i].Contains("\"occupancyID\":" + GetOccupancyID), "The response doesnot contain the Occupancy ID for " + GetOccupancyID);

            }
        }

        //DELETE Request
        [Given(@"I have request to delete Occupancy details")]
        public void GivenIHaveRequestToDeleteOccupancyDetails(Table table)
        {
            var OccupancyIDList = table.CreateSet<DeleteOccupancyData>();
            var deloccupancyIDList = OccupancyIDList.ToList();
            var count = deloccupancyIDList.Count();
            for (var i = 0; i < count; i++) DeleteOccupancyIDList.Add(deloccupancyIDList[i]);
        }

        //DELETE Request
        [When(@"I pass the OccupancyID for a Delete request")]
        public void WhenIPassTheOccupancyIDForADeleteRequest()
        {
            var count = DeleteOccupancyIDList.Count();
            init();
            var host = GetUrl("ResidentAPi");
            //var token = GetTokenInfo();
            for (var i = 0; i < count; i++)
            {
                DelOccupancyID = DeleteOccupancyIDList[i].occupancyID;
                var jsonRequest = host + "/Widget/" + DelOccupancyID;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "DELETE", "application/json", "text/plain", "Bearer " + token, "");
                jsonResponseListDel.Add(jsonResponse);

            }
        }

        //DELETE Request
        [Then(@"the Occupant details will be deleted")]
        public void ThenTheOccupantDetailsWillBeDeleted()
        {
            for (var i = 0; i < jsonResponseListDel.Count(); i++)
            { 
              //  Assert.IsNotNull(jsonResponseListDel);
            }
        }

        //POST Request
        [Given(@"I have request to Post Occupancy details")]
        public void GivenIHaveRequestToPostOccupancyDetails(Table table)
        {
            var OccupancyInfo = table.CreateSet<OccupancyInfo>();
            OccupancyInfoList = OccupancyInfo.ToList();
        }

        //POST Request
        [Given(@"I have provided Residents Information\.")]
        public void GivenIHaveProvidedResidentsInformation_(Table table)
        {
            var ResidentInfo = table.CreateSet<Resident>();
            ResidentInfoList = ResidentInfo.ToList();
        }

        //POST Request
        [When(@"I send a Post request to insert the Occupancy details")]
        public void WhenISendAPostRequestToInsertTheOccupancyDetails()
        {
            init();
            var host = GetUrl("ResidentAPi");
            OccupancyInfo OccupancyInfoObj = new OccupancyInfo();
            OccupancyInfoObject ResidentInfoObj = new OccupancyInfoObject();
            var url = host + "Occupancy/";
            for (var i = 0; i < OccupancyInfoList.Count(); i++)
            {
                OccupancyInfoObj.occupancyGroupId = OccupancyInfoList[i].occupancyGroupId;
                OccupancyInfoObj.locationID = OccupancyInfoList[i].locationID;
                OccupancyInfoObj.leaseStartDate = OccupancyInfoList[i].leaseStartDate;
                OccupancyInfoObj.leaseEndDate = OccupancyInfoList[i].leaseEndDate;
                OccupancyInfoObj.createdDate = OccupancyInfoList[i].createdDate;
                OccupancyInfoObj.residents.Add(ResidentInfoList[i]);

                ResidentInfoObj.OccupancyInfo.Add(OccupancyInfoObj);
                jsonRequest = JsonConvert.SerializeObject(OccupancyInfoObj);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "application/json", "application/json", "Bearer " + token, jsonRequest);
                jsonResponseListPost.Add(jsonResponse);
            }
        }

        //POST Request
        [Then(@"the Occupant details will be added")]
        public void ThenTheOccupantDetailsWillBeAdded()
        {
            for (var i = 0; i < jsonResponseListPost.Count(); i++)
            {
    //            Assert.IsTrue(jsonResponseListPost[i].Contains("\"occupancyGroupId\":" + OccupancyInfoList[i].occupancyGroupId), "The response doesnot contain the Occupancy ID for " + GetOccupancyID);

            }
        }

        //PUT Request
        [Given(@"I have request to PUT Occupancy details")]
        public void GivenIHaveRequestToPUTOccupancyDetails(Table table)
        {
            var OccupancyInfo = table.CreateSet<OccupancyInfo>();
            OccupancyInfoList = OccupancyInfo.ToList();
        }

        //PUT Request
        [Given(@"I have provided Residents Information for PUT Request\.")]
        public void GivenIHaveProvidedResidentsInformationForPUTRequest_(Table table)
        {
            var ResidentInfo = table.CreateSet<Resident>();
            ResidentInfoList = ResidentInfo.ToList();
        }

        //PUT Request
        [When(@"I send a Put request to insert the Occupancy details")]
        public void WhenISendAPutRequestToInsertTheOccupancyDetails()
        {
            init();
            var host = GetUrl("ResidentAPi");
            OccupancyInfo OccupancyInfoObj = new OccupancyInfo();
            OccupancyInfoObject ResidentInfoObj = new OccupancyInfoObject();
            var url = host + "Occupancy/";
            for (var i = 0; i < OccupancyInfoList.Count(); i++)
            {
                OccupancyInfoObj.occupancyGroupId = OccupancyInfoList[i].occupancyGroupId;
                OccupancyInfoObj.locationID = OccupancyInfoList[i].locationID;
                OccupancyInfoObj.leaseStartDate = OccupancyInfoList[i].leaseStartDate;
                OccupancyInfoObj.leaseEndDate = OccupancyInfoList[i].leaseEndDate;
                OccupancyInfoObj.createdDate = OccupancyInfoList[i].createdDate;
                OccupancyInfoObj.residents.Add(ResidentInfoList[i]);

                ResidentInfoObj.OccupancyInfo.Add(OccupancyInfoObj);
                jsonRequest = JsonConvert.SerializeObject(OccupancyInfoObj);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "application/json", "application/json", "Bearer " + token, jsonRequest);
                jsonResponseListPut.Add(jsonResponse);
            }
        }

        //PUT Request
        [Then(@"the Occupant details will be updated")]
        public void ThenTheOccupantDetailsWillBeUpdated()
        {
            for (var i = 0; i < jsonResponseListPut.Count(); i++)
            {
 //               Assert.IsTrue(jsonResponseListPut[i].Contains("\"occupancyGroupId\":" + OccupancyInfoList[i].occupancyGroupId), "The response doesnot contain the Occupancy ID for " + GetOccupancyID);

            }
        }

    }
}
