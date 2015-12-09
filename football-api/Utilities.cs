using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace football_api
{
    class Utilities
    {
        public static HttpClient CreateWebRequest(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static T ConvertJsonToObject<T>(string json)
        {
            var o = JsonConvert.DeserializeObject<T>(json);
            return o;
        }
    }
}
