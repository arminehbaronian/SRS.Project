using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using SRS.Project.Report.Model;
using System.Text;

namespace SRS.Project.Report.Services
{
    public class Settings
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public static class GetData
    {
        private static string _baseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Url").Value;
        private static FetchDataInput _input = new FetchDataInput();
        private static string _resultObj;

        public static string FetchData(string orderId)
        {
            _input.order_id = orderId;
            //_context.Step01Buffers.Take(_top);
            //try
            //{
            using (var webClient = Factor($"{_baseUrl}"))
            {
                var response = webClient.PostAsync(_baseUrl,
                    new StringContent(JsonConvert.SerializeObject(_input), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //_result = JsonConvert.DeserializeObject<Invoice>(response.Content.ReadAsStringAsync().Result);
                    _resultObj = response.Content.ReadAsStringAsync().Result;
                }
                else
                    _resultObj = "";
            }

            return _resultObj;
        }
        private static HttpClient Factor(string url)
        {

            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }) { BaseAddress = new Uri(url) };
            client.Timeout = TimeSpan.FromMinutes(20);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("deflate"));
            return client;
        }
    }
}
