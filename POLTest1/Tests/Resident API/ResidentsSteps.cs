using System;
using TechTalk.SpecFlow;
using RentersInsuranceApiTests;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POL_Test.Tests.ResidentAPI
{
    public class GetResidentDetails
    {
        public string residentID { get; set; }
    }

    public class DelResidentDetails
    {
        public string residentID { get; set; }
    }

    //Post

    public class Resident
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class ResidentInfo
    {
        public Resident resident { get; set; }
        public string email { get; set; }
        public long mobileNumber { get; set; }
        public string externalResID { get; set; }
        public bool isPrimaryResident { get; set; }
        public string dateOfBirth { get; set; }
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

    public class PostResidentsDetails
    {
        public string resType { get; set; }
        public List<ResidentInfo> residentInfo { get; set; }
        public MailingAddress mailingAddress { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int mobileNumber { get; set; }
        public string externalResID { get; set; }
        public string dateOfBirth { get; set; }
        public bool isPrimaryResident { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

    }

    //Put

    public class Rsdnt
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class Rsdt
    {
        public Resident resident { get; set; }
        public string email { get; set; }
        public long mobileNumber { get; set; }
        public string externalResID { get; set; }
        public bool isPrimaryResident { get; set; }
        public string dateOfBirth { get; set; }
        public int residentid { get; set; }
    }

    public class PutMailingAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class PutResidentDetails
    {
        public string resType { get; set; }
        public List<Rsdt> res { get; set; }
        public PutMailingAddress putMailingAddress { get; set; }
        public Rsdnt rsdnt { get; set; }

    }


    [Binding]
    public class ResidentsSteps:TestBase
    {
        private GetResidentDetails getResidentDetails = new GetResidentDetails();
        private List<GetResidentDetails> NewResidentList = new List<GetResidentDetails>();
        private DelResidentDetails delResidentDetails = new DelResidentDetails();
        private List<DelResidentDetails> DelResidentList = new List<DelResidentDetails>();
        private PostResidentsDetails postResidentsDetails = new PostResidentsDetails();
        private PutResidentDetails putResidentDetails = new PutResidentDetails();
        private Resident resident = new Resident();
        private ResidentInfo residentInfo = new ResidentInfo();
        private MailingAddress mailingAddress = new MailingAddress();
        private Rsdnt rsdnt = new Rsdnt();
        private Rsdt rsdt = new Rsdt();
        private PutMailingAddress putMailingAddress = new PutMailingAddress();
        private string firstName;
        private string middleName;
        private string lastName;
        private string email;
        private long mobileNumber;
        private string externalResID;
        private bool isPrimaryResident;
        private string dateOfBirth;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string state;
        private string zipCode;
        private string resType;
        private string jsonResponse = "";
        private string jsonRequest = "";

        [Given(@"I have resident deatils")]
        public void GivenIHaveResidentDeatils(Table table)
        {
            var ResidentList = table.CreateSet<GetResidentDetails>();
            var residentList = ResidentList.ToList();
            var count = residentList.Count();
            for (var i = 0; i < count; i++)
                NewResidentList.Add(residentList[i]);
        }
        
        [Given(@"I have to Delete resident deatils")]
        public void GivenIHaveToDeleteResidentDetails(Table table)
        {
            var DeleteResidentList = table.CreateSet<DelResidentDetails>();
            var deleteResidentList = DeleteResidentList.ToList();
            var count = deleteResidentList.Count();
            for (var i = 0; i < count; i++)
                DelResidentList.Add(deleteResidentList[i]);

        }
        
        [Given(@"I have to Post new resident deatils")]
        public void GivenIHaveToPostNewResidentDetails(Table table)
        {
            var postResidentsDetails = table.CreateInstance<PostResidentsDetails>();
            resType = postResidentsDetails.resType;
            firstName = postResidentsDetails.firstName;
            middleName = postResidentsDetails.middleName;
            lastName = postResidentsDetails.lastName;
            email = postResidentsDetails.email;
            mobileNumber = postResidentsDetails.mobileNumber;
            externalResID = postResidentsDetails.externalResID;
            isPrimaryResident = postResidentsDetails.isPrimaryResident;
            dateOfBirth = postResidentsDetails.dateOfBirth;
            addressLine1 = postResidentsDetails.addressLine1;
            addressLine2 = postResidentsDetails.addressLine2;
            city = postResidentsDetails.city;
            state = postResidentsDetails.state;
            zipCode = postResidentsDetails.zipCode;

        }
        
        [Given(@"I have to update resident deatils")]
        public void GivenIHaveToUpdateResidentDetails(Table table)
        {
            var putResidentDetails = table.CreateInstance<PutResidentDetails>();
            resType = putResidentDetails.resType;
            
        }
        
        [When(@"I pass the residentid for a get request")]
        public void WhenIPassTheResidentidForAGetRequest()
        {
            var count = NewResidentList.Count();
            init();
            var token = GetTokenInfo();
            for (var i = 0; i < count; i++)
            {
                var _ResidentID = NewResidentList[i].residentID;
                endPointUrl = "http://swaggerhub.dev.realpage.com/virts/Realpage/ri-residentapi/1.0.0/Resident/" + _ResidentID;

                jsonResponse = doExecuteApiWithHeaders(endPointUrl, "GET", "application/json-patch+json", "application/json", "Bearer " + token, jsonResponse);
                Console.WriteLine(jsonResponse);
            }
        }
        
        [When(@"I pass the residnet id for a delete request")]
        public void WhenIPassTheResidnetIdForADeleteRequest()
        {
            var count = DelResidentList.Count();
            init();
            var token = GetTokenInfo();
            for (var i = 0; i < count; i++)
            {
                var _ResidentID = NewResidentList[i].residentID;
                endPointUrl = "http://swaggerhub.dev.realpage.com/virts/Realpage/ri-residentapi/1.0.0/Resident/" + _ResidentID;

                jsonResponse = doExecuteApiWithHeaders(endPointUrl, "GET", "application/json-patch+json", "application/json", "Bearer " + token, jsonResponse);
                Console.WriteLine(jsonResponse);
            }

        }
        
        [When(@"I pass the resident id for a post request")]
        public void WhenIPassTheResidentIdForAPostRequest()
        {
            init();
            jsonRequest = JsonConvert.SerializeObject(postResidentsDetails);
            endPointUrl = "http://swaggerhub.dev.realpage.com/virts/Realpage/ri-quoteapi/1.0.0/POL/";
            jsonResponse = doExecuteApiWithHeaders(endPointUrl, "POST", "json", "application/json", "", jsonRequest);
        }
        
        [When(@"I pass the resident id for a put request")]
        public void WhenIPassTheResidentIdForAPutRequest()
        {
            init();
            jsonRequest = JsonConvert.SerializeObject(putResidentDetails);
            endPointUrl = "http://swaggerhub.dev.realpage.com/virts/Realpage/ri-quoteapi/1.0.0/POL/";
            jsonResponse = doExecuteApiWithHeaders(endPointUrl, "POST", "json", "application/json", "", jsonRequest);
        }
        
        [Then(@"the resident details should be displayed")]
        public void ThenTheResidentDetailsShouldBeDisplayed()
        {
            Assert.IsNotNull(jsonResponse);
        }
        
        [Then(@"the Delete resident details should be displayed")]
        public void ThenTheDeleteResidentDetailsShouldBeDisplayed()
        {
            Assert.IsNotNull(jsonResponse);
        }
        
        [Then(@"the post resident details should be displayed")]
        public void ThenThePostResidentDetailsShouldBeDisplayed()
        {
            Assert.IsNotNull(jsonResponse);
        }
        
        [Then(@"the put resident details should be displayed")]
        public void ThenThePutResidentDetailsShouldBeDisplayed()
        {
            Assert.IsNotNull(jsonResponse);
        }
    }
}
