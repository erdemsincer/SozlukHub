FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# ✅ Shared projeyi kopyala
COPY Shared/Shared.csproj ../Shared/

# ✅ UserService projeyi kopyala
COPY UserService/UserService.csproj ./

# ✅ Restore işlemi (bağımlılıklarla birlikte)
RUN dotnet restore UserService.csproj

# ✅ Tüm dosyaları kopyala
COPY Shared/ ../Shared/
COPY UserService/. ./

# ✅ Yayınla
RUN dotnet publish UserService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserService.dll"]
