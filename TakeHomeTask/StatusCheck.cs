using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TakeHomeTask.MakeRequest;

namespace TakeHomeTask
{
    public class StatusCheck
    {
        MakeRequest makeRequest = new MakeRequest();
        public async Task<BuildDetailsResponse> GetBuildDetails(string baseUrl, string endpoint, string apiToken)
        {
            var buildDetailsString = await makeRequest.MakeHttpRequest(HTTPMethods.GET, baseUrl, endpoint, apiToken);

            BuildDetailsResponse buildDetails = JsonConvert.DeserializeObject<BuildDetailsResponse>(buildDetailsString);

            return buildDetails;
        }
    }
}
