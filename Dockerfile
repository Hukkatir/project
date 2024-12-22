FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIROMENT=Development
ENV LANG=C.UTF-8
ENV LC_ALL=C.UTF-8

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /projectAPI

COPY ["projectAPI/projectAPI.csproj", "projectAPI/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "projectAPI/projectAPI.csproj"

COPY . .
FROM build as publish
RUN dotnet publish "projectAPI/projectAPI.csproj" -c Release -o /app/publish /p:UserAppHost=false

FROM base as final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "projectAPI.dll"]