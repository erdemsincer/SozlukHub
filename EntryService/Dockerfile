# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY EntryService/EntryService.csproj ./
RUN dotnet restore EntryService.csproj
COPY EntryService/. ./
RUN dotnet publish EntryService.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EntryService.dll"]
