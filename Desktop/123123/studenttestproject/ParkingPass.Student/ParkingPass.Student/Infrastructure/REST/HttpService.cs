using ParkingPass.Student.Infrastructure.REST.Interfaces;
using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Plugin.Connectivity;
using ParkingPass.Student.Infrastructure.Models.Enum;
using ParkingPass.Student.Infrastructure.Models;

namespace ParkingPass.Student.Infrastructure.REST
{
    public class HttpService : IHttpService
    {
        public HttpService()
        {

        }
        
        static HttpService()
        {
            url = "http://somelink/";
            httpClient = new HttpClient();
        }

        public async Task<T> GetRequest<T>(string controller, string method, string parametr,string value, string token = null)
        {
            try
            {
                if (!IsConnected())
                    throw new Exception("No network connection");

                if (!String.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                var uri = new Uri(String.Format("{0}{1}/{2}?{3}={4}", url, controller, method, parametr, value));
                var result = await httpClient.GetAsync(uri);
                var jsonText = await result.Content.ReadAsStringAsync();
                if (String.IsNullOrEmpty(jsonText))
                    return default(T);
                dynamic jsonResult;
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    jsonResult = JsonConvert.DeserializeObject<ErrorModel>(jsonText);
                    return jsonResult;
                }
                jsonResult = JsonConvert.DeserializeObject<T>(jsonText);
                return jsonResult;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public async Task<T> PostRequest<T>(string controller, string method, ContentType type, string token = null, object obj = null)
        {
            try
            {
                if (!IsConnected())
                    throw new Exception("No network connection");

                var uri = new Uri(String.Format("{0}{1}/{2}", url, controller, method));

                dynamic content=null;
                HttpResponseMessage result = null;

                if (type == ContentType.StringContent)
                {
                    var json = JsonConvert.SerializeObject(obj);
                    content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                else if (type == ContentType.EncodedContent)
                    content = new FormUrlEncodedContent((List<KeyValuePair<string, string>>)obj);
                result = await httpClient.PostAsync(uri, content);

                var jsonText = await result.Content.ReadAsStringAsync();
                if (String.IsNullOrEmpty(jsonText))
                    return default(T);

                dynamic jsonResult;
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    jsonResult = JsonConvert.DeserializeObject<ErrorModel>(jsonText);
                    return jsonResult;
                }
                jsonResult = JsonConvert.DeserializeObject<T>(jsonText);
                return jsonResult;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        private bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        private static readonly string url;
        private static HttpClient httpClient;
    }
}
