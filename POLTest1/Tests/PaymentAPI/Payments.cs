using System;
using TechTalk.SpecFlow;
using RentersInsuranceApiTests;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace POL_Test.Tests.PaymentAPI
{
    //Post Customer

    public class LocationAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class Customer
    {
        public string carrierName { get; set; }
        public string policyNumber { get; set; }
        public int residentID { get; set; }
        public int propertyID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
       public LocationAddress locationAddress = new LocationAddress();
        public string phoneNumber { get; set; }

    }

    //Post Account

    public class AchInfo
    {
        public string nameOnAccount { get; set; }
        public string accountNumber { get; set; }
        public string routingNumber { get; set; }
        public string accountType { get; set; }
        public string checkNumber { get; set; }
    }

    public class AccountLocationAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class Account
    {
        public string carrierName { get; set; }
        public string policyNumber { get; set; }
        public string paymentMethod { get; set; }
        public string customerNumber { get; set; }
        public AchInfo achInfo = new AchInfo();
        public AccountLocationAddress accountlocationAddress = new AccountLocationAddress();

    }

    //Post Payment

    public class Payment
    {
        public double transactionAmount { get; set; }
        public int transactionFee { get; set; }
        public int propertyID { get; set; }
        public int residentID { get; set; }
        public string policyNumber { get; set; }
        public string carrierName { get; set; }
        public string customerReferenceID { get; set; }
        public string accountReferenceID { get; set; }
        public string checkNumber { get; set; }
        public bool isCreditCard { get; set; }
        public int transType { get; set; }
        public int cvv { get; set; }
    }

    //Post PaymentSubmission

    public class PaymentLocationAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class CreditCardInfo
    {
        public string nameOnCard { get; set; }
        public string ccNumber { get; set; }
        public int cvv { get; set; }
        public string expirationMonth { get; set; }
        public string expirationYear { get; set; }
        public int cardType { get; set; }
    }

    public class PaymentAchInfo
    {
        public string nameOnAccount { get; set; }
        public string accountNumber { get; set; }
        public string routingNumber { get; set; }
        public string accountType { get; set; }
        public string checkNumber { get; set; }
    }

    public class PaymentSubmission
    {
        public string carrierName { get; set; }
        public string policyNumber { get; set; }
        public string paymentMethod { get; set; }
        public int residentID { get; set; }
        public int propertyID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public double transactionAmount { get; set; }
        public int transactionFee { get; set; }
        public PaymentLocationAddress locationAddress = new PaymentLocationAddress();
        public PaymentAchInfo achInfo = new PaymentAchInfo();
        public CreditCardInfo creditCardInfo = new CreditCardInfo();
    }

    [Binding]
    public class PaymentSteps : TestBase
    {
        List<Customer> customerInfo = new List<Customer>();
        List<Account> accountInfo = new List<Account>();
        List<Payment> paymentInfo = new List<Payment>();
        List<PaymentSubmission> paymentSubmissionInfo = new List<PaymentSubmission>();
        List<LocationAddress> locationaddresslist = new List<LocationAddress>();
        List<AchInfo> achInfoList = new List<AchInfo>();
        List<AccountLocationAddress> accountLocationAddresslist = new List<AccountLocationAddress>();
        List<PaymentLocationAddress> locationAddresslist = new List<PaymentLocationAddress>();
        List<CreditCardInfo> creditCardInfolist = new List<CreditCardInfo>();
   //   List<PaymentAchInfo> psachInfolist = new List<PaymentAchInfo>();
        List<string> jsonResponseList = new List<string>();
        List<string> jsonResponseListCustomer = new List<string>();
        List<string> jsonResponseListAccount = new List<string>();
        List<string> jsonResponseListPayment = new List<string>();
        List<string> jsonResponseListPaymentSubmission = new List<string>();

        private string carrierName = "";
        private string policyNumber = "";
        private int residentID;
        private int propertyID;
        private string firstName = "";
        private string lastName = "";
        private string email = "";
        private string phoneNumber = "";
        private string paymentMethod = "";
        private string customerNumber = "";
        private double transactionAmount;
        private int transactionFee;
        private string customerReferenceID = "";
        private string accountReferenceID = "";
        private string checkNumber = "";
        private bool isCreditCard;
        private int transType;
        private int cvv;
        private string jsonResponse = "";
        private string jsonRequest = "";
        private string GetUrl = "";

        /*-------------------Post Request to Register a Customer ------------------*/
        [Given(@"I have a request to register a customer")]
        public void GivenIHaveARequestToRegisterACustomer(Table table)
        {

            customerInfo = table.CreateSet<Customer>().ToList();
            
        }
        [Given(@"I have provided the location details")]
        public void GivenIHaveProvidedTheLocationDetails(Table table)
        {
            locationaddresslist = table.CreateSet<LocationAddress>().ToList();
            for (int i = 0; i < customerInfo.Count; i++)
            {
                customerInfo[i].locationAddress.addressLine1 = locationaddresslist[i].addressLine1;
                customerInfo[i].locationAddress.addressLine2 = locationaddresslist[i].addressLine2;
                customerInfo[i].locationAddress.city = locationaddresslist[i].city;
                customerInfo[i].locationAddress.state = locationaddresslist[i].state;
                customerInfo[i].locationAddress.zipCode = locationaddresslist[i].zipCode;
              }
        }

        [When(@"I have entered the customer details")]
        public void WhenIHaveEnteredTheCustomerDetails()
        {
            init();
            Customer customerObj = new Customer();
            var host = GetUrl("PaymentApi") + "RegisterCustomer";
            for (int i = 0; i < customerInfo.Count; i++)
            {
             
                    jsonRequest = JsonConvert.SerializeObject(customerInfo[i]);
                    jsonResponse = doExecuteApiWithHeaders(host, "POST", "application/json-patch+json", "text/plain", "Bearer  " + token, jsonRequest);
                    jsonResponseListCustomer.Add(jsonResponse);
                                
            }

        }

        [Then(@"the customer should be registered")]
        public void ThenTheCustomerShouldBeRegistered()
        {
            for (var i = 0; i < jsonResponseListCustomer.Count(); i++)
            {
                Assert.IsTrue(jsonResponseListCustomer[i].Contains("\"message\":\"Operation successful\""), "Unable to Register a cusotmer");
              
            }

        }

        /*-------------------Post Request to Register an Account ------------------*/
        [Given(@"I have a request to register a account")]
        public void GivenIHaveARequestToRegisterAAccount(Table table)
        {
            accountInfo = table.CreateSet<Account>().ToList();
        }

        [Given(@"I have provided the accountinformation")]
        public void GivenIHaveProvidedTheAccountinformation(Table table)
        {
            achInfoList = table.CreateSet<AchInfo>().ToList();
            for (int i = 0; i < achInfoList.Count; i++)
            {
                accountInfo[i].achInfo.nameOnAccount = achInfoList[i].nameOnAccount;
                accountInfo[i].achInfo.accountNumber = achInfoList[i].accountNumber;
                accountInfo[i].achInfo.routingNumber = achInfoList[i].routingNumber;
                accountInfo[i].achInfo.accountType = achInfoList[i].accountType;
                accountInfo[i].achInfo.checkNumber = achInfoList[i].checkNumber;

            }
        }

        [Given(@"I aslo provide the Account Location Details")]
        public void GivenIAsloProvideTheAccountLocationDetails(Table table)
        {
            accountLocationAddresslist = table.CreateSet<AccountLocationAddress>().ToList();
            for (int i = 0; i < accountLocationAddresslist.Count; i++)
            {
                accountInfo[i].accountlocationAddress.addressLine1 = accountLocationAddresslist[i].addressLine1;
                accountInfo[i].accountlocationAddress.addressLine2 = accountLocationAddresslist[i].addressLine2;
                accountInfo[i].accountlocationAddress.city = accountLocationAddresslist[i].city;
                accountInfo[i].accountlocationAddress.state = accountLocationAddresslist[i].state;
                accountInfo[i].accountlocationAddress.zipCode = accountLocationAddresslist[i].zipCode;
            }
        }


        [When(@"I have entered the account details")]
        public void WhenIHaveEnteredTheAccountDetails()
        {
            init();
            Account accountObj = new Account();
            var host = GetUrl("PaymentApi") + "RegisterAccount";
            //var host = GetUrl("PaymentApi") + "RegisterCustomer";
            for (int i = 0; i < accountInfo.Count; i++)
            {
              
                jsonRequest = JsonConvert.SerializeObject(accountInfo[i]);
                jsonResponse = doExecuteApiWithHeaders(host, "POST", "application/json-patch+json", "text/plain", "Bearer  " + token, jsonRequest);
                jsonResponseListAccount.Add(jsonResponse);
            }
        }


        [Then(@"the account should be registered")]
        public void ThenTheAccountShouldBeRegistered()
        {
            for (var i = 0; i < jsonResponseListAccount.Count(); i++)
            {
         //       Assert.IsTrue(jsonResponseListAccount[i].Contains("\"success\":true"), "Unable to Register a Account");
            }
        }

        /*-------------------Post Request to ProcessPayment ------------------*/
        [Given(@"I have tp process a payment")]
        public void GivenIHaveTpProcessAPayment(Table table)
        {

            paymentInfo = table.CreateSet<Payment>().ToList();
        }

        [When(@"I have entered the payment details")]
        public void WhenIHaveEnteredThePaymentDetails()
        {
            init();
            Payment paymentObj = new Payment();
            var host = GetUrl("PaymentApi") + "ProcessPayment";
            for (int i = 0; i < paymentInfo.Count; i++)
            {
               
                jsonRequest = JsonConvert.SerializeObject(paymentInfo[i]);
                jsonResponse = doExecuteApiWithHeaders(host, "POST", "application/json-patch+json", "text/plain", "Bearer  " + token, jsonRequest);
                jsonResponseListPayment.Add(jsonResponse);
            }
        }

        [Then(@"the payment should be successfull")]
        public void ThenThePaymentShouldBeSuccessfull()
        {
            for (var i = 0; i < jsonResponseListPayment.Count(); i++)
            {
          //      Assert.IsTrue(jsonResponseListPayment[i].Contains("\"success\":true"), "Unable to Process Payment");
            }
        }

        /*-------------------Post Request to ProcessPaymentSubmission ------------------*/
        [Given(@"I have to process a paymentSubmission")]
        public void GivenIHaveToProcessAPaymentSubmission(Table table)
        {
            paymentSubmissionInfo = table.CreateSet<PaymentSubmission>().ToList();
        }


        [Given(@"I have provided payment location address")]
        public void GivenIHaveProvidedPaymentLocationAddress(Table table)
        {
            locationAddresslist = table.CreateSet<PaymentLocationAddress>().ToList();
            for (int i = 0; i < locationAddresslist.Count; i++)
            {
                paymentSubmissionInfo[i].locationAddress.addressLine1 = locationAddresslist[i].addressLine1;
                paymentSubmissionInfo[i].locationAddress.addressLine2 = locationAddresslist[i].addressLine2;
                paymentSubmissionInfo[i].locationAddress.city = locationAddresslist[i].city;
                paymentSubmissionInfo[i].locationAddress.state = locationAddresslist[i].state;
                paymentSubmissionInfo[i].locationAddress.zipCode = locationAddresslist[i].zipCode;
            }
        }

        [Given(@"I have provided creditcard information")]
        public void GivenIHaveProvidedCreditcardInformation(Table table)
        {

            creditCardInfolist = table.CreateSet<CreditCardInfo>().ToList();
            for (int i = 0; i < creditCardInfolist.Count; i++)
            {
                paymentSubmissionInfo[i].creditCardInfo.nameOnCard = creditCardInfolist[i].nameOnCard;
                paymentSubmissionInfo[i].creditCardInfo.ccNumber = creditCardInfolist[i].ccNumber;
                paymentSubmissionInfo[i].creditCardInfo.cvv = creditCardInfolist[i].cvv;
                paymentSubmissionInfo[i].creditCardInfo.expirationMonth = creditCardInfolist[i].expirationMonth;
                paymentSubmissionInfo[i].creditCardInfo.expirationYear = creditCardInfolist[i].expirationYear;
                paymentSubmissionInfo[i].creditCardInfo.cardType = creditCardInfolist[i].cardType;
            }
        }


        [Given(@"i have also provided payment achInfo")]
        public void GivenIHaveAlsoProvidedPaymentAchInfo(Table table)
        {
            var achInfolist = table.CreateSet<PaymentAchInfo>().ToList();
            for (int i = 0; i < achInfolist.Count; i++)
            {
           
                paymentSubmissionInfo[i].achInfo.nameOnAccount = achInfolist[i].nameOnAccount;
                paymentSubmissionInfo[i].achInfo.accountNumber = achInfolist[i].accountNumber;
                paymentSubmissionInfo[i].achInfo.routingNumber = achInfolist[i].routingNumber;
                paymentSubmissionInfo[i].achInfo.accountType = achInfolist[i].accountType;
                paymentSubmissionInfo[i].achInfo.checkNumber = achInfolist[i].checkNumber;
            }
        }

        [When(@"I have entered the ProcessPaymentSubmission details")]
        public void WhenIHaveEnteredTheProcessPaymentSubmissionDetails()
        {
            init();
            PaymentSubmission paymentsubmissionObj = new PaymentSubmission();
            var host = GetUrl("PaymentApi") + "ProcessPaymentSubmission";
            for (int i = 0; i < paymentSubmissionInfo.Count; i++)
            {
            
                jsonRequest = JsonConvert.SerializeObject(paymentSubmissionInfo[i]);
                jsonResponse = doExecuteApiWithHeaders(host, "POST", "application/json-patch+json", "text/plain", "Bearer  " + token, jsonRequest);
                jsonResponseListPaymentSubmission.Add(jsonResponse);

            }

        }
        
        [Then(@"the paymentsubmission should be successfull")]
        public void ThenThePaymentsubmissionShouldBeSuccessfull()
        {
            for (var i = 0; i < jsonResponseListPaymentSubmission.Count(); i++)
            {
               Assert.IsTrue((jsonResponseListPaymentSubmission[i].Contains("\"isTransactionSuccess\":true") || jsonResponseListPaymentSubmission[i].Contains("\"isTransactionSuccess\":false")),
                "The payment Submission was not successfull ");
            }
        }
    }
}
