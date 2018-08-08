FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51833
EXPOSE 44358

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Customers.API/Customers.API.csproj Customers.API/
RUN dotnet restore Customers.API/Customers.API.csproj
COPY . .
WORKDIR /src/Customers.API
RUN dotnet build Customers.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Customers.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Customers.API.dll"]
