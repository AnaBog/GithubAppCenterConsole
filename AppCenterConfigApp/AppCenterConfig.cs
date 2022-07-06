using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace AppCenterConfigApp
{
    public class AppCenterConfig
    {
        public string appSecret;
        public string owner;
        public string appName;
        public string baseUrl;
        public string apiToken;
        public string apiUserToken;

        public AppCenterConfig()
        {
            appSecret = "695ac998-3a69-4257-bc64-ce375d1f8e7c";
            owner = "AnaBogdanovic";
            appName = "TakeHomeTask";
            baseUrl = "https://api.appcenter.ms";
            apiToken = "49db809c7bbea571c0ed285c9e9bc0c7f26bff11";
            apiUserToken = "872bce3a5682c833e82423ea2bbc1edea523e2c3";
        }

        public void AppStart()
        {
            AppCenter.Start(appSecret, typeof(Analytics), typeof(Crashes));
        }

        public static void Main(string[] args)
        {

        }
    }
}
