## Demonstration of Using OAuth with ASP.NET Core

1. Register the custom application at https://github.com/settings/developers
1. The callback URL should be http://localhost:5000/authentication/signedin
1. Run the following commands:

    `dotnet restore`
    `dotnet build`
    `dotnet run`
    
1. Visit http://localhost:5000

Details about the Github OAuth Apps API:

https://developer.github.com/apps/building-oauth-apps/authorizing-oauth-apps/