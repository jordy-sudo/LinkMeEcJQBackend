FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["output/", "app/"]
WORKDIR "/src/app"
ENTRYPOINT ["dotnet", "LinkMeEcJQ.dll"]  

CMD ASPNETCORE_URLS=http://*:80 dotnet LinkMeEc.Api.dll