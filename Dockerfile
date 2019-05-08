FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build

COPY . ./
WORKDIR /src/ATL-API-SMPT
RUN dotnet build ATL-API-SMPT.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ATL-API-SMPT.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENV ASPNETCORE_URLS http://*:5001
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5001
ENTRYPOINT ["dotnet", "ATL-API-SMPT.dll"]