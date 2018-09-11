using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Resident_API
{
    public class SettingsInfo
    {
        public int settingsID { get; set; }
        public string settingType { get; set; }
        public bool settingValue { get; set; }
    }

    public class EntitySettingsInfo
    {
        public List<SettingsInfo> SettingsInfo = new List<SettingsInfo>();
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

    public class RootObject
    {
        public List<EntitySettingsInfo> EntitySettingsInfo = new List<EntitySettingsInfo>();
    }

    [Binding]
    public class PostWidgetSettingsSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private List<EntitySettingsInfo> entitySettingsInfoList = new List<EntitySettingsInfo>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<RootObject> rootObjectList = new List<RootObject>();
        private List<SettingsInfo> settingsinfolist = new List<SettingsInfo>();
        private string url = "";

        [Given(@"I have entered the settings information")]
        public void GivenIHaveEnteredTheSettingsInformation(Table table)
        {
            settingsinfolist = table.CreateSet<SettingsInfo>().ToList();
        }

        [Given(@"I have entered the Entity Settings information")]
        public void GivenIHaveEnteredTheEntitySettingsInformation(Table table)
        {
            entitySettingsInfoList = table.CreateSet<EntitySettingsInfo>().ToList();
        }

        [When(@"I send a post request to insert the settings information")]
        public void WhenISendAPostRequestToInsertTheSettingsInformation()
        {
            var entitySettingsInfoObj = new EntitySettingsInfo();
            var rootobj = new RootObject();
            url = hostUrl + "/ri-settingsapi/1.0.0/Widget";
            for (var i = 0; i < entitySettingsInfoList.Count; i++)
            {
                entitySettingsInfoObj.EntityId = entitySettingsInfoList[i].EntityId;
                entitySettingsInfoObj.EntityType = entitySettingsInfoList[i].EntityType;
                entitySettingsInfoObj.EntityText = entitySettingsInfoList[i].EntityText;
                entitySettingsInfoObj.Address = entitySettingsInfoList[i].Address;
                entitySettingsInfoObj.City = entitySettingsInfoList[i].City;
                entitySettingsInfoObj.State = entitySettingsInfoList[i].State;
                entitySettingsInfoObj.Zip = entitySettingsInfoList[i].Zip;
                entitySettingsInfoObj.SettingsInfo.Add(settingsinfolist[i]);
                entitySettingsInfoObj.UserId = entitySettingsInfoList[i].UserId;
                entitySettingsInfoObj.ModifiedById = entitySettingsInfoList[i].ModifiedById;

                rootobj.EntitySettingsInfo.Add(entitySettingsInfoObj);

                jsonRequest = JsonConvert.SerializeObject(rootobj);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid successful response should be generated with the data posted successfully")]
        public void ThenAValidSuccessfulResponseShouldBeGeneratedWithTheDataPostedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }
    }
}