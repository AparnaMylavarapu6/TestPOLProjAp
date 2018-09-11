using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests
{
    public class PolicyIdInformation
    {
        public string policyid { get; set; }
    }

    public class PolicyIdDelete
    {
        public string policyid { get; set; }
        public string thirdpartypolicyid { get; set; }
    }

    public class PolicyInfo
    {
        public int policyID { get; set; }
        public string policyStatus { get; set; }
        public int policyNumber { get; set; }
        public string policyTitle { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
        public string cancelDate { get; set; }
        public int PolicyLiabilityLimit { get; set; }
        public bool isCorporate { get; set; }
        public string policyActionType { get; set; }
    }

    public class LeaseInfo
    {
        public int leaseId { get; set; }
        public string leaseStartDate { get; set; }
        public string leaseEndDate { get; set; }
        public string actualMoveIn { get; set; }
        public string actualMoveOut { get; set; }
    }

    public class LarrierInfo
    {
        public int carrierId { get; set; }
        public string carrierName { get; set; }
    }

    public class ResidentInfo
    {
        public string residentHOHID { get; set; }
        public string residentMemberID { get; set; }
        public string residentHOHFirstName { get; set; }
        public string residentHOHLastName { get; set; }
    }

    public class PolicyByProperty
    {
        public string propertytype { get; set; }
        public string propertyid { get; set; }
    }

    public class OccupancyByProperty
    {
        public string propertytype { get; set; }
        public string propertyid { get; set; }
    }

    public class PolicyObject
    {
        public PolicyInfo policyInfo { get; set; }
        public LeaseInfo leaseInfo { get; set; }
        public LarrierInfo larrierInfo { get; set; }
        public ResidentInfo residentInfo { get; set; }
        public long externalUnitId { get; set; }
    }

    [Binding]
    public class PMSPoliciesSteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        private readonly List<string> jsonResponseListPost = new List<string>();
        private readonly List<string> jsonResponseListPut = new List<string>();
        private readonly PolicyObject policyObject = new PolicyObject();
        private string _policyid = "";
        private string _policyiddelete = "";
        private string _thirdpartypolicyid = "";
        private string actualMoveIn = "";
        private string actualMoveOut = "";
        private string cancelDate = "";
        private int carrierId = 0;
        private List<LarrierInfo> CarrierInfoList = new List<LarrierInfo>();
        private LarrierInfo carrierInfoObject = new LarrierInfo();
        private string carrierName = "";
        private string effectiveDate = "";
        private string expiryDate = "";
        private long externalUnitId;
        private bool isCorporate = true;
        private string jsonRequest = "";
        private string jsonResponse = "";
        private string leaseEndDate = "";
        private int leaseId = 0;
        private List<LeaseInfo> LeaseInfoList = new List<LeaseInfo>();
        private LeaseInfo leaseInfoObject = new LeaseInfo();
        private string leaseStartDate = "";
        private List<OccupancyByProperty> occupancyInfoList = new List<OccupancyByProperty>();
        private string policyActionType = "";
        private int policyID = 0;
        private List<PolicyIdInformation> PolicyIdList = new List<PolicyIdInformation>();
        private List<PolicyIdDelete> PolicyIdListDelete = new List<PolicyIdDelete>();
        private List<PolicyInfo> PolicyInfoList = new List<PolicyInfo>();

        private PolicyInfo policyInfoObject = new PolicyInfo();
        private int PolicyLiabilityLimit = 0;
        private int policyNumber = 0;
        private string policyStatus = "";
        private string policyTitle = "";
        private string propertyId = "";
        private List<PolicyByProperty> propertyInfoList = new List<PolicyByProperty>();

        private string propertyType = "";
        private string residentHOHFirstName = "";
        private string residentHOHID = "";
        private string residentHOHLastName = "";
        private List<ResidentInfo> ResidentInfoList = new List<ResidentInfo>();
        private ResidentInfo residentInfoObject = new ResidentInfo();
        private string residentMemberID = "";


        /* Code for fetching the policy information when policyid is provided */

        [Given(@"I have entered a valid PolicyId")]
        public void GivenIHaveEnteredAValidPolicyId(Table table)
        {
            var policyIdInfo = table.CreateSet<PolicyIdInformation>();
            PolicyIdList = policyIdInfo.ToList();
        }


        [When(@"I send a valid GET request")]
        public void WhenISendAValidGETRequest()
        {
            init();

            for (var i = 0; i < PolicyIdList.Count(); i++)
            {
                _policyid = PolicyIdList[i].policyid;
                jsonRequest = hostUrl + "/ri-pmsintegrationapi/1.0.0/Policy/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }


        [Then(@"The policy details should be displayed successfully\.")]
        public void ThenThePolicyDetailsShouldBeDisplayedSuccessfully_()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }


        /* Code for Deleting a policy when policyid is given */

        [Given(@"I have entered a valid policyid for Delete")]
        public void GivenIHaveEnteredAValidPolicyidForDelete(Table table)
        {
            var policyIdDelete = table.CreateSet<PolicyIdDelete>();
            PolicyIdListDelete = policyIdDelete.ToList();
        }

        [When(@"I send a DELETE request")]
        public void WhenISendADELETERequest()
        {
            init();
            for (var i = 0; i < PolicyIdListDelete.Count(); i++)
            {
                _policyiddelete = PolicyIdListDelete[i].policyid;
                _thirdpartypolicyid = PolicyIdListDelete[i].thirdpartypolicyid;
                if (_thirdpartypolicyid != "")
                    jsonRequest = hostUrl + "/ri-pmsintegrationapi/1.0.0/Policy/" + _policyiddelete +
                                  "?thirdPartyPolicyId=" +
                                  _thirdpartypolicyid;
                else
                    jsonRequest = hostUrl + "/ri-pmsintegrationapi/1.0.0/Policy/" + _policyiddelete;

                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "DELETE", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"the policy information should be deleted successfully")]
        public void ThenThePolicyInformationShouldBeDeletedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        /* Code for Posting and Updating the policy information */

        [Given(@"I have provided the Policy information")]
        public void GivenIHaveProvidedThePolicyInformation(Table table)
        {
            var PolicyInfo = table.CreateSet<PolicyInfo>();
            PolicyInfoList = PolicyInfo.ToList();
        }

        [Given(@"I have provided the lease information")]
        public void GivenIHaveProvidedTheLeaseInformation(Table table)
        {
            var LeaseInfo = table.CreateSet<LeaseInfo>();
            LeaseInfoList = LeaseInfo.ToList();
        }

        [Given(@"I have provided the Carrier information")]
        public void GivenIHaveProvidedTheCarrierInformation(Table table)
        {
            var CarrierInfo = table.CreateSet<LarrierInfo>();
            CarrierInfoList = CarrierInfo.ToList();
        }

        [Given(@"I have provided the resident information")]
        public void GivenIHaveProvidedTheResidentInformation(Table table)
        {
            var ResidentInfo = table.CreateSet<ResidentInfo>();
            ResidentInfoList = ResidentInfo.ToList();
        }

        [Given(@"I have provided the unit information")]
        public void GivenIHaveProvidedTheUnitInformation(Table table)
        {
            var externalunitid = table.CreateInstance<PolicyObject>();
            externalUnitId = externalunitid.externalUnitId;
        }

        [When(@"I send a POST request")]
        public void WhenISendAPOSTRequest()
        {
            init();
            var url = hostUrl + "/ri-pmsintegrationapi/1.0.0/Policy";
            for (var i = 0; i < PolicyInfoList.Count(); i++)
            {
                policyObject.policyInfo = PolicyInfoList[i];
                policyObject.leaseInfo = LeaseInfoList[i];
                policyObject.larrierInfo = CarrierInfoList[i];
                policyObject.residentInfo = ResidentInfoList[i];
                policyObject.externalUnitId = externalUnitId;
                jsonRequest = JsonConvert.SerializeObject(policyObject);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseListPost.Add(jsonResponse);
            }
        }

        [When(@"I send a PUT request")]
        public void WhenISendAPUTRequest()
        {
            init();
            var url = hostUrl + "/ri-pmsintegrationapi/1.0.0/Policy";
            for (var i = 0; i < PolicyInfoList.Count(); i++)
            {
                policyObject.policyInfo = PolicyInfoList[i];
                policyObject.leaseInfo = LeaseInfoList[i];
                policyObject.larrierInfo = CarrierInfoList[i];
                policyObject.residentInfo = ResidentInfoList[i];
                policyObject.externalUnitId = externalUnitId;
                jsonRequest = JsonConvert.SerializeObject(policyObject);
                jsonResponse = doExecuteApiWithHeaders(url, "PUT", "json", "application/json", "", jsonRequest);
                jsonResponseListPut.Add(jsonResponse);
            }
        }


        [Then(@"A valid response should be generated for POST")]
        public void ThenAValidResponseShouldBeGeneratedForPOST()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseListPost[i]);
        }

        [Then(@"A valid response should be generated for PUT")]
        public void ThenAValidResponseShouldBeGeneratedForPUT()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseListPut[i]);
        }


        /* Code to fetch the policies when property type and propertyid are passed */
        [Given(@"I have entered the valid PropertyType and PropertyId")]
        public void GivenIHaveEnteredTheValidPropertyTypeAndPropertyId(Table table)
        {
            var propertyTypeInfo = table.CreateSet<PolicyByProperty>();
            propertyInfoList = propertyTypeInfo.ToList();
        }

        [When(@"I send a valid GET request with PropertyType and PropertyId")]
        public void WhenISendAValidGETRequestWithPropertyTypeAndPropertyId()
        {
            init();
            var url = hostUrl + "/ri-pmsintegrationapi/1.0.0/IntegrationSettings/";
            for (var i = 0; i < propertyInfoList.Count(); i++)
            {
                propertyType = propertyInfoList[i].propertytype;
                propertyId = propertyInfoList[i].propertyid;
                jsonRequest = url + propertyId + "/" + propertyType;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"List of policies in the property should be returned")]
        public void ThenListOfPoliciesInThePropertyShouldBeReturned()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }


        /* Code to fetch the occupancy information when property type and propertyid are submitted */

        [Given(@"I have entered the valid PropertyType and PropertyId to fetch the occupancy details")]
        public void GivenIHaveEnteredTheValidPropertyTypeAndPropertyIdToFetchTheOccupancyDetails(Table table)
        {
            var occupancyinfo = table.CreateSet<OccupancyByProperty>();
            occupancyInfoList = occupancyinfo.ToList();
        }

        [When(@"I send a valid GET request to fetch the occupancy details")]
        public void WhenISendAValidGETRequestToFetchTheOccupancyDetails()
        {
            init();
            var url = hostUrl + "/ri-pmsintegrationapi/1.0.0/OccupancyInfo/";
            for (var i = 0; i < occupancyInfoList.Count(); i++)
            {
                propertyType = occupancyInfoList[i].propertytype;
                propertyId = occupancyInfoList[i].propertyid;
                jsonRequest = url + propertyType + "/" + propertyId;
                jsonResponse = doExecuteApiWithHeaders(jsonRequest, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The occupancy details should be returned")]
        public void ThenTheOccupancyDetailsShouldBeReturned()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
            //sw.WriteLineAsync(CurrentScenario);
            //sw.WriteLineAsync(jsonResponseList[i]);
        }
    }
}