FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY . .
RUN dotnet restore "./MrMoney.Infrastructure/MrMoney.Infrastructure.csproj"
RUN dotnet restore "./MrMoney.Domain/MrMoney.Domain.csproj"
RUN dotnet restore "./MrMoney.API/MrMoney.API.csproj"

COPY . .
WORKDIR "/app/."
RUN dotnet build "MrMoney.Infrastructure/MrMoney.Infrastructure.csproj" -c Release -o /app/build
RUN dotnet build "MrMoney.Domain/MrMoney.Domain.csproj" -c Release -o /app/build
RUN dotnet build "MrMoney.API/MrMoney.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MrMoney.Infrastructure/MrMoney.Infrastructure.csproj" -c Release -o /app/publish
RUN dotnet publish "MrMoney.Domain/MrMoney.Domain.csproj" -c Release -o /app/publish
RUN dotnet publish "MrMoney.API/MrMoney.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MrMoney.API.dll"]