FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . ./
WORKDIR /source/.
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000
ENV ASPNETCORE_ENVIRONMENT="Production"
ENV ASPNETCORE_URLS="http://+:80"
ENTRYPOINT ["dotnet", "dev-certs", "https", "--trust"]
ENTRYPOINT ["dotnet", "dotnetWebApp.dll"]