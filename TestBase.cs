using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RentersInsuranceApiTests.Controllers;

namespace RentersInsuranceApiTests
{
    [TestClass]
    public class TestBase
    {
        public string billingAPIUrlDev;
        public string carrierAPIUrlDev;
        public string dataPath = ".\\data\\";
        public string dbConnString = null;
        public string endPointUrl;
        public string hostUrl;
        public string paymentAPIUrlDev;
        public string policyAPIUrlDev;
        public Dictionary<string, string> properties;
        private bool propertyLoaded;
        private string propPath;
        public string quoteAPIUrlDev;
        public string residentAPIUrlD;
        private RestController restClient = new RestController();
        public string token;
        private bool verbose;


        /* This initialization runs for all test classes. It loads properties from .ini, sets hostUrl, sets logging levels, etc.
         */
        [ClassInitialize]
        public virtual void init()
        {
            if (!propertyLoaded)
            {
                //Find properties.ini path 
                propPath = PropertiesController.getPropertiesPath();

                //Load properties from .ini file
                properties = PropertiesController.readProperties(propPath);

                //TODO: Use a logger library
                if (properties["verbose"] != null) verbose = Convert.ToBoolean(properties["verbose"]);

                //Set hostUrl
                if (hostUrl == null) hostUrl = properties["hostUrl"].Trim();
                if (token == null) token = properties["token"].Trim();


                propertyLoaded = true;
            }
        }

        /* This method facilitates HTTP Methods GET, POST, PUT and DELETE for the tests
         * INPUT    : string endPointUrl, string httpVerb, string jsonPostPayload
         * OUTPUT   : string response (or Exception.Message) in json format
         */
        public string doExecuteApi(string endPointUrl, string httpVerb, string jsonPostPayload = "")
        {
            string jsonResponse = null;
            try
            {
                switch (httpVerb)
                {
                    case "GET":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.GET, "application/json",
                            "application/json", jsonPostPayload);
                        break;
                    case "POST":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.POST, "application/json",
                            "application/json", jsonPostPayload);
                        break;
                    case "PUT":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.PUT, "application/json",
                            "application/json", jsonPostPayload);
                        break;
                    case "DELETE":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.DELETE, "application/json",
                            "application/json", jsonPostPayload);
                        break;
                }

                jsonResponse = restClient.MakeRequest();
            }
            catch (Exception e)
            {
                jsonResponse = e.Message;
            }

            return jsonResponse;
        }

        public string doExecuteApiWithHeaders(string endPointUrl, string httpVerb,
            string contentTypeHeader = "", string acceptHeader = "", string authHeader = "",
            string jsonPostPayload = "")
        {
            string jsonResponse = null;
            try
            {
                switch (httpVerb)
                {
                    case "GET":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.GET, contentTypeHeader,
                            acceptHeader, authHeader, jsonPostPayload);
                        break;
                    case "POST":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.POST, contentTypeHeader,
                            acceptHeader, authHeader, jsonPostPayload);
                        break;
                    case "PUT":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.PUT, contentTypeHeader,
                            acceptHeader, authHeader, jsonPostPayload);
                        break;
                    case "DELETE":
                        restClient = new RestController(
                            endPointUrl, HttpVerb.DELETE, contentTypeHeader,
                            acceptHeader, authHeader, jsonPostPayload);
                        break;
                }

                jsonResponse = restClient.MakeRequest();
            }
            catch (Exception e)
            {
                jsonResponse = e.Message;
            }

            return jsonResponse;
        }


        public string GetTokenInfo()
        {
            string token = null;

            endPointUrl = hostUrl + "/InsuranceServices/Security/ValidateAnalytics";
            var analyticsCode = doExecuteApi(endPointUrl, "GET", null);
            Assert.IsNotNull(analyticsCode);
            Console.WriteLine(analyticsCode);

            endPointUrl = hostUrl + "/InsuranceServices/Security/RequestToken";
            var tokenResponse = doExecuteApi(endPointUrl, "POST", analyticsCode);
            Assert.IsNotNull(tokenResponse);

            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResponse);
            foreach (var kv in dict) token = kv.Value;
            Console.WriteLine(token);

            return token;
        }

        public string GetUrl(string apiName)
        {
            var table = new DataTable("ApiUrls");
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ApiName";
            column.AutoIncrement = false;
            column.Caption = "ApiName";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Environment";
            column.AutoIncrement = false;
            column.Caption = "Environment";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Url";
            column.AutoIncrement = false;
            column.Caption = "Url";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);
            var ds = new DataSet();
            ds.Tables.Add(table);

            var environment = "";
            propPath = PropertiesController.getPropertiesPath();

            //Load properties from .ini file
            properties = PropertiesController.readProperties(propPath);
            environment = properties["environment"].Trim();

            table.Rows.Add("BillingApi", "dev", "https://ri-billingapi-dev.realpage.com/");
            table.Rows.Add("BillingApi", "sat", "https://ri-billingapi-sat.realpage.com/");
            table.Rows.Add("BillingApi", "uat", "https://ri-billingapi-uat.realpage.com/");
            table.Rows.Add("QuoteApi", "dev", "https://ri-quoteapi-dev.realpage.com/v2/");
            table.Rows.Add("QuoteApi", "sat", "https://ri-quoteapi-sat.realpage.com/v2/");
            table.Rows.Add("QuoteApi", "uat", "https://ri-quoteapi-uat.realpage.com/v2/");
            table.Rows.Add("ResidentApi", "dev", "https://ri-residentapi-dev.realpage.com/v2/");
            table.Rows.Add("ResidentApi", "sat", "https://ri-residentapi-sat.realpage.com/v2/");
            table.Rows.Add("ResidentApi", "uat", "https://ri-residentapi-uat.realpage.com/v2/");
            table.Rows.Add("PolicyApi", "dev", "https://ri-policyapi-dev.realpage.com/");
            table.Rows.Add("PolicyApi", "sat", "https://ri-policyapi-sat.realpage.com/");
            table.Rows.Add("PolicyApi", "uat", "https://ri-policyapi-uat.realpage.com/");
            table.Rows.Add("PaymentApi", "dev", "https://ri-paymentapi-dev.realpage.com/");
            table.Rows.Add("PaymentApi", "sat", "https://ri-paymentapi-sat.realpage.com/");
            table.Rows.Add("PaymentApi", "uat", "https://ri-paymentapi-uat.realpage.com/");
            table.Rows.Add("CarrierApi", "dev", "https://ri-carrierintegrationapi-dev.realpage.com/");
            table.Rows.Add("CarrierApi", "sat", "https://ri-carrierintegrationapi-sat.realpage.com/");
            table.Rows.Add("CarrierApi", "uat", "https://ri-carrierintegrationapi-uat.realpage.com/");
            table.Rows.Add("SettingsApi", "dev", "https://ri-settingsapi-dev.realpage.com/");
            table.Rows.Add("SettingsApi", "sat", "https://ri-settingsapi-sat.realpage.com/");
            table.Rows.Add("SettingsApi", "uat", "https://ri-settingsapi-uat.realpage.com/");
            table.Rows.Add("NotificationsApi", "dev", "https://ri-notificationapi-dev.realpage.com/");
            table.Rows.Add("NotificationsApi", "sat", "https://ri-notificationapi-sat.realpage.com/");
            table.Rows.Add("NotificationsApi", "uat", "https://ri-notificationapi-uat.realpage.com/");
            table.Rows.Add("SecurityApi", "dev", "https://ri-securityapi-dev.realpage.com/");
            table.Rows.Add("SecurityApi", "sat", "https://ri-securityapi-sat.realpage.com/");
            table.Rows.Add("SecurityApi", "uat", "https://ri-securityapi-uat.realpage.com/");
            table.Rows.Add("PMSAPI", "dev",
                "http://swaggerhub.dev.realpage.com/virts/Realpage/ri-pmsintegrationapi/1.0.0/");


            var url = "";

            //DataRow[] resultUrl = table.Select("ApiName="+apiName+" AND Environment="+environment+"");
            //   DataRow[] resultUrl = ds.Tables["ApiUrls"].Select("ApiName=" + apiName + "");
            //DataRowCollection collection=   ds.Tables["ApiUrls"].Rows;
            if (ds.Tables.Count > 0 && ds.Tables["ApiUrls"].Rows.Count > 0)
                for (var i = 0; i < ds.Tables["ApiUrls"].Rows.Count; i++)
                    if (ds.Tables["ApiUrls"].Rows[i]["Environment"].ToString().ToLower().Trim() ==
                        environment.ToLower().Trim() &&
                        ds.Tables["ApiUrls"].Rows[i]["ApiName"].ToString().ToLower().Trim() == apiName.ToLower().Trim())
                        url = ds.Tables["ApiUrls"].Rows[i]["Url"].ToString();

            return url;
        }
    }
}