using System.IO;
using Newtonsoft.Json.Linq;

namespace RentersInsuranceApiTests.Controllers
{
    internal class JsonController
    {
        /* This method facilitates loading json string given a path to a .json file 
         * INPUT    : string directory path to the json file (filename.json included)
         * OUTPUT   : string json payload
         */
        public string LoadJsonAsString(string filePath)
        {
            string json = null;
            using (var r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
            }

            return json;
        }

        /* This method uses jsonpath expressions to get an attribute value or a json fragment 
         http://jsonpath.com/ 
         https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenJsonPath.htm 
         */
        public string QueryJson(string json, string query)
        {
            string ret = null;
            json = JToken.Parse(json).ToString();
            var jo = JObject.Parse(json);
            var returnToken = jo.SelectToken(query);
            ret = returnToken.ToString();
            return ret;
        }
    }
}