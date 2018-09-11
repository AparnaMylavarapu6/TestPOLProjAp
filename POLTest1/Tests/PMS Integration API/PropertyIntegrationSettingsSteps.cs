using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests
{
    public class PropertyInfo
    {
        public string PropertyType { get; set; }
        public string PropertyId { get; set; }
    }

    [Binding]
    public class PropertyIntegrationSettingsSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string jsonResponse = "";
        private string propertyid = "";
        private string propertyType = "";
        private List<PropertyInfo> propinfolist = new List<PropertyInfo>();

        [Given(@"I have entered a valid property type and propertyid")]
        public void GivenIHaveEnteredAValidPropertyTypeAndPropertyid(Table table)
        {
            var propinfo = table.CreateSet<PropertyInfo>();
            propinfolist = propinfo.ToList();
        }

        [When(@"I send a valid GET request to fetch the Integration information")]
        public void WhenISendAValidGETRequestToFetchTheIntegrationInformation()
        {
            init();
            for (var i = 0; i < propinfolist.Count(); i++)
            {
                propertyType = propinfolist[i].PropertyType;
                propertyid = propinfolist[i].PropertyId;
                var jsonRequest = hostUrl + "/ri-pmsintegrationapi/1.0.0/IntegrationSettings/" + propertyid + "/" +
                                  propertyType;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"Valid Integration settings should be displayed")]
        public void ThenValidIntegrationSettingsShouldBeDisplayed()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}