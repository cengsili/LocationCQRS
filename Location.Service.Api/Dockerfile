#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Location.Service.Api/Location.Service.Api.csproj", "Location.Service.Api/"]
COPY ["src/Location.Service.Core/Location.Service.Application.csproj", "src/Location.Service.Application/"]
COPY ["src/Location.Service.Core/Location.Service.Domain.csproj", "src/Location.Service.Domain/"]
COPY ["src/Location.Service.Infrastructure/Location.Service.Infrastructure.csproj", "src/Location.Service.Infrastructure/"]
RUN dotnet restore "Location.Service.Api/Location.Service.Api.csproj" --configfile "./Location.Service.Api/nuget.config"
COPY . .
WORKDIR "Location.Service.Api"
RUN dotnet build "Location.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Location.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Location.Service.Api.dll"]