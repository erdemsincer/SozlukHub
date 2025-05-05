# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY TopicService/TopicService.csproj ./  
RUN dotnet restore TopicService.csproj

COPY TopicService/. ./  
RUN dotnet publish TopicService.csproj -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TopicService.dll"]
