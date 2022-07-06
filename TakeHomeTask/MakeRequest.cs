using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeTask
{
    public class MakeRequest
    {
        public async Task<string> MakeHttpRequest(HTTPMethods method, string baseUrl, string endpoint, string apiToken, string sourceVersion = null)
        {
            HttpClient client = new HttpClient();
            //Clear headers for every request 
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-API-Token", apiToken);

            switch (method)
            {
                case HTTPMethods.GET:
                    return await client.GetStringAsync($"{baseUrl}/{endpoint}");
                case HTTPMethods.POST:
                    //Prepare the data for starting the build
                    string data = JsonConvert.SerializeObject(new
                    {
                        sourceVersion = sourceVersion,
                        debug = false,
                    }); ;

                    var content = new StringContent(data, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"{baseUrl}/{endpoint}", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                default:
                    return await client.GetStringAsync($"{baseUrl}/{endpoint}");
            }
        }

        public enum HTTPMethods
        {
            GET = 0,
            POST = 1,
        }
    }
}
