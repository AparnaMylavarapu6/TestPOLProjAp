using System;
using System.Collections.Generic;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace POLTest1.Tests.Settings_API
{
    public class SettingsInformation
    {
        public string settingsID { get; set; }
    }
    public class DeleteSettingsInformation
    {
        public string settingsID { get; set; }
    }
    public class SettingsInfo
    {
        public int settingsID { get; set; }
        public string settingType { get; set; }
        public bool settingValue { get; set; }

      
        }
    public class EntitySettingsInfo
    {
        public int EntityId { get; set; }
        public int EntityType { get; set; }
        public string EntityText { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public List<SettingsInfo> SettingsInfo = new List<SettingsInfo>();
        public int UserId { get; set; }
        public int ModifiedById { get; set; }

    }
    public class PutSettingsInfo
    {
        public int settingsID { get; set; }
        public string settingType { get; set; }
        public bool settingValue { get; set; }


    }

    public class GetSettingsInfo
        {
            public int settingsID { get; set; }
            public string settingType { get; set; }
            public bool settingValue { get; set; }


        }
        public class GetEntitySettingsInfo
        {
            public int EntityId { get; set; }
            public int EntityType { get; set; }
            public string EntityText { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public int UserId { get; set; }
            public int ModifiedById { get; set; }


            
    }
    public class EntityInfo
    {
        public int EntityId { get; set; }
        public string EntityType { get; set; }
     }

    public class PropertyInfo
    {
        public int PropertyId { get; set; }
        public String PropertyType { get; set; }
    }

    public class EntitySettingsObject
    {

        public List<EntitySettingsInfo> EntitySettingsInfo = new List<EntitySettingsInfo>();
    }


    [Binding]

    public class SettingsSteps : TestBase
    {
        private string jsonResponse = null;
        private string jsonRequest = "";
        private readonly List<string> jsonResponseList = new List<string>();
        private readonly List<string> jsonResponseListPost = new List<string>();
        private readonly List<string> jsonResponseListPut = new List<string>();
        private readonly List<string> jsonResponseListGetwithEntity = new List<string>();
        private readonly List<string> jsonResponseListGetwithProperty = new List<string>();
        private List<string> lstsettingsID = new List<string>();
        private List<SettingsInformation> settingsIDlist = new List<SettingsInformation>();
        private List<DeleteSettingsInformation> DeletesettingsIDlist = new List<DeleteSettingsInformation>();
        private List<EntitySettingsInfo> EntitySettingsInfoList = new List<EntitySettingsInfo>();
        private List<SettingsInfo> SettingsInfoList = new List<SettingsInfo>();
        private List<GetSettingsInfo> GetSettingsInfo = new List<GetSettingsInfo>();
        private List<GetEntitySettingsInfo> GetEntitySettingsInfo = new List<GetEntitySettingsInfo>();
        private EntitySettingsObject entitySettingsObject = new EntitySettingsObject();
        private List<EntitySettingsObject> EntitySettingsObjectList = new List<EntitySettingsObject>();
        private List<EntityInfo> EntityInfoList = new List<EntityInfo>();
        private List<PropertyInfo> PropertyInfoList = new List<PropertyInfo>();

        private int EntityId;
        private string EntityType;
        private string propertyId;
        private string propertyType;
        public string GetsettingsID;
        public string DelsettingsID;
        public string settingType;
        public bool settingValue;


        //GET Method
        [Given(@"Provided with the valid SettingsID\.")]
        public void GivenProvidedWithTheValidSettingsID_(Table table)
        {
            Console.WriteLine("Testpass");
            var SettingsTableList = table.CreateSet<SettingsInformation>();
            var settingsTableList = SettingsTableList.ToList();
            var count = settingsTableList.Count();
            for (var i = 0; i < count; i++) settingsIDlist.Add(settingsTableList[i]);
        }

        //GET Method
        [When(@"I send a GET request to fetch settings details\.")]
        public void WhenISendAGETRequestToFetchSettingsDetails_()
        {
            var count = settingsIDlist.Count();
            init();
           var host = GetUrl("SettingsApi");
          // var token = GetTokenInfo();
            for (var i = 0; i < count; i++)
            {
                GetsettingsID = settingsIDlist[i].settingsID;
                var jsonRequest = host + "/Widget/" + GetsettingsID;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "", "text/plain", "Bearer " + token, "");
                jsonResponseList.Add(jsonResponse);

            }
        }

        //GET Method
        [Then(@"The valid settings details should be displayed\.")]
        public void ThenTheValidSettingsDetailsShouldBeDisplayed_()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
            {
                Assert.IsTrue(jsonResponseList[i].Contains("\"settingsId\":" + GetsettingsID), "The response doesnot contain the settings ID for "+ GetsettingsID);

            }
        }


        //DELETE Method
        [Given(@"Provided with the valid SettingsID to be deleted\.")]
        public void GivenProvidedWithTheValidSettingsIDToBeDeleted_(Table table)
        {
            var SettingsTableList = table.CreateSet<DeleteSettingsInformation>();
            var settingsTableList = SettingsTableList.ToList();
            var count = settingsTableList.Count();
            for (var i = 0; i < count; i++) DeletesettingsIDlist.Add(settingsTableList[i]);
        }

        //DELETE Method
        [When(@"I send a DELETE request to Delete settings details\.")]
        public void WhenISendADELETERequestToDeleteSettingsDetails_()
        {
            var count = DeletesettingsIDlist.Count();
            init();
            var host = GetUrl("SettingsApi");
            //var token = GetTokenInfo();
            for (var i = 0; i < count; i++)
            {
                DelsettingsID = DeletesettingsIDlist[i].settingsID;
                var jsonRequest = host + "/Widget/" + DelsettingsID;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "DELETE", acceptHeader:"application/json", authHeader:"Bearer " + token,jsonPostPayload: "");
                jsonResponseList.Add(jsonResponse);

            }
        }

        //DELETE Method
        [Then(@"The settings details should be deleted\.")]
        public void ThenTheSettingsDetailsShouldBeDeleted_()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.IsNotNull(jsonResponse);
        }

        //Post 
        [Given(@"I have provided Entity Settings details\.")]
        public void GivenIHaveProvidedEntitySettingsDetails_(Table table)
        {
            var entitySettingsInfo = table.CreateSet<EntitySettingsInfo>();
            EntitySettingsInfoList = entitySettingsInfo.ToList();
        }

        //Post
        [Given(@"Provided with the new SettingsInfo details\.")]
        public void GivenProvidedWithTheNewSettingsInfoDetails_(Table table)
        {
            var SettingsInfo = table.CreateSet<SettingsInfo>();
            SettingsInfoList = SettingsInfo.ToList();
        }

        //POST Method
        [When(@"I send a POST request to add new settings")]
        public void WhenISendAPOSTRequestToAddNewSettings()
        {
            init();
            var host = GetUrl("SettingsApi");
            EntitySettingsInfo entitySettingsInfoObj = new EntitySettingsInfo();
            EntitySettingsObject entitySettingsObject = new EntitySettingsObject();
            var url = host + "/Widget/";
            for (var i = 0; i < EntitySettingsInfoList.Count(); i++)
            {
                entitySettingsInfoObj.EntityId = EntitySettingsInfoList[i].EntityId;
                entitySettingsInfoObj.EntityType = EntitySettingsInfoList[i].EntityType;
                entitySettingsInfoObj.EntityText = EntitySettingsInfoList[i].EntityText;
                entitySettingsInfoObj.Address = EntitySettingsInfoList[i].Address;
                entitySettingsInfoObj.City = EntitySettingsInfoList[i].City;
                entitySettingsInfoObj.State = EntitySettingsInfoList[i].State;
                entitySettingsInfoObj.Zip = EntitySettingsInfoList[i].Zip;
                entitySettingsInfoObj.UserId = EntitySettingsInfoList[i].UserId;
                entitySettingsInfoObj.ModifiedById = EntitySettingsInfoList[i].ModifiedById;
                entitySettingsInfoObj.SettingsInfo.Add(SettingsInfoList[i]);
                entitySettingsObject.EntitySettingsInfo.Add(entitySettingsInfoObj);

                jsonRequest = JsonConvert.SerializeObject(entitySettingsObject);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "application/json", "application/json", "Bearer " + token, jsonRequest);
                jsonResponseListPost.Add(jsonResponse);
            }
        }

        //POST Method
        [Then(@"The valid settings details should be saved\.")]
        public void ThenTheValidSettingsDetailsShouldBeSaved_()
        {
            for (var i = 0; i < jsonResponseListPost.Count(); i++)
            {
                Assert.IsTrue(jsonResponseListPost[i].Contains("\"success\":true"), "The Entitysettings details are not posted successfully");
            }
        }


        [Given(@"I have provided Entity Settings details for PUT Request\.")]
        public void GivenIHaveProvidedEntitySettingsDetailsForPUTRequest_(Table table)
        {
            var entitySettingsInfo = table.CreateSet<EntitySettingsInfo>();
            EntitySettingsInfoList = entitySettingsInfo.ToList();
        }

        [Given(@"Provided with the new SettingsInfo details for PUT\.")]
        public void GivenProvidedWithTheNewSettingsInfoDetailsForPUT_(Table table)
        {
            var SettingsInfo = table.CreateSet<SettingsInfo>();
            SettingsInfoList = SettingsInfo.ToList();
        }

        //PUT Method
        [When(@"I send a PUT request to update new settings")]
        public void WhenISendAPUTRequestToUpdateNewSettings()
        {

            init();
            var host = GetUrl("SettingsApi");
           EntitySettingsInfo putentitySettingsInfoObj = new EntitySettingsInfo();
           EntitySettingsObject putentitySettingsObject = new EntitySettingsObject();

            var url = host + "/Widget/";
            for (var i = 0; i < EntitySettingsInfoList.Count(); i++)
            {
     
                putentitySettingsInfoObj.EntityId = EntitySettingsInfoList[i].EntityId;
                putentitySettingsInfoObj.EntityType = EntitySettingsInfoList[i].EntityType;
                putentitySettingsInfoObj.EntityText = EntitySettingsInfoList[i].EntityText;
                putentitySettingsInfoObj.Address = EntitySettingsInfoList[i].Address;
                putentitySettingsInfoObj.City = EntitySettingsInfoList[i].City;
                putentitySettingsInfoObj.State = EntitySettingsInfoList[i].State;
                putentitySettingsInfoObj.Zip = EntitySettingsInfoList[i].Zip;
                putentitySettingsInfoObj.UserId = EntitySettingsInfoList[i].UserId;
                putentitySettingsInfoObj.ModifiedById = EntitySettingsInfoList[i].ModifiedById;
                putentitySettingsInfoObj.SettingsInfo.Add(SettingsInfoList[i]);

                putentitySettingsObject.EntitySettingsInfo.Add(putentitySettingsInfoObj);
                jsonRequest = JsonConvert.SerializeObject(putentitySettingsObject);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "application/json-patch+json", "application/json", "Bearer " + token, jsonRequest);
                jsonResponseListPut.Add(jsonResponse);
            }
        }

        //PUT Method
        [Then(@"The valid settings details should be updated\.")]
        public void ThenTheValidSettingsDetailsShouldBeUpdated_()
        {
            for (var i = 0; i < jsonResponseListPut.Count(); i++) {

                   Assert.IsTrue(jsonResponseListPut[i].Contains("\"success\":true"), "The Entitysettings details are not updated");
            }
        }

        //GET Method with multiple parameters EntityID and Entitytype
        [Given(@"Provided with the valid EntityID and EntityType\.")]
            public void GivenProvidedWithTheValidEntityIDAndEntityType_(Table table)
            {
            var EntityInfo = table.CreateSet<EntityInfo>();
            EntityInfoList = EntityInfo.ToList();
            }

            //GET Method with multiple parameters EntityID and Entitytype    
            [When(@"I send a GET request to fetch settings details EntityID and EntityType\.")]
            public void WhenISendAGETRequestToFetchSettingsDetailsEntityIDAndEntityType_()
            {

            init();
            var host = GetUrl("SettingsApi");
            var url = host + "Widget/";
            for (var i = 0; i < EntityInfoList.Count(); i++)
            {
                EntityId = EntityInfoList[i].EntityId;
                EntityType = EntityInfoList[i].EntityType.ToString();
                jsonRequest = url + EntityType + "/" + EntityId;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "text/plain", "application/json", "Bearer " + token, "");
                jsonResponseListGetwithEntity.Add(jsonResponse);
            }
        }

            //GET Method with multiple parameters EntityID and Entitytype
            [Then(@"The valid settings details should be displayed based on EntityID and EntityType\.")]
            public void ThenTheValidSettingsDetailsShouldBeDisplayedBasedOnEntityIDAndEntityType_()
            {
            for (var i = 0; i < jsonResponseListGetwithEntity.Count(); i++)
             {
                    Assert.IsTrue(jsonResponseListGetwithEntity[i].Contains("\"EntityId\":" + EntityInfoList[i].EntityId), "The settings details are not displayed when fetched based on EntityID and EntityType for "+EntityInfoList[i].EntityId); 
            }
        }

            //GET Method with multiple parameters PropertyID and PropertyType
            [Given(@"Provided with the valid PropertyID and PropertyType\.")]
            public void GivenProvidedWithTheValidPropertyIDAndPropertyType_(Table table)
            {
            var PropertyInfo = table.CreateSet<PropertyInfo>();
            PropertyInfoList = PropertyInfo.ToList();
            }
    

            //GET Method with multiple parameters PropertyID and PropertyType
            [When(@"I send a GET request to fetch settings details PropertyID and PropertyType\.")]
            public void WhenISendAGETRequestToFetchSettingsDetailsPropertyIDAndPropertyType_()
            {
                init();
                var host = GetUrl("SettingsApi");
                var url = host + "/Widget/PropertyType/";
                for (var i = 0; i < PropertyInfoList.Count(); i++)
                {
                    propertyId = PropertyInfoList[i].PropertyId.ToString();
                    propertyType = PropertyInfoList[i].PropertyType;
                    jsonRequest = url + propertyType + "/PropertyId/" + propertyId;
                    jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "text/plain", "application/json", "Bearer " + token, "");
                    jsonResponseListGetwithProperty.Add(jsonResponse);
                }
            }
            //GET Method with multiple parameters PropertyID and PropertyType
            [Then(@"The valid settings details should be displayed based on PropertyID and PropertyType\.")]
            public void ThenTheValidSettingsDetailsShouldBeDisplayedBasedOnPropertyIDAndPropertyType_()
            {
            for (var i = 0; i < jsonResponseListGetwithProperty.Count(); i++)
               {
                //Assert.IsTrue(jsonResponseListGetwithProperty[i].Contains("\"EntityType\":" [1-2]), "The settings details are not displayed when fetched based on "+ PropertyInfoList[i].PropertyType +" and "+ PropertyInfoList[i].PropertyId); }
            Assert.IsTrue((jsonResponseListGetwithProperty[i].Contains("\"EntityType\":1")|| jsonResponseListGetwithProperty[i].Contains("\"EntityType\":2")), "The settings details are not displayed when fetched based on " + PropertyInfoList[i].PropertyType + " and " + PropertyInfoList[i].PropertyId);
        }
        
            }

    }

}
