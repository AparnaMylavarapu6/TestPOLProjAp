using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests
{
    public class PropertyInformation
    {
        public string PropertyType { get; set; }
        public string PropertyId { get; set; }
    }

    [Binding]
    public class SettingsTestSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private string jsonResponse = "";
        private List<string> propertyid = new List<string>();

        private List<PropertyInformation> propertyinfolist = new List<PropertyInformation>();
        //private PropertyInformation propertyinfoobject = new PropertyInformation();
        //private string propertytype = "";
        //private string propertyid = "";

        private List<string> propertytype = new List<string>();


        [Given(@"I have entered a valid Property type and Property id")]
        public void GivenIHaveEnteredAValidPropertyTypeAndPropertyId(Table table)
        {
            var propertyinfo = table.CreateSet<PropertyInformation>();
            propertyinfolist = propertyinfo.ToList();
            //propertyinfoobject = propertyinfo;
        }

        [When(@"I send a valid GET request to fetch the unit information")]
        public void WhenISendAValidGETRequestToFetchTheUnitInformation()
        {
            init();
            var host = hostUrl;
            var i = propertyinfolist.Count();
            for (var j = 0; j < i; j++)
            {
                var jsonRequest = host + "/ri-pmsintegrationapi/1.0.0/UnitsInfo/" + propertyinfolist[j].PropertyId +
                                  "/" + propertyinfolist[j].PropertyType;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }


            //var token = GetTokenInfo();
        }

        [Then(@"List of valid locations should be displayed")]
        public void ThenListOfValidLocationsShouldBeDisplayed()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}