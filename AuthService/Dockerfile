FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Shared/Shared.csproj ../Shared/


COPY AuthService/AuthService.csproj ./
RUN dotnet restore AuthService.csproj

COPY Shared/ ../Shared/
COPY AuthService/. ./


RUN dotnet publish AuthService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AuthService.dll"]
