using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_Enrollment_API
{
    public class AuthInfo
    {
        public string userId { get; set; }
        public string password { get; set; }
    }

    public class PropertyInfo
    {
        public string propertyIdType { get; set; }
        public string propertyID { get; set; }
    }

    public class PropertyTypeInfo
    {
        public string propertyIdType { get; set; }
        public string propertyID { get; set; }
    }

    public class UnitInfo
    {
        public string UnitIDType { get; set; }
        public string UnitID { get; set; }
    }

    public class Resident
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class ResidentInfo
    {
        public Resident resident { get; set; }
        public string externalResID { get; set; }
        public bool isPrimaryResident { get; set; }
        public string dateofBirth { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
    }

    public class ErrorInfo
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class LeaseInfo
    {
        public string coverageDate { get; set; }
        public string quoteRequestSource { get; set; }
        public int leaseID { get; set; }
        public bool isRenewal { get; set; }
    }

    public class WidgetSettingsObject
    {
        public AuthInfo authInfo { get; set; }
        public PropertyInfo propertyInfo { get; set; }
        public UnitInfo unitInfo { get; set; }
        public ResidentInfo residentInfo { get; set; }
        public ErrorInfo errorInfo { get; set; }
        public LeaseInfo LeaseInfo { get; set; }
    }

    [Binding]
    public class PropertyInfoSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private List<AuthInfo> authInfoList = new List<AuthInfo>();
        private List<ErrorInfo> errorinfolist = new List<ErrorInfo>();

        private string jsonRequest = "";
        private string jsonResponse = "";
        private List<LeaseInfo> leaseInfolist = new List<LeaseInfo>();
        private List<PropertyInfo> PropertyInfoList = new List<PropertyInfo>();
        private List<PropertyTypeInfo> PropertyTypeInfoList = new List<PropertyTypeInfo>();
        private List<ResidentInfo> residentinfolist = new List<ResidentInfo>();
        private List<Resident> residentnamelist = new List<Resident>();
        private List<UnitInfo> unitinfolist = new List<UnitInfo>();
        private List<WidgetSettingsObject> widgetObjectlist = new List<WidgetSettingsObject>();


        [Given(@"I have entered the property type information")]
        public void GivenIHaveEnteredThePropertyTypeInformation(Table table)
        {
            var propertyInfo = table.CreateSet<PropertyInfo>();
            PropertyInfoList = propertyInfo.ToList();
        }

        [When(@"I send a POST request with the property type information input")]
        public void WhenISendAPOSTRequestWithThePropertyTypeInformationInput()
        {
            init();
            var url = hostUrl + "/ri-policyenrollmentapi/1.0.0/GetPropertyStatus";
            for (var i = 0; i < PropertyInfoList.Count(); i++)
            {
                jsonRequest = JsonConvert.SerializeObject(PropertyInfoList[i]);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A successful property status response should be generated")]
        public void ThenASuccessfulPropertyStatusResponseShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Given(@"I have entered the property type information to the GetPropertyAddress method as input")]
        public void GivenIHaveEnteredThePropertyTypeInformationToTheGetPropertyAddressMethodAsInput(Table table)
        {
            var propertytypeinfo = table.CreateSet<PropertyTypeInfo>();
            PropertyTypeInfoList = propertytypeinfo.ToList();
        }

        [When(@"I send a POST request to the GetPropertyAddress method")]
        public void WhenISendAPOSTRequestToTheGetPropertyAddressMethod()
        {
            init();
            var url = "";
            string _propertytype;
            string _propertyid;
            for (var i = 0; i < PropertyTypeInfoList.Count(); i++)
            {
                _propertytype = PropertyTypeInfoList[i].propertyIdType;
                _propertyid = PropertyTypeInfoList[i].propertyID;
                url = hostUrl + "ri-policyenrollmentapi/1.0.0/GetPropertyAddresses/PropertyIDType" + _propertytype +
                      "PropertyID" + _propertyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A Valid Property Addresses response should be generated")]
        public void ThenAValidPropertyAddressesResponseShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }


        [Given(@"I have entered the authentication information")]
        public void GivenIHaveEnteredTheAuthenticationInformation(Table table)
        {
            var authinfo = table.CreateSet<AuthInfo>();
            authInfoList = authinfo.ToList();
        }

        [Given(@"I have entered the property information")]
        public void GivenIHaveEnteredThePropertyInformation(Table table)
        {
            var propertyinfo = table.CreateSet<PropertyInfo>();
            PropertyInfoList = propertyinfo.ToList();
        }

        [Given(@"I have entered the unit information")]
        public void GivenIHaveEnteredTheUnitInformation(Table table)
        {
            var unitinfo = table.CreateSet<UnitInfo>();
            unitinfolist = unitinfo.ToList();
        }

        [Given(@"I have entered the Resident details")]
        public void GivenIHaveEnteredTheResidentDetails(Table table)
        {
            //var residentnamelist = table.CreateSet<Resident>();
            var residentlist = table.CreateSet<Resident>();
            residentnamelist = residentlist.ToList();
        }

        [Given(@"I have entered the resident personal information")]
        public void GivenIHaveEnteredTheResidentPersonalInformation(Table table)
        {
            var personalinfo = table.CreateSet<ResidentInfo>();
            residentinfolist = personalinfo.ToList();
        }

        [Given(@"I have entered the error code information")]
        public void GivenIHaveEnteredTheErrorCodeInformation(Table table)
        {
            var errorinfo = table.CreateSet<ErrorInfo>();
            errorinfolist = errorinfo.ToList();
        }

        [Given(@"I have entered other lease information")]
        public void GivenIHaveEnteredOtherLeaseInformation(Table table)
        {
            var leaseinfo = table.CreateSet<LeaseInfo>();
            leaseInfolist = leaseinfo.ToList();
        }

        [When(@"I send a POST request to fetch the widget settings")]
        public void WhenISendAPOSTRequestToFetchTheWidgetSettings()
        {
            var widgetobj = new WidgetSettingsObject();
            init();
            var url = hostUrl + "/ri-policyenrollmentapi/1.0.0/GetWidgetSettings";
            for (var i = 0; i < PropertyInfoList.Count(); i++)
            {
                widgetobj.authInfo = authInfoList[i];
                widgetobj.propertyInfo = PropertyInfoList[i];
                widgetobj.unitInfo = unitinfolist[i];
                widgetobj.residentInfo = residentinfolist[i];
                widgetobj.LeaseInfo = leaseInfolist[i];
                widgetobj.errorInfo = errorinfolist[i];
                jsonRequest = JsonConvert.SerializeObject(widgetobj);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid settings response should be generated")]
        public void ThenAValidSettingsResponseShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}