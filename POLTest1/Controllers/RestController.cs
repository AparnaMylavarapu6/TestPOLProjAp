using System;
using System.IO;
using System.Net;
using System.Text;

public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace RentersInsuranceApiTests.Controllers
{
    public class RestController
    {
        public RestController()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "application/json";
            Accept = "application/json";
            PostData = "";
        }

        public RestController(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "application/json";
            Accept = "application/json";
            PostData = "";
        }

        public RestController(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            Accept = "application/json";
            PostData = "";
        }

        public RestController(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            Accept = "application/json";
            PostData = postData;
        }

        public RestController(string endpoint, HttpVerb method, string contentType, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = contentType;
            PostData = postData;
        }

        public RestController(string endpoint, HttpVerb method, string contentType, string accept, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = contentType;
            Accept = accept;
            PostData = postData;
        }

        public RestController(string endpoint, HttpVerb method, string contentType, string accept, string authorization,
            string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = contentType;
            Accept = accept;
            Authorization = authorization;
            PostData = postData;
        }

        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string Accept { get; set; }
        public string Authorization { get; set; }
        public string PostData { get; set; }

        public string MakeRequest()
        {
            return MakeRequest("");
            //  return FetchResponseCode("");
        }

        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest) WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            request.Accept = Accept;
            if (Authorization != null) request.Headers.Add("Authorization", Authorization);

            if (!string.IsNullOrEmpty(PostData) && (Method == HttpVerb.POST || Method == HttpVerb.PUT))
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse) request.GetResponse())
            {
                var responseValue = string.Empty;

                if (
                    Method == HttpVerb.PUT && response.StatusCode == HttpStatusCode.OK ||
                    Method == HttpVerb.PUT && response.StatusCode == HttpStatusCode.Accepted ||
                    Method == HttpVerb.POST && response.StatusCode == HttpStatusCode.OK ||
                    Method == HttpVerb.POST &&
                    response.StatusCode ==
                    HttpStatusCode.Created || //TODO: Need confirmation from Iqbal regarding this.
                    Method == HttpVerb.GET && response.StatusCode == HttpStatusCode.OK
                )
                {
                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }
                }
                else
                {
                    var message = string.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    var statusCode = response.StatusCode;
                    throw new ApplicationException(message);
                }

                return responseValue;
            }
        }
    }
}