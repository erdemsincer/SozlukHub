# 🔧 Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 📁 Proje dosyalarını kopyala
COPY Shared/Shared.csproj ../Shared/
COPY ReviewService/ReviewService.csproj ./ReviewService/

# 🔄 Restore işlemi
WORKDIR /src/ReviewService
RUN dotnet restore

# 📦 Kaynak dosyaları kopyala
COPY ReviewService/. ./
COPY Shared/ ../Shared/

# 🚀 Yayınla (publish)
RUN dotnet publish -c Release -o /app/publish

# 🏃 Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ReviewService.dll"]
