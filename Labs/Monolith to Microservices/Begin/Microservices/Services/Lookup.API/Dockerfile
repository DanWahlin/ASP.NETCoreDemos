FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51834
EXPOSE 44359

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Lookup.API/Lookup.API.csproj Lookup.API/
RUN dotnet restore Lookup.API/Lookup.API.csproj
COPY . .
WORKDIR /src/Lookup.API
RUN dotnet build Lookup.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Lookup.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lookup.API.dll"]
