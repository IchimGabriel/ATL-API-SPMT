FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ATL-API-SPMT/ATL-API-SPMT.csproj", "ATL-API-SPMT/"]
RUN dotnet restore "ATL-API-SPMT/ATL-API-SPMT.csproj"
COPY . .
WORKDIR "/src/ATL-API-SPMT"
RUN dotnet build "ATL-API-SPMT.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ATL-API-SPMT.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ATL-API-SPMT.dll"]