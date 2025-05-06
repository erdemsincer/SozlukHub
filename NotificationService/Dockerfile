FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY Shared/Shared.csproj Shared/
COPY NotificationService/NotificationService.csproj NotificationService/

RUN dotnet restore NotificationService/NotificationService.csproj

COPY Shared/ Shared/
COPY NotificationService/ NotificationService/

WORKDIR /src/NotificationService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "NotificationService.dll"]
