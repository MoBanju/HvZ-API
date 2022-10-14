FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /source

COPY *.sln .
COPY HvZWebAPI/*.csproj ./HvZWebAPI/

RUN dotnet restore --use-current-runtime
COPY HvZWebAPI/. ./HvZWebAPI/
WORKDIR /source/HvZWebAPI

RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app ./

ENTRYPOINT ["dotnet", "HvZWebAPI.dll"]