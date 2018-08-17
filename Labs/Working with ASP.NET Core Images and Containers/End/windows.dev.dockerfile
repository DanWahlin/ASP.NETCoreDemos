FROM        microsoft/dotnet:sdk
LABEL       author="Your Name"

ENV         ASPNETCORE_URLS=http://*:5000
ENV         DOTNET_USE_POLLING_FILE_WATCHER=1
ENV         ASPNETCORE_ENVIRONMENT=development

EXPOSE      5000

WORKDIR     /app

CMD         ["dotnet restore && dotnet build && dotnet watch run"]




# Run the following:
# 1. docker build -f windows.dev.dockerfile -t aspnetcore-dev .  
# 2. docker run -p 5000:5000 -v %cd%:/app aspnetcore-dev
# 3. Visit http://localhost:5000 in the browser.


