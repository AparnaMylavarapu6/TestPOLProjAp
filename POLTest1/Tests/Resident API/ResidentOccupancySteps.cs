using System;
using System.Collections.Generic;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace POLTest1.Tests.Resident_API
{

    public class ResidentName
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class AddlnResidentInfo
    {
        public ResidentName resident = new ResidentName();
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string externalResID { get; set; }
        public bool isPrimaryResident { get; set;}
        public DateTime dateOfBirth { get; set; }
        public int residentid { get; set; }
    }

    public class MailingAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }   
        public string zipCode { get; set; }
    }

    public class ResidentOccupancyInfo
    {
        public int resType { get; set; }
        public List<AddlnResidentInfo> res = new List<AddlnResidentInfo>();
         public MailingAddress mailingAddress = new MailingAddress();
        public int locationID { get; set; }
        public string leaseStartDate { get; set; }
        public string leaseEndDate { get; set; }
    }
    public class ResidentOccupancyObject
    {
        public List<ResidentOccupancyInfo> ResidentOccupancyObj = new List<ResidentOccupancyInfo>();
    }

    [Binding]
    public class ResidentOccupancySteps : TestBase
    {
        private string jsonResponse = null;
        private string jsonRequest = "";
        private readonly List<string> jsonResponseListPost = new List<string>();

        private List<ResidentOccupancyInfo> ResidentOccupancyDetails = new List<ResidentOccupancyInfo>();
        private List<ResidentName> ResidentNameDetails = new List<ResidentName>();
        private List<AddlnResidentInfo> AddlnResidentDetails = new List<AddlnResidentInfo>();
        private List<MailingAddress> MailingAddressDetails = new List<MailingAddress>();

        [Given(@"I have to Post ResidentOccupancy details")]
        public void GivenIHaveToPostResidentOccupancyDetails(Table table)
        {
           var ResidentOccupancyInfoList = table.CreateSet<ResidentOccupancyInfo>();
            var residentOccupancyInfoList = ResidentOccupancyInfoList.ToList();
            var count = residentOccupancyInfoList.Count();
            for (var i = 0; i < count; i++) ResidentOccupancyDetails.Add(residentOccupancyInfoList[i]);
        }

        [Given(@"I have provided Residents Name Information\.")]
        public void GivenIHaveProvidedResidentsNameInformation_(Table table)
        {
            var ResidentNameList = table.CreateSet<ResidentName>();
            var residentNameList = ResidentNameList.ToList();
            var count = residentNameList.Count();
            for (var i = 0; i < count; i++) ResidentNameDetails.Add(residentNameList[i]);
          
        }

        [Given(@"Provided additional Resident details")]
        public void GivenProvidedAdditionalResidentDetails(Table table)
        {
            var AddlnResidentDetailsList = table.CreateSet<AddlnResidentInfo>();
            var addlnResidentDetailsList = AddlnResidentDetailsList.ToList();
            var count = addlnResidentDetailsList.Count();
            for (var i = 0; i < count; i++) AddlnResidentDetails.Add(addlnResidentDetailsList[i]);

        }
        
        [Given(@"I have provided Mailing Address Information\.")]
        public void GivenIHaveProvidedMailingAddressInformation_(Table table)
        {
            var MailingAddressList = table.CreateSet<MailingAddress>();
            var mailingAddressList = MailingAddressList.ToList();
            var count = mailingAddressList.Count();
            for (var i = 0; i < count; i++) MailingAddressDetails.Add(mailingAddressList[i]);
         }
        
        [When(@"I send a Post request to insert the ResidentOccupancy details")]
        public void WhenISendAPostRequestToInsertTheResidentOccupancyDetails()
        {

            init();
            var host = GetUrl("ResidentApi");
            ResidentOccupancyInfo residentOccupancyInfoObj = new ResidentOccupancyInfo();
            ResidentName ResidentNameobj = new ResidentName();
            MailingAddress mailingaddressobj = new MailingAddress();

            var url = host + "/ResidentOccupancy/";
            for (var i = 0; i < ResidentOccupancyDetails.Count(); i++)
            {
                residentOccupancyInfoObj.resType = ResidentOccupancyDetails[i].resType;
                residentOccupancyInfoObj.locationID = ResidentOccupancyDetails[i].locationID;
                residentOccupancyInfoObj.leaseStartDate = ResidentOccupancyDetails[i].leaseStartDate;
                residentOccupancyInfoObj.leaseEndDate = ResidentOccupancyDetails[i].leaseEndDate;

                mailingaddressobj.addressLine1 = MailingAddressDetails[i].addressLine1;
                mailingaddressobj.addressLine2 = MailingAddressDetails[i].addressLine2;
                mailingaddressobj.city = MailingAddressDetails[i].city;
                mailingaddressobj.state = MailingAddressDetails[i].state;
                mailingaddressobj.zipCode = MailingAddressDetails[i].zipCode;

                AddlnResidentDetails[i].resident.firstName= ResidentNameDetails[i].firstName;
                AddlnResidentDetails[i].resident.middleName = ResidentNameDetails[i].middleName;
                AddlnResidentDetails[i].resident.lastName = ResidentNameDetails[i].lastName;

                residentOccupancyInfoObj.res.Add(AddlnResidentDetails[i]);
                residentOccupancyInfoObj.mailingAddress.addressLine1= MailingAddressDetails[i].addressLine1;
                residentOccupancyInfoObj.mailingAddress.addressLine2 = MailingAddressDetails[i].addressLine2;
                residentOccupancyInfoObj.mailingAddress.city = MailingAddressDetails[i].city;
                residentOccupancyInfoObj.mailingAddress.state = MailingAddressDetails[i].state;
                residentOccupancyInfoObj.mailingAddress.zipCode = MailingAddressDetails[i].zipCode;
  
                jsonRequest = JsonConvert.SerializeObject(residentOccupancyInfoObj);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "application/json", "application/json", "Bearer " + token, jsonRequest);
                jsonResponseListPost.Add(jsonResponse);
            }
        }
        
        [Then(@"The ResidentOccupancy details should be posted")]
        public void ThenTheResidentOccupancyDetailsShouldBePosted()
        {
            for (var i = 0; i < jsonResponseListPost.Count(); i++)
            {
               // Assert.IsTrue(jsonResponseListPost[i].Contains("\"firstName\":\"+ ResidentNameDetails[i].firstName), ""The Resident and occupancy are not posted successfully"");
            }
        }
    }
}
