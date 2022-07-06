using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using static TakeHomeTask.MakeRequest;

namespace TakeHomeTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            MakeRequest makeRequest = new MakeRequest();
            StatusCheck statusCheck = new StatusCheck();
            int secondsToSleep = 125000;

            // Endpoit for list of branches
            var branchListEP = $"v0.1/apps/{AppCenterConfig.owner}/{AppCenterConfig.appName}/branches";
            var response = await makeRequest.MakeHttpRequest(HTTPMethods.GET, AppCenterConfig.baseUrl, branchListEP, AppCenterConfig.apiToken);

            Console.WriteLine("Please wait until branches are loaded.\n");

            // Converting string to json
            List<BranchResponse> listOfBranches = JsonConvert.DeserializeObject<List<BranchResponse>>(response);
            
            Console.WriteLine("------------------------LIST OF BRANCHES------------------------\n");
           
            foreach (var branch in listOfBranches)
            {
              
                // Endpoint to start the build of the Branch
                var buildBranchEP = $"v0.1/apps/{AppCenterConfig.owner}/{AppCenterConfig.appName}/branches/{branch.Branch.Name}/builds";
               

                if (branch.LastBuild != null)
                {
                    // Action for starting the build
                    string createdBuildStr = await makeRequest.MakeHttpRequest(HTTPMethods.POST, AppCenterConfig.baseUrl, buildBranchEP, AppCenterConfig.apiToken, branch.LastBuild.SourceVersion);
                    BuildDetailsResponse createdBuild = JsonConvert.DeserializeObject<BuildDetailsResponse>(createdBuildStr);
                    
                    Console.WriteLine($"Build started for {branch.Branch.Name}");

                    var buildDetailsEP = $"v0.1/apps/{AppCenterConfig.owner}/{AppCenterConfig.appName}/builds/{createdBuild.Id}";
                    BuildDetailsResponse buildDetails = await statusCheck.GetBuildDetails(AppCenterConfig.baseUrl, buildDetailsEP, AppCenterConfig.apiToken);

                    do
                    {
                        // Endpoint for  getting the details of the current build
                        buildDetails = await statusCheck.GetBuildDetails(AppCenterConfig.baseUrl, buildDetailsEP, AppCenterConfig.apiToken);
                        Console.WriteLine($"\r{branch.Branch.Name}: {buildDetails.Status}");

                        if (buildDetails.Status == "completed")
                        {
                            break;
                        }

                        Thread.Sleep(secondsToSleep);
                    } while (createdBuild.Status != "completed");

                    var logLink = $"https://appcenter.ms/download?url=/v0.1/apps/{AppCenterConfig.owner}/{AppCenterConfig.appName}/builds/{buildDetails.Id}/downloads/logs";

                    Console.WriteLine($"\n{buildDetails.SourceBranch} build {buildDetails.Result} in {secondsToSleep/1000} seconds. Link to build logs: {logLink}.\n");

                    buildDetails = null;
                }
            }
        }
    }
}
