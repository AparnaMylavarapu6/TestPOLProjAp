using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace POLTest1.Tests.Policy_Enrollment_API
{
    /* Class for Quote Package Method */
    public class AuthenticationInformation
    {
        public string userId { get; set; }
        public string password { get; set; }
    }

    public class PropertyTypeInformation
    {
        public string propertyIdType { get; set; }
        public string propertyID { get; set; }
    }

    public class UnitInformation
    {
        public string UnitIDType { get; set; }
        public string UnitID { get; set; }
    }

    public class ResidentNameInformation
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class ResidentInformation
    {
        public ResidentNameInformation ResidentNameInformation { get; set; }
        public string externalResID { get; set; }
        public bool isPrimaryResident { get; set; }
        public string dateofBirth { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
    }

    public class GetQuoteObject
    {
        public List<ResidentInformation> residentInfo = new List<ResidentInformation>();
        public AuthenticationInformation authInfo { get; set; }
        public PropertyTypeInformation propertyInfo { get; set; }
        public UnitInformation unitInfo { get; set; }
        public string coverageDate { get; set; }
        public string quoteRequestSource { get; set; }
        public int leaseID { get; set; }
        public bool isRenewal { get; set; }
    }

    /* Class for Send Decline Notices Method */
    public class PropertyInformationSendDecline
    {
        public string propertyIdType { get; set; }
        public string propertyID { get; set; }
    }

    public class DeclineReasonIDInformation
    {
        public int declineReasonId { get; set; }
    }

    public class DeclineReasonInformation
    {
        public string declineReason { get; set; }
    }

    public class SendDeclineNoticesObject
    {
        public List<DeclineReasonInformation> declineReason = new List<DeclineReasonInformation>();

        public List<DeclineReasonIDInformation> declineReasonId = new List<DeclineReasonIDInformation>();
        public PropertyInfo propertyInfo = new PropertyInfo();
        public int quoteId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public bool notifyByEmail { get; set; }
        public bool notifyByPost { get; set; }
    }


    /* Class for Fetch Confirmation Document Method */
    public class ConfirmationDocumentPolicyID
    {
        public string policyid { get; set; }
    }

    /* Classes for Quote Submission Method */
    public class DeductibleInformation
    {
        public int poaid { get; set; }
    }

    public class EndorsementInformation
    {
        public int poaid { get; set; }
    }

    public class SelectedOptions
    {
        public List<EndorsementInformation> endorsementInfo = new List<EndorsementInformation>();
        public int deductibleInfo { get; set; }
    }

    public class QuoteResidentInformation
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class QuoteResidentsInformation
    {
        public QuoteResidentInformation resident = new QuoteResidentInformation();
        public int residentID { get; set; }
        public int externalResID { get; set; }
        public int mobileNumber { get; set; }
        public string email { get; set; }
        public bool isPrimaryResident { get; set; }
        public string dateOfBirth { get; set; }
    }

    public class MailingAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
    }

    public class QuoteSubmission
    {
        public AuthInfo authInfo = new AuthInfo();
        public MailingAddress mailingAddress = new MailingAddress();
        public List<QuoteResidentsInformation> residentsInfo = new List<QuoteResidentsInformation>();
        public SelectedOptions selectedOptions = new SelectedOptions();
        public int quoteID { get; set; }
        public int productGroupID { get; set; }
        public int locationID { get; set; }
        public bool isMailingAddressAsUnitAddress { get; set; }
        public bool underwritingQuestionsAcceptance { get; set; }
        public string quoteRequestSource { get; set; }
    }

    /* Classes for Payment Submission */
    public class CreditCardInformation
    {
        public string nameOnCard { get; set; }
        public string cardType { get; set; }
        public long cardNumber { get; set; }
        public int cVV { get; set; }
        public string cCExpDateMonth { get; set; }
        public int cCExpDateFourDigitYear { get; set; }
    }

    public class AchBankInformation
    {
        public string name { get; set; }
        public string accountName { get; set; }
        public string routingNumber { get; set; }
        public string accountNumber { get; set; }
        public string checkNumber { get; set; }
    }

    public class BillingInformation
    {
        public AchBankInformation achBankInfoType = new AchBankInformation();
        public CreditCardInformation creditCardInfo = new CreditCardInformation();
        public string paymentTypesInfo { get; set; }
        public string paymentFrequency { get; set; }
    }

    public class PaymentSubmission
    {
        public AuthenticationInformation authInfo = new AuthenticationInformation();
        public BillingInformation billingInfo = new BillingInformation();
        public int quoteID { get; set; }
        public int annualPremium { get; set; }
        public int modalFeePremium { get; set; }
        public int termFeePremium { get; set; }
        public int termPremium { get; set; }
        public bool noticeofPrivacyPolicyPracticesAcceptance { get; set; }
        public bool noticeofFraudWarningAcceptance { get; set; }
        public bool termsandConditionsAcceptance { get; set; }
        public bool isPaperLess { get; set; }
        public bool isSameDayDisclaimer { get; set; }
    }

    /* SpecFlow Binding Class */
    [Binding]
    public class HO4Steps : TestBase
    {
        private readonly List<BillingInformation> billingInformationList = new List<BillingInformation>();

        private readonly List<string> coverageDateList = new List<string>();

        private readonly GetQuoteObject getQuoteObject = new GetQuoteObject();
        private readonly List<bool> isRenewalList = new List<bool>();
        private readonly List<string> jsonResponseList = new List<string>();
        private readonly List<int> leaseIDList = new List<int>();
        private readonly PaymentSubmission paymentObject = new PaymentSubmission();
        private readonly List<string> quoteRequestSourceList = new List<string>();
        private readonly QuoteResidentsInformation quoteResidentsInformationObject = new QuoteResidentsInformation();
        private readonly QuoteSubmission quoteSubmissionObject = new QuoteSubmission();
        private readonly SelectedOptions selectedOptionObject = new SelectedOptions();
        private readonly SendDeclineNoticesObject sendDeclineNoticesObject = new SendDeclineNoticesObject();
        private string _policyid = "";
        private List<AchBankInformation> achBankInformationList = new List<AchBankInformation>();
        private readonly AchBankInformation achBankObject = new AchBankInformation();
        private List<AuthenticationInformation> authenticationInformationList = new List<AuthenticationInformation>();
        private BillingInformation billingObject = new BillingInformation();

        private List<ConfirmationDocumentPolicyID> confirmationDocumentPolicyIdList =
            new List<ConfirmationDocumentPolicyID>();

        private List<CreditCardInformation> creditCardInformationList = new List<CreditCardInformation>();
        private readonly CreditCardInformation creditCardObject = new CreditCardInformation();
        private List<DeclineReasonIDInformation> declineReasonIdList = new List<DeclineReasonIDInformation>();
        private List<DeclineReasonInformation> declineReasonList = new List<DeclineReasonInformation>();
        private List<DeductibleInformation> deductibleInformationList = new List<DeductibleInformation>();
        private List<EndorsementInformation> endorsementInformationList = new List<EndorsementInformation>();
        private List<GetQuoteObject> getQuoteObjectList = new List<GetQuoteObject>();
        private string jsonRequest = "";

        private string jsonResponse = "";
        private List<MailingAddress> mailingAddressList = new List<MailingAddress>();
        private List<PaymentSubmission> paymentSubmissionList = new List<PaymentSubmission>();

        private List<PropertyInformationSendDecline> propertyInformationSendDeclineList =
            new List<PropertyInformationSendDecline>();

        private List<PropertyTypeInformation> propertyTypeInformationList = new List<PropertyTypeInformation>();
        private List<QuoteResidentInformation> quoteResidentInformationList = new List<QuoteResidentInformation>();
        private List<QuoteResidentsInformation> quoteResidentsInformationList = new List<QuoteResidentsInformation>();
        private List<QuoteSubmission> quoteSubmissionList = new List<QuoteSubmission>();
        private List<ResidentInformation> residentInformationList = new List<ResidentInformation>();
        private List<ResidentNameInformation> residentNameInformationList = new List<ResidentNameInformation>();
        private List<SelectedOptions> selectedOptionsList = new List<SelectedOptions>();
        private List<SendDeclineNoticesObject> sendDeclineNoticesObjectList = new List<SendDeclineNoticesObject>();
        private List<UnitInformation> unitInformationList = new List<UnitInformation>();
        private string url = "";

        /* Quote Product Package Scenario */
        [Given(@"I have entered the authentication information to fetch the Quote Product Package Details")]
        public void GivenIHaveEnteredTheAuthenticationInformationToFetchTheQuoteProductPackageDetails(Table table)
        {
            authenticationInformationList = table.CreateSet<AuthenticationInformation>().ToList();
        }

        [Given(@"I have entered the property information to fetch the Quote Product Package Details")]
        public void GivenIHaveEnteredThePropertyInformationToFetchTheQuoteProductPackageDetails(Table table)
        {
            propertyTypeInformationList = table.CreateSet<PropertyTypeInformation>().ToList();
        }

        [Given(@"I have entered the unit information to fetch the Quote Product Package Details")]
        public void GivenIHaveEnteredTheUnitInformationToFetchTheQuoteProductPackageDetails(Table table)
        {
            unitInformationList = table.CreateSet<UnitInformation>().ToList();
        }

        [Given(@"I have entered the resident name to fetch the Quote Product Package Details")]
        public void GivenIHaveEnteredTheResidentNameToFetchTheQuoteProductPackageDetails(Table table)
        {
            residentNameInformationList = table.CreateSet<ResidentNameInformation>().ToList();
        }

        [Given(@"I have entered the resident information to fetch the Quote Product Package Details")]
        public void GivenIHaveEnteredTheResidentInformationToFetchTheQuoteProductPackageDetails(Table table)
        {
            var residentInfoList = table.CreateSet<ResidentInformation>().ToList();

            for (var i = 0; i < residentInfoList.Count(); i++)
                residentInfoList[i].ResidentNameInformation = residentNameInformationList[i];

            residentInformationList = residentInfoList.ToList();
        }

        [Given(@"I have entered the lease information to fetch the Quote Product Package Details")]
        public void GivenIHaveEnteredTheLeaseInformationToFetchTheQuoteProductPackageDetails(Table table)
        {
            getQuoteObjectList = table.CreateSet<GetQuoteObject>().ToList();
            for (var i = 0; i < getQuoteObjectList.Count; i++)
            {
                quoteRequestSourceList.Add(getQuoteObjectList[i].quoteRequestSource);
                leaseIDList.Add(getQuoteObjectList[i].leaseID);
                isRenewalList.Add(getQuoteObjectList[i].isRenewal);
                coverageDateList.Add(getQuoteObjectList[i].coverageDate);
            }
        }


        [When(@"I Send a Post request to fetch the Quote Product Package Details")]
        public void WhenISendAPostRequestToFetchTheQuoteProductPackageDetails()
        {
            init();
            url = "/ri-policyenrollmentapi/1.0.0/GetQuote";
            for (var i = 0; i < getQuoteObjectList.Count; i++)
            {
                getQuoteObject.authInfo = authenticationInformationList[i];
                getQuoteObject.propertyInfo = propertyTypeInformationList[i];
                getQuoteObject.unitInfo = unitInformationList[i];
                getQuoteObject.residentInfo.Add(residentInformationList[i]);
                getQuoteObject.coverageDate = coverageDateList[i];
                getQuoteObject.quoteRequestSource = quoteRequestSourceList[i];
                getQuoteObject.leaseID = leaseIDList[i];
                getQuoteObject.isRenewal = isRenewalList[i];

                jsonRequest = JsonConvert.SerializeObject(getQuoteObject);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid Quote Product Package Details should be returned")]
        public void ThenAValidQuoteProductPackageDetailsShouldBeReturned()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
        }

        /* Send Decline Notices Scenario */

        [Given(@"I have entered the property information to send decline notices")]
        public void GivenIHaveEnteredThePropertyInformationToSendDeclineNotices(Table table)
        {
            propertyInformationSendDeclineList = table.CreateSet<PropertyInformationSendDecline>().ToList();
        }

        [Given(@"I have entered the quote and decline notice information")]
        public void GivenIHaveEnteredTheQuoteAndDeclineNoticeInformation(Table table)
        {
            sendDeclineNoticesObjectList = table.CreateSet<SendDeclineNoticesObject>().ToList();
        }

        [Given(@"I have entered the decline reason id")]
        public void GivenIHaveEnteredTheDeclineReasonId(Table table)
        {
            declineReasonIdList = table.CreateSet<DeclineReasonIDInformation>().ToList();
        }

        [Given(@"I have entered the decline reason")]
        public void GivenIHaveEnteredTheDeclineReason(Table table)
        {
            declineReasonList = table.CreateSet<DeclineReasonInformation>().ToList();
        }


        [When(@"I send a post request to send the decline reasons")]
        public void WhenISendAPostRequestToSendTheDeclineReasons()
        {
            init();
            url = hostUrl + "/ri-policyenrollmentapi/1.0.0/SendDeclineNotices";
            for (var i = 0; i < sendDeclineNoticesObjectList.Count; i++)
            {
                sendDeclineNoticesObject.quoteId = sendDeclineNoticesObjectList[i].quoteId;
                sendDeclineNoticesObject.propertyInfo.propertyIdType =
                    propertyInformationSendDeclineList[i].propertyIdType;
                sendDeclineNoticesObject.propertyInfo.propertyID = propertyInformationSendDeclineList[i].propertyID;
                sendDeclineNoticesObject.firstName = sendDeclineNoticesObjectList[i].firstName;
                sendDeclineNoticesObject.lastName = sendDeclineNoticesObjectList[i].lastName;
                sendDeclineNoticesObject.email = sendDeclineNoticesObjectList[i].email;
                sendDeclineNoticesObject.address = sendDeclineNoticesObjectList[i].address;
                sendDeclineNoticesObject.address2 = sendDeclineNoticesObjectList[i].address2;
                sendDeclineNoticesObject.city = sendDeclineNoticesObjectList[i].city;
                sendDeclineNoticesObject.state = sendDeclineNoticesObjectList[i].state;
                sendDeclineNoticesObject.zipcode = sendDeclineNoticesObjectList[i].zipcode;
                sendDeclineNoticesObject.declineReasonId.Add(declineReasonIdList[i]);
                sendDeclineNoticesObject.declineReason.Add(declineReasonList[i]);
                sendDeclineNoticesObject.notifyByEmail = sendDeclineNoticesObjectList[i].notifyByEmail;
                sendDeclineNoticesObject.notifyByPost = sendDeclineNoticesObjectList[i].notifyByPost;

                jsonRequest = JsonConvert.SerializeObject(sendDeclineNoticesObject);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid response should be generated from the system")]
        public void ThenAValidResponseShouldBeGeneratedFromTheSystem()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
        }

        /* Quote Submission Scenario */

        [Given(@"I have entered the authentication information for quote submission")]
        public void GivenIHaveEnteredTheAuthenticationInformationForQuoteSubmission(Table table)
        {
            authenticationInformationList = table.CreateSet<AuthenticationInformation>().ToList();
        }

        [Given(@"I have entered the Deductible Information")]
        public void GivenIHaveEnteredTheDeductibleInformation(Table table)
        {
            deductibleInformationList = table.CreateSet<DeductibleInformation>().ToList();
        }

        [Given(@"I have entered the Endorsement Information")]
        public void GivenIHaveEnteredTheEndorsementInformation(Table table)
        {
            endorsementInformationList = table.CreateSet<EndorsementInformation>().ToList();
        }

        [Given(@"I have entered the resident name for quote submission")]
        public void GivenIHaveEnteredTheResidentNameForQuoteSubmission(Table table)
        {
            quoteResidentInformationList = table.CreateSet<QuoteResidentInformation>().ToList();
        }

        [Given(@"I have entered the other resident information for quote submission")]
        public void GivenIHaveEnteredTheOtherResidentInformationForQuoteSubmission(Table table)
        {
            quoteResidentsInformationList = table.CreateSet<QuoteResidentsInformation>().ToList();
        }

        [Given(@"I have entered the Mailing Address Information for Quote Submission")]
        public void GivenIHaveEnteredTheMailingAddressInformationForQuoteSubmission(Table table)
        {
            mailingAddressList = table.CreateSet<MailingAddress>().ToList();
        }

        [Given(@"I have entered the Quote Information")]
        public void GivenIHaveEnteredTheQuoteInformation(Table table)
        {
            quoteSubmissionList = table.CreateSet<QuoteSubmission>().ToList();
        }

        [When(@"I send a Post request for quote submission")]
        public void WhenISendAPostRequestForQuoteSubmission()
        {
            init();
            url = hostUrl + "/ri-policyenrollmentapi/1.0.0/QuoteSubmission";
            quoteSubmissionObject.authInfo.userId = authenticationInformationList[0].userId;
            quoteSubmissionObject.authInfo.password = authenticationInformationList[0].password;

            for (var i = 0; i < quoteSubmissionList.Count; i++)
            {
                selectedOptionObject.deductibleInfo = deductibleInformationList[i].poaid;
                selectedOptionObject.endorsementInfo.Add(endorsementInformationList[i]);
                quoteResidentsInformationObject.resident.firstName = quoteResidentInformationList[i].firstName;
                quoteResidentsInformationObject.resident.middleName = quoteResidentInformationList[i].middleName;
                quoteResidentsInformationObject.resident.lastName = quoteResidentInformationList[i].lastName;
                quoteResidentsInformationObject.dateOfBirth = quoteResidentsInformationList[i].dateOfBirth;
                quoteResidentsInformationObject.email = quoteResidentsInformationList[i].email;
                quoteResidentsInformationObject.externalResID = quoteResidentsInformationList[i].externalResID;
                quoteResidentsInformationObject.isPrimaryResident = quoteResidentsInformationList[i].isPrimaryResident;
                quoteResidentsInformationObject.mobileNumber = quoteResidentsInformationList[i].mobileNumber;
                quoteResidentsInformationObject.residentID = quoteResidentsInformationList[i].residentID;

                quoteSubmissionObject.quoteID = quoteSubmissionList[i].quoteID;
                quoteSubmissionObject.productGroupID = quoteSubmissionList[i].productGroupID;
                quoteSubmissionObject.selectedOptions = selectedOptionObject;
                quoteSubmissionObject.residentsInfo.Add(quoteResidentsInformationObject);
                quoteSubmissionObject.locationID = quoteSubmissionList[i].locationID;
                quoteSubmissionObject.isMailingAddressAsUnitAddress =
                    quoteSubmissionList[i].isMailingAddressAsUnitAddress;
                quoteSubmissionObject.mailingAddress.addressLine1 = mailingAddressList[i].addressLine1;
                quoteSubmissionObject.mailingAddress.addressLine2 = mailingAddressList[i].addressLine2;
                quoteSubmissionObject.mailingAddress.city = mailingAddressList[i].city;
                quoteSubmissionObject.mailingAddress.state = mailingAddressList[i].state;
                quoteSubmissionObject.mailingAddress.zipCode = mailingAddressList[i].zipCode;
                quoteSubmissionObject.underwritingQuestionsAcceptance =
                    quoteSubmissionList[i].underwritingQuestionsAcceptance;
                quoteSubmissionObject.quoteRequestSource = quoteSubmissionList[i].quoteRequestSource;

                jsonRequest = JsonConvert.SerializeObject(quoteSubmissionObject);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"The quote should be successfully posted")]
        public void ThenTheQuoteShouldBeSuccessfullyPosted()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
        }

        /* Payment Submission Scenario */

        [Given(@"I have entered the authentication information for payment submission")]
        public void GivenIHaveEnteredTheAuthenticationInformationForPaymentSubmission(Table table)
        {
            authenticationInformationList = table.CreateSet<AuthenticationInformation>().ToList();
        }

        [Given(@"I have entered the credit card information for payment submission")]
        public void GivenIHaveEnteredTheCreditCardInformationForPaymentSubmission(Table table)
        {
            creditCardInformationList = table.CreateSet<CreditCardInformation>().ToList();
        }

        [Given(@"I have entered the ACH information for payment submission")]
        public void GivenIHaveEnteredTheACHInformationForPaymentSubmission(Table table)
        {
            achBankInformationList = table.CreateSet<AchBankInformation>().ToList();
        }

        [Given(@"I have entered the payment type information for payment submission")]
        public void GivenIHaveEnteredThePaymentTypeInformationForPaymentSubmission(Table table)
        {
            var billingInformation = table.CreateSet<BillingInformation>().ToList();
            for (var i = 0; i < billingInformation.Count; i++)
            {
                creditCardObject.nameOnCard = creditCardInformationList[i].nameOnCard;
                creditCardObject.cardType = creditCardInformationList[i].cardType;
                creditCardObject.cardNumber = creditCardInformationList[i].cardNumber;
                creditCardObject.cVV = creditCardInformationList[i].cVV;
                creditCardObject.cCExpDateMonth = creditCardInformationList[i].cCExpDateMonth;
                creditCardObject.cCExpDateFourDigitYear =
                    creditCardInformationList[i].cCExpDateFourDigitYear;
                billingInformation[i].creditCardInfo = creditCardObject;

                //billingInformationList[i].creditCardInfo = creditCardObject;

                achBankObject.name = achBankInformationList[i].name;
                achBankObject.accountName = achBankInformationList[i].accountName;
                achBankObject.routingNumber = achBankInformationList[i].routingNumber;
                achBankObject.accountNumber = achBankInformationList[i].accountNumber;
                achBankObject.checkNumber = achBankInformationList[i].checkNumber;
                //billingInformationList[i].paymentFrequency = billingInformation[i].paymentFrequency;
                //billingInformationList[i].paymentTypesInfo = billingInformation[i].paymentTypesInfo;

                billingInformationList.Add(billingInformation[i]);
            }
        }

        [Given(@"I have entered the quote and premium information")]
        public void GivenIHaveEnteredTheQuoteAndPremiumInformation(Table table)
        {
            paymentSubmissionList = table.CreateSet<PaymentSubmission>().ToList();
        }

        [When(@"I send a Post request for payment submission")]
        public void WhenISendAPostRequestForPaymentSubmission()
        {
            init();
            url = hostUrl + "/ri-policyenrollmentapi/1.0.0/PaymentSubmission";
            paymentObject.authInfo.userId = authenticationInformationList[0].userId;
            paymentObject.authInfo.password = authenticationInformationList[0].password;
            for (var i = 0; i < paymentSubmissionList.Count; i++)
            {
                paymentObject.quoteID = paymentSubmissionList[i].quoteID;
                paymentObject.billingInfo.creditCardInfo = billingInformationList[i].creditCardInfo;
                paymentObject.billingInfo.achBankInfoType = billingInformationList[i].achBankInfoType;
                paymentObject.billingInfo.paymentFrequency = billingInformationList[i].paymentFrequency;
                paymentObject.billingInfo.paymentTypesInfo = billingInformationList[i].paymentTypesInfo;
                paymentObject.annualPremium = paymentSubmissionList[i].annualPremium;
                paymentObject.modalFeePremium = paymentSubmissionList[i].modalFeePremium;
                paymentObject.termFeePremium = paymentSubmissionList[i].termFeePremium;
                paymentObject.termPremium = paymentSubmissionList[i].termPremium;
                paymentObject.noticeofPrivacyPolicyPracticesAcceptance =
                    paymentSubmissionList[i].noticeofPrivacyPolicyPracticesAcceptance;
                paymentObject.noticeofFraudWarningAcceptance = paymentSubmissionList[i].noticeofFraudWarningAcceptance;
                paymentObject.termsandConditionsAcceptance = paymentSubmissionList[i].termsandConditionsAcceptance;
                paymentObject.isPaperLess = paymentSubmissionList[i].isPaperLess;
                paymentObject.isSameDayDisclaimer = paymentSubmissionList[i].isSameDayDisclaimer;

                jsonRequest = JsonConvert.SerializeObject(paymentObject);
                jsonResponse = doExecuteApiWithHeaders(url, "POST", "json", "application/json", "", jsonRequest);
                jsonResponseList.Add(jsonRequest);
            }
        }

        [Then(@"A valid response should be generated for the payment submission method")]
        public void ThenAValidResponseShouldBeGeneratedForThePaymentSubmissionMethod()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
        }

        /* Fetch Confirmation Document Scenario */

        [Given(@"I have provided the policy id to fetch the confirmation document")]
        public void GivenIHaveProvidedThePolicyIdToFetchTheConfirmationDocument(Table table)
        {
            confirmationDocumentPolicyIdList = table.CreateSet<ConfirmationDocumentPolicyID>().ToList();
        }


        [When(@"I send a Get Request to fetch the confirmation document")]
        public void WhenISendAGetRequestToFetchTheConfirmationDocument()
        {
            init();
            for (var i = 0; i < confirmationDocumentPolicyIdList.Count; i++)
            {
                _policyid = confirmationDocumentPolicyIdList[i].policyid;
                url = hostUrl + "/ri-policyenrollmentapi/1.0.0/GetPolicyConfirmationDocument/" + _policyid;
                jsonResponse = doExecuteApiWithHeaders(url, "GET", "json", "application/json", "", "");
                jsonResponseList.Add(jsonResponse);
            }
        }

        [Then(@"A valid confirmation document response should be generated")]
        public void ThenAValidConfirmationDocumentResponseShouldBeGenerated()
        {
            for (var i = 0; i < jsonResponseList.Count(); i++)
                Assert.AreNotEqual("The remote server returned an error: (400) Bad Request.", jsonResponseList[i]);
            //sw.Write(jsonResponseList[i]);
        }
    }
}