# TakeHomeTask

## Description
This is a C# Console application that is used for consuming endpoints that build branches and get time and logs of those builds, it is made in .NET 6.0.3.

### Titles and contents

- Program
- BranchResponse
    - This is just a name of the branch
- BranchLastBuildReponse
    - This contains the id and sourceVersion of the last build
- BranchResponse
    - this contains branch and last build
- BuildBRanchRequestData
    - This contains sourceVersion and debug
- BuildDetailsRepsonse
    - This is a branch build status, it contained all the information about the build

### Installation

In order to run this app, please follow the next steps:

- Before getting the code, please ensure that you have Visual Studio 2022 installed on your PC 
- Download zip file from GitHub (green button "Code" -> "Download ZIP"), extract it in the desired folder
- Open the TakeHomeTask.sln in Visual Studio
- Right-click on 'Solution TakeHomeTask' -> Manage NuGet packages for solution, and install the latest versions of the following:

        - Newtonsoft.json (13.0.1)

- Go to the App Center -> Create a new app, and then go to Build -> choose a repository that has TakeHomeTaskXamarin on it.

Once you build that app, you can go to Settings in the AppCenter, scroll down, find Add API Tokens, if there is no token there, add one, copy it, and paste it in the Visual Studio AppCenterConfig.cs, here:

        - var apiToken = "{api token here}";
        
Also, add the name of the app from AppCenter and the name of the owner of the app. You can find both in the url when you open your AppCenter app. (https://appcenter.ms/users/{owner}/apps/{appName}/build/branches/develop)

        -  public string owner = "{owner}";
        -  public string appName = "{appName}";

## Usage

Once everything is installed and set up, you can press the green start button with "TakeHomeTask" written on it. Wait for the console to appear, and follow these steps:

- Simply wait for the builds to finish and for the program to write the status of your builds.
- You can track the status of the build in App Center as well while you are waiting for the status in the Console app.

## Support
For any further questions, or any help in starting the project, you can contact me on anabogdanovic995@gmail.com, I'd be happy to help or provide more information. 

