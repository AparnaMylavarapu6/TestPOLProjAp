using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_API
{
    public class EntityInformation
    {
        public int entityid { get; set; }
        public string entitytype { get; set; }
    }

    public class DetailsbyResident
    {
        public string certificatenumber { get; set; }
        public int residentid { get; set; }
    }

    public class PolicyDetailsbyResident
    {
        public string certificatenumber { get; set; }
        public int residentid { get; set; }
    }

    public class PolicyDetailsbyLocation
    {
        public string certificatenumber { get; set; }
        public int locationid { get; set; }
    }

    public class MonthlyLedgerDetails
    {
        public int ledgerinfoid { get; set; }
    }

    public class LedgerDetails
    {
        public int ledgerinfoid { get; set; }
    }

    public class ResidentDetails
    {
        public string certificatenumber { get; set; }
    }

    public class ProductCoverageDetails
    {
        public string certificatenumber { get; set; }
        public int locationid { get; set; }
    }

    [Binding]
    public class POLPolicySteps : TestBase
    {
        private readonly List<string> jsonResponseList = new List<string>();
        public string _certificationnumber = "";
        public int _entityid;
        public string _entitytype = "";
        public int _ledgerinfoid;
        public int _locationid;
        public int _residentid;
        private List<DetailsbyResident> detailsByResidentList = new List<DetailsbyResident>();

        private List<EntityInformation> entityInformationList = new List<EntityInformation>();

        public string jsonRequest = "";
        public string jsonResponse = "";
        private List<LedgerDetails> ledgerDetailList = new List<LedgerDetails>();
        private List<MonthlyLedgerDetails> monthlyLedgerDetailList = new List<MonthlyLedgerDetails>();
        private List<PolicyDetailsbyLocation> policyDetailsbyLocationList = new List<PolicyDetailsbyLocation>();
        private List<PolicyDetailsbyResident> policyDetailsbyResidentList = new List<PolicyDetailsbyResident>();
        private List<ProductCoverageDetails> productCoverageDetailList = new List<ProductCoverageDetails>();
        private List<ResidentDetails> residentDetailList = new List<ResidentDetails>();
        public string url = "";


        [Given(@"I have entered the entity type and the entity id")]
        public void GivenIHaveEnteredTheEntityTypeAndTheEntityId(Table table)
        {
            entityInformationList = table.CreateSet<EntityInformation>().ToList();
        }

        [Given(@"I have entered the resident id and the certificate number of the pol policy")]
        public void GivenIHaveEnteredTheResidentIdAndTheCertificateNumberOfThePolPolicy(Table table)
        {
            detailsByResidentList = table.CreateSet<DetailsbyResident>().ToList();
        }

        [Given(@"I have provided the resident id and certificate number for policy details")]
        public void GivenIHaveProvidedTheResidentIdAndCertificateNumberForPolicyDetails(Table table)
        {
            policyDetailsbyResidentList = table.CreateSet<PolicyDetailsbyResident>().ToList();
        }

        [Given(@"I have provided the location id and the certificate number fo policy details")]
        public void GivenIHaveProvidedTheLocationIdAndTheCertificateNumberFoPolicyDetails(Table table)
        {
            policyDetailsbyLocationList = table.CreateSet<PolicyDetailsbyLocation>().ToList();
        }

        [Given(@"I have entered the ledger info id to fetch the ledger details")]
        public void GivenIHaveEnteredTheLedgerInfoIdToFetchTheLedgerDetails(Table table)
        {
            monthlyLedgerDetailList = table.CreateSet<MonthlyLedgerDetails>().ToList();
        }

        [Given(@"I have provided the ledger info id to fetch the ledger information")]
        public void GivenIHaveProvidedTheLedgerInfoIdToFetchTheLedgerInformation(Table table)
        {
            ledgerDetailList = table.CreateSet<LedgerDetails>().ToList();
        }

        [Given(@"I have entered the certificate number to fetch the resident details")]
        public void GivenIHaveEnteredTheCertificateNumberToFetchTheResidentDetails(Table table)
        {
            residentDetailList = table.CreateSet<ResidentDetails>().ToList();
        }

        [Given(@"I have entered the certificate number and location id to fetch the product coverage details")]
        public void GivenIHaveEnteredTheCertificateNumberAndLocationIdToFetchTheProductCoverageDetails(Table table)
        {
            productCoverageDetailList = table.CreateSet<ProductCoverageDetails>().ToList();
        }

        [When(@"I send a Get request to fetch the POL policies")]
        public void WhenISendAGetRequestToFetchThePOLPolicies()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < entityInformationList.Count(); i++)
            {
                _entityid = entityInformationList[i].entityid;
                _entitytype = entityInformationList[i].entitytype;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/" + _entitytype + "/" + _entityid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request with the certificate number and the residentid")]
        public void WhenISendAGetRequestWithTheCertificateNumberAndTheResidentid()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < detailsByResidentList.Count(); i++)
            {
                _certificationnumber = detailsByResidentList[i].certificatenumber;
                _residentid = detailsByResidentList[i].residentid;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetDetails/Policy/" + _certificationnumber + "/Resident/" +
                      _residentid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request to the get policy details method")]
        public void WhenISendAGetRequestToTheGetPolicyDetailsMethod()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < policyDetailsbyResidentList.Count(); i++)
            {
                _certificationnumber = policyDetailsbyResidentList[i].certificatenumber;
                _residentid = policyDetailsbyResidentList[i].residentid;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetPolicyDetails/Policy/" + _certificationnumber +
                      "/Resident/" + _residentid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request with the location id and certification number")]
        public void WhenISendAGetRequestWithTheLocationIdAndCertificationNumber()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < policyDetailsbyLocationList.Count(); i++)
            {
                _certificationnumber = policyDetailsbyLocationList[i].certificatenumber;
                _locationid = policyDetailsbyLocationList[i].locationid;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetPolicyDetails/Policy/" + _certificationnumber +
                      "/Location/" + _locationid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request to fetch the monthly ledger details")]
        public void WhenISendAGetRequestToFetchTheMonthlyLedgerDetails()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < monthlyLedgerDetailList.Count(); i++)
            {
                _ledgerinfoid = monthlyLedgerDetailList[i].ledgerinfoid;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetLedgerMonthlyDetails/" + _ledgerinfoid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request to fetch the ledger information")]
        public void WhenISendAGetRequestToFetchTheLedgerInformation()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < ledgerDetailList.Count(); i++)
            {
                _ledgerinfoid = ledgerDetailList[i].ledgerinfoid;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetLedgerInfo/" + _ledgerinfoid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request to fetch the resident details")]
        public void WhenISendAGetRequestToFetchTheResidentDetails()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < residentDetailList.Count; i++)
            {
                _certificationnumber = residentDetailList[i].certificatenumber;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetResidentDetails/Policy/" + _certificationnumber;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [When(@"I send a Get request to fetch the product coverage details")]
        public void WhenISendAGetRequestToFetchTheProductCoverageDetails()
        {
            init();
            hostUrl = GetUrl("PolicyAPI");
            for (var i = 0; i < productCoverageDetailList.Count; i++)

            {
                _certificationnumber = productCoverageDetailList[i].certificatenumber;
                _locationid = productCoverageDetailList[i].locationid;
                url = hostUrl + "/ri-policyapi/1.0.0/POL/GetProductCoverageDetails/Policy/" + _certificationnumber +
                      "/Location/" + _locationid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The POL policies should be fetched successfully")]
        public void ThenThePOLPoliciesShouldBeFetchedSuccessfully()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"The policy, property, lease and ledger information tied up to the resident should be displayed")]
        public void ThenThePolicyPropertyLeaseAndLedgerInformationTiedUpToTheResidentShouldBeDisplayed()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated from the method with the resident id and certificate number")]
        public void ThenASuccessfulResponseShouldBeGeneratedFromTheMethodWithTheResidentIdAndCertificateNumber()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated from the method with the location id and certificate number")]
        public void ThenASuccessfulResponseShouldBeGeneratedFromTheMethodWithTheLocationIdAndCertificateNumber()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the monthly ledger details")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithTheMonthlyLedgerDetails()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the ledger information")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithTheLedgerInformation()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the resident details")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithTheResidentDetails()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
        }

        [Then(@"A successful response should be generated with the product coverage details")]
        public void ThenASuccessfulResponseShouldBeGeneratedWithTheProductCoverageDetails()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            
        }
    }
}