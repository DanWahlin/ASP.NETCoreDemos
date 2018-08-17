FROM        microsoft/dotnet:aspnetcore-runtime
LABEL       author="Your Name"

ENV         ASPNETCORE_URLS=http://*:5000
ENV         ASPNETCORE_ENVIRONMENT=production

EXPOSE      5000

WORKDIR     /app

COPY        ./dist /app

ENTRYPOINT  ["dotnet", "ASPNET-Core-And-Docker.dll"]




# Run the following:
# 1. dotnet restore
# 2. dotnet build
# 3. dotnet publish -c Release -o dist
# 4. docker build -f windows.prod.dockerfile -t aspnetcore-prod . 
# 5. docker run -p 5000:5000 aspnetcore-prod
# 6. Visit http://[containerIP]:5000 in the browser.