#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Services/Product/Product.Api/Product.Api.csproj", "src/Services/Product/Product.Api/"]
COPY ["src/Services/Product/Product.Service/Product.Service.csproj", "src/Services/Product/Product.Service/"]
COPY ["src/Services/Product/Product.Domain/Product.Domain.csproj", "src/Services/Product/Product.Domain/"]
COPY ["src/Common/Common/Common.Utilities.csproj", "src/Common/Common/"]
COPY ["src/Services/Product/Product.DTOs/Product.DTOs.csproj", "src/Services/Product/Product.DTOs/"]
COPY ["src/Services/Product/Product.Persistense.Database/Product.Persistense.Database.csproj", "src/Services/Product/Product.Persistense.Database/"]
RUN dotnet restore "src/Services/Product/Product.Api/Product.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Product/Product.Api"
RUN dotnet build "Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.Api.dll"]