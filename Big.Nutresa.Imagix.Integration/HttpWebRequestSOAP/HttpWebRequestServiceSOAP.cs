using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Big.Nutresa.Imagix.Integration.HttpWebRequestSOAP
{
    public class HttpWebRequestServiceSOAP
    {
        private static HttpWebRequestServiceSOAP _instance = null;
        public HttpWebRequestServiceSOAP(string contentType, string accept, string method, string service)
        {
            this.ContentType = contentType;
            this.Accept = accept;
            this.Method = method;
            this.Service = service;
        }

        public static HttpWebRequestServiceSOAP GetInstance(string contentType, string accept, string method, string service)
        {
            if (_instance == null)
            {
                _instance = new HttpWebRequestServiceSOAP(contentType, accept, method, service);
            }

            return _instance;
        }

        private string ContentType { get; set; }
        private string Accept { get; set; }
        private string Method { get; set; }
        private string Service { get; set; }

        public string ConsumeServiceUserByAction(string action, string parameter)
        {
            return getData(parameter, this.Service, action);
        }

        public string getData(string xml, string address, string action)
        {
            HttpWebRequest request = CreateWebRequest(address, action);
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(xml);
            string result = string.Empty;

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    result = rd.ReadToEnd();
                }
            }

            return result;
        }

        public HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = this.ContentType;
            webRequest.Accept = this.Accept;
            webRequest.Method = this.Method;
            return webRequest;
        }

    }
}
